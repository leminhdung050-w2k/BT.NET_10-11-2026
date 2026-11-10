using System;
using System.Collections.Generic;

namespace BT6._4.DTO
{
    // Phiếu sửa chữa
    public class PhieuSuaChuaDTO
    {
        public int MaPhieu { get; set; }
        public string BienSo { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayNhan { get; set; }
        public string NoiDungSua { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }      // Đang sửa / Đã hoàn thành / Đã thanh toán
        public List<ChiTietSuaChuaDTO> ChiTiet { get; set; } = new List<ChiTietSuaChuaDTO>();
    }
}