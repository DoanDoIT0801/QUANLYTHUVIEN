using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANNHOM
{
    public partial class frmQLNhanVien : Form
    {
        string connectionString = "data source=LAPTOP-9GGQMNJG\\SQLEXPRESS;initial catalog=QuanLyThuVienDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

        string imagePath = ""; // Lưu đường dẫn ảnh tạm thời

        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        // Khi form được tải, hiển thị dữ liệu
        private void frmQLNhanVien_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        // ------------------ HÀM LOAD DỮ LIỆU ------------------
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanVien"; // Lấy tất cả nhân viên
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNV.DataSource = dt;
            }
        }

        // ------------------ NÚT THÊM (ĐĂNG KÝ) ------------------
        private void btnDK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng mã
                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text.Trim());
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!");
                        return;
                    }

                    // Thêm nhân viên mới
                    string insertQuery = @"INSERT INTO NhanVien (MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, GioiTinh, MatKhau)
                                           VALUES (@MaNhanVien, @TenNhanVien, @SoDienThoai, @DiaChi, @GioiTinh, @MatKhau)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên mới thành công!");
                }

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        // ------------------ NÚT SỬA (ĐỔI MẬT KHẨU) ------------------
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE NhanVien
                                           SET TenNhanVien = @TenNhanVien, 
                                               SoDienThoai = @SoDienThoai, 
                                               DiaChi = @DiaChi,
                                               GioiTinh = @GioiTinh, 
                                               MatKhau = @MatKhau
                                           WHERE MaNhanVien = @MaNhanVien";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text.Trim());

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Cập nhật nhân viên thành công!");
                    else
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật!");
                }

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        // ------------------ NÚT XÓA ------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text.Trim());
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Xóa nhân viên thành công!");
                    else
                        MessageBox.Show("Không tìm thấy nhân viên cần xóa!");
                }

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        // ------------------ NÚT THOÁT ------------------
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ------------------ CHỌN DÒNG TRONG DATAGRIDVIEW ------------------
        private void dgvNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value?.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtMK.Text = row.Cells["MatKhau"].Value?.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                if (gioiTinh == "Nam") rdNam.Checked = true;
                else rdNu.Checked = true;
            }
        }

        // ------------------ HÀM XÓA DỮ LIỆU TRÊN FORM ------------------
        private void ClearInput()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMK.Clear();
            rdNam.Checked = false;
            rdNu.Checked = false;
        }

        
    }
}
