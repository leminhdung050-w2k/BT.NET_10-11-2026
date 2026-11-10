using System;

namespace BT6._5.DTO
{
    // Hóa đơn sử dụng phòng
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public decimal GiaTheoGio { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public double SoGio { get; set; }
        public decimal TongTienPhong { get; set; }
        public decimal TongTienDichVu { get; set; }
        public bool TrangThai { get; set; }        // false: chưa thanh toán, true: đã thanh toán

        public decimal TongCong
        {
            get { return TongTienPhong + TongTienDichVu; }
        }
    }
}