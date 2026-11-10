namespace BT6._4.DTO
{
    // 1 dòng phụ tùng thay thế + tiền công
    public class ChiTietSuaChuaDTO
    {
        public int MaPhuTung { get; set; }
        public string TenPhuTung { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal TienCong { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuong * DonGia + TienCong; }
        }
    }
}