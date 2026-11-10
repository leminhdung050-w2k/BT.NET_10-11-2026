using System;

namespace BT6._3.DTO
{
    // Dự án
    public class DuAnDTO
    {
        public int MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; }      // Đang chạy / Hoàn thành / Tạm dừng
    }
}