using System;
using System.Drawing;
using System.Windows.Forms;
using BT6._4.BUS;
using BT6._4.DTO;

namespace BT6._4.GUI
{
    public partial class frmPhuTung : Form
    {
        private readonly PhuTungBUS bus = new PhuTungBUS();
        private int maChon = -1;

        public frmPhuTung()
        {
            InitializeComponent();
        }

        private void frmPhuTung_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            try
            {
                bindingSource1.DataSource = bus.LayDanhSach();
                dgvPhuTung.Columns["MaPhuTung"].HeaderText = "Mã";
                dgvPhuTung.Columns["MaPhuTung"].FillWeight = 40;
                dgvPhuTung.Columns["TenPhuTung"].HeaderText = "Tên phụ tùng";
                dgvPhuTung.Columns["TenPhuTung"].FillWeight = 200;
                dgvPhuTung.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvPhuTung.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvPhuTung.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
                dgvPhuTung.Columns["HienThi"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô đỏ phụ tùng sắp hết (tồn dưới 5)
        private void dgvPhuTung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PhuTungDTO pt = dgvPhuTung.Rows[e.RowIndex].DataBoundItem as PhuTungDTO;
            if (pt != null && pt.SoLuongTon < 5) e.CellStyle.ForeColor = Color.Red;
        }

        private void dgvPhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PhuTungDTO pt = (PhuTungDTO)bindingSource1[e.RowIndex];
            maChon = pt.MaPhuTung;
            txtTenPhuTung.Text = pt.TenPhuTung;
            txtDonGia.Text = pt.DonGia.ToString("0");
            txtSoLuongTon.Text = pt.SoLuongTon.ToString();
            errorProvider1.Clear();
        }

        // Đơn giá cho phép gõ "850.000" hoặc "850,000"
        private PhuTungDTO DocForm()
        {
            decimal gia = 0;
            string s = txtDonGia.Text.Replace(",", "").Replace(".", "").Trim();
            if (s != "" && !decimal.TryParse(s, out gia)) throw new LoiNhapLieu("DonGia", "Đơn giá phải là số!");
            int ton;
            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out ton)) throw new LoiNhapLieu("SoLuongTon", "Số lượng tồn phải là số nguyên!");
            return new PhuTungDTO { MaPhuTung = maChon, TenPhuTung = txtTenPhuTung.Text, DonGia = gia, SoLuongTon = ton };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Them(DocForm()), "Thêm phụ tùng thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Sua(DocForm()), "Cập nhật đơn giá / tồn kho thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maChon > 0 && MessageBox.Show("Xóa phụ tùng \"" + txtTenPhuTung.Text + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            XuLy(() => bus.Xoa(maChon), "Xóa phụ tùng thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maChon = -1;
            txtTenPhuTung.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Text = "0";
            errorProvider1.Clear();
            txtTenPhuTung.Focus();
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
                Control o = ex.TenTruong == "TenPhuTung" ? txtTenPhuTung : ex.TenTruong == "DonGia" ? txtDonGia : txtSoLuongTon;
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
