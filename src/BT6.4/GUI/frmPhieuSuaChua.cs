using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BT6._4.BUS;
using BT6._4.DTO;

namespace BT6._4.GUI
{
    public partial class frmPhieuSuaChua : Form
    {
        private readonly PhieuSuaChuaBUS bus = new PhieuSuaChuaBUS();
        private readonly XeBUS xeBUS = new XeBUS();
        private readonly PhuTungBUS phuTungBUS = new PhuTungBUS();

        // Danh sách phụ tùng / dịch vụ của phiếu đang lập
        private readonly BindingList<ChiTietSuaChuaDTO> dsChiTiet = new BindingList<ChiTietSuaChuaDTO>();

        public frmPhieuSuaChua()
        {
            InitializeComponent();
        }

        private void frmPhieuSuaChua_Load(object sender, EventArgs e)
        {
            try
            {
                cboXe.DisplayMember = "HienThi";
                cboXe.ValueMember = "BienSo";
                cboXe.DataSource = xeBUS.LayDanhSach();
                TaiPhuTung();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bindingSource1.DataSource = dsChiTiet;
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
            CapNhatTong();
        }

        private void TaiPhuTung()
        {
            cboPhuTung.DisplayMember = "HienThi";
            cboPhuTung.ValueMember = "MaPhuTung";
            cboPhuTung.DataSource = phuTungBUS.LayDanhSach();
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                decimal tienCong = 0;
                string s = txtTienCong.Text.Replace(",", "").Replace(".", "").Trim();
                if (s != "" && !decimal.TryParse(s, out tienCong)) throw new LoiNhapLieu("TienCong", "Tiền công phải là số!");

                PhuTungDTO pt = cboPhuTung.SelectedItem as PhuTungDTO;
                ChiTietSuaChuaDTO ct = new ChiTietSuaChuaDTO
                {
                    MaPhuTung = pt == null ? 0 : pt.MaPhuTung,
                    TenPhuTung = pt == null ? "" : pt.TenPhuTung,
                    DonGia = pt == null ? 0 : pt.DonGia,
                    SoLuong = (int)numSoLuong.Value,
                    TienCong = tienCong
                };
                bus.KiemTraDong(ct);

                // Phụ tùng đã có trong phiếu thì cộng dồn số lượng và tiền công
                ChiTietSuaChuaDTO cu = dsChiTiet.FirstOrDefault(x => x.MaPhuTung == ct.MaPhuTung);
                if (cu != null)
                {
                    cu.SoLuong += ct.SoLuong;
                    cu.TienCong += ct.TienCong;
                    dsChiTiet.ResetBindings();
                }
                else
                {
                    dsChiTiet.Add(ct);
                }
                numSoLuong.Value = 1;
                txtTienCong.Clear();
                CapNhatTong();
            }
            catch (LoiNhapLieu ex)
            {
                Control o = ex.TenTruong == "SoLuong" ? numSoLuong : ex.TenTruong == "TienCong" ? (Control)txtTienCong : cboPhuTung;
                errorProvider1.SetError(o, ex.Message);
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null) return;
            dsChiTiet.Remove((ChiTietSuaChuaDTO)bindingSource1.Current);
            CapNhatTong();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dsChiTiet.Clear();
            txtNoiDung.Clear();
            txtTienCong.Clear();
            errorProvider1.Clear();
            CapNhatTong();
        }

        private void CapNhatTong()
        {
            lblTong.Text = "Tổng chi phí: " + PhieuSuaChuaBUS.TinhTongTien(dsChiTiet.ToList()).ToString("N0") + " đ";
        }

        // Xác nhận hoàn tất phiếu sửa chữa: toàn bộ chạy trong 1 SqlTransaction (xem PhieuSuaChuaDAL.LapPhieu)
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            PhieuSuaChuaDTO phieu = new PhieuSuaChuaDTO
            {
                BienSo = cboXe.SelectedValue as string,
                NoiDungSua = txtNoiDung.Text.Trim(),
                ChiTiet = dsChiTiet.ToList()
            };
            try
            {
                int ma = bus.LapPhieu(phieu);
                MessageBox.Show("Lập phiếu sửa chữa thành công!\nMã phiếu: " + ma + "\nXe: " + phieu.BienSo +
                                "\nTổng chi phí: " + phieu.TongTien.ToString("N0") + " đ\n\nĐã trừ phụ tùng trong kho.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsChiTiet.Clear();
                txtNoiDung.Clear();
                CapNhatTong();
            }
            catch (LoiNhapLieu ex)
            {
                errorProvider1.SetError(cboXe, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaiPhuTung();   // cập nhật số lượng tồn mới
        }
    }
}
