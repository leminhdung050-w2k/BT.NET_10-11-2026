using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BT6._3.DTO;

namespace BT6._3.DAL
{
    public class BaoCaoDAL
    {
        // SqlDataReader: các công việc đã quá HanNop mà TrangThai != 'Done' (maDuAn = 0: tất cả dự án)
        public List<CongViecDTO> TaskTreHan(int maDuAn)
        {
            return CongViecDAL.Doc(CongViecDAL.SELECT_TASK +
                "WHERE cv.HanNop < GETDATE() AND cv.TrangThai <> 'Done' AND (@MaDuAn = 0 OR cv.MaDuAn = @MaDuAn) " +
                "ORDER BY cv.HanNop",
                new SqlParameter("@MaDuAn", SqlDbType.Int) { Value = maDuAn });
        }

        // ExecuteScalar: số công việc trễ hạn
        public int DemTreHan()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM CongViec WHERE HanNop < GETDATE() AND TrangThai <> 'Done'"));
        }

        // ExecuteScalar: % task Done của dự án
        public double TyLeHoanThanhDuAn(int maDuAn)
        {
            object kq = DatabaseHelper.ExecuteScalar(
                "SELECT CASE WHEN COUNT(*) = 0 THEN 0 ELSE 100.0 * SUM(CASE WHEN TrangThai = 'Done' THEN 1 ELSE 0 END) / COUNT(*) END " +
                "FROM CongViec WHERE (@MaDuAn = 0 OR MaDuAn = @MaDuAn)",
                new SqlParameter("@MaDuAn", SqlDbType.Int) { Value = maDuAn });
            return Convert.ToDouble(kq);
        }

        // GROUP BY: tỷ lệ hoàn thành công việc của từng thành viên trong dự án
        public List<ThongKeDTO> ThongKeThanhVien(int maDuAn)
        {
            List<ThongKeDTO> ds = new List<ThongKeDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT tv.HoTen, COUNT(*) AS TongTask, SUM(CASE WHEN cv.TrangThai = 'Done' THEN 1 ELSE 0 END) AS SoTaskDone " +
                "FROM PhanCong pc JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien JOIN CongViec cv ON pc.MaTask = cv.MaTask " +
                "WHERE (@MaDuAn = 0 OR cv.MaDuAn = @MaDuAn) " +
                "GROUP BY tv.MaThanhVien, tv.HoTen ORDER BY tv.MaThanhVien", conn))
            {
                cmd.Parameters.Add("@MaDuAn", SqlDbType.Int).Value = maDuAn;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int tong = (int)dr["TongTask"], done = (int)dr["SoTaskDone"];
                        ds.Add(new ThongKeDTO
                        {
                            HoTen = dr["HoTen"].ToString(),
                            TongTask = tong,
                            SoTaskDone = done,
                            TyLeHoanThanh = tong == 0 ? 0 : Math.Round(100.0 * done / tong, 1)
                        });
                    }
                }
            }
            return ds;
        }
    }
}
