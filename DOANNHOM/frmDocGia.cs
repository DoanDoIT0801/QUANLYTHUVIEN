using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmDocGia : Form
    {
        string connectionString = "data source=LAPTOP-66PONRPJ\\SQLEXPRESS;initial catalog=QuanLyThuVienDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        public frmDocGia()
        {
            InitializeComponent();
        }

        //  Khi form mở lên, load dữ liệu ban đầu
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm tải lại toàn bộ dữ liệu từ bảng SinhVien
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SinhVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDocGia.DataSource = dt; // hiển thị lên DataGridView
            }
        }

        // Nút Thêm dữ liệu mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO SinhVien (MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai) VALUES (@Ma, @Ten, @Nganh, @Khoa, @SDT)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Gán dữ liệu từ textbox vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@Ma", txtMaSV.Text.Trim());
                cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text.Trim());
                cmd.Parameters.AddWithValue("@Nganh", txtNganhHoc.Text.Trim());
                cmd.Parameters.AddWithValue("@Khoa", txtKhoaHoc.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật lại bảng
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        // Nút Sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE SinhVien SET TenSV=@Ten, NganhHoc=@Nganh, KhoaHoc=@Khoa, SoDienThoai=@SDT WHERE MaSV=@Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Ma", txtMaSV.Text.Trim());
                cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text.Trim());
                cmd.Parameters.AddWithValue("@Nganh", txtNganhHoc.Text.Trim());
                cmd.Parameters.AddWithValue("@Khoa", txtKhoaHoc.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Không tìm thấy mã sinh viên để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        // Nút Xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM SinhVien WHERE MaSV=@Ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaSV.Text.Trim());

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không tìm thấy mã sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        // Nút Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM SinhVien WHERE 1=1";

                if (rbTimTheoMa.Checked)
                    sql += " AND MaSV LIKE @TuKhoa";
                else if (rbTimTheoTen.Checked)
                    sql += " AND TenSV LIKE @TuKhoa";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDocGia.DataSource = dt;
            }
        }

        // Khi nhấn vào một dòng trong DataGridView, dữ liệu sẽ tự động đổ lên textbox
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo không nhấn vào tiêu đề
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtTenSV.Text = row.Cells["TenSV"].Value?.ToString();
                txtNganhHoc.Text = row.Cells["NganhHoc"].Value?.ToString();
                txtKhoaHoc.Text = row.Cells["KhoaHoc"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            }
        }

        // Nút Thoát
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
