using System;
using System.Windows.Forms;
using BT6._3.BUS;
using BT6._3.DTO;

namespace BT6._3.GUI
{
    public partial class frmDuAn : Form
    {
        private readonly DuAnBUS bus = new DuAnBUS();
        private int maDuAnChon = -1;

        public frmDuAn()
        {
            InitializeComponent();
        }

        private void frmDuAn_Load(object sender, EventArgs e)
        {
            LamMoi();
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            try
            {
                bindingSource1.DataSource = bus.LayDanhSach();
                dgvDuAn.Columns["MaDuAn"].HeaderText = "Mã";
                dgvDuAn.Columns["MaDuAn"].FillWeight = 40;
                dgvDuAn.Columns["TenDuAn"].HeaderText = "Tên dự án";
                dgvDuAn.Columns["TenDuAn"].FillWeight = 200;
                dgvDuAn.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
                dgvDuAn.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDuAn.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
                dgvDuAn.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDuAn.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DuAnDTO da = (DuAnDTO)bindingSource1[e.RowIndex];
            maDuAnChon = da.MaDuAn;
            txtTenDuAn.Text = da.TenDuAn;
            dtpNgayBatDau.Value = da.NgayBatDau ?? DateTime.Today;
            dtpNgayKetThuc.Value = da.NgayKetThuc ?? DateTime.Today;
            cboTrangThai.Text = da.TrangThai;
            errorProvider1.Clear();
        }

        private DuAnDTO DocForm()
        {
            return new DuAnDTO
            {
                MaDuAn = maDuAnChon,
                TenDuAn = txtTenDuAn.Text,
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayKetThuc = dtpNgayKetThuc.Value.Date,
                TrangThai = cboTrangThai.SelectedIndex < 0 ? "" : cboTrangThai.Text
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Them(DocForm()), "Thêm dự án thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy(() => bus.Sua(DocForm()), "Cập nhật dự án thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDuAnChon > 0 && MessageBox.Show("Xóa dự án \"" + txtTenDuAn.Text + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            XuLy(() => bus.Xoa(maDuAnChon), "Xóa dự án thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maDuAnChon = -1;
            txtTenDuAn.Clear();
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddMonths(1);
            cboTrangThai.SelectedIndex = 0;
            errorProvider1.Clear();
            txtTenDuAn.Focus();
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
                Control o = ex.TenTruong == "TenDuAn" ? txtTenDuAn
                          : ex.TenTruong == "NgayKetThuc" ? (Control)dtpNgayKetThuc
                          : cboTrangThai;
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
