using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BT6._3.DTO;

namespace BT6._3.DAL
{
    public class ThanhVienDAL
    {
        public List<ThanhVienDTO> LayDanhSach()
        {
            List<ThanhVienDTO> ds = new List<ThanhVienDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT MaThanhVien, HoTen, Email, ChuyenMon FROM ThanhVien ORDER BY MaThanhVien", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new ThanhVienDTO
                        {
                            MaThanhVien = (int)dr["MaThanhVien"],
                            HoTen = dr["HoTen"].ToString(),
                            Email = dr["Email"].ToString(),
                            ChuyenMon = dr["ChuyenMon"].ToString()
                        });
                    }
                }
            }
            return ds;
        }
    }
}
