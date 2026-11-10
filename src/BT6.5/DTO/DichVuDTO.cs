namespace BT6._5.DTO
{
    // Dịch vụ / đồ uống
    public class DichVuDTO
    {
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }
        public int TonKho { get; set; }

        public string HienThi
        {
            get { return TenDV + " - " + DonGia.ToString("N0") + " đ (còn " + TonKho + ")"; }
        }
    }
}