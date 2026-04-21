namespace QuanLyQuanNet
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThongKe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDichVuMay = new Guna.UI2.WinForms.Guna2Button();
            this.btnKetThuc = new Guna.UI2.WinForms.Guna2Button();
            this.btnChuyenMay = new Guna.UI2.WinForms.Guna2Button();
            this.btnBatDau = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemGio = new Guna.UI2.WinForms.Guna2Button();
            this.cmbChonPC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpViTriPC = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiaoCa = new Guna.UI2.WinForms.Guna2Button();
            this.btnGoiMon = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiaoDich = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnViTriPC = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhoHang = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 10;
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Location = new System.Drawing.Point(208, 70);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.Size = new System.Drawing.Size(928, 566);
            this.guna2Panel1.TabIndex = 2;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2Panel3.BorderRadius = 15;
            this.guna2Panel3.Controls.Add(this.dgvThongKe);
            this.guna2Panel3.Controls.Add(this.btnDichVuMay);
            this.guna2Panel3.Controls.Add(this.btnKetThuc);
            this.guna2Panel3.Controls.Add(this.btnChuyenMay);
            this.guna2Panel3.Controls.Add(this.btnBatDau);
            this.guna2Panel3.Controls.Add(this.btnThemGio);
            this.guna2Panel3.Controls.Add(this.cmbChonPC);
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Controls.Add(this.btnThanhToan);
            this.guna2Panel3.Location = new System.Drawing.Point(569, 22);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(345, 541);
            this.guna2Panel3.TabIndex = 1;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKe.ColumnHeadersHeight = 34;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPC,
            this.colUser,
            this.colStartTime,
            this.colTimeUsed,
            this.colCost});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKe.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvThongKe.Location = new System.Drawing.Point(3, 300);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(342, 241);
            this.dgvThongKe.TabIndex = 4;
            this.dgvThongKe.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvThongKe.ThemeStyle.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvThongKe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.dgvThongKe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThongKe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvThongKe.ThemeStyle.ReadOnly = true;
            this.dgvThongKe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvThongKe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThongKe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // colPC
            // 
            this.colPC.HeaderText = "PC";
            this.colPC.MinimumWidth = 6;
            this.colPC.Name = "colPC";
            this.colPC.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "Người Dùng";
            this.colUser.MinimumWidth = 6;
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "StartTime";
            this.colStartTime.MinimumWidth = 6;
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colTimeUsed
            // 
            this.colTimeUsed.HeaderText = "TimeUsed";
            this.colTimeUsed.MinimumWidth = 6;
            this.colTimeUsed.Name = "colTimeUsed";
            this.colTimeUsed.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "Cost";
            this.colCost.MinimumWidth = 6;
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // btnDichVuMay
            // 
            this.btnDichVuMay.BorderRadius = 15;
            this.btnDichVuMay.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDichVuMay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDichVuMay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDichVuMay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDichVuMay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDichVuMay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnDichVuMay.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnDichVuMay.ForeColor = System.Drawing.Color.White;
            this.btnDichVuMay.Image = global::QuanLyQuanNet.Properties.Resources.repair;
            this.btnDichVuMay.Location = new System.Drawing.Point(180, 241);
            this.btnDichVuMay.Name = "btnDichVuMay";
            this.btnDichVuMay.Size = new System.Drawing.Size(130, 43);
            this.btnDichVuMay.TabIndex = 3;
            this.btnDichVuMay.Text = "Dịch Vụ Máy";
            this.btnDichVuMay.Click += new System.EventHandler(this.btnDichVuMay_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.BorderRadius = 15;
            this.btnKetThuc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKetThuc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKetThuc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKetThuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKetThuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKetThuc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnKetThuc.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Image = global::QuanLyQuanNet.Properties.Resources.cancel;
            this.btnKetThuc.Location = new System.Drawing.Point(180, 103);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(130, 46);
            this.btnKetThuc.TabIndex = 2;
            this.btnKetThuc.Text = "Kết Thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnChuyenMay
            // 
            this.btnChuyenMay.BorderRadius = 15;
            this.btnChuyenMay.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChuyenMay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenMay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChuyenMay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChuyenMay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChuyenMay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnChuyenMay.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnChuyenMay.ForeColor = System.Drawing.Color.White;
            this.btnChuyenMay.Image = global::QuanLyQuanNet.Properties.Resources.next;
            this.btnChuyenMay.Location = new System.Drawing.Point(180, 173);
            this.btnChuyenMay.Name = "btnChuyenMay";
            this.btnChuyenMay.Size = new System.Drawing.Size(130, 49);
            this.btnChuyenMay.TabIndex = 3;
            this.btnChuyenMay.Text = "Chuyển Máy";
            this.btnChuyenMay.Click += new System.EventHandler(this.btnChuyenMay_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.BorderRadius = 15;
            this.btnBatDau.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBatDau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBatDau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBatDau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnBatDau.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Image = global::QuanLyQuanNet.Properties.Resources.play;
            this.btnBatDau.Location = new System.Drawing.Point(28, 103);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(130, 46);
            this.btnBatDau.TabIndex = 0;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnThemGio
            // 
            this.btnThemGio.BorderRadius = 15;
            this.btnThemGio.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThemGio.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemGio.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemGio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemGio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemGio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnThemGio.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnThemGio.ForeColor = System.Drawing.Color.White;
            this.btnThemGio.Image = global::QuanLyQuanNet.Properties.Resources.plus;
            this.btnThemGio.Location = new System.Drawing.Point(28, 241);
            this.btnThemGio.Name = "btnThemGio";
            this.btnThemGio.Size = new System.Drawing.Size(130, 43);
            this.btnThemGio.TabIndex = 1;
            this.btnThemGio.Text = "Thêm Giờ";
            this.btnThemGio.Click += new System.EventHandler(this.btnThemGio_Click);
            // 
            // cmbChonPC
            // 
            this.cmbChonPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChonPC.BackColor = System.Drawing.Color.Transparent;
            this.cmbChonPC.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbChonPC.BorderRadius = 15;
            this.cmbChonPC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChonPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChonPC.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.cmbChonPC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonPC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonPC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChonPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbChonPC.ItemHeight = 30;
            this.cmbChonPC.Location = new System.Drawing.Point(13, 39);
            this.cmbChonPC.Name = "cmbChonPC";
            this.cmbChonPC.Size = new System.Drawing.Size(206, 36);
            this.cmbChonPC.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn PC:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 15;
            this.btnThanhToan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Image = global::QuanLyQuanNet.Properties.Resources.money;
            this.btnThanhToan.Location = new System.Drawing.Point(28, 173);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(130, 49);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.flpViTriPC);
            this.guna2Panel2.Location = new System.Drawing.Point(24, 22);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(524, 569);
            this.guna2Panel2.TabIndex = 0;
            // 
            // flpViTriPC
            // 
            this.flpViTriPC.AutoScroll = true;
            this.flpViTriPC.BackColor = System.Drawing.Color.Transparent;
            this.flpViTriPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpViTriPC.Location = new System.Drawing.Point(0, 0);
            this.flpViTriPC.Name = "flpViTriPC";
            this.flpViTriPC.Size = new System.Drawing.Size(524, 569);
            this.flpViTriPC.TabIndex = 0;
            this.flpViTriPC.Paint += new System.Windows.Forms.PaintEventHandler(this.flpViTriPC_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(21, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "HyperScore-Leo rank như gió";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(69, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Solo không lo";
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BorderRadius = 15;
            this.btnKhachHang.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhachHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnKhachHang.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Image = global::QuanLyQuanNet.Properties.Resources.mechanical_gears_;
            this.btnKhachHang.Location = new System.Drawing.Point(12, 413);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(180, 45);
            this.btnKhachHang.TabIndex = 11;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnGiaoCa
            // 
            this.btnGiaoCa.BorderRadius = 15;
            this.btnGiaoCa.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnGiaoCa.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGiaoCa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoCa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoCa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiaoCa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiaoCa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnGiaoCa.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGiaoCa.ForeColor = System.Drawing.Color.White;
            this.btnGiaoCa.Image = global::QuanLyQuanNet.Properties.Resources.mechanical_gears_;
            this.btnGiaoCa.Location = new System.Drawing.Point(12, 481);
            this.btnGiaoCa.Name = "btnGiaoCa";
            this.btnGiaoCa.Size = new System.Drawing.Size(180, 45);
            this.btnGiaoCa.TabIndex = 10;
            this.btnGiaoCa.Text = "Giao Ca ";
            this.btnGiaoCa.Click += new System.EventHandler(this.btnGiaoCa_Click);
            // 
            // btnGoiMon
            // 
            this.btnGoiMon.BorderRadius = 15;
            this.btnGoiMon.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnGoiMon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGoiMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoiMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoiMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoiMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoiMon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnGoiMon.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGoiMon.ForeColor = System.Drawing.Color.White;
            this.btnGoiMon.Image = global::QuanLyQuanNet.Properties.Resources.fast_food;
            this.btnGoiMon.Location = new System.Drawing.Point(12, 344);
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.Size = new System.Drawing.Size(180, 45);
            this.btnGoiMon.TabIndex = 9;
            this.btnGoiMon.Text = "Dịch Vụ Gọi Món";
            this.btnGoiMon.Click += new System.EventHandler(this.btnGoiMon_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BorderRadius = 15;
            this.btnDangXuat.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnDangXuat.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Image = global::QuanLyQuanNet.Properties.Resources.logout;
            this.btnDangXuat.Location = new System.Drawing.Point(936, 12);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(160, 33);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnGiaoDich
            // 
            this.btnGiaoDich.BorderRadius = 15;
            this.btnGiaoDich.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnGiaoDich.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGiaoDich.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoDich.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoDich.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiaoDich.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiaoDich.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnGiaoDich.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGiaoDich.ForeColor = System.Drawing.Color.White;
            this.btnGiaoDich.Image = global::QuanLyQuanNet.Properties.Resources.payment_method;
            this.btnGiaoDich.Location = new System.Drawing.Point(12, 282);
            this.btnGiaoDich.Name = "btnGiaoDich";
            this.btnGiaoDich.Size = new System.Drawing.Size(180, 45);
            this.btnGiaoDich.TabIndex = 5;
            this.btnGiaoDich.Text = "Giao Dịch";
            this.btnGiaoDich.Click += new System.EventHandler(this.btnGiaoDich_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BorderRadius = 15;
            this.btnThongKe.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnThongKe.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnThongKe.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Image = global::QuanLyQuanNet.Properties.Resources.clipboard;
            this.btnThongKe.Location = new System.Drawing.Point(12, 213);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(180, 45);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống Kê ";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnViTriPC
            // 
            this.btnViTriPC.BorderRadius = 15;
            this.btnViTriPC.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnViTriPC.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnViTriPC.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViTriPC.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViTriPC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViTriPC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViTriPC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnViTriPC.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnViTriPC.ForeColor = System.Drawing.Color.White;
            this.btnViTriPC.Image = global::QuanLyQuanNet.Properties.Resources.computer;
            this.btnViTriPC.Location = new System.Drawing.Point(12, 149);
            this.btnViTriPC.Name = "btnViTriPC";
            this.btnViTriPC.Size = new System.Drawing.Size(180, 45);
            this.btnViTriPC.TabIndex = 3;
            this.btnViTriPC.Text = "Vị Trí PC";
            this.btnViTriPC.Click += new System.EventHandler(this.btnViTriPC_Click);
            // 
            // btnKhoHang
            // 
            this.btnKhoHang.BorderRadius = 15;
            this.btnKhoHang.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnKhoHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhoHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhoHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhoHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnKhoHang.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKhoHang.ForeColor = System.Drawing.Color.White;
            this.btnKhoHang.Location = new System.Drawing.Point(12, 544);
            this.btnKhoHang.Name = "btnKhoHang";
            this.btnKhoHang.Size = new System.Drawing.Size(180, 45);
            this.btnKhoHang.TabIndex = 12;
            this.btnKhoHang.Text = "Kho Hàng";
            this.btnKhoHang.Click += new System.EventHandler(this.btnKhoHang_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1137, 632);
            this.Controls.Add(this.btnKhoHang);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.btnGiaoCa);
            this.Controls.Add(this.btnGoiMon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnGiaoDich);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnViTriPC);
            this.Controls.Add(this.guna2Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HyperScore";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnViTriPC;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnDichVuMay;
        private Guna.UI2.WinForms.Guna2Button btnKetThuc;
        private Guna.UI2.WinForms.Guna2Button btnThemGio;
        private Guna.UI2.WinForms.Guna2Button btnBatDau;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnChuyenMay;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChonPC;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2Button btnGiaoDich;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flpViTriPC;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnGoiMon;
        private Guna.UI2.WinForms.Guna2Button btnGiaoCa;
        private Guna.UI2.WinForms.Guna2Button btnKhachHang;
        private Guna.UI2.WinForms.Guna2Button btnKhoHang;
    }
}

