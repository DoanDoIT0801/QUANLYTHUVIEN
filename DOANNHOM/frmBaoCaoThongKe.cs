using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmBaoCaoThongKe : Form
    {
        private readonly string connectionString =
            @"Data Source=LAPTOP-66PONRPJ\SQLEXPRESS;Initial Catalog=QuanLyThuVienDB;Integrated Security=True;TrustServerCertificate=True";

        private bool _isOverdue = false; // false = Đang mượn, true = Quá hạn

        public frmBaoCaoThongKe()
        {
            InitializeComponent();

            // Trường hợp Designer chưa gắn:
            this.Load += frmBaoCaoThongKe_Load;
            this.btnDangMuon.Click += btnDangMuon_Click;
            this.btnQuaHan.Click += btnQuaHan_Click;

            // Grid
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.ReadOnly = true;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKe.MultiSelect = false;
        }

        #region ADO.NET helpers
        private object ExecScalar(string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                var val = cmd.ExecuteScalar();
                return val == DBNull.Value || val == null ? null : val;
            }
        }

        private DataTable GetDataTable(string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSummaryTiles();     // Đếm số liệu cho các tile
                LoadBorrowList(false);  // Mặc định: Đang mượn
                HighlightFilterButtons();

                // (Tuỳ chọn) nạp danh mục sách (giống query cũ của bạn)
                // LoadBooksCatalogIntoGrid(); // nếu muốn hiển thị danh mục thay vì danh sách mượn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSummaryTiles()
        {
            // Đổi tên bảng/cột cho khớp DB bạn (nếu khác)
            lblSachValue.Text     = (ExecScalar("SELECT COUNT(*) FROM Sach") ?? 0).ToString();
            lblLoaiSachValue.Text = (ExecScalar("SELECT COUNT(*) FROM LoaiSach") ?? 0).ToString();
            lblTacGiaValue.Text   = (ExecScalar("SELECT COUNT(*) FROM TacGia") ?? 0).ToString();
            lblNXBValue.Text      = (ExecScalar("SELECT COUNT(*) FROM NhaXuatBan") ?? 0).ToString();

            lblSinhVienValue.Text = (ExecScalar("SELECT COUNT(*) FROM SinhVien") ?? 0).ToString();
            lblNhanVienValue.Text = (ExecScalar("SELECT COUNT(*) FROM NhanVien") ?? 0).ToString();

            // Số sách đang mượn (tuỳ schema)
            // --- Lựa chọn A: bảng MuonTra (NgayTra NULL khi chưa trả) ---
            // lblSachMuonValue.Text = (ExecScalar("SELECT COUNT(*) FROM MuonTra WHERE NgayTra IS NULL") ?? 0).ToString();

            // --- Lựa chọn B: bảng MuonTraSach dùng cột HanTra/NgayTra là hạn trả, chưa có ngày trả thực tế ---
            // Đang mượn = hạn trả (NgayTra) >= hôm nay
            lblSachMuonValue.Text = (ExecScalar("IF OBJECT_ID('MuonTraSach') IS NOT NULL SELECT COUNT(*) FROM MuonTraSach WHERE NgayTra >= CAST(GETDATE() AS DATE) ELSE SELECT 0") ?? 0).ToString();
        }

        private void LoadBorrowList(bool overdue)
        {
            _isOverdue = overdue;
            lblListTitle.Text = overdue ? "Danh sách quá hạn" : "Danh sách đang mượn";

            // ===== CHỌN 1 TRONG 2 KHỐI TRUY VẤN SAU =====

            // ---------- Lựa chọn A: Có bảng MuonTra (NgayTra = ngày trả thực tế, NULL = chưa trả) ----------
            // string whereA = overdue
            //     ? "WHERE mt.NgayTra IS NULL AND mt.HanTra < CAST(GETDATE() AS DATE)"
            //     : "WHERE mt.NgayTra IS NULL";
            // string sqlA = $@"
            //     SELECT 
            //         mt.MaMT,
            //         sv.MaSV, sv.TenSV,
            //         mt.MaSach, s.TenSach,
            //         mt.NgayMuon,
            //         mt.HanTra,
            //         DATEDIFF(DAY, CAST(GETDATE() AS DATE), mt.HanTra) AS SoNgayConLai,
            //         CASE WHEN mt.NgayTra IS NULL AND mt.HanTra < CAST(GETDATE() AS DATE) THEN N'Quá hạn'
            //              WHEN mt.NgayTra IS NULL THEN N'Đang mượn'
            //              ELSE N'Đã trả' END AS TinhTrang
            //     FROM MuonTra mt
            //     JOIN SinhVien sv ON sv.MaSV = mt.MaSV
            //     JOIN Sach s ON s.MaSach = mt.MaSach
            //     {whereA}
            //     ORDER BY mt.HanTra ASC, mt.NgayMuon DESC;";

            // ---------- Lựa chọn B: Bảng MuonTraSach (NgayTra = hạn trả, không có ngày trả thực tế) ----------
            string whereB = overdue
                ? "WHERE m.NgayTra < CAST(GETDATE() AS DATE)"
                : "WHERE m.NgayTra >= CAST(GETDATE() AS DATE)";

            string sqlB = $@"
                IF OBJECT_ID('MuonTraSach') IS NULL
                BEGIN
                    SELECT TOP 0 CAST(NULL AS INT) AS MaPhieuMuon, CAST(NULL AS NVARCHAR(20)) AS MaSV, CAST(NULL AS NVARCHAR(100)) AS TenSV,
                                 CAST(NULL AS NVARCHAR(20)) AS MaSach, CAST(NULL AS NVARCHAR(200)) AS TenSach,
                                 CAST(NULL AS DATE) AS NgayMuon, CAST(NULL AS DATE) AS HanTra,
                                 CAST(NULL AS INT) AS SoNgayConLai, CAST(NULL AS NVARCHAR(20)) AS TinhTrang;
                END
                ELSE
                BEGIN
                    SELECT 
                        m.MaPhieuMuon,
                        m.MaSV,
                        sv.TenSV,
                        m.MaSach,
                        s.TenSach,
                        m.NgayMuon,
                        m.NgayTra AS HanTra,
                        DATEDIFF(DAY, CAST(GETDATE() AS DATE), m.NgayTra) AS SoNgayConLai,
                        CASE WHEN m.NgayTra < CAST(GETDATE() AS DATE) THEN N'Quá hạn'
                             ELSE N'Đang mượn' END AS TinhTrang
                    FROM MuonTraSach m
                    JOIN SinhVien sv ON sv.MaSV = m.MaSV
                    JOIN Sach s ON s.MaSach = m.MaSach
                    {whereB}
                    ORDER BY m.NgayTra ASC, m.NgayMuon DESC;
                END";

            // === chọn A hay B ===
            // var dt = GetDataTable(sqlA);
            var dt = GetDataTable(sqlB);

            dgvThongKe.DataSource = dt;

            if (dgvThongKe.Columns.Contains("NgayMuon"))
                dgvThongKe.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvThongKe.Columns.Contains("HanTra"))
                dgvThongKe.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";

          
        }

        private void LoadBooksCatalogIntoGrid()
        {
            // Chính là query bạn đang có:
            string sql = @"
                SELECT S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong
                FROM LoaiSach LS
                JOIN Sach S ON LS.MaLoai = S.MaLoai
                JOIN NhaXuatBan XB ON XB.MaXB = S.MaXB
                JOIN TacGia TG ON TG.MaTacGia = S.MaTacGia
                ORDER BY S.TenSach ASC;";
            var dt = GetDataTable(sql);
            // dgvThongKe.DataSource = dt; // mở dòng này nếu muốn xem danh mục thay vì danh sách mượn
        }

        private void btnDangMuon_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBorrowList(false);
                HighlightFilterButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đang mượn.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuaHan_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBorrowList(true);
                HighlightFilterButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách quá hạn.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightFilterButtons()
        {
            if (_isOverdue)
            {
                btnQuaHan.BackColor = System.Drawing.Color.MediumSeaGreen;
                btnQuaHan.ForeColor = System.Drawing.Color.White;
                btnDangMuon.BackColor = System.Drawing.Color.Gainsboro;
                btnDangMuon.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                btnDangMuon.BackColor = System.Drawing.Color.MediumSeaGreen;
                btnDangMuon.ForeColor = System.Drawing.Color.White;
                btnQuaHan.BackColor = System.Drawing.Color.Gainsboro;
                btnQuaHan.ForeColor = System.Drawing.Color.Black;
            }
        }

        // Xoá các handler rỗng cũ: frmThongKe_Load, button1_Click, button3_Click, textBox1_TextChanged, tileSinhVien_Paint nếu không dùng.
    }
}
