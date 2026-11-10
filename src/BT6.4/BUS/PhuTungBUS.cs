using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BT6._4.DAL;
using BT6._4.DTO;

namespace BT6._4.BUS
{
    public class PhuTungBUS
    {
        private readonly PhuTungDAL dal = new PhuTungDAL();

        public List<PhuTungDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public void Them(PhuTungDTO pt)
        {
            KiemTra(pt);
            dal.Them(pt);
        }

        public void Sua(PhuTungDTO pt)
        {
            if (pt.MaPhuTung <= 0) throw new Exception("Vui lòng chọn phụ tùng cần sửa!");
            KiemTra(pt);
            dal.Sua(pt);
        }

        public void Xoa(int maPhuTung)
        {
            if (maPhuTung <= 0) throw new Exception("Vui lòng chọn phụ tùng cần xóa!");
            try
            {
                dal.Xoa(maPhuTung);
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại
            {
                throw new Exception("Phụ tùng đã được dùng trong phiếu sửa chữa, không thể xóa!");
            }
        }

        // Kiểm tra dữ liệu
        private void KiemTra(PhuTungDTO pt)
        {
            pt.TenPhuTung = (pt.TenPhuTung ?? "").Trim();
            if (pt.TenPhuTung == "")
                throw new LoiNhapLieu("TenPhuTung", "Tên phụ tùng không được để trống!");
            if (pt.DonGia < 0)
                throw new LoiNhapLieu("DonGia", "Đơn giá không được âm!");
            if (pt.SoLuongTon < 0)
                throw new LoiNhapLieu("SoLuongTon", "Số lượng tồn không được âm!");
        }
    }
}