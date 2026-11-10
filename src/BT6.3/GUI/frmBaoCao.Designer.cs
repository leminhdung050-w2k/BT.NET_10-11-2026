namespace BT6._3.GUI
{
    partial class frmBaoCao
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboDuAn = new System.Windows.Forms.ComboBox();
            this.lblTienDo = new System.Windows.Forms.Label();
            this.grpTreHan = new System.Windows.Forms.GroupBox();
            this.dgvTreHan = new System.Windows.Forms.DataGridView();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.grpTreHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreHan)).BeginInit();
            this.grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = "Dự án";
            // 
            // cboDuAn
            // 
            this.cboDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuAn.FormattingEnabled = true;
            this.cboDuAn.Location = new System.Drawing.Point(65, 16);
            this.cboDuAn.Name = "cboDuAn";
            this.cboDuAn.Size = new System.Drawing.Size(300, 24);
            this.cboDuAn.TabIndex = 1;
            this.cboDuAn.SelectedIndexChanged += new System.EventHandler(this.cboDuAn_SelectedIndexChanged);
            // 
            // lblTienDo
            // 
            this.lblTienDo.AutoSize = true;
            this.lblTienDo.Location = new System.Drawing.Point(390, 20);
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.TabIndex = 2;
            this.lblTienDo.Text = "";
            this.lblTienDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDo.ForeColor = System.Drawing.Color.Navy;
            // 
            // grpTreHan
            // 
            this.grpTreHan.Controls.Add(this.dgvTreHan);
            this.grpTreHan.Location = new System.Drawing.Point(12, 55);
            this.grpTreHan.Name = "grpTreHan";
            this.grpTreHan.Size = new System.Drawing.Size(876, 250);
            this.grpTreHan.TabIndex = 3;
            this.grpTreHan.TabStop = false;
            this.grpTreHan.Text = "Công việc trễ hạn";
            // 
            // dgvTreHan
            // 
            this.dgvTreHan.AllowUserToAddRows = false;
            this.dgvTreHan.AllowUserToDeleteRows = false;
            this.dgvTreHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreHan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTreHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreHan.Location = new System.Drawing.Point(12, 22);
            this.dgvTreHan.MultiSelect = false;
            this.dgvTreHan.Name = "dgvTreHan";
            this.dgvTreHan.ReadOnly = true;
            this.dgvTreHan.RowHeadersVisible = false;
            this.dgvTreHan.RowHeadersWidth = 51;
            this.dgvTreHan.RowTemplate.Height = 24;
            this.dgvTreHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreHan.Size = new System.Drawing.Size(852, 216);
            this.dgvTreHan.TabIndex = 4;
            this.dgvTreHan.DataSource = this.bindingSource1;
            this.dgvTreHan.ForeColor = System.Drawing.Color.Black;
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.dgvThongKe);
            this.grpThongKe.Location = new System.Drawing.Point(12, 315);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(876, 270);
            this.grpThongKe.TabIndex = 5;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "Tỷ lệ hoàn thành công việc của từng thành viên";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(12, 22);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(852, 236);
            this.dgvThongKe.TabIndex = 6;
            this.dgvThongKe.DataSource = this.bindingSource2;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.grpThongKe);
            this.Controls.Add(this.grpTreHan);
            this.Controls.Add(this.lblTienDo);
            this.Controls.Add(this.cboDuAn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo - Cảnh báo trễ hạn";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.grpTreHan.ResumeLayout(false);
            this.grpTreHan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreHan)).EndInit();
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDuAn;
        private System.Windows.Forms.Label lblTienDo;
        private System.Windows.Forms.GroupBox grpTreHan;
        private System.Windows.Forms.DataGridView dgvTreHan;
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}
