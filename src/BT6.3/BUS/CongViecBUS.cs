using System;
using System.Collections.Generic;
using BT6._3.DAL;
using BT6._3.DTO;

namespace BT6._3.BUS
{
    public class CongViecBUS
    {
        private readonly CongViecDAL dal = new CongViecDAL();

        // Thứ tự các cột trên bảng Kanban
        public static readonly string[] TRANG_THAI = { "To Do", "In Progress", "Review", "Done" };

        public List<CongViecDTO> LayDanhSach(int maDuAn, string trangThai)
        {
            return dal.LayDanhSach(maDuAn, trangThai);
        }

        public List<int> LayPhanCong(int maTask)
        {
            return dal.LayPhanCong(maTask);
        }

        public int Them(CongViecDTO cv)
        {
            KiemTra(cv);
            return dal.Them(cv);
        }

        public void Sua(CongViecDTO cv)
        {
            if (cv.MaTask <= 0) throw new Exception("Vui lòng chọn công việc cần sửa!");
            KiemTra(cv);
            dal.Sua(cv);
        }

        public void Xoa(int maTask)
        {
            if (maTask <= 0) throw new Exception("Vui lòng chọn công việc cần xóa!");
            dal.Xoa(maTask);
        }

        // Chuyển sang trạng thái kế tiếp (buoc = +1) hoặc lùi lại (buoc = -1); trả về trạng thái mới
        public string ChuyenTrangThai(CongViecDTO cv, int buoc)
        {
            if (cv == null) throw new Exception("Vui lòng chọn công việc cần chuyển trạng thái!");
            int i = Array.IndexOf(TRANG_THAI, cv.TrangThai) + buoc;
            if (i < 0) throw new Exception("Công việc đang ở trạng thái đầu tiên (To Do)!");
            if (i >= TRANG_THAI.Length) throw new Exception("Công việc đã hoàn thành (Done)!");
            dal.CapNhatTrangThai(cv.MaTask, TRANG_THAI[i]);
            return TRANG_THAI[i];
        }

        public void LuuPhanCong(int maTask, List<int> dsThanhVien)
        {
            if (maTask <= 0) throw new Exception("Vui lòng chọn công việc cần giao!");
            if (dsThanhVien.Count == 0) throw new Exception("Vui lòng chọn ít nhất 1 thành viên!");
            dal.LuuPhanCong(maTask, dsThanhVien);
        }

        // Kiểm tra dữ liệu
        private void KiemTra(CongViecDTO cv)
        {
            cv.TenTask = (cv.TenTask ?? "").Trim();
            if (cv.MaDuAn <= 0)
                throw new LoiNhapLieu("MaDuAn", "Vui lòng chọn dự án!");
            if (cv.TenTask == "")
                throw new LoiNhapLieu("TenTask", "Tên công việc không được để trống!");
            if (string.IsNullOrEmpty(cv.DoUuTien))
                throw new LoiNhapLieu("DoUuTien", "Vui lòng chọn độ ưu tiên!");
            if (Array.IndexOf(TRANG_THAI, cv.TrangThai) < 0)
                throw new LoiNhapLieu("TrangThai", "Vui lòng chọn trạng thái!");
        }
    }
}