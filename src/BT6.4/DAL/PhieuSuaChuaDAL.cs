using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._4.DTO;

namespace BT6._4.DAL
{
    public class PhieuSuaChuaDAL
    {
        // Lập phiếu sửa chữa trong 1 SqlTransaction:
        // 1. Tạo PhieuSuaChua -> 2. Tạo ChiTietSuaChua -> 3. Trừ SoLuongTon (không đủ thì Rollback và báo lỗi)
        public int LapPhieu(PhieuSuaChuaDTO phieu)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int maPhieu = (int)TaoLenh(
                        "INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) OUTPUT INSERTED.MaPhieu " +
                        "VALUES (@BienSo, GETDATE(), @NoiDung, @TongTien, N'Đã hoàn thành')", conn, trans,
                        new SqlParameter("@BienSo", SqlDbType.VarChar, 20) { Value = phieu.BienSo },
                        new SqlParameter("@NoiDung", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(phieu.NoiDungSua) ? (object)DBNull.Value : phieu.NoiDungSua },
                        new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = phieu.TongTien, Precision = 18, Scale = 2 }
                    ).ExecuteScalar();

                    foreach (ChiTietSuaChuaDTO ct in phieu.ChiTiet)
                    {
                        TaoLenh("INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES (@MaPhieu, @MaPT, @SL, @TienCong)", conn, trans,
                            new SqlParameter("@MaPhieu", SqlDbType.Int) { Value = maPhieu },
                            new SqlParameter("@MaPT", SqlDbType.Int) { Value = ct.MaPhuTung },
                            new SqlParameter("@SL", SqlDbType.Int) { Value = ct.SoLuong },
                            new SqlParameter("@TienCong", SqlDbType.Decimal) { Value = ct.TienCong, Precision = 18, Scale = 2 }).ExecuteNonQuery();

                        object ton = TaoLenh("SELECT SoLuongTon FROM PhuTung WITH (UPDLOCK) WHERE MaPhuTung = @MaPT", conn, trans,
                            new SqlParameter("@MaPT", SqlDbType.Int) { Value = ct.MaPhuTung }).ExecuteScalar();
                        int soLuongTon = ton == null ? 0 : (int)ton;
                        if (soLuongTon < ct.SoLuong)
                        {
                            trans.Rollback();
                            throw new Exception("Phụ tùng không đủ số lượng trong kho!\n" + ct.TenPhuTung + ": còn " + soLuongTon +
                                ", cần " + ct.SoLuong + "\n\nĐã hủy (Rollback) toàn bộ phiếu sửa chữa.");
                        }
                        TaoLenh("UPDATE PhuTung SET SoLuongTon = SoLuongTon - @SL WHERE MaPhuTung = @MaPT", conn, trans,
                            new SqlParameter("@SL", SqlDbType.Int) { Value = ct.SoLuong },
                            new SqlParameter("@MaPT", SqlDbType.Int) { Value = ct.MaPhuTung }).ExecuteNonQuery();
                    }

                    trans.Commit();
                    return maPhieu;
                }
                catch
                {
                    if (trans.Connection != null) trans.Rollback();   // chưa rollback thì rollback
                    throw;
                }
            }
        }

        // Danh sách phiếu theo trạng thái (null: tất cả)
        public List<PhieuSuaChuaDTO> LayDanhSach(string trangThai)
        {
            List<PhieuSuaChuaDTO> ds = new List<PhieuSuaChuaDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT p.MaPhieu, p.BienSo, k.TenKH, p.NgayNhan, p.NoiDungSua, p.TongTien, p.TrangThai " +
                "FROM PhieuSuaChua p JOIN Xe x ON p.BienSo = x.BienSo JOIN KhachHang k ON x.MaKH = k.MaKH " +
                "WHERE (@TrangThai IS NULL OR p.TrangThai = @TrangThai) ORDER BY p.MaPhieu DESC", conn))
            {
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 30).Value = (object)trangThai ?? DBNull.Value;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new PhieuSuaChuaDTO
                        {
                            MaPhieu = (int)dr["MaPhieu"],
                            BienSo = dr["BienSo"].ToString(),
                            TenKH = dr["TenKH"].ToString(),
                            NgayNhan = (DateTime)dr["NgayNhan"],
                            NoiDungSua = dr["NoiDungSua"].ToString(),
                            TongTien = (decimal)dr["TongTien"],
                            TrangThai = dr["TrangThai"].ToString()
                        });
                    }
                }
            }
            return ds;
        }

        public List<ChiTietSuaChuaDTO> LayChiTiet(int maPhieu)
        {
            List<ChiTietSuaChuaDTO> ds = new List<ChiTietSuaChuaDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT c.MaPhuTung, t.TenPhuTung, c.SoLuong, t.DonGia, c.TienCong " +
                "FROM ChiTietSuaChua c JOIN PhuTung t ON c.MaPhuTung = t.MaPhuTung WHERE c.MaPhieu = @MaPhieu", conn))
            {
                cmd.Parameters.Add("@MaPhieu", SqlDbType.Int).Value = maPhieu;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new ChiTietSuaChuaDTO
                        {
                            MaPhuTung = (int)dr["MaPhuTung"],
                            TenPhuTung = dr["TenPhuTung"].ToString(),
                            SoLuong = (int)dr["SoLuong"],
                            DonGia = (decimal)dr["DonGia"],
                            TienCong = (decimal)dr["TienCong"]
                        });
                    }
                }
            }
            return ds;
        }

        // Thanh toán: chốt tổng tiền và chuyển trạng thái phiếu sang "Đã thanh toán"
        public int ThanhToan(int maPhieu, decimal tongTien)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE PhieuSuaChua SET TongTien = @TongTien, TrangThai = N'Đã thanh toán' " +
                "WHERE MaPhieu = @MaPhieu AND TrangThai <> N'Đã thanh toán'",
                new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien, Precision = 18, Scale = 2 },
                new SqlParameter("@MaPhieu", SqlDbType.Int) { Value = maPhieu });
        }

        private static SqlCommand TaoLenh(string sql, SqlConnection conn, SqlTransaction trans, params SqlParameter[] thamSo)
        {
            SqlCommand cmd = new SqlCommand(sql, conn, trans);
            cmd.Parameters.AddRange(thamSo);
            return cmd;
        }
    }
}
