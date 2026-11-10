namespace BT6._5.DTO
{
    // Phòng hát
    public class PhongHatDTO
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }      // VIP / Thường
        public decimal GiaTheoGio { get; set; }
        public string TrangThai { get; set; }      // Trống / Đang hát
    }
}