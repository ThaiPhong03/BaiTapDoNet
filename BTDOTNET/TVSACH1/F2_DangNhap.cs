using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TVSACH1
{
    public partial class F2_DangNhap : Form
    {
        public static string TenTaiKhoanDangNhap;

        public F2_DangNhap()
        {
            InitializeComponent();
        }

        private bool CheckDangNhap(string taiKhoan, string matKhau)
        {
            bool ketQua = false;
            using (SqlConnection connection = KetNoiDL.KetNoi())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM QLTaiKhoan WHERE Taikhoan = @taiKhoan AND Matkhau = @matKhau", connection);
                    cmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);

                    int count = (int)cmd.ExecuteScalar();
                    ketQua = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return ketQua;
        }

        private string GetChucVu(string taiKhoan)
        {
            string chucVu = "";
            using (SqlConnection connection = KetNoiDL.KetNoi())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Chucvu FROM QLTaiKhoan WHERE Taikhoan = @taiKhoan", connection);
                    cmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        chucVu = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return chucVu;
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTK.Text;
            string matKhau = txtMK.Text;

            if (CheckDangNhap(taiKhoan, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenTaiKhoanDangNhap = taiKhoan;
                string chucVu = GetChucVu(taiKhoan);

                if (!string.IsNullOrEmpty(chucVu))
                {
                    F3_TrangChu f = new F3_TrangChu(chucVu);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin chức vụ cho tài khoản này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
