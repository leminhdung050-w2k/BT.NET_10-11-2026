using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BT6._5.BUS;
using BT6._5.DTO;

namespace BT6._5.GUI
{
    public partial class frmMain : Form
    {
        private readonly PhongHatBUS phongBUS = new PhongHatBUS();
        private readonly DichVuBUS dichVuBUS = new DichVuBUS();
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();

        private PhongHatDTO phongChon;      // phòng đang chọn trên sơ đồ
        private HoaDonDTO hoaDon;           // hóa đơn đang mở của phòng
        private DataTable dtDichVu;         // dịch vụ đã gọi (ngắt kết nối)

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDichVu();
                TaiSoDoPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HienPhong();
            timer1.Start();
        }

        private void TaiDichVu()
        {
            object chon = cboDichVu.SelectedValue;
            cboDichVu.DisplayMember = "HienThi";
            cboDichVu.ValueMember = "MaDV";
            cboDichVu.DataSource = dichVuBUS.LayDanhSach();
            if (chon != null) cboDichVu.SelectedValue = chon;
        }

        //SƠ ĐỒ PHÒNG
        private void TaiSoDoPhong()
        {
            List<PhongHatDTO> ds = phongBUS.LayDanhSach();
            while (flpPhong.Controls.Count > 0) flpPhong.Controls[0].Dispose();
            foreach (PhongHatDTO p in ds)
            {
                Button btn = new Button();
                btn.Size = new Size(118, 80);
                btn.Text = p.TenPhong + "\n" + p.GiaTheoGio.ToString("N0") + " đ/giờ\n" + p.TrangThai;
                btn.Tag = p;
                btn.Font = new Font(Font, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = p.TrangThai == "Trống" ? Color.LightGreen : Color.Tomato;   // xanh: trống, đỏ: đang hát
                if (phongChon != null && p.MaPhong == phongChon.MaPhong)
                {
                    btn.FlatAppearance.BorderSize = 4;
                    btn.FlatAppearance.BorderColor = Color.Blue;
                    phongChon = p;
                }
                btn.Click += btnPhong_Click;
                flpPhong.Controls.Add(btn);
            }
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            phongChon = (PhongHatDTO)((Button)sender).Tag;
            TaiSoDoPhong();
            HienPhong();
        }

        //THÔNG TIN PHÒNG
        private void HienPhong()
        {
            hoaDon = null;
            dtDichVu = null;
            if (phongChon != null && phongChon.TrangThai == "Đang hát")
            {
                try
                {
                    hoaDon = hoaDonBUS.LayHoaDonDangMo(phongChon.MaPhong);
                    if (hoaDon != null) dtDichVu = hoaDonBUS.LayDichVuDaGoi(hoaDon.MaHD);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            lblPhong.Text = phongChon == null ? "Chọn 1 phòng trên sơ đồ"
                          : phongChon.TenPhong + " (" + phongChon.LoaiPhong + ") - " + phongChon.TrangThai;
            lblGioVao.Text = hoaDon == null ? "" : "Giờ vào: " + hoaDon.GioVao.ToString("HH:mm dd/MM/yyyy") + "   (Mã HĐ: " + hoaDon.MaHD + ")";
            btnMoPhong.Enabled = phongChon != null && phongChon.TrangThai == "Trống";
            btnThemDV.Enabled = btnThanhToan.Enabled = hoaDon != null;

            bindingSource1.DataSource = dtDichVu;
            if (dtDichVu != null)
            {
                dgvDichVu.Columns["MaHD"].Visible = false;
                dgvDichVu.Columns["MaDV"].Visible = false;
                dgvDichVu.Columns["TenDV"].HeaderText = "Dịch vụ";
                dgvDichVu.Columns["TenDV"].DisplayIndex = 0;
                dgvDichVu.Columns["TenDV"].FillWeight = 200;
                dgvDichVu.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvDichVu.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvDichVu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            CapNhatTien();
        }

        // Tính giờ tự động: thời gian hát và tiền tạm tính
        private void CapNhatTien()
        {
            if (hoaDon == null)
            {
                lblThoiGian.Text = "";
                lblTienPhong.Text = "Tiền phòng: 0 đ";
                lblTienDV.Text = "Tiền dịch vụ: 0 đ";
                lblTong.Text = "Tạm tính: 0 đ";
                return;
            }
            DateTime bayGio = DateTime.Now;
            double soGio = HoaDonBUS.TinhSoGio(hoaDon.GioVao, bayGio);
            decimal tienPhong = HoaDonBUS.TinhTienPhong(hoaDon.GiaTheoGio, soGio);
            decimal tienDV = dtDichVu == null ? 0 : HoaDonBUS.TinhTienDichVu(dtDichVu);
            lblThoiGian.Text = "Thời gian hát: " + HoaDonBUS.ThoiGianHat(hoaDon.GioVao, bayGio);
            lblTienPhong.Text = "Tiền phòng: " + soGio.ToString("0.00") + " giờ x " + hoaDon.GiaTheoGio.ToString("N0") + " = " + tienPhong.ToString("N0") + " đ";
            lblTienDV.Text = "Tiền dịch vụ: " + tienDV.ToString("N0") + " đ";
            lblTong.Text = "Tạm tính: " + (tienPhong + tienDV).ToString("N0") + " đ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CapNhatTien();
        }

        // Mở phòng: tạo HoaDon (GioVao = GETDATE()), phòng chuyển "Đang hát"
        private void btnMoPhong_Click(object sender, EventArgs e)
        {
            try
            {
                hoaDonBUS.MoPhong(phongChon);
                TaiSoDoPhong();
                HienPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gọi thêm dịch vụ / đồ uống
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            try
            {
                hoaDonBUS.ThemDichVu(dtDichVu, hoaDon, cboDichVu.SelectedItem as DichVuDTO, (int)numSoLuong.Value);
                numSoLuong.Value = 1;
                CapNhatTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienPhong();
            }
        }

        // Thanh toán: SqlTransaction cập nhật hóa đơn, trừ tồn kho, trả phòng
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (hoaDon == null) return;
            if (MessageBox.Show("Thanh toán " + phongChon.TenPhong + "?\n" + lblTong.Text, "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                HoaDonDTO hd = hoaDonBUS.ThanhToan(hoaDon);
                string hoaDonText =
                    phongChon.TenPhong + "  -  Mã HĐ: " + hd.MaHD + "\n" +
                    "Giờ vào: " + hd.GioVao.ToString("HH:mm dd/MM") + "   Giờ ra: " + hd.GioRa.Value.ToString("HH:mm dd/MM") + "\n" +
                    "Thời gian hát: " + HoaDonBUS.ThoiGianHat(hd.GioVao, hd.GioRa.Value) + " (" + hd.SoGio.ToString("0.00") + " giờ)\n\n" +
                    "Tiền phòng: " + hd.SoGio.ToString("0.00") + " x " + hd.GiaTheoGio.ToString("N0") + " = " + hd.TongTienPhong.ToString("N0") + " đ\n" +
                    "Tiền dịch vụ: " + hd.TongTienDichVu.ToString("N0") + " đ\n\n" +
                    "TỔNG THANH TOÁN: " + hd.TongCong.ToString("N0") + " đ";
                MessageBox.Show(hoaDonText, "Hóa đơn thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaiSoDoPhong();
            HienPhong();
            TaiDichVu();
        }

        private void btnQuanLyDV_Click(object sender, EventArgs e)
        {
            using (frmDichVu f = new frmDichVu()) f.ShowDialog();
            TaiDichVu();
            HienPhong();
        }
    }
}
