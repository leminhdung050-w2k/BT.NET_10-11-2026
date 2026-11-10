namespace BT6._5.GUI
{
    partial class frmMain
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
            this.grpPhong = new System.Windows.Forms.GroupBox();
            this.flpPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.btnMoPhong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblTienDV = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnQuanLyDV = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpPhong.SuspendLayout();
            this.grpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPhong
            // 
            this.grpPhong.Controls.Add(this.flpPhong);
            this.grpPhong.Controls.Add(this.lblChuThich);
            this.grpPhong.Location = new System.Drawing.Point(12, 12);
            this.grpPhong.Name = "grpPhong";
            this.grpPhong.Size = new System.Drawing.Size(520, 625);
            this.grpPhong.TabIndex = 0;
            this.grpPhong.TabStop = false;
            this.grpPhong.Text = "Sơ đồ phòng hát";
            // 
            // flpPhong
            // 
            this.flpPhong.AutoScroll = true;
            this.flpPhong.Location = new System.Drawing.Point(6, 22);
            this.flpPhong.Name = "flpPhong";
            this.flpPhong.Size = new System.Drawing.Size(508, 560);
            this.flpPhong.TabIndex = 1;
            // 
            // lblChuThich
            // 
            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Location = new System.Drawing.Point(100, 595);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.TabIndex = 2;
            this.lblChuThich.Text = "Màu xanh: phòng Trống          Màu đỏ: phòng Đang hát";
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Controls.Add(this.lblPhong);
            this.grpHoaDon.Controls.Add(this.lblGioVao);
            this.grpHoaDon.Controls.Add(this.lblThoiGian);
            this.grpHoaDon.Controls.Add(this.btnMoPhong);
            this.grpHoaDon.Controls.Add(this.label1);
            this.grpHoaDon.Controls.Add(this.cboDichVu);
            this.grpHoaDon.Controls.Add(this.label2);
            this.grpHoaDon.Controls.Add(this.numSoLuong);
            this.grpHoaDon.Controls.Add(this.btnThemDV);
            this.grpHoaDon.Controls.Add(this.dgvDichVu);
            this.grpHoaDon.Controls.Add(this.lblTienPhong);
            this.grpHoaDon.Controls.Add(this.lblTienDV);
            this.grpHoaDon.Controls.Add(this.lblTong);
            this.grpHoaDon.Controls.Add(this.btnThanhToan);
            this.grpHoaDon.Controls.Add(this.btnQuanLyDV);
            this.grpHoaDon.Location = new System.Drawing.Point(545, 12);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new System.Drawing.Size(593, 625);
            this.grpHoaDon.TabIndex = 3;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "Thông tin phòng && hóa đơn";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(15, 30);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.TabIndex = 4;
            this.lblPhong.Text = "Chọn 1 phòng trên sơ đồ";
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblGioVao
            // 
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Location = new System.Drawing.Point(15, 62);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.TabIndex = 5;
            this.lblGioVao.Text = "";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(15, 87);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.TabIndex = 6;
            this.lblThoiGian.Text = "";
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMoPhong
            // 
            this.btnMoPhong.Location = new System.Drawing.Point(440, 25);
            this.btnMoPhong.Name = "btnMoPhong";
            this.btnMoPhong.Size = new System.Drawing.Size(135, 45);
            this.btnMoPhong.TabIndex = 7;
            this.btnMoPhong.Text = "Mở phòng";
            this.btnMoPhong.UseVisualStyleBackColor = true;
            this.btnMoPhong.Click += new System.EventHandler(this.btnMoPhong_Click);
            this.btnMoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 125);
            this.label1.Name = "label1";
            this.label1.TabIndex = 8;
            this.label1.Text = "Dịch vụ";
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(75, 121);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(300, 24);
            this.cboDichVu.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 125);
            this.label2.Name = "label2";
            this.label2.TabIndex = 10;
            this.label2.Text = "SL";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(415, 122);
            this.numSoLuong.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(55, 22);
            this.numSoLuong.TabIndex = 11;
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
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(485, 116);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(90, 32);
            this.btnThemDV.TabIndex = 12;
            this.btnThemDV.Text = "Gọi thêm";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Location = new System.Drawing.Point(15, 160);
            this.dgvDichVu.MultiSelect = false;
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.RowHeadersWidth = 51;
            this.dgvDichVu.RowTemplate.Height = 24;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(560, 290);
            this.dgvDichVu.TabIndex = 13;
            this.dgvDichVu.DataSource = this.bindingSource1;
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Location = new System.Drawing.Point(15, 465);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.TabIndex = 14;
            this.lblTienPhong.Text = "Tiền phòng: 0 đ";
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Location = new System.Drawing.Point(15, 492);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.TabIndex = 15;
            this.lblTienDV.Text = "Tiền dịch vụ: 0 đ";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(15, 525);
            this.lblTong.Name = "lblTong";
            this.lblTong.TabIndex = 16;
            this.lblTong.Text = "Tạm tính: 0 đ";
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.ForeColor = System.Drawing.Color.Red;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(425, 515);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(150, 50);
            this.btnThanhToan.TabIndex = 17;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnQuanLyDV
            // 
            this.btnQuanLyDV.Location = new System.Drawing.Point(15, 580);
            this.btnQuanLyDV.Name = "btnQuanLyDV";
            this.btnQuanLyDV.Size = new System.Drawing.Size(160, 32);
            this.btnQuanLyDV.TabIndex = 18;
            this.btnQuanLyDV.Text = "Quản lý dịch vụ";
            this.btnQuanLyDV.UseVisualStyleBackColor = true;
            this.btnQuanLyDV.Click += new System.EventHandler(this.btnQuanLyDV_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.grpPhong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng hát Karaoke";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPhong.ResumeLayout(false);
            this.grpPhong.PerformLayout();
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhong;
        private System.Windows.Forms.FlowLayoutPanel flpPhong;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Button btnMoPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTienDV;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnQuanLyDV;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Timer timer1;
    }
}
