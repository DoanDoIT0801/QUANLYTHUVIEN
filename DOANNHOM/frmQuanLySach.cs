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
    public partial class frmQuanLySach : Form
    {
        string connectionString = "data source=LAPTOP-66PONRPJ\\SQLEXPRESS;initial catalog=QuanLyThuVienDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        DataTable dtSach;

        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            LoadData();

            // Set default radio button
            if (!rbLoaiSach.Checked && !rbTacGia.Checked && !rbNXB.Checked)
            {
                rbTenSach.Checked = true; // Hoặc chọn radio button mặc định khác
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, 
                                            S.SoTrang, S.GiaBan, S.SoLuong 
                                     FROM LoaiSach LS 
                                     JOIN Sach S ON LS.MaLoai = S.MaLoai 
                                     JOIN NhaXuatBan XB ON XB.MaXB = S.MaXB 
                                     JOIN TacGia TG ON TG.MaTacGia = S.MaTacGia";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtSach = new DataTable();
                    da.Fill(dtSach);
                    dgvDSTK.DataSource = dtSach;

                    // Tùy chỉnh hiển thị DataGridView
                    if (dgvDSTK.Columns.Count > 0)
                    {
                        dgvDSTK.Columns["TenSach"].HeaderText = "Tên Sách";
                        dgvDSTK.Columns["TenLoaiSach"].HeaderText = "Loại Sách";
                        dgvDSTK.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
                        dgvDSTK.Columns["TacGia"].HeaderText = "Tác Giả";
                        dgvDSTK.Columns["SoTrang"].HeaderText = "Số Trang";
                        dgvDSTK.Columns["GiaBan"].HeaderText = "Giá Bán";
                        dgvDSTK.Columns["SoLuong"].HeaderText = "Số Lượng";

                        dgvDSTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem()
        {
            if (dtSach == null || dtSach.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filterColumn = GetSelectedFilterColumn();
            string keyword = txtTK.Text.Trim();

            try
            {
                DataView dv = dtSach.DefaultView;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu không có từ khóa, hiển thị tất cả
                    dv.RowFilter = "";
                }
                else
                {
                    // Escape single quotes để tránh lỗi
                    keyword = keyword.Replace("'", "''");
                    dv.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, keyword);
                }

                dgvDSTK.DataSource = dv;

                // Hiển thị số kết quả tìm được (tùy chọn)
                // lblKetQua.Text = $"Tìm thấy {dv.Count} kết quả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedFilterColumn()
        {
            if (rbLoaiSach.Checked)
                return "TenLoaiSach";
            else if (rbTacGia.Checked)
                return "TacGia";
            else if (rbNXB.Checked)
                return "NhaXuatBan";
            else
                return "TenSach"; // Mặc định tìm theo tên sách
        }


        private void rbLoaiSach_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLoaiSach.Checked)
                TimKiem();
        }

        private void rbTacGia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTacGia.Checked)
                TimKiem();
        }

        private void rbNXB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNXB.Checked)
                TimKiem();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia frm = new frmDocGia();
            frm.Show();
            this.Hide();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia frm = new frmDocGia();
            frm.Show();
            this.Hide();
        }

        // Thêm nút làm mới dữ liệu (nếu cần)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTK.Clear();
            LoadData();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged_1(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnTheLoai_Click_1(object sender, EventArgs e)
        {
            frmLoaiSach frm = new frmLoaiSach();
            frm.Show();
            Hide();
        }
    }
}