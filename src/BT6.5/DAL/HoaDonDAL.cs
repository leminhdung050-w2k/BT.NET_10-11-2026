using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._5.DTO;

namespace BT6._5.DAL
{
    public class HoaDonDAL
    {
        private const string SELECT_CHI_TIET = "SELECT MaHD, MaDV, SoLuong, DonGia FROM ChiTietDichVu WHERE MaHD = @MaHD";

        // Mở phòng (1 transaction): tạo HoaDon với GioVao = GETDATE() -> phòng chuyển sang "Đang hát"
        public int MoPhong(int maPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    object trangThai = TaoLenh("SELECT TrangThai FROM PhongHat WITH (UPDLOCK) WHERE MaPhong = @MaPhong", conn, trans,
                        new SqlParameter("@MaPhong", SqlDbType.Int) { Value = maPhong }).ExecuteScalar();
                    if (trangThai == null || trangThai.ToString() != "Trống")
                        throw new Exception("Phòng này đang có khách hát!");

                    int maHD = (int)TaoLenh("INSERT INTO HoaDon (MaPhong, GioVao) OUTPUT INSERTED.MaHD VALUES (@MaPhong, GETDATE())", conn, trans,
                        new SqlParameter("@MaPhong", SqlDbType.Int) { Value = maPhong }).ExecuteScalar();
                    TaoLenh("UPDATE PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong = @MaPhong", conn, trans,
                        new SqlParameter("@MaPhong", SqlDbType.Int) { Value = maPhong }).ExecuteNonQuery();

                    trans.Commit();
                    return maHD;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Hóa đơn chưa thanh toán của phòng đang hát (không có thì null)
        public HoaDonDTO LayHoaDonDangMo(int maPhong)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT h.MaHD, h.MaPhong, p.TenPhong, p.GiaTheoGio, h.GioVao FROM HoaDon h JOIN PhongHat p ON h.MaPhong = p.MaPhong " +
                "WHERE h.MaPhong = @MaPhong AND h.TrangThai = 0",
                new SqlParameter("@MaPhong", SqlDbType.Int) { Value = maPhong });
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new HoaDonDTO
            {
                MaHD = (int)r["MaHD"],
                MaPhong = (int)r["MaPhong"],
                TenPhong = r["TenPhong"].ToString(),
                GiaTheoGio = (decimal)r["GiaTheoGio"],
                GioVao = (DateTime)r["GioVao"]
            };
        }

        // Mô hình ngắt kết nối: nạp dịch vụ đã gọi của hóa đơn vào DataTable bằng SqlDataAdapter
        public DataTable LayDichVuDaGoi(int maHD)
        {
            DataTable dt = new DataTable("ChiTietDichVu");
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlDataAdapter da = TaoAdapter(conn, maHD))
            {
                da.Fill(dt);
            }

