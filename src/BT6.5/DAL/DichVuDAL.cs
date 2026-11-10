using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._5.DTO;

namespace BT6._5.DAL
{
    public class DichVuDAL
    {
        public List<DichVuDTO> LayDanhSach()
        {
            List<DichVuDTO> ds = new List<DichVuDTO>();
            foreach (DataRow r in DatabaseHelper.ExecuteQuery("SELECT MaDV, TenDV, DonGia, TonKho FROM DichVu ORDER BY MaDV").Rows)
            {
                ds.Add(new DichVuDTO
                {
                    MaDV = (int)r["MaDV"],
                    TenDV = r["TenDV"].ToString(),
                    DonGia = (decimal)r["DonGia"],
                    TonKho = (int)r["TonKho"]
                });
            }
            return ds;
        }

        public int Them(DichVuDTO dv)
        {
            return DatabaseHelper.ExecuteNonQuery("INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES (@Ten, @Gia, @Ton)", ThamSo(dv));
        }

        public int Sua(DichVuDTO dv)
        {
            return DatabaseHelper.ExecuteNonQuery("UPDATE DichVu SET TenDV = @Ten, DonGia = @Gia, TonKho = @Ton WHERE MaDV = @Ma", ThamSo(dv));
        }

        public int Xoa(int maDV)
        {
            return DatabaseHelper.ExecuteNonQuery("DELETE FROM DichVu WHERE MaDV = @Ma",
                new SqlParameter("@Ma", SqlDbType.Int) { Value = maDV });
        }

        private SqlParameter[] ThamSo(DichVuDTO dv)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Ten", SqlDbType.NVarChar, 100) { Value = dv.TenDV },
                new SqlParameter("@Gia", SqlDbType.Decimal) { Value = dv.DonGia, Precision = 18, Scale = 2 },
                new SqlParameter("@Ton", SqlDbType.Int) { Value = dv.TonKho },
                new SqlParameter("@Ma", SqlDbType.Int) { Value = dv.MaDV }
            };
        }
    }
}