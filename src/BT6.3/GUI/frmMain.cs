using System;
using System.Windows.Forms;
using BT6._3.BUS;

namespace BT6._3.GUI
{
    public partial class frmMain : Form
    {
        private readonly BaoCaoBUS baoCaoBUS = new BaoCaoBUS();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CapNhatCanhBao();
        }

        // Cảnh báo số công việc trễ hạn (ExecuteScalar)
        private void CapNhatCanhBao()
        {
            try
            {
                int n = baoCaoBUS.DemTreHan();
                lblCanhBao.Text = n > 0 ? "Cảnh báo: có " + n + " công việc đã trễ hạn!" : "Không có công việc trễ hạn";
                lblCanhBao.ForeColor = n > 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblCanhBao.Text = "Không kết nối được CSDL: " + ex.Message;
            }
        }

        private void btnDuAn_Click(object sender, EventArgs e)
        {
            using (frmDuAn f = new frmDuAn()) f.ShowDialog();
            CapNhatCanhBao();
        }

        private void btnCongViec_Click(object sender, EventArgs e)
        {
            using (frmCongViec f = new frmCongViec()) f.ShowDialog();
            CapNhatCanhBao();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            using (frmBaoCao f = new frmBaoCao()) f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
