namespace BT6._4.DTO
{
    // Khách hàng (chủ xe); MaKH = 0 là khách mới
    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
    }
}