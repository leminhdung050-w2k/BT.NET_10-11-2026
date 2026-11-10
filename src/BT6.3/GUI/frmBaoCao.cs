using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BT6._3.BUS;
using BT6._3.DTO;

namespace BT6._3.GUI
{
    public partial class frmBaoCao : Form
    {
        private readonly BaoCaoBUS bus = new BaoCaoBUS();
        private readonly DuAnBUS duAnBUS = new DuAnBUS();

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                List<DuAnDTO> ds = new List<DuAnDTO> { new DuAnDTO { MaDuAn = 0, TenDuAn = "Tất cả dự án" } };
                ds.AddRange(duAnBUS.LayDanhSach());
                cboDuAn.DisplayMember = "TenDuAn";
                cboDuAn.ValueMember = "MaDuAn";
                cboDuAn.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void XemBaoCao()
        {
            if (!(cboDuAn.SelectedValue is int)) return;
            int maDuAn = (int)cboDuAn.SelectedValue;
            try
            {
                // SqlDataReader: công việc quá hạn mà chưa Done
                List<CongViecDTO> treHan = bus.TaskTreHan(maDuAn);
                bindingSource1.DataSource = treHan;
                dgvTreHan.Columns["MaTask"].HeaderText = "Mã";
                dgvTreHan.Columns["MaTask"].FillWeight = 35;
                dgvTreHan.Columns["TenDuAn"].HeaderText = "Dự án";
                dgvTreHan.Columns["TenTask"].HeaderText = "Công việc";
                dgvTreHan.Columns["TenTask"].FillWeight = 160;
                dgvTreHan.Columns["HanNop"].HeaderText = "Hạn nộp";
                dgvTreHan.Columns["HanNop"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvTreHan.Columns["HanNop"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                dgvTreHan.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvTreHan.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
                foreach (string c in new[] { "MaDuAn", "MoTa", "DoUuTien", "TreHan", "HienThi" }) dgvTreHan.Columns[c].Visible = false;
                grpTreHan.Text = "Cảnh báo: " + treHan.Count + " công việc trễ hạn (quá hạn nộp mà chưa Done)";

                // GROUP BY: tỷ lệ hoàn thành của từng thành viên
                bindingSource2.DataSource = bus.ThongKeThanhVien(maDuAn);
                dgvThongKe.Columns["HoTen"].HeaderText = "Thành viên";
                dgvThongKe.Columns["HoTen"].FillWeight = 160;
                dgvThongKe.Columns["TongTask"].HeaderText = "Số task được giao";
                dgvThongKe.Columns["SoTaskDone"].HeaderText = "Số task Done";
                dgvThongKe.Columns["TyLeHoanThanh"].HeaderText = "% hoàn thành";

                // ExecuteScalar: tiến độ chung
                lblTienDo.Text = "Tiến độ: " + bus.TyLeHoanThanhDuAn(maDuAn).ToString("0.#") + "% công việc đã Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
