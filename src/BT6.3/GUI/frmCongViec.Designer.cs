namespace BT6._3.GUI
{
    partial class frmCongViec
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.rdoKanban = new System.Windows.Forms.RadioButton();
            this.rdoList = new System.Windows.Forms.RadioButton();
            this.lblTreHan = new System.Windows.Forms.Label();
            this.grpToDo = new System.Windows.Forms.GroupBox();
            this.lstToDo = new System.Windows.Forms.ListBox();
            this.grpInProgress = new System.Windows.Forms.GroupBox();
            this.lstInProgress = new System.Windows.Forms.ListBox();
            this.grpReview = new System.Windows.Forms.GroupBox();
            this.lstReview = new System.Windows.Forms.ListBox();
            this.grpDone = new System.Windows.Forms.GroupBox();
            this.lstDone = new System.Windows.Forms.ListBox();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.btnLui = new System.Windows.Forms.Button();
            this.btnTien = new System.Windows.Forms.Button();
            this.lblChon = new System.Windows.Forms.Label();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenTask = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHanNop = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDoUuTien = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.clbThanhVien = new System.Windows.Forms.CheckedListBox();
            this.btnLuuPhanCong = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpToDo.SuspendLayout();
            this.grpInProgress.SuspendLayout();
            this.grpReview.SuspendLayout();
            this.grpDone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = "Dự án";
            // 
            // cboDuAn
            // 
            this.cboDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuAn.FormattingEnabled = true;
            this.cboDuAn.Location = new System.Drawing.Point(60, 14);
            this.cboDuAn.Name = "cboDuAn";
            this.cboDuAn.Size = new System.Drawing.Size(260, 24);
            this.cboDuAn.TabIndex = 1;
            this.cboDuAn.SelectedIndexChanged += new System.EventHandler(this.cboDuAn_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 18);
            this.label2.Name = "label2";
            this.label2.TabIndex = 2;
            this.label2.Text = "Lọc trạng thái";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(445, 14);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(125, 24);
            this.cboLocTrangThai.TabIndex = 3;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // rdoKanban
            // 
            this.rdoKanban.AutoSize = true;
            this.rdoKanban.Location = new System.Drawing.Point(590, 16);
            this.rdoKanban.Name = "rdoKanban";
            this.rdoKanban.TabIndex = 4;
            this.rdoKanban.Text = "Kanban";
            this.rdoKanban.UseVisualStyleBackColor = true;
            this.rdoKanban.Checked = true;
            this.rdoKanban.TabStop = true;
            this.rdoKanban.CheckedChanged += new System.EventHandler(this.rdoKanban_CheckedChanged);
            // 
            // rdoList
            // 
            this.rdoList.AutoSize = true;
            this.rdoList.Location = new System.Drawing.Point(680, 16);
            this.rdoList.Name = "rdoList";
            this.rdoList.TabIndex = 5;
            this.rdoList.Text = "Danh sách (List)";
            this.rdoList.UseVisualStyleBackColor = true;
            // 
            // lblTreHan
            // 
            this.lblTreHan.AutoSize = true;
            this.lblTreHan.Location = new System.Drawing.Point(830, 18);
            this.lblTreHan.Name = "lblTreHan";
            this.lblTreHan.TabIndex = 6;
            this.lblTreHan.Text = "";
            this.lblTreHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreHan.ForeColor = System.Drawing.Color.Red;
            // 
            // grpToDo
            // 
            this.grpToDo.Controls.Add(this.lstToDo);
            this.grpToDo.Location = new System.Drawing.Point(12, 50);
            this.grpToDo.Name = "grpToDo";
            this.grpToDo.Size = new System.Drawing.Size(205, 470);
            this.grpToDo.TabIndex = 7;
            this.grpToDo.TabStop = false;
            this.grpToDo.Text = "TO DO";
            // 
            // lstToDo
            // 
            this.lstToDo.FormattingEnabled = true;
            this.lstToDo.ItemHeight = 16;
            this.lstToDo.Location = new System.Drawing.Point(8, 22);
            this.lstToDo.Name = "lstToDo";
            this.lstToDo.Size = new System.Drawing.Size(189, 436);
            this.lstToDo.TabIndex = 8;
            this.lstToDo.HorizontalScrollbar = true;
            this.lstToDo.SelectedIndexChanged += new System.EventHandler(this.lstKanban_SelectedIndexChanged);
            // 
            // grpInProgress
            // 
            this.grpInProgress.Controls.Add(this.lstInProgress);
            this.grpInProgress.Location = new System.Drawing.Point(222, 50);
            this.grpInProgress.Name = "grpInProgress";
            this.grpInProgress.Size = new System.Drawing.Size(205, 470);
            this.grpInProgress.TabIndex = 9;
            this.grpInProgress.TabStop = false;
            this.grpInProgress.Text = "IN PROGRESS";
            // 
            // lstInProgress
            // 
            this.lstInProgress.FormattingEnabled = true;
            this.lstInProgress.ItemHeight = 16;
            this.lstInProgress.Location = new System.Drawing.Point(8, 22);
            this.lstInProgress.Name = "lstInProgress";
            this.lstInProgress.Size = new System.Drawing.Size(189, 436);
            this.lstInProgress.TabIndex = 10;
            this.lstInProgress.HorizontalScrollbar = true;
            this.lstInProgress.SelectedIndexChanged += new System.EventHandler(this.lstKanban_SelectedIndexChanged);
            // 
            // grpReview
            // 
            this.grpReview.Controls.Add(this.lstReview);
            this.grpReview.Location = new System.Drawing.Point(432, 50);
            this.grpReview.Name = "grpReview";
            this.grpReview.Size = new System.Drawing.Size(205, 470);
            this.grpReview.TabIndex = 11;
            this.grpReview.TabStop = false;
            this.grpReview.Text = "REVIEW";
            // 
            // lstReview
            // 
            this.lstReview.FormattingEnabled = true;
            this.lstReview.ItemHeight = 16;
            this.lstReview.Location = new System.Drawing.Point(8, 22);
            this.lstReview.Name = "lstReview";
            this.lstReview.Size = new System.Drawing.Size(189, 436);
            this.lstReview.TabIndex = 12;
            this.lstReview.HorizontalScrollbar = true;
            this.lstReview.SelectedIndexChanged += new System.EventHandler(this.lstKanban_SelectedIndexChanged);
            // 
            // grpDone
            // 
            this.grpDone.Controls.Add(this.lstDone);
            this.grpDone.Location = new System.Drawing.Point(642, 50);
            this.grpDone.Name = "grpDone";
            this.grpDone.Size = new System.Drawing.Size(205, 470);
            this.grpDone.TabIndex = 13;
            this.grpDone.TabStop = false;
            this.grpDone.Text = "DONE";
            // 
            // lstDone
            // 
            this.lstDone.FormattingEnabled = true;
            this.lstDone.ItemHeight = 16;
            this.lstDone.Location = new System.Drawing.Point(8, 22);
            this.lstDone.Name = "lstDone";
            this.lstDone.Size = new System.Drawing.Size(189, 436);
            this.lstDone.TabIndex = 14;
            this.lstDone.HorizontalScrollbar = true;
            this.lstDone.SelectedIndexChanged += new System.EventHandler(this.lstKanban_SelectedIndexChanged);
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.AllowUserToDeleteRows = false;
            this.dgvTask.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTask.BackgroundColor = System.Drawing.Color.White;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Location = new System.Drawing.Point(12, 50);
            this.dgvTask.MultiSelect = false;
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.ReadOnly = true;
            this.dgvTask.RowHeadersVisible = false;
            this.dgvTask.RowHeadersWidth = 51;
            this.dgvTask.RowTemplate.Height = 24;
            this.dgvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTask.Size = new System.Drawing.Size(835, 470);
            this.dgvTask.TabIndex = 15;
            this.dgvTask.DataSource = this.bindingSource1;
            this.dgvTask.Visible = false;
            this.dgvTask.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTask_CellClick);
            this.dgvTask.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTask_CellFormatting);
            // 
            // btnLui
            // 
            this.btnLui.Location = new System.Drawing.Point(12, 530);
            this.btnLui.Name = "btnLui";
            this.btnLui.Size = new System.Drawing.Size(160, 38);
            this.btnLui.TabIndex = 16;
            this.btnLui.Text = "<< Lùi trạng thái";
            this.btnLui.UseVisualStyleBackColor = true;
            this.btnLui.Click += new System.EventHandler(this.btnLui_Click);
            // 
            // btnTien
            // 
            this.btnTien.Location = new System.Drawing.Point(180, 530);
            this.btnTien.Name = "btnTien";
            this.btnTien.Size = new System.Drawing.Size(160, 38);
            this.btnTien.TabIndex = 17;
            this.btnTien.Text = "Tiến trạng thái >>";
            this.btnTien.UseVisualStyleBackColor = true;
            this.btnTien.Click += new System.EventHandler(this.btnTien_Click);
            // 
            // lblChon
            // 
            this.lblChon.AutoSize = true;
            this.lblChon.Location = new System.Drawing.Point(355, 541);
            this.lblChon.Name = "lblChon";
            this.lblChon.TabIndex = 18;
            this.lblChon.Text = "Chưa chọn công việc";
            this.lblChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.label3);
            this.grpChiTiet.Controls.Add(this.txtTenTask);
            this.grpChiTiet.Controls.Add(this.label4);
            this.grpChiTiet.Controls.Add(this.txtMoTa);
            this.grpChiTiet.Controls.Add(this.label5);
            this.grpChiTiet.Controls.Add(this.dtpHanNop);
            this.grpChiTiet.Controls.Add(this.label6);
            this.grpChiTiet.Controls.Add(this.cboDoUuTien);
            this.grpChiTiet.Controls.Add(this.label7);
            this.grpChiTiet.Controls.Add(this.cboTrangThai);
            this.grpChiTiet.Controls.Add(this.btnThem);
            this.grpChiTiet.Controls.Add(this.btnSua);
            this.grpChiTiet.Controls.Add(this.btnXoa);
            this.grpChiTiet.Controls.Add(this.btnLamMoi);
            this.grpChiTiet.Controls.Add(this.label8);
            this.grpChiTiet.Controls.Add(this.clbThanhVien);
            this.grpChiTiet.Controls.Add(this.btnLuuPhanCong);
            this.grpChiTiet.Location = new System.Drawing.Point(860, 45);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(408, 560);
            this.grpChiTiet.TabIndex = 19;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết công việc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên công việc";
            // 
            // txtTenTask
            // 
            this.txtTenTask.Location = new System.Drawing.Point(15, 48);
            this.txtTenTask.Name = "txtTenTask";
            this.txtTenTask.Size = new System.Drawing.Size(360, 22);
            this.txtTenTask.TabIndex = 21;
            this.txtTenTask.MaxLength = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.TabIndex = 22;
            this.label4.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(15, 100);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(360, 22);
            this.txtMoTa.TabIndex = 23;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(360, 60);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 175);
            this.label5.Name = "label5";
            this.label5.TabIndex = 24;
            this.label5.Text = "Hạn nộp";
            // 
            // dtpHanNop
            // 
            this.dtpHanNop.CustomFormat = "dd/MM/yyyy";
            this.dtpHanNop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanNop.Location = new System.Drawing.Point(110, 171);
            this.dtpHanNop.Name = "dtpHanNop";
            this.dtpHanNop.Size = new System.Drawing.Size(130, 22);
            this.dtpHanNop.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 210);
            this.label6.Name = "label6";
            this.label6.TabIndex = 26;
            this.label6.Text = "Độ ưu tiên";
            // 
            // cboDoUuTien
            // 
            this.cboDoUuTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoUuTien.FormattingEnabled = true;
            this.cboDoUuTien.Location = new System.Drawing.Point(110, 206);
            this.cboDoUuTien.Name = "cboDoUuTien";
            this.cboDoUuTien.Size = new System.Drawing.Size(130, 24);
            this.cboDoUuTien.TabIndex = 27;
            this.cboDoUuTien.Items.AddRange(new object[] {
            "Cao",
            "Trung bình",
            "Thấp"});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 245);
            this.label7.Name = "label7";
            this.label7.TabIndex = 28;
            this.label7.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(110, 241);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(130, 24);
            this.cboTrangThai.TabIndex = 29;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 280);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 34);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(108, 280);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 34);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(201, 280);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 34);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(294, 280);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(88, 34);
            this.btnLamMoi.TabIndex = 33;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 330);
            this.label8.Name = "label8";
            this.label8.TabIndex = 34;
            this.label8.Text = "Giao việc cho thành viên (tick chọn nhiều người)";
            // 
            // clbThanhVien
            // 
            this.clbThanhVien.CheckOnClick = true;
            this.clbThanhVien.FormattingEnabled = true;
            this.clbThanhVien.Location = new System.Drawing.Point(15, 352);
            this.clbThanhVien.Name = "clbThanhVien";
            this.clbThanhVien.Size = new System.Drawing.Size(367, 140);
            this.clbThanhVien.TabIndex = 35;
            // 
            // btnLuuPhanCong
            // 
            this.btnLuuPhanCong.Location = new System.Drawing.Point(15, 505);
            this.btnLuuPhanCong.Name = "btnLuuPhanCong";
            this.btnLuuPhanCong.Size = new System.Drawing.Size(367, 40);
            this.btnLuuPhanCong.TabIndex = 36;
            this.btnLuuPhanCong.Text = "Lưu phân công";
            this.btnLuuPhanCong.UseVisualStyleBackColor = true;
            this.btnLuuPhanCong.Click += new System.EventHandler(this.btnLuuPhanCong_Click);
            this.btnLuuPhanCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 615);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.lblChon);
            this.Controls.Add(this.btnTien);
            this.Controls.Add(this.btnLui);
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.grpDone);
            this.Controls.Add(this.grpReview);
            this.Controls.Add(this.grpInProgress);
            this.Controls.Add(this.grpToDo);
            this.Controls.Add(this.lblTreHan);
            this.Controls.Add(this.rdoList);
            this.Controls.Add(this.rdoKanban);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDuAn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCongViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý công việc - Kanban / List";
            this.Load += new System.EventHandler(this.frmCongViec_Load);
            this.grpToDo.ResumeLayout(false);
            this.grpToDo.PerformLayout();
            this.grpInProgress.ResumeLayout(false);
            this.grpInProgress.PerformLayout();
            this.grpReview.ResumeLayout(false);
            this.grpReview.PerformLayout();
            this.grpDone.ResumeLayout(false);
            this.grpDone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDuAn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.RadioButton rdoKanban;
        private System.Windows.Forms.RadioButton rdoList;
        private System.Windows.Forms.Label lblTreHan;
        private System.Windows.Forms.GroupBox grpToDo;
        private System.Windows.Forms.ListBox lstToDo;
        private System.Windows.Forms.GroupBox grpInProgress;
        private System.Windows.Forms.ListBox lstInProgress;
        private System.Windows.Forms.GroupBox grpReview;
        private System.Windows.Forms.ListBox lstReview;
        private System.Windows.Forms.GroupBox grpDone;
        private System.Windows.Forms.ListBox lstDone;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Button btnLui;
        private System.Windows.Forms.Button btnTien;
        private System.Windows.Forms.Label lblChon;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHanNop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDoUuTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clbThanhVien;
        private System.Windows.Forms.Button btnLuuPhanCong;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
