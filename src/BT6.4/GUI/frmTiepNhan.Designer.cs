namespace BT6._4.GUI
{
    partial class frmTiepNhan
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
            this.grpTraCuu = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHieuXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvXe = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpTraCuu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTraCuu
            // 
            this.grpTraCuu.Controls.Add(this.label1);
            this.grpTraCuu.Controls.Add(this.txtBienSo);
            this.grpTraCuu.Controls.Add(this.btnTraCuu);
            this.grpTraCuu.Controls.Add(this.lblKetQua);
            this.grpTraCuu.Controls.Add(this.label2);
            this.grpTraCuu.Controls.Add(this.txtHieuXe);
            this.grpTraCuu.Controls.Add(this.label3);
            this.grpTraCuu.Controls.Add(this.txtNamSX);
            this.grpTraCuu.Controls.Add(this.label4);
            this.grpTraCuu.Controls.Add(this.txtTenKH);
            this.grpTraCuu.Controls.Add(this.label5);
            this.grpTraCuu.Controls.Add(this.txtDienThoai);
            this.grpTraCuu.Controls.Add(this.label6);
            this.grpTraCuu.Controls.Add(this.txtDiaChi);
            this.grpTraCuu.Controls.Add(this.btnLuu);
            this.grpTraCuu.Controls.Add(this.btnSua);
            this.grpTraCuu.Controls.Add(this.btnXoa);
            this.grpTraCuu.Controls.Add(this.btnLamMoi);
            this.grpTraCuu.Location = new System.Drawing.Point(12, 12);
            this.grpTraCuu.Name = "grpTraCuu";
            this.grpTraCuu.Size = new System.Drawing.Size(896, 190);
            this.grpTraCuu.TabIndex = 0;
            this.grpTraCuu.TabStop = false;
            this.grpTraCuu.Text = "Tra cứu biển số && tiếp nhận xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            this.label1.Text = "Biển số xe";
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(120, 29);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(150, 22);
            this.txtBienSo.TabIndex = 2;
            this.txtBienSo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBienSo.MaxLength = 20;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(290, 24);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(100, 32);
            this.btnTraCuu.TabIndex = 3;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(405, 32);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "";
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.TabIndex = 5;
            this.label2.Text = "Hiệu xe";
            // 
            // txtHieuXe
            // 
            this.txtHieuXe.Location = new System.Drawing.Point(120, 69);
            this.txtHieuXe.Name = "txtHieuXe";
            this.txtHieuXe.Size = new System.Drawing.Size(150, 22);
            this.txtHieuXe.TabIndex = 6;
            this.txtHieuXe.MaxLength = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 72);
            this.label3.Name = "label3";
            this.label3.TabIndex = 7;
            this.label3.Text = "Năm sản xuất";
            // 
            // txtNamSX
            // 
            this.txtNamSX.Location = new System.Drawing.Point(390, 69);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(80, 22);
            this.txtNamSX.TabIndex = 8;
            this.txtNamSX.MaxLength = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 110);
            this.label4.Name = "label4";
            this.label4.TabIndex = 9;
            this.label4.Text = "Chủ xe";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(120, 107);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(250, 22);
            this.txtTenKH.TabIndex = 10;
            this.txtTenKH.MaxLength = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 110);
            this.label5.Name = "label5";
            this.label5.TabIndex = 11;
            this.label5.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(470, 107);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(130, 22);
            this.txtDienThoai.TabIndex = 12;
            this.txtDienThoai.MaxLength = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 110);
            this.label6.Name = "label6";
            this.label6.TabIndex = 13;
            this.label6.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(680, 107);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(195, 22);
            this.txtDiaChi.TabIndex = 14;
            this.txtDiaChi.MaxLength = 200;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(120, 145);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 34);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu xe mới";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(250, 145);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 34);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(360, 145);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa xe";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(470, 145);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 34);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvXe
            // 
            this.dgvXe.AllowUserToAddRows = false;
            this.dgvXe.AllowUserToDeleteRows = false;
            this.dgvXe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXe.BackgroundColor = System.Drawing.Color.White;
            this.dgvXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXe.Location = new System.Drawing.Point(12, 215);
            this.dgvXe.MultiSelect = false;
            this.dgvXe.Name = "dgvXe";
            this.dgvXe.ReadOnly = true;
            this.dgvXe.RowHeadersVisible = false;
            this.dgvXe.RowHeadersWidth = 51;
            this.dgvXe.RowTemplate.Height = 24;
            this.dgvXe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXe.Size = new System.Drawing.Size(896, 330);
            this.dgvXe.TabIndex = 19;
            this.dgvXe.DataSource = this.bindingSource1;
            this.dgvXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXe_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTiepNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.dgvXe);
            this.Controls.Add(this.grpTraCuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiepNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiếp nhận xe & Quản lý chủ xe";
            this.Load += new System.EventHandler(this.frmTiepNhan_Load);
            this.grpTraCuu.ResumeLayout(false);
            this.grpTraCuu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTraCuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHieuXe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamSX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvXe;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
