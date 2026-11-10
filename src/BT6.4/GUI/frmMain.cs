using System;
using System.Windows.Forms;

namespace BT6._4.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            using (frmTiepNhan f = new frmTiepNhan()) f.ShowDialog();
        }

        private void btnPhuTung_Click(object sender, EventArgs e)
        {
            using (frmPhuTung f = new frmPhuTung()) f.ShowDialog();
        }

        private void btnPhieuSuaChua_Click(object sender, EventArgs e)
        {
            using (frmPhieuSuaChua f = new frmPhieuSuaChua()) f.ShowDialog();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            using (frmThanhToan f = new frmThanhToan()) f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
