namespace BT6._3.DTO
{
    // Thành viên nhóm
    public class ThanhVienDTO
    {
        public int MaThanhVien { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string ChuyenMon { get; set; }

        public string HienThi
        {
            get { return HoTen + " (" + ChuyenMon + ")"; }
        }
    }
}