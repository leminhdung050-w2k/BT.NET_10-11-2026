using System;
using System.Drawing;
using System.Windows.Forms;
using BT6._4.BUS;
using BT6._4.DTO;

namespace BT6._4.GUI
{
    public partial class frmTiepNhan : Form
    {
        private readonly XeBUS bus = new XeBUS();
        private XeDTO xeChon;       // xe đã có trong hệ thống (đang xem / sửa)

        public frmTiepNhan()
        {
            InitializeComponent();
        }

        private void frmTiepNhan_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu()
        {
            try
            {
                bindingSource1.DataSource = bus.LayDanhSach();
                dgvXe.Columns["BienSo"].HeaderText = "Biển số";
                dgvXe.Columns["HieuXe"].HeaderText = "Hiệu xe";
                dgvXe.Columns["NamSanXuat"].HeaderText = "Năm SX";
                dgvXe.Columns["NamSanXuat"].FillWeight = 60;
                dgvXe.Columns["TenKH"].HeaderText = "Chủ xe";
                dgvXe.Columns["TenKH"].FillWeight = 150;
                dgvXe.Columns["DienThoai"].HeaderText = "Điện thoại";
                dgvXe.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvXe.Columns["DiaChi"].FillWeight = 150;
                dgvXe.Columns["MaKH"].Visible = false;
                dgvXe.Columns["HienThi"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tra cứu biển số xe (SqlParameter)
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                XeDTO xe = bus.TraCuu(txtBienSo.Text);
                txtBienSo.Text = XeBUS.ChuanHoaBienSo(txtBienSo.Text);
                if (xe != null)
                {
                    HienXe(xe);
                    lblKetQua.ForeColor = Color.Green;
                    lblKetQua.Text = "Xe đã có trong hệ thống - chủ xe: " + xe.TenKH;
                }
                else
                {
                    xeChon = null;
                    txtBienSo.ReadOnly = false;
                    txtHieuXe.Clear(); txtNamSX.Clear(); txtTenKH.Clear(); txtDienThoai.Clear(); txtDiaChi.Clear();
                    lblKetQua.ForeColor = Color.OrangeRed;
                    lblKetQua.Text = "Xe mới - nhập thông tin chủ xe và xe rồi bấm \"Lưu xe mới\"";
                    txtHieuXe.Focus();
                }
            }
            catch (LoiNhapLieu ex)
            {
                errorProvider1.SetError(txtBienSo, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HienXe((XeDTO)bindingSource1[e.RowIndex]);
            lblKetQua.ForeColor = Color.Navy;
            lblKetQua.Text = "Đang chọn xe " + xeChon.BienSo;
        }

        private void HienXe(XeDTO xe)
        {
            xeChon = xe;
            txtBienSo.Text = xe.BienSo;
            txtBienSo.ReadOnly = true;     // không sửa khóa chính
            txtHieuXe.Text = xe.HieuXe;
            txtNamSX.Text = xe.NamSanXuat.HasValue ? xe.NamSanXuat.ToString() : "";
            txtTenKH.Text = xe.TenKH;
            txtDienThoai.Text = xe.DienThoai;
            txtDiaChi.Text = xe.DiaChi;
            errorProvider1.Clear();
        }

        private void DocForm(out KhachHangDTO kh, out XeDTO xe)
        {
            int nam = 0;
            if (txtNamSX.Text.Trim() != "" && !int.TryParse(txtNamSX.Text.Trim(), out nam))
                throw new LoiNhapLieu("NamSanXuat", "Năm sản xuất phải là số!");
            kh = new KhachHangDTO
            {
                MaKH = xeChon == null ? 0 : xeChon.MaKH,
                TenKH = txtTenKH.Text,
                DienThoai = txtDienThoai.Text,
                DiaChi = txtDiaChi.Text
            };
            xe = new XeDTO
            {
                BienSo = txtBienSo.Text,
                HieuXe = txtHieuXe.Text,
                NamSanXuat = txtNamSX.Text.Trim() == "" ? (int?)null : nam
            };
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (xeChon != null)
            {
                MessageBox.Show("Xe này đã có trong hệ thống, dùng \"Cập nhật\" để sửa thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            XuLy(() => { KhachHangDTO kh; XeDTO xe; DocForm(out kh, out xe); bus.LuuXeMoi(kh, xe); }, "Tiếp nhận xe mới thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy(() => { KhachHangDTO kh; XeDTO xe; DocForm(out kh, out xe); bus.CapNhat(kh, xe); }, "Cập nhật thông tin xe & chủ xe thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xeChon != null && MessageBox.Show("Xóa xe " + xeChon.BienSo + "?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            XuLy(() => bus.Xoa(xeChon == null ? "" : xeChon.BienSo), "Xóa xe thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            xeChon = null;
            txtBienSo.ReadOnly = false;
            txtBienSo.Clear(); txtHieuXe.Clear(); txtNamSX.Clear(); txtTenKH.Clear(); txtDienThoai.Clear(); txtDiaChi.Clear();
            lblKetQua.Text = "";
            errorProvider1.Clear();
            txtBienSo.Focus();
        }

        private void XuLy(Action thaoTac, string thongBao)
        {
            errorProvider1.Clear();
            try
            {
                thaoTac();
                TaiDuLieu();
                LamMoi();
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (LoiNhapLieu ex)
            {
                Control o = ex.TenTruong == "BienSo" ? txtBienSo
                          : ex.TenTruong == "HieuXe" ? txtHieuXe
                          : ex.TenTruong == "NamSanXuat" ? txtNamSX
                          : ex.TenTruong == "TenKH" ? (Control)txtTenKH
                          : txtDienThoai;
                errorProvider1.SetError(o, ex.Message);
                o.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
