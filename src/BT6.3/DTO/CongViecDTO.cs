using System;

namespace BT6._3.DTO
{
    // Công việc / Task
    public class CongViecDTO
    {
        public int MaTask { get; set; }
        public int MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public string TenTask { get; set; }
        public string MoTa { get; set; }
        public DateTime? HanNop { get; set; }
        public string DoUuTien { get; set; }       // Cao / Trung bình / Thấp
        public string TrangThai { get; set; }      // To Do / In Progress / Review / Done
        public string NguoiThucHien { get; set; }  // danh sách thành viên được giao

        // Quá hạn nộp mà chưa Done
        public bool TreHan
        {
            get { return HanNop.HasValue && HanNop.Value < DateTime.Now && TrangThai != "Done"; }
        }

        // Hiển thị trên bảng Kanban
        public string HienThi
        {
            get
            {
                return "[" + DoUuTien + "] " + TenTask +
                       (HanNop.HasValue ? " - hạn " + HanNop.Value.ToString("dd/MM") : "") +
                       (TreHan ? "  (TRỄ HẠN)" : "");
            }
        }
    }
}