            // Cột hiển thị thêm: tên dịch vụ + thành tiền (CommandBuilder bỏ qua khi Update)
            dt.Columns.Add("TenDV", typeof(string));
            dt.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            DataTable ten = DatabaseHelper.ExecuteQuery("SELECT MaDV, TenDV FROM DichVu");
            foreach (DataRow r in dt.Rows)
            {
                DataRow[] t = ten.Select("MaDV = " + (int)r["MaDV"]);
                r["TenDV"] = t.Length > 0 ? t[0]["TenDV"] : "";
            }
            dt.AcceptChanges();
            return dt;
        }

        // Đồng bộ các dòng thêm / sửa trong DataTable về SQL Server (SqlCommandBuilder + adapter.Update)
        public int LuuDichVu(DataTable dt, int maHD)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlDataAdapter da = TaoAdapter(conn, maHD))
            using (SqlCommandBuilder cb = new SqlCommandBuilder(da))
            {
                cb.ConflictOption = ConflictOption.OverwriteChanges;   // UPDATE theo khóa (MaHD, MaDV)
                return da.Update(dt);
            }
        }

        // Thanh toán trong 1 SqlTransaction:
        // 1. Cập nhật GioRa, TongTienPhong, TongTienDichVu, TrangThai = 1 -> 2. Trừ TonKho dịch vụ
        // -> 3. Phòng về "Trống" -> 4. Commit
        public void ThanhToan(HoaDonDTO hd)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    hd.TongTienDichVu = Convert.ToDecimal(TaoLenh(
                        "SELECT ISNULL(SUM(SoLuong * DonGia), 0) FROM ChiTietDichVu WHERE MaHD = @MaHD", conn, trans,
                        new SqlParameter("@MaHD", SqlDbType.Int) { Value = hd.MaHD }).ExecuteScalar());

                    int n = TaoLenh("UPDATE HoaDon SET GioRa = @GioRa, TongTienPhong = @TienPhong, TongTienDichVu = @TienDV, TrangThai = 1 " +
                                    "WHERE MaHD = @MaHD AND TrangThai = 0", conn, trans,
                        new SqlParameter("@GioRa", SqlDbType.DateTime) { Value = hd.GioRa.Value },
                        new SqlParameter("@TienPhong", SqlDbType.Decimal) { Value = hd.TongTienPhong, Precision = 18, Scale = 2 },
                        new SqlParameter("@TienDV", SqlDbType.Decimal) { Value = hd.TongTienDichVu, Precision = 18, Scale = 2 },
                        new SqlParameter("@MaHD", SqlDbType.Int) { Value = hd.MaHD }).ExecuteNonQuery();
                    if (n == 0) throw new Exception("Hóa đơn đã được thanh toán trước đó!");

                    // Trừ tồn kho; dịch vụ nào không đủ hàng thì hủy toàn bộ giao dịch
                    DataTable ct = new DataTable();
                    SqlCommand docCT = TaoLenh("SELECT c.MaDV, d.TenDV, c.SoLuong, d.TonKho FROM ChiTietDichVu c JOIN DichVu d ON c.MaDV = d.MaDV " +
                                               "WHERE c.MaHD = @MaHD", conn, trans,
                        new SqlParameter("@MaHD", SqlDbType.Int) { Value = hd.MaHD });
                    using (SqlDataReader dr = docCT.ExecuteReader()) ct.Load(dr);
                    foreach (DataRow r in ct.Rows)
                    {
                        if ((int)r["TonKho"] < (int)r["SoLuong"])
                        {
                            trans.Rollback();
                            throw new Exception("Không đủ hàng trong kho: " + r["TenDV"] + " còn " + r["TonKho"] + ", đã gọi " + r["SoLuong"] +
                                                "\n\nĐã hủy (Rollback) thanh toán.");
                        }
                        TaoLenh("UPDATE DichVu SET TonKho = TonKho - @SL WHERE MaDV = @MaDV", conn, trans,
                            new SqlParameter("@SL", SqlDbType.Int) { Value = (int)r["SoLuong"] },
                            new SqlParameter("@MaDV", SqlDbType.Int) { Value = (int)r["MaDV"] }).ExecuteNonQuery();
                    }

                    TaoLenh("UPDATE PhongHat SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong", conn, trans,
                        new SqlParameter("@MaPhong", SqlDbType.Int) { Value = hd.MaPhong }).ExecuteNonQuery();

                    trans.Commit();
                    hd.TrangThai = true;
                }
                catch
                {
                    if (trans.Connection != null) trans.Rollback();   // chưa rollback thì rollback
                    throw;
                }
            }
        }

        private static SqlDataAdapter TaoAdapter(SqlConnection conn, int maHD)
        {
            SqlDataAdapter da = new SqlDataAdapter(SELECT_CHI_TIET, conn);
            da.SelectCommand.Parameters.Add("@MaHD", SqlDbType.Int).Value = maHD;
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;      // lấy khóa chính (MaHD, MaDV)
            return da;
        }

        private static SqlCommand TaoLenh(string sql, SqlConnection conn, SqlTransaction trans, params SqlParameter[] thamSo)
        {
            SqlCommand cmd = new SqlCommand(sql, conn, trans);
            cmd.Parameters.AddRange(thamSo);
            return cmd;
        }
    }
}
