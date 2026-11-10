using System;

namespace BT6._3.BUS
{
    // Lỗi dữ liệu nhập: cho GUI biết sai ở trường nào để hiện ErrorProvider đúng ô
    public class LoiNhapLieu : Exception
    {
        public string TenTruong { get; private set; }

        public LoiNhapLieu(string tenTruong, string thongBao) : base(thongBao)
        {
            TenTruong = tenTruong;
        }
    }
}
