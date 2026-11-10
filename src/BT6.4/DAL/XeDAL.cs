using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._4.DTO;

namespace BT6._4.DAL
{
    public class XeDAL
    {
        private const string SELECT_XE =
            "SELECT x.BienSo, x.MaKH, x.HieuXe, x.NamSanXuat, k.TenKH, k.DienThoai, k.DiaChi " +
            "FROM Xe x JOIN KhachHang k ON x.MaKH = k.MaKH ";

        public List<XeDTO> LayDanhSach()
        {
            return Doc(SELECT_XE + "ORDER BY x.BienSo");
        }

        // Tra cứu biển số xe bằng SqlParameter; không có thì trả về null
        public XeDTO TimTheoBienSo(string bienSo)
        {
            List<XeDTO> ds = Doc(SELECT_XE + "WHERE x.BienSo = @BienSo",
                new SqlParameter("@BienSo", SqlDbType.VarChar, 20) { Value = bienSo });
            return ds.Count == 0 ? null : ds[0];
        }

        // Tìm chủ xe theo số điện thoại; không có thì trả về null
        public KhachHangDTO TimKhachTheoSDT(string dienThoai)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT MaKH, TenKH, DienThoai, DiaChi FROM KhachHang WHERE DienThoai = @DT",
                new SqlParameter("@DT", SqlDbType.VarChar, 15) { Value = dienThoai });
            if (dt.Rows.Count == 0) return null;
            return new KhachHangDTO
            {
                MaKH = (int)dt.Rows[0]["MaKH"],
                TenKH = dt.Rows[0]["TenKH"].ToString(),
                DienThoai = dt.Rows[0]["DienThoai"].ToString(),
                DiaChi = dt.Rows[0]["DiaChi"].ToString()
            };
        }

        // Lưu xe mới (1 transaction): chủ xe đã có (theo SĐT) thì dùng lại, chưa có thì thêm mới -> thêm xe
        public void LuuXeMoi(KhachHangDTO kh, XeDTO xe)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    object maKH = null;
                    if (!string.IsNullOrEmpty(kh.DienThoai))
                    {
                        maKH = TaoLenh("SELECT MaKH FROM KhachHang WHERE DienThoai = @DT", conn, trans,
                            new SqlParameter("@DT", SqlDbType.VarChar, 15) { Value = kh.DienThoai }).ExecuteScalar();
                    }
                    if (maKH == null)
                    {
                        maKH = TaoLenh("INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) OUTPUT INSERTED.MaKH VALUES (@Ten, @DT, @DiaChi)", conn, trans,
                            ThamSoKH(kh)).ExecuteScalar();
                    }

                    TaoLenh("INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES (@BienSo, @MaKH, @Hieu, @Nam)", conn, trans,
                        new SqlParameter("@BienSo", SqlDbType.VarChar, 20) { Value = xe.BienSo },
                        new SqlParameter("@MaKH", SqlDbType.Int) { Value = (int)maKH },
                        new SqlParameter("@Hieu", SqlDbType.NVarChar, 50) { Value = xe.HieuXe },
                        new SqlParameter("@Nam", SqlDbType.Int) { Value = xe.NamSanXuat.HasValue ? (object)xe.NamSanXuat.Value : DBNull.Value }
                    ).ExecuteNonQuery();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Cập nhật thông tin xe và chủ xe (1 transaction)
        public void CapNhat(KhachHangDTO kh, XeDTO xe)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    SqlParameter[] p = ThamSoKH(kh);
                    TaoLenh("UPDATE KhachHang SET TenKH = @Ten, DienThoai = @DT, DiaChi = @DiaChi WHERE MaKH = @MaKH", conn, trans,
                        p[0], p[1], p[2], new SqlParameter("@MaKH", SqlDbType.Int) { Value = kh.MaKH }).ExecuteNonQuery();
                    TaoLenh("UPDATE Xe SET HieuXe = @Hieu, NamSanXuat = @Nam WHERE BienSo = @BienSo", conn, trans,
                        new SqlParameter("@Hieu", SqlDbType.NVarChar, 50) { Value = xe.HieuXe },
                        new SqlParameter("@Nam", SqlDbType.Int) { Value = xe.NamSanXuat.HasValue ? (object)xe.NamSanXuat.Value : DBNull.Value },
                        new SqlParameter("@BienSo", SqlDbType.VarChar, 20) { Value = xe.BienSo }).ExecuteNonQuery();
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public int Xoa(string bienSo)
        {
            return DatabaseHelper.ExecuteNonQuery("DELETE FROM Xe WHERE BienSo = @BienSo",
                new SqlParameter("@BienSo", SqlDbType.VarChar, 20) { Value = bienSo });
        }

        private static SqlParameter[] ThamSoKH(KhachHangDTO kh)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Ten", SqlDbType.NVarChar, 100) { Value = kh.TenKH },
                new SqlParameter("@DT", SqlDbType.VarChar, 15) { Value = string.IsNullOrEmpty(kh.DienThoai) ? (object)DBNull.Value : kh.DienThoai },
                new SqlParameter("@DiaChi", SqlDbType.NVarChar, 200) { Value = string.IsNullOrEmpty(kh.DiaChi) ? (object)DBNull.Value : kh.DiaChi }
            };
        }

        private static SqlCommand TaoLenh(string sql, SqlConnection conn, SqlTransaction trans, params SqlParameter[] thamSo)
        {
            SqlCommand cmd = new SqlCommand(sql, conn, trans);
            cmd.Parameters.AddRange(thamSo);
            return cmd;
        }

        private List<XeDTO> Doc(string sql, params SqlParameter[] thamSo)
        {
            List<XeDTO> ds = new List<XeDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new XeDTO
                        {
                            BienSo = dr["BienSo"].ToString(),
                            MaKH = (int)dr["MaKH"],
                            HieuXe = dr["HieuXe"].ToString(),
                            NamSanXuat = dr["NamSanXuat"] == DBNull.Value ? (int?)null : (int)dr["NamSanXuat"],
                            TenKH = dr["TenKH"].ToString(),
                            DienThoai = dr["DienThoai"].ToString(),
                            DiaChi = dr["DiaChi"].ToString()
                        });
                    }
                }
            }
            return ds;
        }
    }
}
