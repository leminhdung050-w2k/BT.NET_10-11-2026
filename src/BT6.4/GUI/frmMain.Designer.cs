namespace BT6._4.GUI
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

            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnTiepNhan = new System.Windows.Forms.Button();
            this.btnPhuTung = new System.Windows.Forms.Button();
            this.btnPhieuSuaChua = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "GARAGE Ô TÔ";
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lblTieuDe.Size = new System.Drawing.Size(440, 40);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTiepNhan
            // 
            this.btnTiepNhan.Location = new System.Drawing.Point(70, 80);
            this.btnTiepNhan.Name = "btnTiepNhan";
            this.btnTiepNhan.Size = new System.Drawing.Size(300, 45);
            this.btnTiepNhan.TabIndex = 1;
            this.btnTiepNhan.Text = "Tiếp nhận xe && chủ xe";
            this.btnTiepNhan.UseVisualStyleBackColor = true;
            this.btnTiepNhan.Click += new System.EventHandler(this.btnTiepNhan_Click);
            this.btnTiepNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPhuTung
            // 
            this.btnPhuTung.Location = new System.Drawing.Point(70, 138);
            this.btnPhuTung.Name = "btnPhuTung";
            this.btnPhuTung.Size = new System.Drawing.Size(300, 45);
            this.btnPhuTung.TabIndex = 2;
            this.btnPhuTung.Text = "Quản lý phụ tùng";
            this.btnPhuTung.UseVisualStyleBackColor = true;
            this.btnPhuTung.Click += new System.EventHandler(this.btnPhuTung_Click);
            this.btnPhuTung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPhieuSuaChua
            // 
            this.btnPhieuSuaChua.Location = new System.Drawing.Point(70, 196);
            this.btnPhieuSuaChua.Name = "btnPhieuSuaChua";
            this.btnPhieuSuaChua.Size = new System.Drawing.Size(300, 45);
            this.btnPhieuSuaChua.TabIndex = 3;
            this.btnPhieuSuaChua.Text = "Lập phiếu sửa chữa";
            this.btnPhieuSuaChua.UseVisualStyleBackColor = true;
            this.btnPhieuSuaChua.Click += new System.EventHandler(this.btnPhieuSuaChua_Click);
            this.btnPhieuSuaChua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(70, 254);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(300, 45);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh toán && hóa đơn";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(70, 312);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(300, 45);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 385);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnPhieuSuaChua);
            this.Controls.Add(this.btnPhuTung);
            this.Controls.Add(this.btnTiepNhan);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý garage & bảo dưỡng xe ô tô";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnTiepNhan;
        private System.Windows.Forms.Button btnPhuTung;
        private System.Windows.Forms.Button btnPhieuSuaChua;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThoat;
    }
}
