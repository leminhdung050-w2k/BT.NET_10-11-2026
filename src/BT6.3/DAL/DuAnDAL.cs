using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._3.DTO;

namespace BT6._3.DAL
{
    public class DuAnDAL
    {
        public List<DuAnDTO> LayDanhSach()
        {
            List<DuAnDTO> ds = new List<DuAnDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, TrangThai FROM DuAn ORDER BY MaDuAn", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ds.Add(new DuAnDTO
                        {
                            MaDuAn = (int)dr["MaDuAn"],
                            TenDuAn = dr["TenDuAn"].ToString(),
                            NgayBatDau = dr["NgayBatDau"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["NgayBatDau"],
                            NgayKetThuc = dr["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["NgayKetThuc"],
                            TrangThai = dr["TrangThai"].ToString()
                        });
                    }
                }
            }
            return ds;
        }

        public int Them(DuAnDTO da)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES (@Ten, @BatDau, @KetThuc, @TrangThai)", ThamSo(da));
        }

        public int Sua(DuAnDTO da)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE DuAn SET TenDuAn = @Ten, NgayBatDau = @BatDau, NgayKetThuc = @KetThuc, TrangThai = @TrangThai WHERE MaDuAn = @Ma",
                ThamSo(da));
        }

        public int Xoa(int maDuAn)
        {
            return DatabaseHelper.ExecuteNonQuery("DELETE FROM DuAn WHERE MaDuAn = @Ma",
                new SqlParameter("@Ma", SqlDbType.Int) { Value = maDuAn });
        }

        private SqlParameter[] ThamSo(DuAnDTO da)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Ten", SqlDbType.NVarChar, 150) { Value = da.TenDuAn },
                new SqlParameter("@BatDau", SqlDbType.DateTime) { Value = da.NgayBatDau.HasValue ? (object)da.NgayBatDau.Value : DBNull.Value },
                new SqlParameter("@KetThuc", SqlDbType.DateTime) { Value = da.NgayKetThuc.HasValue ? (object)da.NgayKetThuc.Value : DBNull.Value },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = da.TrangThai },
                new SqlParameter("@Ma", SqlDbType.Int) { Value = da.MaDuAn }
            };
        }
    }
}
