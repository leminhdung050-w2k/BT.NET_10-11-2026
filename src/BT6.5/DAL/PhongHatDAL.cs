using System.Collections.Generic;
using System.Data;
using BT6._5.DTO;

namespace BT6._5.DAL
{
    public class PhongHatDAL
    {
        public List<PhongHatDTO> LayDanhSach()
        {
            List<PhongHatDTO> ds = new List<PhongHatDTO>();
            foreach (DataRow r in DatabaseHelper.ExecuteQuery("SELECT MaPhong, TenPhong, LoaiPhong, GiaTheoGio, TrangThai FROM PhongHat ORDER BY MaPhong").Rows)
            {
                ds.Add(new PhongHatDTO
                {
                    MaPhong = (int)r["MaPhong"],
                    TenPhong = r["TenPhong"].ToString(),
                    LoaiPhong = r["LoaiPhong"].ToString(),
                    GiaTheoGio = (decimal)r["GiaTheoGio"],
                    TrangThai = r["TrangThai"].ToString()
                });
            }
            return ds;
        }
    }
}