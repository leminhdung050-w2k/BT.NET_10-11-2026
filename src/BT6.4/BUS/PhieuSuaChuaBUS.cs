using System;
using System.Collections.Generic;
using System.Linq;
using BT6._4.DAL;
using BT6._4.DTO;

namespace BT6._4.BUS
{
    public class PhieuSuaChuaBUS
    {
        private readonly PhieuSuaChuaDAL dal = new PhieuSuaChuaDAL();

        public void KiemTraDong(ChiTietSuaChuaDTO ct)
        {
            if (ct.MaPhuTung <= 0) throw new LoiNhapLieu("MaPhuTung", "Vui lòng chọn phụ tùng!");
            if (ct.SoLuong <= 0) throw new LoiNhapLieu("SoLuong", "Số lượng phải lớn hơn 0!");
            if (ct.TienCong < 0) throw new LoiNhapLieu("TienCong", "Tiền công không được âm!");
        }

        // Tổng chi phí = Tổng (Số lượng phụ tùng x Đơn giá) + Tổng tiền công
        public static decimal TinhTongTien(List<ChiTietSuaChuaDTO> ds)
        {
            return ds.Sum(x => x.SoLuong * x.DonGia) + ds.Sum(x => x.TienCong);
        }

        public int LapPhieu(PhieuSuaChuaDTO phieu)
        {
            if (string.IsNullOrEmpty(phieu.BienSo)) throw new LoiNhapLieu("BienSo", "Vui lòng chọn xe!");
            if (phieu.ChiTiet.Count == 0) throw new Exception("Phiếu chưa có phụ tùng / dịch vụ nào!");
            foreach (ChiTietSuaChuaDTO ct in phieu.ChiTiet) KiemTraDong(ct);
            phieu.TongTien = TinhTongTien(phieu.ChiTiet);
            return dal.LapPhieu(phieu);
        }

        public List<PhieuSuaChuaDTO> LayDanhSach(string trangThai)
        {
            return dal.LayDanhSach(trangThai);
        }

        public List<ChiTietSuaChuaDTO> LayChiTiet(int maPhieu)
        {
            return dal.LayChiTiet(maPhieu);
        }

        // Thanh toán: tính tổng chi phí, chuyển phiếu sang "Đã thanh toán"
        public decimal ThanhToan(PhieuSuaChuaDTO phieu)
        {
            if (phieu == null) throw new Exception("Vui lòng chọn phiếu cần thanh toán!");
            if (phieu.TrangThai == "Đã thanh toán") throw new Exception("Phiếu #" + phieu.MaPhieu + " đã thanh toán rồi!");
            decimal tong = TinhTongTien(dal.LayChiTiet(phieu.MaPhieu));
            if (dal.ThanhToan(phieu.MaPhieu, tong) == 0) throw new Exception("Không thanh toán được phiếu #" + phieu.MaPhieu + "!");
            phieu.TongTien = tong;
            phieu.TrangThai = "Đã thanh toán";
            return tong;
        }

        // Nội dung hóa đơn dịch vụ
        public static string TaoHoaDon(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> ds)
        {
            string s = "HÓA ĐƠN DỊCH VỤ SỬA CHỮA - GARAGE\r\n" +
                       "Phiếu số: " + phieu.MaPhieu + "   Ngày nhận: " + phieu.NgayNhan.ToString("dd/MM/yyyy HH:mm") + "\r\n" +
                       "Xe: " + phieu.BienSo + "   Chủ xe: " + phieu.TenKH + "\r\n" +
                       "Nội dung: " + phieu.NoiDungSua + "\r\n" +
                       "----------------------------------------------\r\n";
            foreach (ChiTietSuaChuaDTO ct in ds)
                s += ct.TenPhuTung + ": " + ct.SoLuong + " x " + ct.DonGia.ToString("N0") + " + công " + ct.TienCong.ToString("N0") +
                     " = " + ct.ThanhTien.ToString("N0") + " đ\r\n";
            s += "----------------------------------------------\r\n" +
                 "Tiền phụ tùng: " + ds.Sum(x => x.SoLuong * x.DonGia).ToString("N0") + " đ\r\n" +
                 "Tiền công: " + ds.Sum(x => x.TienCong).ToString("N0") + " đ\r\n" +
                 "TỔNG CHI PHÍ: " + TinhTongTien(ds).ToString("N0") + " đ\r\n" +
                 "Trạng thái: " + phieu.TrangThai;
            return s;
        }
    }
}