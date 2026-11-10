using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BT6._3.BUS;
using BT6._3.DTO;

namespace BT6._3.GUI
{
    public partial class frmCongViec : Form
    {
        private readonly CongViecBUS bus = new CongViecBUS();
        private readonly DuAnBUS duAnBUS = new DuAnBUS();
        private readonly ThanhVienBUS thanhVienBUS = new ThanhVienBUS();

        private List<CongViecDTO> dsTask = new List<CongViecDTO>();
        private CongViecDTO taskChon;          // task đang chọn
        private bool dangNap;                   // chặn sự kiện khi đang nạp dữ liệu
        private ListBox[] cotKanban;
        private GroupBox[] khungKanban;

        public frmCongViec()
        {
            InitializeComponent();
        }

        private void frmCongViec_Load(object sender, EventArgs e)
        {
            cotKanban = new[] { lstToDo, lstInProgress, lstReview, lstDone };
            khungKanban = new[] { grpToDo, grpInProgress, grpReview, grpDone };
            foreach (ListBox l in cotKanban) l.DisplayMember = "HienThi";

            cboLocTrangThai.Items.Add("Tất cả");
            cboLocTrangThai.Items.AddRange(CongViecBUS.TRANG_THAI);
            cboTrangThai.Items.AddRange(CongViecBUS.TRANG_THAI);
            cboLocTrangThai.SelectedIndex = 0;

            try
            {
                clbThanhVien.DisplayMember = "HienThi";
                foreach (ThanhVienDTO tv in thanhVienBUS.LayDanhSach()) clbThanhVien.Items.Add(tv);

                dangNap = true;
                cboDuAn.DisplayMember = "TenDuAn";
                cboDuAn.ValueMember = "MaDuAn";
                cboDuAn.DataSource = duAnBUS.LayDanhSach();
                dangNap = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamMoi();
            TaiTask(0);
        }

        //DANH SÁCH TASK
        // Lọc theo dự án và trạng thái, đổ lên bảng Kanban và lưới danh sách
        private void TaiTask(int chonMaTask)
        {
            if (!(cboDuAn.SelectedValue is int)) return;
            try
            {
                string loc = cboLocTrangThai.SelectedIndex > 0 ? cboLocTrangThai.Text : null;
                dsTask = bus.LayDanhSach((int)cboDuAn.SelectedValue, loc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dangNap = true;
            for (int i = 0; i < cotKanban.Length; i++)
            {
                List<CongViecDTO> cot = dsTask.Where(x => x.TrangThai == CongViecBUS.TRANG_THAI[i]).ToList();
                cotKanban[i].DataSource = cot;
                cotKanban[i].ClearSelected();
                khungKanban[i].Text = CongViecBUS.TRANG_THAI[i].ToUpper() + " (" + cot.Count + ")";
            }

            bindingSource1.DataSource = dsTask;
            dgvTask.Columns["MaTask"].HeaderText = "Mã";
            dgvTask.Columns["MaTask"].FillWeight = 35;
            dgvTask.Columns["TenTask"].HeaderText = "Tên công việc";
            dgvTask.Columns["TenTask"].FillWeight = 180;
            dgvTask.Columns["HanNop"].HeaderText = "Hạn nộp";
            dgvTask.Columns["HanNop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTask.Columns["DoUuTien"].HeaderText = "Ưu tiên";
            dgvTask.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvTask.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
            dgvTask.Columns["NguoiThucHien"].FillWeight = 150;
            foreach (string c in new[] { "MaDuAn", "TenDuAn", "MoTa", "TreHan", "HienThi" }) dgvTask.Columns[c].Visible = false;
            dgvTask.ClearSelection();
            dangNap = false;

            int treHan = dsTask.Count(x => x.TreHan);
            lblTreHan.Text = treHan > 0 ? "Có " + treHan + " công việc trễ hạn!" : "";

            CongViecDTO chon = dsTask.FirstOrDefault(x => x.MaTask == chonMaTask);
            if (chon != null) ChonTask(chon); else LamMoi();
        }

        private void cboDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap) TaiTask(0);
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap && cotKanban != null) TaiTask(0);
        }

        // Đổi giữa giao diện Kanban và List view
        private void rdoKanban_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GroupBox g in khungKanban ?? new GroupBox[0]) g.Visible = rdoKanban.Checked;
            dgvTask.Visible = !rdoKanban.Checked;
        }

