using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using BT6._4.DAL;
using BT6._4.DTO;

namespace BT6._4.BUS
{
    public class XeBUS
    {
        private readonly XeDAL dal = new XeDAL();

        public List<XeDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public static string ChuanHoaBienSo(string bienSo)
        {
            return (bienSo ?? "").Trim().ToUpper().Replace(" ", "");
        }

        // Tra cứu biển số (SqlParameter)
        public XeDTO TraCuu(string bienSo)
        {
            bienSo = ChuanHoaBienSo(bienSo);
            if (bienSo == "") throw new LoiNhapLieu("BienSo", "Vui lòng nhập biển số xe!");
            return dal.TimTheoBienSo(bienSo);
        }

        public void LuuXeMoi(KhachHangDTO kh, XeDTO xe)
        {
            KiemTra(kh, xe);
            if (dal.TimTheoBienSo(xe.BienSo) != null)
                throw new LoiNhapLieu("BienSo", "Biển số " + xe.BienSo + " đã có trong hệ thống!");
            // SĐT đã có: chỉ dùng lại khi đúng là chủ xe đó (cùng tên)
            KhachHangDTO cu = kh.DienThoai == "" ? null : dal.TimKhachTheoSDT(kh.DienThoai);
            if (cu != null && !string.Equals(cu.TenKH, kh.TenKH, StringComparison.CurrentCultureIgnoreCase))
                throw new LoiNhapLieu("DienThoai", "SĐT " + kh.DienThoai + " đã thuộc khách hàng " + cu.TenKH + "!");
            dal.LuuXeMoi(kh, xe);
        }

        public void CapNhat(KhachHangDTO kh, XeDTO xe)
        {
            if (kh.MaKH <= 0) throw new Exception("Vui lòng tra cứu / chọn xe cần cập nhật!");
            KiemTra(kh, xe);
            try
            {
                dal.CapNhat(kh, xe);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // trùng UNIQUE
            {
                throw new LoiNhapLieu("DienThoai", "Số điện thoại đã thuộc khách hàng khác!");
            }
        }

        public void Xoa(string bienSo)
        {
            bienSo = ChuanHoaBienSo(bienSo);
            if (bienSo == "") throw new Exception("Vui lòng chọn xe cần xóa!");
            try
            {
                dal.Xoa(bienSo);
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại
            {
                throw new Exception("Xe đã có phiếu sửa chữa, không thể xóa!");
            }
        }

        // Kiểm tra dữ liệu
        private void KiemTra(KhachHangDTO kh, XeDTO xe)
        {
            xe.BienSo = ChuanHoaBienSo(xe.BienSo);
            kh.TenKH = (kh.TenKH ?? "").Trim();
            kh.DienThoai = (kh.DienThoai ?? "").Trim();
            kh.DiaChi = (kh.DiaChi ?? "").Trim();
            xe.HieuXe = (xe.HieuXe ?? "").Trim();

            if (xe.BienSo.Length < 6)
                throw new LoiNhapLieu("BienSo", "Biển số không hợp lệ (VD: 30A-123.45)!");
            if (xe.HieuXe == "")
                throw new LoiNhapLieu("HieuXe", "Vui lòng nhập hiệu xe!");
            if (xe.NamSanXuat.HasValue && (xe.NamSanXuat < 1980 || xe.NamSanXuat > DateTime.Today.Year + 1))
                throw new LoiNhapLieu("NamSanXuat", "Năm sản xuất không hợp lệ!");
            if (kh.TenKH == "")
                throw new LoiNhapLieu("TenKH", "Vui lòng nhập tên chủ xe!");
            if (kh.DienThoai != "" && (kh.DienThoai.Length != 10 || kh.DienThoai[0] != '0' || !kh.DienThoai.All(char.IsDigit)))
                throw new LoiNhapLieu("DienThoai", "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0!");
        }
    }
}