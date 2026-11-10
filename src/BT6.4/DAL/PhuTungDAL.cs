using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._4.DTO;

namespace BT6._4.DAL
{
    public class PhuTungDAL
    {
        public List<PhuTungDTO> LayDanhSach()
        {
            List<PhuTungDTO> ds = new List<PhuTungDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT MaPhuTung, TenPhuTung, DonGia, SoLuongTon FROM PhuTung ORDER BY MaPhuTung", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new PhuTungDTO
                        {
                            MaPhuTung = (int)dr["MaPhuTung"],
                            TenPhuTung = dr["TenPhuTung"].ToString(),
                            DonGia = (decimal)dr["DonGia"],
                            SoLuongTon = (int)dr["SoLuongTon"]
                        });
                    }
                }
            }
            return ds;
        }

        public int Them(PhuTungDTO pt)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES (@Ten, @Gia, @Ton)", ThamSo(pt));
        }

        // Cập nhật đơn giá, số lượng tồn kho
        public int Sua(PhuTungDTO pt)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE PhuTung SET TenPhuTung = @Ten, DonGia = @Gia, SoLuongTon = @Ton WHERE MaPhuTung = @Ma", ThamSo(pt));
        }

        public int Xoa(int maPhuTung)
        {
            return DatabaseHelper.ExecuteNonQuery("DELETE FROM PhuTung WHERE MaPhuTung = @Ma",
                new SqlParameter("@Ma", SqlDbType.Int) { Value = maPhuTung });
        }

        private SqlParameter[] ThamSo(PhuTungDTO pt)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Ten", SqlDbType.NVarChar, 150) { Value = pt.TenPhuTung },
                new SqlParameter("@Gia", SqlDbType.Decimal) { Value = pt.DonGia, Precision = 18, Scale = 2 },
                new SqlParameter("@Ton", SqlDbType.Int) { Value = pt.SoLuongTon },
                new SqlParameter("@Ma", SqlDbType.Int) { Value = pt.MaPhuTung }
            };
        }
    }
}
