using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._3.DTO;

namespace BT6._3.DAL
{
    public class CongViecDAL
    {
        // Danh sách thành viên được giao (gộp thành 1 chuỗi bằng FOR XML PATH)
        public const string SELECT_TASK =
            "SELECT cv.MaTask, cv.MaDuAn, da.TenDuAn, cv.TenTask, cv.MoTa, cv.HanNop, cv.DoUuTien, cv.TrangThai, " +
            "STUFF((SELECT ', ' + tv.HoTen FROM PhanCong pc JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien " +
            "       WHERE pc.MaTask = cv.MaTask FOR XML PATH('')), 1, 2, '') AS NguoiThucHien " +
            "FROM CongViec cv JOIN DuAn da ON cv.MaDuAn = da.MaDuAn ";

        // Lọc task theo dự án và trạng thái (trangThai = null: tất cả)
        public List<CongViecDTO> LayDanhSach(int maDuAn, string trangThai)
        {
            return Doc(SELECT_TASK + "WHERE cv.MaDuAn = @MaDuAn AND (@TrangThai IS NULL OR cv.TrangThai = @TrangThai) " +
                       "ORDER BY cv.HanNop",
                new SqlParameter("@MaDuAn", SqlDbType.Int) { Value = maDuAn },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = (object)trangThai ?? DBNull.Value });
        }

        public int Them(CongViecDTO cv)
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) OUTPUT INSERTED.MaTask " +
                "VALUES (@MaDuAn, @Ten, @MoTa, @HanNop, @UuTien, @TrangThai)", ThamSo(cv)));
        }

        public int Sua(CongViecDTO cv)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE CongViec SET TenTask = @Ten, MoTa = @MoTa, HanNop = @HanNop, DoUuTien = @UuTien, TrangThai = @TrangThai " +
                "WHERE MaTask = @MaTask", ThamSo(cv));
        }

        // Chuyển trạng thái: Parameterized SQL UPDATE
        public int CapNhatTrangThai(int maTask, string trangThai)
        {
            return DatabaseHelper.ExecuteNonQuery("UPDATE CongViec SET TrangThai = @TrangThai WHERE MaTask = @MaTask",
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = trangThai },
                new SqlParameter("@MaTask", SqlDbType.Int) { Value = maTask });
        }

        // Xóa task cùng các dòng phân công trong 1 transaction
        public void Xoa(int maTask)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    foreach (string sql in new[] { "DELETE FROM PhanCong WHERE MaTask = @MaTask", "DELETE FROM CongViec WHERE MaTask = @MaTask" })
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn, trans);
                        cmd.Parameters.Add("@MaTask", SqlDbType.Int).Value = maTask;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public List<int> LayPhanCong(int maTask)
        {
            List<int> ds = new List<int>();
            foreach (DataRow r in DatabaseHelper.ExecuteQuery("SELECT MaThanhVien FROM PhanCong WHERE MaTask = @MaTask",
                         new SqlParameter("@MaTask", SqlDbType.Int) { Value = maTask }).Rows)
                ds.Add((int)r["MaThanhVien"]);
            return ds;
        }

        // Giao việc cho nhiều thành viên: bỏ người không còn được chọn, thêm người mới (giữ NgayGiao cũ)
        public void LuuPhanCong(int maTask, List<int> dsThanhVien)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Người đang được giao nhưng không còn được chọn -> xóa
                    List<int> cu = new List<int>();
                    SqlCommand doc = new SqlCommand("SELECT MaThanhVien FROM PhanCong WHERE MaTask = @MaTask", conn, trans);
                    doc.Parameters.Add("@MaTask", SqlDbType.Int).Value = maTask;
                    using (SqlDataReader dr = doc.ExecuteReader())
                        while (dr.Read()) cu.Add((int)dr["MaThanhVien"]);

                    foreach (int ma in cu)
                    {
                        if (dsThanhVien.Contains(ma)) continue;
                        SqlCommand xoa = new SqlCommand("DELETE FROM PhanCong WHERE MaTask = @MaTask AND MaThanhVien = @MaTV", conn, trans);
                        xoa.Parameters.Add("@MaTask", SqlDbType.Int).Value = maTask;
                        xoa.Parameters.Add("@MaTV", SqlDbType.Int).Value = ma;
                        xoa.ExecuteNonQuery();
                    }

                    foreach (int ma in dsThanhVien)
                    {
                        SqlCommand them = new SqlCommand(
                            "IF NOT EXISTS (SELECT 1 FROM PhanCong WHERE MaTask = @MaTask AND MaThanhVien = @MaTV) " +
                            "INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (@MaTask, @MaTV, GETDATE())", conn, trans);
                        them.Parameters.Add("@MaTask", SqlDbType.Int).Value = maTask;
                        them.Parameters.Add("@MaTV", SqlDbType.Int).Value = ma;
                        them.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public static List<CongViecDTO> Doc(string sql, params SqlParameter[] thamSo)
        {
            List<CongViecDTO> ds = new List<CongViecDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new CongViecDTO
                        {
                            MaTask = (int)dr["MaTask"],
                            MaDuAn = (int)dr["MaDuAn"],
                            TenDuAn = dr["TenDuAn"].ToString(),
                            TenTask = dr["TenTask"].ToString(),
                            MoTa = dr["MoTa"].ToString(),
                            HanNop = dr["HanNop"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["HanNop"],
                            DoUuTien = dr["DoUuTien"].ToString(),
                            TrangThai = dr["TrangThai"].ToString(),
                            NguoiThucHien = dr["NguoiThucHien"].ToString()
                        });
                    }
                }
            }
            return ds;
        }

        private SqlParameter[] ThamSo(CongViecDTO cv)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@MaDuAn", SqlDbType.Int) { Value = cv.MaDuAn },
                new SqlParameter("@Ten", SqlDbType.NVarChar, 200) { Value = cv.TenTask },
                new SqlParameter("@MoTa", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(cv.MoTa) ? (object)DBNull.Value : cv.MoTa },
                new SqlParameter("@HanNop", SqlDbType.DateTime) { Value = cv.HanNop.HasValue ? (object)cv.HanNop.Value : DBNull.Value },
                new SqlParameter("@UuTien", SqlDbType.NVarChar, 20) { Value = cv.DoUuTien },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = cv.TrangThai },
                new SqlParameter("@MaTask", SqlDbType.Int) { Value = cv.MaTask }
            };
        }
    }
}
