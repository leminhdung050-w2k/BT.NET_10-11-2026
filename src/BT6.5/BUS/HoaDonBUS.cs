using System;
using System.Data;
using System.Linq;
using BT6._5.DAL;
using BT6._5.DTO;

namespace BT6._5.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public int MoPhong(PhongHatDTO phong)
        {
            if (phong == null) throw new Exception("Vui lòng chọn phòng!");
            if (phong.TrangThai != "Trống") throw new Exception(phong.TenPhong + " đang có khách hát!");
            return dal.MoPhong(phong.MaPhong);
        }

        public HoaDonDTO LayHoaDonDangMo(int maPhong)
        {
            return dal.LayHoaDonDangMo(maPhong);
        }

        public DataTable LayDichVuDaGoi(int maHD)
        {
            return dal.LayDichVuDaGoi(maHD);
        }

        // Thời gian hát = GioRa - GioVao (tính theo phút, quy ra giờ)
        public static double TinhSoGio(DateTime gioVao, DateTime gioRa)
        {
            return Math.Round(Math.Max(0, (gioRa - gioVao).TotalMinutes) / 60.0, 2);
        }

        // TongTienPhong = (Số giờ) x GiaTheoGio
        public static decimal TinhTienPhong(decimal giaTheoGio, double soGio)
        {
            return Math.Round(giaTheoGio * (decimal)soGio, 0);
        }

        public static decimal TinhTienDichVu(DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Where(r => r.RowState != DataRowState.Deleted)
                     .Sum(r => (int)r["SoLuong"] * (decimal)r["DonGia"]);
        }

        // Gọi thêm dịch vụ: sửa trên DataTable (ngắt kết nối) rồi đồng bộ về CSDL
        public void ThemDichVu(DataTable dt, HoaDonDTO hd, DichVuDTO dv, int soLuong)
        {
            if (hd == null) throw new Exception("Phòng chưa được mở!");
            if (dv == null) throw new Exception("Vui lòng chọn dịch vụ!");
            if (soLuong <= 0) throw new Exception("Số lượng phải lớn hơn 0!");

            DataRow r = dt.Rows.Cast<DataRow>().FirstOrDefault(x => x.RowState != DataRowState.Deleted && (int)x["MaDV"] == dv.MaDV);
            int daGoi = r == null ? 0 : (int)r["SoLuong"];
            if (daGoi + soLuong > dv.TonKho)
                throw new Exception("Không đủ hàng: " + dv.TenDV + " chỉ còn " + dv.TonKho + " (phòng đã gọi " + daGoi + ")!");

            if (r == null)
            {
                r = dt.NewRow();
                r["MaHD"] = hd.MaHD;
                r["MaDV"] = dv.MaDV;
                r["SoLuong"] = soLuong;
                r["DonGia"] = dv.DonGia;
                r["TenDV"] = dv.TenDV;
                dt.Rows.Add(r);
            }
            else
            {
                r["SoLuong"] = daGoi + soLuong;
            }
            dal.LuuDichVu(dt, hd.MaHD);
            dt.AcceptChanges();
        }

        // Thanh toán: tính giờ hát, tiền phòng rồi chạy SqlTransaction (xem HoaDonDAL.ThanhToan)
        public HoaDonDTO ThanhToan(HoaDonDTO hd)
        {
            if (hd == null) throw new Exception("Phòng chưa có hóa đơn để thanh toán!");
            hd.GioRa = DateTime.Now;
            hd.SoGio = TinhSoGio(hd.GioVao, hd.GioRa.Value);
            hd.TongTienPhong = TinhTienPhong(hd.GiaTheoGio, hd.SoGio);
            dal.ThanhToan(hd);
            return hd;
        }

        public static string ThoiGianHat(DateTime gioVao, DateTime den)
        {
            TimeSpan t = den - gioVao;
            return (int)t.TotalHours + " giờ " + t.Minutes + " phút";
        }
    }
}