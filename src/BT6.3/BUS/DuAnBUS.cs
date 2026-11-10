using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BT6._3.DAL;
using BT6._3.DTO;

namespace BT6._3.BUS
{
    public class DuAnBUS
    {
        private readonly DuAnDAL dal = new DuAnDAL();

        public List<DuAnDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public void Them(DuAnDTO da)
        {
            KiemTra(da);
            dal.Them(da);
        }

        public void Sua(DuAnDTO da)
        {
            if (da.MaDuAn <= 0) throw new Exception("Vui lòng chọn dự án cần sửa!");
            KiemTra(da);
            dal.Sua(da);
        }

        public void Xoa(int maDuAn)
        {
            if (maDuAn <= 0) throw new Exception("Vui lòng chọn dự án cần xóa!");
            try
            {
                dal.Xoa(maDuAn);
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại
            {
                throw new Exception("Dự án đang có công việc, hãy xóa các công việc trước!");
            }
        }

        // Kiểm tra dữ liệu
        private void KiemTra(DuAnDTO da)
        {
            da.TenDuAn = (da.TenDuAn ?? "").Trim();
            if (da.TenDuAn == "")
                throw new LoiNhapLieu("TenDuAn", "Tên dự án không được để trống!");
            if (da.NgayBatDau.HasValue && da.NgayKetThuc.HasValue && da.NgayKetThuc.Value < da.NgayBatDau.Value)
                throw new LoiNhapLieu("NgayKetThuc", "Ngày kết thúc phải sau ngày bắt đầu!");
            if (string.IsNullOrEmpty(da.TrangThai))
                throw new LoiNhapLieu("TrangThai", "Vui lòng chọn trạng thái dự án!");
        }
    }
}