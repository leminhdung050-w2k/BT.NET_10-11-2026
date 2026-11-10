using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BT6._5.DAL;
using BT6._5.DTO;

namespace BT6._5.BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL dal = new DichVuDAL();

        public List<DichVuDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public void Them(DichVuDTO dv)
        {
            KiemTra(dv);
            dal.Them(dv);
        }

        public void Sua(DichVuDTO dv)
        {
            if (dv.MaDV <= 0) throw new Exception("Vui lòng chọn dịch vụ cần sửa!");
            KiemTra(dv);
            dal.Sua(dv);
        }

        public void Xoa(int maDV)
        {
            if (maDV <= 0) throw new Exception("Vui lòng chọn dịch vụ cần xóa!");
            try
            {
                dal.Xoa(maDV);
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại
            {
                throw new Exception("Dịch vụ đã có trong hóa đơn, không thể xóa!");
            }
        }

        // Kiểm tra dữ liệu
        private void KiemTra(DichVuDTO dv)
        {
            dv.TenDV = (dv.TenDV ?? "").Trim();
            if (dv.TenDV == "") throw new LoiNhapLieu("TenDV", "Tên dịch vụ không được để trống!");
            if (dv.DonGia < 0) throw new LoiNhapLieu("DonGia", "Đơn giá không được âm!");
            if (dv.TonKho < 0) throw new LoiNhapLieu("TonKho", "Tồn kho không được âm!");
        }
    }
}