namespace BT6._3.DTO
{
    // Tỷ lệ hoàn thành công việc của 1 thành viên
    public class ThongKeDTO
    {
        public string HoTen { get; set; }
        public int TongTask { get; set; }
        public int SoTaskDone { get; set; }
        public double TyLeHoanThanh { get; set; }  // %
    }
}