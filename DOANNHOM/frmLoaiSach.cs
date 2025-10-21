using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmLoaiSach : Form
    {
        string connectionString = "data source=LAPTOP-66PONRPJ\\SQLEXPRESS;initial catalog=QuanLyThuVienDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        DataTable dtSach;

        public frmLoaiSach()
        {
            InitializeComponent();
        }

        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvLS.CellClick += dgvLS_CellClick;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT S.MaSach, S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, 
                                            S.SoTrang, S.GiaBan, S.SoLuong,
                                            S.MaLoai, S.MaXB, S.MaTacGia
                                     FROM LoaiSach LS 
                                     JOIN Sach S ON LS.MaLoai = S.MaLoai 
                                     JOIN NhaXuatBan XB ON XB.MaXB = S.MaXB 
                                     JOIN TacGia TG ON TG.MaTacGia = S.MaTacGia";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtSach = new DataTable();
                    da.Fill(dtSach);
                    dgvLS.DataSource = dtSach;

                    if (dgvLS.Columns.Count > 0)
                    {
                        dgvLS.Columns["MaSach"].Visible = false;
                        dgvLS.Columns["MaLoai"].Visible = false;
                        dgvLS.Columns["MaXB"].Visible = false;
                        dgvLS.Columns["MaTacGia"].Visible = false;

                        dgvLS.Columns["TenSach"].HeaderText = "Tên Sách";
                        dgvLS.Columns["TenLoaiSach"].HeaderText = "Loại Sách";
                        dgvLS.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
                        dgvLS.Columns["TacGia"].HeaderText = "Tác Giả";
                        dgvLS.Columns["SoTrang"].HeaderText = "Số Trang";
                        dgvLS.Columns["GiaBan"].HeaderText = "Giá Bán";
                        dgvLS.Columns["SoLuong"].HeaderText = "Số Lượng";

                        dgvLS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvLS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvLS.MultiSelect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === HÀM CHUẨN HÓA ===

        // THAY ĐỔI: Đổi kiểu trả về từ int sang string và thêm MaLoai vào INSERT
        private string GetOrCreateLoaiSach(SqlConnection conn, string tenLoaiSach)
        {
            if (string.IsNullOrWhiteSpace(tenLoaiSach))
                return "L1";

            string selectQuery = "SELECT MaLoai FROM LoaiSach WHERE TenLoaiSach = @TenLoaiSach";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenLoaiSach", tenLoaiSach.Trim());
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return result.ToString();

                // Tạo mã loại sách mới theo format L1, L2, L3...
                string insertQuery = @"
                    DECLARE @NewMa INT = (SELECT ISNULL(MAX(CAST(REPLACE(MaLoai, 'L', '') AS INT)), 0) + 1 
                                          FROM LoaiSach 
                                          WHERE MaLoai LIKE 'L%' AND ISNUMERIC(REPLACE(MaLoai, 'L', '')) = 1);
                    DECLARE @NewCode NVARCHAR(10) = 'L' + CAST(@NewMa AS NVARCHAR(10));
                    INSERT INTO LoaiSach (MaLoai, TenLoaiSach, GhiChu)
                    VALUES (@NewCode, @TenLoaiSach, N'khong');
                    SELECT @NewCode;";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@TenLoaiSach", tenLoaiSach.Trim());
                    return insertCmd.ExecuteScalar().ToString();
                }
            }
        }

        private string GetOrCreateNhaXuatBan(SqlConnection conn, string tenNXB)
        {
            if (string.IsNullOrWhiteSpace(tenNXB))
                return "4XB1";

            string selectQuery = "SELECT MaXB FROM NhaXuatBan WHERE NhaXuatBan = @TenNXB";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenNXB", tenNXB.Trim());
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return result.ToString();

                string insertQuery = @"
                    DECLARE @NewMa INT = (SELECT ISNULL(MAX(CAST(REPLACE(MaXB, '4XB', '') AS INT)), 0) + 1 FROM NhaXuatBan);
                    DECLARE @NewCode NVARCHAR(10) = '4XB' + CAST(@NewMa AS NVARCHAR(10));
                    INSERT INTO NhaXuatBan (MaXB, NhaXuatBan, GhiChu)
                    VALUES (@NewCode, @TenNXB, N'khong');
                    SELECT @NewCode;";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@TenNXB", tenNXB);
                    return insertCmd.ExecuteScalar().ToString();
                }
            }
        }

        private string GetOrCreateTacGia(SqlConnection conn, string tenTacGia)
        {
            if (string.IsNullOrWhiteSpace(tenTacGia))
                return "TG1";

            string selectQuery = "SELECT MaTacGia FROM TacGia WHERE TacGia = @TenTacGia";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenTacGia", tenTacGia.Trim());
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return result.ToString();

                string insertQuery = @"
                    DECLARE @NewMa INT = (SELECT ISNULL(MAX(CAST(REPLACE(MaTacGia, 'TG', '') AS INT)), 0) + 1 FROM TacGia);
                    DECLARE @NewCode NVARCHAR(10) = 'TG' + CAST(@NewMa AS NVARCHAR(10));
                    INSERT INTO TacGia (MaTacGia, TacGia, GhiChu)
                    VALUES (@NewCode, @TenTacGia, N'khong');
                    SELECT @NewCode;";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                    return insertCmd.ExecuteScalar().ToString();
                }
            }
        }

        private void ClearTextBoxes()
        {
            txtTenSach.Clear();
            txtLoaiSach.Clear();
            txtNhaXuatBan.Clear();
            txtTacGia.Clear();
            txtGiaBan.Clear();
            txtSoTrang.Clear();
            txtSoLuong.Clear();
            txtTenSach.Focus();
        }

        private void dgvLS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header hoặc dòng không hợp lệ
                if (e.RowIndex < 0)
                    return;

                // Lấy dòng được chọn
                DataGridViewRow row = dgvLS.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                txtTenSach.Text = row.Cells["TenSach"].Value?.ToString() ?? "";
                txtLoaiSach.Text = row.Cells["TenLoaiSach"].Value?.ToString() ?? "";
                txtNhaXuatBan.Text = row.Cells["NhaXuatBan"].Value?.ToString() ?? "";
                txtTacGia.Text = row.Cells["TacGia"].Value?.ToString() ?? "";
                txtSoTrang.Text = row.Cells["SoTrang"].Value?.ToString() ?? "";
                txtGiaBan.Text = row.Cells["GiaBan"].Value?.ToString() ?? "";
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



     
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenSach.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sách!");
                    return;
                }

                int soTrang = 0;
                int.TryParse(txtSoTrang.Text.Trim(), out soTrang);

                int soLuong = 0;
                int.TryParse(txtSoLuong.Text.Trim(), out soLuong);

                // SỬA: Đổi từ decimal sang int
                int giaBan = 0;
                int.TryParse(txtGiaBan.Text.Trim(), out giaBan);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string maLoai = GetOrCreateLoaiSach(conn, txtLoaiSach.Text);
                    string maXB = GetOrCreateNhaXuatBan(conn, txtNhaXuatBan.Text);
                    string maTacGia = GetOrCreateTacGia(conn, txtTacGia.Text);

                    string query = @"
                DECLARE @NewMa INT = (
                    SELECT ISNULL(MAX(CAST(REPLACE(MaSach, 'S', '') AS INT)), 0) + 1 
                    FROM Sach 
                    WHERE MaSach LIKE 'S[0-9]%' 
                    AND ISNUMERIC(REPLACE(MaSach, 'S', '')) = 1
                );
                INSERT INTO Sach (MaSach, TenSach, MaLoai, MaXB, MaTacGia, SoTrang, GiaBan, SoLuong) 
                VALUES ('S' + CAST(@NewMa AS VARCHAR(10)), @TenSach, @MaLoai, @MaXB, @MaTacGia, @SoTrang, @GiaBan, @SoLuong)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                        cmd.Parameters.AddWithValue("@MaXB", maXB);
                        cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                        cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                        cmd.Parameters.AddWithValue("@GiaBan", giaBan);  // Đã đổi thành int
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sách thành công!");
                        LoadData();
                        ClearTextBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvLS.CurrentRow == null || dgvLS.CurrentRow.Index < 0)
                {
                    MessageBox.Show("Vui lòng chọn sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenSach.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soTrang = 0;
                int.TryParse(txtSoTrang.Text.Trim(), out soTrang);

                int soLuong = 0;
                int.TryParse(txtSoLuong.Text.Trim(), out soLuong);

                // SỬA: Đổi từ decimal sang int
                int giaBan = 0;
                int.TryParse(txtGiaBan.Text.Trim(), out giaBan);

                string maSach = dgvLS.CurrentRow.Cells["MaSach"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string maLoai = GetOrCreateLoaiSach(conn, txtLoaiSach.Text);
                    string maXB = GetOrCreateNhaXuatBan(conn, txtNhaXuatBan.Text);
                    string maTacGia = GetOrCreateTacGia(conn, txtTacGia.Text);

                    string query = @"UPDATE Sach 
                            SET TenSach = @TenSach, 
                                MaLoai = @MaLoai, 
                                MaXB = @MaXB, 
                                MaTacGia = @MaTacGia, 
                                SoTrang = @SoTrang, 
                                GiaBan = @GiaBan, 
                                SoLuong = @SoLuong 
                            WHERE MaSach = @MaSach";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                        cmd.Parameters.AddWithValue("@MaXB", maXB);
                        cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                        cmd.Parameters.AddWithValue("@SoTrang", soTrang);
                        cmd.Parameters.AddWithValue("@GiaBan", giaBan);  // Đã đổi thành int
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvLS.CurrentRow == null || dgvLS.CurrentRow.Index < 0)
                {
                    MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSach = dgvLS.CurrentRow.Cells["MaSach"].Value.ToString();
                string tenSach = dgvLS.CurrentRow.Cells["TenSach"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sách '{tenSach}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Sach WHERE MaSach = @MaSach";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSach", maSach);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Không thể xóa sách này vì đang được sử dụng trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát không?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu ô tìm kiếm rỗng, hiển thị tất cả
                    LoadData();
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Tìm kiếm theo tên sách, loại sách, nhà xuất bản, tác giả
                    string query = @"SELECT S.MaSach, S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, 
                                    S.SoTrang, S.GiaBan, S.SoLuong,
                                    S.MaLoai, S.MaXB, S.MaTacGia
                             FROM LoaiSach LS 
                             JOIN Sach S ON LS.MaLoai = S.MaLoai 
                             JOIN NhaXuatBan XB ON XB.MaXB = S.MaXB 
                             JOIN TacGia TG ON TG.MaTacGia = S.MaTacGia
                             WHERE LOWER(S.TenSach) LIKE @Keyword 
                                OR LOWER(LS.TenLoaiSach) LIKE @Keyword 
                                OR LOWER(XB.NhaXuatBan) LIKE @Keyword 
                                OR LOWER(TG.TacGia) LIKE @Keyword
                                OR CAST(S.GiaBan AS NVARCHAR) LIKE @Keyword
                                OR CAST(S.SoLuong AS NVARCHAR) LIKE @Keyword";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    DataTable dtSearch = new DataTable();
                    da.Fill(dtSearch);
                    dgvLS.DataSource = dtSearch;

                    // Cập nhật tiêu đề cột (vì đã load lại data)
                    if (dgvLS.Columns.Count > 0)
                    {
                        dgvLS.Columns["MaSach"].Visible = false;
                        dgvLS.Columns["MaLoai"].Visible = false;
                        dgvLS.Columns["MaXB"].Visible = false;
                        dgvLS.Columns["MaTacGia"].Visible = false;

                        dgvLS.Columns["TenSach"].HeaderText = "Tên Sách";
                        dgvLS.Columns["TenLoaiSach"].HeaderText = "Loại Sách";
                        dgvLS.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
                        dgvLS.Columns["TacGia"].HeaderText = "Tác Giả";
                        dgvLS.Columns["SoTrang"].HeaderText = "Số Trang";
                        dgvLS.Columns["GiaBan"].HeaderText = "Giá Bán";
                        dgvLS.Columns["SoLuong"].HeaderText = "Số Lượng";
                    }

                    // Hiển thị số kết quả tìm được (tùy chọn)
                    if (dtSearch.Rows.Count == 0)
                    {
                        // Có thể thêm label để hiển thị thông báo
                        // lblThongBao.Text = "Không tìm thấy kết quả phù hợp!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}