namespace BT6._4.DTO
{
    // Phụ tùng / vật tư
    public class PhuTungDTO
    {
        public int MaPhuTung { get; set; }
        public string TenPhuTung { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public string HienThi
        {
            get { return TenPhuTung + " - " + DonGia.ToString("N0") + " đ (tồn: " + SoLuongTon + ")"; }
        }
    }
}