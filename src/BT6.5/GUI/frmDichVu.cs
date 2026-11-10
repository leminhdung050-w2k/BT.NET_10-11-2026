using System;
using System.Drawing;
using System.Windows.Forms;
using BT6._5.BUS;
using BT6._5.DTO;

namespace BT6._5.GUI
{
    public partial class frmDichVu : Form
    {
        private readonly DichVuBUS bus = new DichVuBUS();
        private int maChon = -1;

        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            try
            {
                bindingSource1.DataSource = bus.LayDanhSach();
                dgvDichVu.Columns["MaDV"].HeaderText = "Mã";
                dgvDichVu.Columns["MaDV"].FillWeight = 40;
                dgvDichVu.Columns["TenDV"].HeaderText = "Tên dịch vụ / đồ uống";
                dgvDichVu.Columns["TenDV"].FillWeight = 200;
                dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvDichVu.Columns["TonKho"].HeaderText = "Tồn kho";
                dgvDichVu.Columns["HienThi"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô đỏ mặt hàng sắp hết (tồn dưới 10)
        private void dgvDichVu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DichVuDTO dv = dgvDichVu.Rows[e.RowIndex].DataBoundItem as DichVuDTO;
            if (dv != null && dv.TonKho < 10) e.CellStyle.ForeColor = Color.Red;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DichVuDTO dv = (DichVuDTO)bindingSource1[e.RowIndex];
            maChon = dv.MaDV;
            txtTenDV.Text = dv.TenDV;
            txtDonGia.Text = dv.DonGia.ToString("0");
            txtTonKho.Text = dv.TonKho.ToString();
            errorProvider1.Clear();
        }

        private DichVuDTO DocForm()
        {
            decimal gia = 0;
            string s = txtDonGia.Text.Replace(",", "").Replace(".", "").Trim();
            if (s != "" && !decimal.TryParse(s, out gia)) throw new LoiNhapLieu("DonGia", "Đơn giá phải là số!");
            int ton;
            if (!int.TryParse(txtTonKho.Text.Trim(), out ton)) throw new LoiNhapLieu("TonKho", "Tồn kho phải là số nguyên!");
            return new DichVuDTO { MaDV = maChon, TenDV = txtTenDV.Text, DonGia = gia, TonKho = ton };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Them(DocForm()), "Thêm dịch vụ thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Sua(DocForm()), "Cập nhật dịch vụ thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maChon > 0 && MessageBox.Show("Xóa dịch vụ \"" + txtTenDV.Text + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            XuLy(() => bus.Xoa(maChon), "Xóa dịch vụ thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maChon = -1;
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtTonKho.Text = "0";
            errorProvider1.Clear();
            txtTenDV.Focus();
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
                Control o = ex.TenTruong == "TenDV" ? txtTenDV : ex.TenTruong == "DonGia" ? txtDonGia : txtTonKho;
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
