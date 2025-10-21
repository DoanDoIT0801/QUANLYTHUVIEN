namespace DOANNHOM
{
    partial class frmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongKeSach = new System.Windows.Forms.GroupBox();
            this.tblSach = new System.Windows.Forms.TableLayoutPanel();
            this.tileSach = new System.Windows.Forms.Panel();
            this.lblSachValue = new System.Windows.Forms.Label();
            this.lblSachTitle = new System.Windows.Forms.Label();
            this.tileLoaiSach = new System.Windows.Forms.Panel();
            this.lblLoaiSachValue = new System.Windows.Forms.Label();
            this.lblLoaiSachTitle = new System.Windows.Forms.Label();
            this.tileTacGia = new System.Windows.Forms.Panel();
            this.lblTacGiaValue = new System.Windows.Forms.Label();
            this.lblTacGiaTitle = new System.Windows.Forms.Label();
            this.tileNXB = new System.Windows.Forms.Panel();
            this.lblNXBValue = new System.Windows.Forms.Label();
            this.lblNXBTitle = new System.Windows.Forms.Label();
            this.grpThongKeKhac = new System.Windows.Forms.GroupBox();
            this.tblKhac = new System.Windows.Forms.TableLayoutPanel();
            this.tileSinhVien = new System.Windows.Forms.Panel();
            this.lblSinhVienValue = new System.Windows.Forms.Label();
            this.lblSinhVienTitle = new System.Windows.Forms.Label();
            this.tileSachMuon = new System.Windows.Forms.Panel();
            this.lblSachMuonValue = new System.Windows.Forms.Label();
            this.lblSachMuonTitle = new System.Windows.Forms.Label();
            this.tileNhanVien = new System.Windows.Forms.Panel();
            this.lblNhanVienValue = new System.Windows.Forms.Label();
            this.lblNhanVienTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnQuaHan = new System.Windows.Forms.Button();
            this.btnDangMuon = new System.Windows.Forms.Button();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.pnlListHeader = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.grpThongKeSach.SuspendLayout();
            this.tblSach.SuspendLayout();
            this.tileSach.SuspendLayout();
            this.tileLoaiSach.SuspendLayout();
            this.tileTacGia.SuspendLayout();
            this.tileNXB.SuspendLayout();
            this.grpThongKeKhac.SuspendLayout();
            this.tblKhac.SuspendLayout();
            this.tileSinhVien.SuspendLayout();
            this.tileSachMuon.SuspendLayout();
            this.tileNhanVien.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlHeader.Size = new System.Drawing.Size(2038, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(493, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            // 
            // grpThongKeSach
            // 
            this.grpThongKeSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeSach.Controls.Add(this.tblSach);
            this.grpThongKeSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeSach.Location = new System.Drawing.Point(24, 72);
            this.grpThongKeSach.Name = "grpThongKeSach";
            this.grpThongKeSach.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeSach.Size = new System.Drawing.Size(1990, 145);
            this.grpThongKeSach.TabIndex = 1;
            this.grpThongKeSach.TabStop = false;
            this.grpThongKeSach.Text = "Thống Kê Sách";
            // 
            // tblSach
            // 
            this.tblSach.ColumnCount = 4;
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSach.Controls.Add(this.tileSach, 0, 0);
            this.tblSach.Controls.Add(this.tileLoaiSach, 1, 0);
            this.tblSach.Controls.Add(this.tileTacGia, 2, 0);
            this.tblSach.Controls.Add(this.tileNXB, 3, 0);
            this.tblSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSach.Location = new System.Drawing.Point(12, 46);
            this.tblSach.Name = "tblSach";
            this.tblSach.RowCount = 1;
            this.tblSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSach.Size = new System.Drawing.Size(1966, 87);
            this.tblSach.TabIndex = 0;
            // 
            // tileSach
            // 
            this.tileSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSach.Controls.Add(this.lblSachValue);
            this.tileSach.Controls.Add(this.lblSachTitle);
            this.tileSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSach.Location = new System.Drawing.Point(6, 6);
            this.tileSach.Margin = new System.Windows.Forms.Padding(6);
            this.tileSach.Name = "tileSach";
            this.tileSach.Size = new System.Drawing.Size(479, 75);
            this.tileSach.TabIndex = 0;
            // 
            // lblSachValue
            // 
            this.lblSachValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSachValue.AutoSize = true;
            this.lblSachValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSachValue.Location = new System.Drawing.Point(433, 22);
            this.lblSachValue.Name = "lblSachValue";
            this.lblSachValue.Size = new System.Drawing.Size(38, 45);
            this.lblSachValue.TabIndex = 1;
            this.lblSachValue.Text = "9";
            // 
            // lblSachTitle
            // 
            this.lblSachTitle.AutoSize = true;
            this.lblSachTitle.Location = new System.Drawing.Point(12, 20);
            this.lblSachTitle.Name = "lblSachTitle";
            this.lblSachTitle.Size = new System.Drawing.Size(76, 37);
            this.lblSachTitle.TabIndex = 0;
            this.lblSachTitle.Text = "Sách";
            // 
            // tileLoaiSach
            // 
            this.tileLoaiSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.tileLoaiSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileLoaiSach.Controls.Add(this.lblLoaiSachValue);
            this.tileLoaiSach.Controls.Add(this.lblLoaiSachTitle);
            this.tileLoaiSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileLoaiSach.Location = new System.Drawing.Point(497, 6);
            this.tileLoaiSach.Margin = new System.Windows.Forms.Padding(6);
            this.tileLoaiSach.Name = "tileLoaiSach";
            this.tileLoaiSach.Size = new System.Drawing.Size(479, 75);
            this.tileLoaiSach.TabIndex = 1;
            // 
            // lblLoaiSachValue
            // 
            this.lblLoaiSachValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLoaiSachValue.AutoSize = true;
            this.lblLoaiSachValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoaiSachValue.Location = new System.Drawing.Point(417, 22);
            this.lblLoaiSachValue.Name = "lblLoaiSachValue";
            this.lblLoaiSachValue.Size = new System.Drawing.Size(56, 45);
            this.lblLoaiSachValue.TabIndex = 1;
            this.lblLoaiSachValue.Text = "18";
            // 
            // lblLoaiSachTitle
            // 
            this.lblLoaiSachTitle.AutoSize = true;
            this.lblLoaiSachTitle.Location = new System.Drawing.Point(12, 20);
            this.lblLoaiSachTitle.Name = "lblLoaiSachTitle";
            this.lblLoaiSachTitle.Size = new System.Drawing.Size(137, 37);
            this.lblLoaiSachTitle.TabIndex = 0;
            this.lblLoaiSachTitle.Text = "Loại Sách";
            // 
            // tileTacGia
            // 
            this.tileTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileTacGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileTacGia.Controls.Add(this.lblTacGiaValue);
            this.tileTacGia.Controls.Add(this.lblTacGiaTitle);
            this.tileTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileTacGia.Location = new System.Drawing.Point(988, 6);
            this.tileTacGia.Margin = new System.Windows.Forms.Padding(6);
            this.tileTacGia.Name = "tileTacGia";
            this.tileTacGia.Size = new System.Drawing.Size(479, 75);
            this.tileTacGia.TabIndex = 2;
            // 
            // lblTacGiaValue
            // 
            this.lblTacGiaValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTacGiaValue.AutoSize = true;
            this.lblTacGiaValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTacGiaValue.Location = new System.Drawing.Point(418, 22);
            this.lblTacGiaValue.Name = "lblTacGiaValue";
            this.lblTacGiaValue.Size = new System.Drawing.Size(56, 45);
            this.lblTacGiaValue.TabIndex = 1;
            this.lblTacGiaValue.Text = "12";
            // 
            // lblTacGiaTitle
            // 
            this.lblTacGiaTitle.AutoSize = true;
            this.lblTacGiaTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTacGiaTitle.Name = "lblTacGiaTitle";
            this.lblTacGiaTitle.Size = new System.Drawing.Size(108, 37);
            this.lblTacGiaTitle.TabIndex = 0;
            this.lblTacGiaTitle.Text = "Tác Giả";
            // 
            // tileNXB
            // 
            this.tileNXB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.tileNXB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileNXB.Controls.Add(this.lblNXBValue);
            this.tileNXB.Controls.Add(this.lblNXBTitle);
            this.tileNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNXB.Location = new System.Drawing.Point(1479, 6);
            this.tileNXB.Margin = new System.Windows.Forms.Padding(6);
            this.tileNXB.Name = "tileNXB";
            this.tileNXB.Size = new System.Drawing.Size(481, 75);
            this.tileNXB.TabIndex = 3;
            // 
            // lblNXBValue
            // 
            this.lblNXBValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNXBValue.AutoSize = true;
            this.lblNXBValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNXBValue.Location = new System.Drawing.Point(419, 22);
            this.lblNXBValue.Name = "lblNXBValue";
            this.lblNXBValue.Size = new System.Drawing.Size(56, 45);
            this.lblNXBValue.TabIndex = 1;
            this.lblNXBValue.Text = "13";
            // 
            // lblNXBTitle
            // 
            this.lblNXBTitle.AutoSize = true;
            this.lblNXBTitle.Location = new System.Drawing.Point(12, 20);
            this.lblNXBTitle.Name = "lblNXBTitle";
            this.lblNXBTitle.Size = new System.Drawing.Size(191, 37);
            this.lblNXBTitle.TabIndex = 0;
            this.lblNXBTitle.Text = "Nhà Xuất Bản";
            // 
            // grpThongKeKhac
            // 
            this.grpThongKeKhac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongKeKhac.Controls.Add(this.tblKhac);
            this.grpThongKeKhac.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKeKhac.Location = new System.Drawing.Point(24, 230);
            this.grpThongKeKhac.Name = "grpThongKeKhac";
            this.grpThongKeKhac.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            this.grpThongKeKhac.Size = new System.Drawing.Size(1990, 149);
            this.grpThongKeKhac.TabIndex = 2;
            this.grpThongKeKhac.TabStop = false;
            this.grpThongKeKhac.Text = "Thống kê Nhân viên - Độc giả - Số sách mượn";
            // 
            // tblKhac
            // 
            this.tblKhac.ColumnCount = 3;
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblKhac.Controls.Add(this.tileSinhVien, 0, 0);
            this.tblKhac.Controls.Add(this.tileSachMuon, 1, 0);
            this.tblKhac.Controls.Add(this.tileNhanVien, 2, 0);
            this.tblKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblKhac.Location = new System.Drawing.Point(12, 46);
            this.tblKhac.Name = "tblKhac";
            this.tblKhac.RowCount = 1;
            this.tblKhac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblKhac.Size = new System.Drawing.Size(1966, 91);
            this.tblKhac.TabIndex = 0;
            // 
            // tileSinhVien
            // 
            this.tileSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.tileSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSinhVien.Controls.Add(this.lblSinhVienValue);
            this.tileSinhVien.Controls.Add(this.lblSinhVienTitle);
            this.tileSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSinhVien.Location = new System.Drawing.Point(6, 6);
            this.tileSinhVien.Margin = new System.Windows.Forms.Padding(6);
            this.tileSinhVien.Name = "tileSinhVien";
            this.tileSinhVien.Size = new System.Drawing.Size(643, 79);
            this.tileSinhVien.TabIndex = 0;
            // 
            // lblSinhVienValue
            // 
            this.lblSinhVienValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSinhVienValue.AutoSize = true;
            this.lblSinhVienValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSinhVienValue.Location = new System.Drawing.Point(599, 24);
            this.lblSinhVienValue.Name = "lblSinhVienValue";
            this.lblSinhVienValue.Size = new System.Drawing.Size(38, 45);
            this.lblSinhVienValue.TabIndex = 1;
            this.lblSinhVienValue.Text = "9";
            // 
            // lblSinhVienTitle
            // 
            this.lblSinhVienTitle.AutoSize = true;
            this.lblSinhVienTitle.Location = new System.Drawing.Point(12, 18);
            this.lblSinhVienTitle.Name = "lblSinhVienTitle";
            this.lblSinhVienTitle.Size = new System.Drawing.Size(136, 37);
            this.lblSinhVienTitle.TabIndex = 0;
            this.lblSinhVienTitle.Text = "Sinh Viên";
            // 
            // tileSachMuon
            // 
            this.tileSachMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tileSachMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSachMuon.Controls.Add(this.lblSachMuonValue);
            this.tileSachMuon.Controls.Add(this.lblSachMuonTitle);
            this.tileSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSachMuon.Location = new System.Drawing.Point(661, 6);
            this.tileSachMuon.Margin = new System.Windows.Forms.Padding(6);
            this.tileSachMuon.Name = "tileSachMuon";
            this.tileSachMuon.Size = new System.Drawing.Size(643, 79);
            this.tileSachMuon.TabIndex = 1;
            // 
            // lblSachMuonValue
            // 
            this.lblSachMuonValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSachMuonValue.AutoSize = true;
            this.lblSachMuonValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSachMuonValue.Location = new System.Drawing.Point(580, 26);
            this.lblSachMuonValue.Name = "lblSachMuonValue";
            this.lblSachMuonValue.Size = new System.Drawing.Size(56, 45);
            this.lblSachMuonValue.TabIndex = 1;
            this.lblSachMuonValue.Text = "11";
            // 
            // lblSachMuonTitle
            // 
            this.lblSachMuonTitle.AutoSize = true;
            this.lblSachMuonTitle.Location = new System.Drawing.Point(12, 18);
            this.lblSachMuonTitle.Name = "lblSachMuonTitle";
            this.lblSachMuonTitle.Size = new System.Drawing.Size(160, 37);
            this.lblSachMuonTitle.TabIndex = 0;
            this.lblSachMuonTitle.Text = "Sách Mượn";
            // 
            // tileNhanVien
            // 
            this.tileNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.tileNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileNhanVien.Controls.Add(this.lblNhanVienValue);
            this.tileNhanVien.Controls.Add(this.lblNhanVienTitle);
            this.tileNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNhanVien.Location = new System.Drawing.Point(1316, 6);
            this.tileNhanVien.Margin = new System.Windows.Forms.Padding(6);
            this.tileNhanVien.Name = "tileNhanVien";
            this.tileNhanVien.Size = new System.Drawing.Size(644, 79);
            this.tileNhanVien.TabIndex = 2;
            // 
            // lblNhanVienValue
            // 
            this.lblNhanVienValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNhanVienValue.AutoSize = true;
            this.lblNhanVienValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNhanVienValue.Location = new System.Drawing.Point(600, 24);
            this.lblNhanVienValue.Name = "lblNhanVienValue";
            this.lblNhanVienValue.Size = new System.Drawing.Size(38, 45);
            this.lblNhanVienValue.TabIndex = 1;
            this.lblNhanVienValue.Text = "5";
            // 
            // lblNhanVienTitle
            // 
            this.lblNhanVienTitle.AutoSize = true;
            this.lblNhanVienTitle.Location = new System.Drawing.Point(12, 18);
            this.lblNhanVienTitle.Name = "lblNhanVienTitle";
            this.lblNhanVienTitle.Size = new System.Drawing.Size(149, 37);
            this.lblNhanVienTitle.TabIndex = 0;
            this.lblNhanVienTitle.Text = "Nhân Viên";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlFilter.Controls.Add(this.btnQuaHan);
            this.pnlFilter.Controls.Add(this.btnDangMuon);
            this.pnlFilter.Controls.Add(this.lblSectionTitle);
            this.pnlFilter.Location = new System.Drawing.Point(438, 379);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1213, 74);
            this.pnlFilter.TabIndex = 3;
            // 
            // btnQuaHan
            // 
            this.btnQuaHan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuaHan.BackColor = System.Drawing.Color.Gainsboro;
            this.btnQuaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuaHan.Location = new System.Drawing.Point(862, 6);
            this.btnQuaHan.Name = "btnQuaHan";
            this.btnQuaHan.Size = new System.Drawing.Size(170, 59);
            this.btnQuaHan.TabIndex = 2;
            this.btnQuaHan.Text = "DS Quá Hạn";
            this.btnQuaHan.UseVisualStyleBackColor = false;
            // 
            // btnDangMuon
            // 
            this.btnDangMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDangMuon.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDangMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangMuon.ForeColor = System.Drawing.Color.White;
            this.btnDangMuon.Location = new System.Drawing.Point(657, 6);
            this.btnDangMuon.Name = "btnDangMuon";
            this.btnDangMuon.Size = new System.Drawing.Size(170, 59);
            this.btnDangMuon.TabIndex = 1;
            this.btnDangMuon.Text = "Đang Mượn";
            this.btnDangMuon.UseVisualStyleBackColor = false;
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.Location = new System.Drawing.Point(6, 15);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(626, 37);
            this.lblSectionTitle.TabIndex = 0;
            this.lblSectionTitle.Text = "Thống kê Sinh Viên đang mượn sách và quá hạn";
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListHeader.Controls.Add(this.lblListTitle);
            this.pnlListHeader.Location = new System.Drawing.Point(24, 454);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.Size = new System.Drawing.Size(1990, 60);
            this.pnlListHeader.TabIndex = 4;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(6, 6);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(289, 36);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách đang mượn";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(24, 515);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.Size = new System.Drawing.Size(1990, 712);
            this.dgvThongKe.TabIndex = 5;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2038, 1479);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.pnlListHeader);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.grpThongKeKhac);
            this.Controls.Add(this.grpThongKeSach);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmBaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo - Thống kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongKeSach.ResumeLayout(false);
            this.tblSach.ResumeLayout(false);
            this.tileSach.ResumeLayout(false);
            this.tileSach.PerformLayout();
            this.tileLoaiSach.ResumeLayout(false);
            this.tileLoaiSach.PerformLayout();
            this.tileTacGia.ResumeLayout(false);
            this.tileTacGia.PerformLayout();
            this.tileNXB.ResumeLayout(false);
            this.tileNXB.PerformLayout();
            this.grpThongKeKhac.ResumeLayout(false);
            this.tblKhac.ResumeLayout(false);
            this.tileSinhVien.ResumeLayout(false);
            this.tileSinhVien.PerformLayout();
            this.tileSachMuon.ResumeLayout(false);
            this.tileSachMuon.PerformLayout();
            this.tileNhanVien.ResumeLayout(false);
            this.tileNhanVien.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlListHeader.ResumeLayout(false);
            this.pnlListHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpThongKeSach;
        private System.Windows.Forms.TableLayoutPanel tblSach;
        private System.Windows.Forms.Panel tileSach;
        private System.Windows.Forms.Label lblSachValue;
        private System.Windows.Forms.Label lblSachTitle;
        private System.Windows.Forms.Panel tileLoaiSach;
        private System.Windows.Forms.Label lblLoaiSachValue;
        private System.Windows.Forms.Label lblLoaiSachTitle;
        private System.Windows.Forms.Panel tileTacGia;
        private System.Windows.Forms.Label lblTacGiaValue;
        private System.Windows.Forms.Label lblTacGiaTitle;
        private System.Windows.Forms.Panel tileNXB;
        private System.Windows.Forms.Label lblNXBValue;
        private System.Windows.Forms.Label lblNXBTitle;

        private System.Windows.Forms.GroupBox grpThongKeKhac;
        private System.Windows.Forms.TableLayoutPanel tblKhac;
        private System.Windows.Forms.Panel tileSinhVien;
        private System.Windows.Forms.Label lblSinhVienValue;
        private System.Windows.Forms.Label lblSinhVienTitle;
        private System.Windows.Forms.Panel tileSachMuon;
        private System.Windows.Forms.Label lblSachMuonValue;
        private System.Windows.Forms.Label lblSachMuonTitle;
        private System.Windows.Forms.Panel tileNhanVien;
        private System.Windows.Forms.Label lblNhanVienValue;
        private System.Windows.Forms.Label lblNhanVienTitle;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnQuaHan;
        private System.Windows.Forms.Button btnDangMuon;
        private System.Windows.Forms.Label lblSectionTitle;

        private System.Windows.Forms.Panel pnlListHeader;
        private System.Windows.Forms.Label lblListTitle;

        private System.Windows.Forms.DataGridView dgvThongKe;
    }
}
