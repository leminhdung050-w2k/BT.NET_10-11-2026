using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BT6._4.BUS;
using BT6._4.DTO;

namespace BT6._4.GUI
{
    public partial class frmThanhToan : Form
    {
        private readonly PhieuSuaChuaBUS bus = new PhieuSuaChuaBUS();
        private PhieuSuaChuaDTO phieuChon;
        private List<ChiTietSuaChuaDTO> chiTietChon = new List<ChiTietSuaChuaDTO>();

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            cboLoc.SelectedIndex = 0;
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiPhieu(0);
        }

        private void TaiPhieu(int chonMa)
        {
            try
            {
                string loc = cboLoc.SelectedIndex == 0 ? "Đã hoàn thành" : cboLoc.SelectedIndex == 1 ? "Đã thanh toán" : null;
                List<PhieuSuaChuaDTO> ds = bus.LayDanhSach(loc);
                bindingSource1.DataSource = ds;
                dgvPhieu.Columns["MaPhieu"].HeaderText = "Mã phiếu";
                dgvPhieu.Columns["MaPhieu"].FillWeight = 50;
                dgvPhieu.Columns["BienSo"].HeaderText = "Biển số";
                dgvPhieu.Columns["TenKH"].HeaderText = "Chủ xe";
                dgvPhieu.Columns["NgayNhan"].HeaderText = "Ngày nhận";
                dgvPhieu.Columns["NgayNhan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvPhieu.Columns["NoiDungSua"].HeaderText = "Nội dung sửa";
                dgvPhieu.Columns["NoiDungSua"].FillWeight = 200;
                dgvPhieu.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvPhieu.Columns["TrangThai"].HeaderText = "Trạng thái";

                PhieuSuaChuaDTO chon = ds.Find(x => x.MaPhieu == chonMa) ?? (ds.Count > 0 ? ds[0] : null);
                ChonPhieu(chon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ChonPhieu((PhieuSuaChuaDTO)bindingSource1[e.RowIndex]);
        }

        private void ChonPhieu(PhieuSuaChuaDTO phieu)
        {
            phieuChon = phieu;
            chiTietChon = phieu == null ? new List<ChiTietSuaChuaDTO>() : bus.LayChiTiet(phieu.MaPhieu);
            bindingSource2.DataSource = chiTietChon;
            dgvChiTiet.Columns["MaPhuTung"].Visible = false;
            dgvChiTiet.Columns["TenPhuTung"].HeaderText = "Phụ tùng";
            dgvChiTiet.Columns["TenPhuTung"].FillWeight = 200;
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["TienCong"].HeaderText = "Tiền công";
            dgvChiTiet.Columns["TienCong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            grpChiTiet.Text = phieu == null ? "Chi tiết phiếu" : "Chi tiết phiếu #" + phieu.MaPhieu + " - " + phieu.BienSo + " (" + phieu.TrangThai + ")";
            lblTong.Text = "Tổng chi phí: " + PhieuSuaChuaBUS.TinhTongTien(chiTietChon).ToString("N0") + " đ";
            btnThanhToan.Enabled = phieu != null && phieu.TrangThai != "Đã thanh toán";
            btnLuuFile.Enabled = phieu != null;
        }

        // Thanh toán: Tổng chi phí = Tổng (SL x Đơn giá) + Tổng tiền công, chuyển phiếu sang "Đã thanh toán"
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (phieuChon == null) return;
            if (MessageBox.Show("Thanh toán phiếu #" + phieuChon.MaPhieu + " - xe " + phieuChon.BienSo + "?\n" + lblTong.Text,
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                bus.ThanhToan(phieuChon);
                MessageBox.Show(PhieuSuaChuaBUS.TaoHoaDon(phieuChon, chiTietChon), "Hóa đơn thanh toán",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiPhieu(phieuChon.MaPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xuất hóa đơn ra file .txt (SaveFileDialog từ Toolbox)
        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            if (phieuChon == null) return;
            saveFileDialog1.FileName = "HoaDon_Phieu" + phieuChon.MaPhieu + ".txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(saveFileDialog1.FileName, PhieuSuaChuaBUS.TaoHoaDon(phieuChon, chiTietChon), Encoding.UTF8);
            MessageBox.Show("Đã lưu hóa đơn: " + saveFileDialog1.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