        private void lstKanban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNap) return;
            ListBox l = (ListBox)sender;
            if (l.SelectedItem is CongViecDTO) ChonTask((CongViecDTO)l.SelectedItem);
        }

        private void dgvTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ChonTask((CongViecDTO)bindingSource1[e.RowIndex]);
        }

        // Tô đỏ task trễ hạn trên lưới
        private void dgvTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CongViecDTO cv = dgvTask.Rows[e.RowIndex].DataBoundItem as CongViecDTO;
            if (cv != null && cv.TreHan) e.CellStyle.ForeColor = Color.Red;
        }

        //CHI TIẾT TASK
        private void ChonTask(CongViecDTO cv)
        {
            taskChon = cv;
            dangNap = true;
            foreach (ListBox l in cotKanban) if (!l.Items.Contains(cv)) l.ClearSelected();
            dangNap = false;

            txtTenTask.Text = cv.TenTask;
            txtMoTa.Text = cv.MoTa;
            dtpHanNop.Value = cv.HanNop ?? DateTime.Today;
            cboDoUuTien.Text = cv.DoUuTien;
            cboTrangThai.Text = cv.TrangThai;
            lblChon.Text = "Đang chọn: #" + cv.MaTask + " " + cv.TenTask + "  [" + cv.TrangThai + "]";
            lblChon.ForeColor = cv.TreHan ? Color.Red : Color.Navy;

            List<int> giao = bus.LayPhanCong(cv.MaTask);
            for (int i = 0; i < clbThanhVien.Items.Count; i++)
                clbThanhVien.SetItemChecked(i, giao.Contains(((ThanhVienDTO)clbThanhVien.Items[i]).MaThanhVien));
            errorProvider1.Clear();
        }

        private CongViecDTO DocForm()
        {
            return new CongViecDTO
            {
                MaTask = taskChon == null ? 0 : taskChon.MaTask,
                MaDuAn = cboDuAn.SelectedValue is int ? (int)cboDuAn.SelectedValue : 0,
                TenTask = txtTenTask.Text,
                MoTa = txtMoTa.Text.Trim(),
                HanNop = dtpHanNop.Value.Date,
                DoUuTien = cboDoUuTien.SelectedIndex < 0 ? "" : cboDoUuTien.Text,
                TrangThai = cboTrangThai.SelectedIndex < 0 ? "" : cboTrangThai.Text
            };
        }

        private void LamMoi()
        {
            taskChon = null;
            txtTenTask.Clear();
            txtMoTa.Clear();
            dtpHanNop.Value = DateTime.Today.AddDays(7);
            cboDoUuTien.SelectedIndex = 1;      // Trung bình
            cboTrangThai.SelectedIndex = 0;     // To Do
            for (int i = 0; i < clbThanhVien.Items.Count; i++) clbThanhVien.SetItemChecked(i, false);
            lblChon.Text = "Chưa chọn công việc";
            lblChon.ForeColor = Color.Navy;
            errorProvider1.Clear();
            dangNap = true;
            foreach (ListBox l in cotKanban ?? new ListBox[0]) l.ClearSelected();
            dangNap = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            txtTenTask.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy(() =>
            {
                CongViecDTO cv = DocForm();
                int ma = bus.Them(cv);
                List<int> chon = ThanhVienDuocChon();
                if (chon.Count > 0) bus.LuuPhanCong(ma, chon);   // giao việc luôn nếu đã tick thành viên
                return ma;
            }, "Thêm công việc thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy(() => { CongViecDTO cv = DocForm(); bus.Sua(cv); return cv.MaTask; }, "Cập nhật công việc thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (taskChon != null && MessageBox.Show("Xóa công việc \"" + taskChon.TenTask + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            XuLy(() => { bus.Xoa(taskChon == null ? 0 : taskChon.MaTask); return 0; }, "Xóa công việc thành công!");
        }

        // Chuyển trạng thái task (Parameterized SQL UPDATE)
        private void btnTien_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(+1);
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(-1);
        }

        private void ChuyenTrangThai(int buoc)
        {
            try
            {
                string cu = taskChon == null ? "" : taskChon.TrangThai;
                string moi = bus.ChuyenTrangThai(taskChon, buoc);
                int ma = taskChon.MaTask;
                TaiTask(ma);
                lblChon.Text = "Đã chuyển #" + ma + " từ \"" + cu + "\" sang \"" + moi + "\"";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Giao việc cho một hoặc nhiều thành viên
        private void btnLuuPhanCong_Click(object sender, EventArgs e)
        {
            XuLy(() => { bus.LuuPhanCong(taskChon == null ? 0 : taskChon.MaTask, ThanhVienDuocChon()); return taskChon.MaTask; },
                 "Đã giao việc cho " + clbThanhVien.CheckedItems.Count + " thành viên!");
        }

        private List<int> ThanhVienDuocChon()
        {
            return clbThanhVien.CheckedItems.Cast<ThanhVienDTO>().Select(x => x.MaThanhVien).ToList();
        }

        private void XuLy(Func<int> thaoTac, string thongBao)
        {
            errorProvider1.Clear();
            try
            {
                int ma = thaoTac();
                TaiTask(ma);
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (LoiNhapLieu ex)
            {
                Control o = ex.TenTruong == "TenTask" ? txtTenTask
                          : ex.TenTruong == "DoUuTien" ? cboDoUuTien
                          : ex.TenTruong == "TrangThai" ? (Control)cboTrangThai
                          : cboDuAn;
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
