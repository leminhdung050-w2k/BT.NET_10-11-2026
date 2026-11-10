namespace BT6._3.GUI
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
            this.btnDuAn = new System.Windows.Forms.Button();
            this.btnCongViec = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ CÔNG VIỆC && DỰ ÁN";
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lblTieuDe.Size = new System.Drawing.Size(440, 40);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDuAn
            // 
            this.btnDuAn.Location = new System.Drawing.Point(70, 80);
            this.btnDuAn.Name = "btnDuAn";
            this.btnDuAn.Size = new System.Drawing.Size(300, 45);
            this.btnDuAn.TabIndex = 1;
            this.btnDuAn.Text = "Quản lý dự án";
            this.btnDuAn.UseVisualStyleBackColor = true;
            this.btnDuAn.Click += new System.EventHandler(this.btnDuAn_Click);
            this.btnDuAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnCongViec
            // 
            this.btnCongViec.Location = new System.Drawing.Point(70, 138);
            this.btnCongViec.Name = "btnCongViec";
            this.btnCongViec.Size = new System.Drawing.Size(300, 45);
            this.btnCongViec.TabIndex = 2;
            this.btnCongViec.Text = "Công việc (Kanban / List)";
            this.btnCongViec.UseVisualStyleBackColor = true;
            this.btnCongViec.Click += new System.EventHandler(this.btnCongViec_Click);
            this.btnCongViec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(70, 196);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(300, 45);
            this.btnBaoCao.TabIndex = 3;
            this.btnBaoCao.Text = "Báo cáo - Cảnh báo trễ hạn";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(70, 254);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(300, 45);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Location = new System.Drawing.Point(0, 315);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.TabIndex = 5;
            this.lblCanhBao.Text = "";
            this.lblCanhBao.AutoSize = false;
            this.lblCanhBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanhBao.Size = new System.Drawing.Size(440, 25);
            this.lblCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 355);
            this.Controls.Add(this.lblCanhBao);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.btnCongViec);
            this.Controls.Add(this.btnDuAn);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý công việc & tiến độ dự án";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDuAn;
        private System.Windows.Forms.Button btnCongViec;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblCanhBao;
    }
}
