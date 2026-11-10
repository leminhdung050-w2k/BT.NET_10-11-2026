namespace BT6._4.GUI
{
    partial class frmPhieuSuaChua
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboXe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPhuTung = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.btnThemDong = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpPhieu.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.label1);
            this.grpPhieu.Controls.Add(this.cboXe);
            this.grpPhieu.Controls.Add(this.label2);
            this.grpPhieu.Controls.Add(this.txtNoiDung);
            this.grpPhieu.Location = new System.Drawing.Point(12, 12);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(876, 120);
            this.grpPhieu.TabIndex = 0;
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Thông tin phiếu sửa chữa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            this.label1.Text = "Xe (biển số)";
            // 
            // cboXe
            // 
            this.cboXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXe.FormattingEnabled = true;
            this.cboXe.Location = new System.Drawing.Point(110, 29);
            this.cboXe.Name = "cboXe";
            this.cboXe.Size = new System.Drawing.Size(350, 24);
            this.cboXe.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.TabIndex = 3;
            this.label2.Text = "Nội dung sửa";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(110, 67);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(745, 22);
            this.txtNoiDung.TabIndex = 4;
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Size = new System.Drawing.Size(745, 40);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.label3);
            this.grpChiTiet.Controls.Add(this.cboPhuTung);
            this.grpChiTiet.Controls.Add(this.label4);
            this.grpChiTiet.Controls.Add(this.numSoLuong);
            this.grpChiTiet.Controls.Add(this.label5);
            this.grpChiTiet.Controls.Add(this.txtTienCong);
            this.grpChiTiet.Controls.Add(this.btnThemDong);
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Location = new System.Drawing.Point(12, 140);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(876, 390);
            this.grpChiTiet.TabIndex = 5;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Phụ tùng thay thế && tiền công";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 35);
            this.label3.Name = "label3";
            this.label3.TabIndex = 6;
            this.label3.Text = "Phụ tùng";
            // 
            // cboPhuTung
            // 
            this.cboPhuTung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuTung.FormattingEnabled = true;
            this.cboPhuTung.Location = new System.Drawing.Point(85, 31);
            this.cboPhuTung.Name = "cboPhuTung";
            this.cboPhuTung.Size = new System.Drawing.Size(330, 24);
            this.cboPhuTung.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 35);
            this.label4.Name = "label4";
            this.label4.TabIndex = 8;
            this.label4.Text = "SL";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(455, 32);
            this.numSoLuong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(55, 22);
            this.numSoLuong.TabIndex = 9;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 35);
            this.label5.Name = "label5";
            this.label5.TabIndex = 10;
            this.label5.Text = "Tiền công";
            // 
            // txtTienCong
            // 
            this.txtTienCong.Location = new System.Drawing.Point(605, 32);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(115, 22);
            this.txtTienCong.TabIndex = 11;
            // 
            // btnThemDong
            // 
            this.btnThemDong.Location = new System.Drawing.Point(735, 27);
            this.btnThemDong.Name = "btnThemDong";
            this.btnThemDong.Size = new System.Drawing.Size(125, 34);
            this.btnThemDong.TabIndex = 12;
            this.btnThemDong.Text = "Thêm vào phiếu";
            this.btnThemDong.UseVisualStyleBackColor = true;
            this.btnThemDong.Click += new System.EventHandler(this.btnThemDong_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(15, 75);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(846, 300);
            this.dgvChiTiet.TabIndex = 13;
            this.dgvChiTiet.DataSource = this.bindingSource1;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(12, 552);
            this.lblTong.Name = "lblTong";
            this.lblTong.TabIndex = 14;
            this.lblTong.Text = "Tổng chi phí: 0 đ";
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.ForeColor = System.Drawing.Color.Red;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(430, 542);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(110, 45);
            this.btnXoaDong.TabIndex = 15;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(550, 542);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 45);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(670, 542);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(218, 45);
            this.btnXacNhan.TabIndex = 17;
            this.btnXacNhan.Text = "Xác nhận phiếu sửa chữa";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPhieuSuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoaDong);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpPhieu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuSuaChua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập phiếu sửa chữa & thay thế phụ tùng";
            this.Load += new System.EventHandler(this.frmPhieuSuaChua_Load);
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboXe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPhuTung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTienCong;
        private System.Windows.Forms.Button btnThemDong;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
