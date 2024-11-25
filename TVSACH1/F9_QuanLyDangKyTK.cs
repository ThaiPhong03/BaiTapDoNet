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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TVSACH1
{
    public partial class F9_QuanLyDangKyTK : Form
    {
        private string chuyennut = ""; 
        public F9_QuanLyDangKyTK()
        {
            InitializeComponent();

        }
        private void QuanLyDangKyTK_Load(object sender, EventArgs e)
        {
            Vohieutextbox();
            HienThiDS();
            LoadChucVu();

            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void Vohieutextbox()
        {
            txtTenTK.Enabled = txtMK.Enabled = false;
        }
        private void Kichhoattextbox()
        {
            txtTenTK.Enabled = txtMK.Enabled = true;
        }
        private void Xoatextbox()
        {
            txtTenTK.Clear();
            txtMK.Clear();
        }
        private void HienThiDS()
        {
            dtgvDanhsach.DataSource = KetNoiDL.GetTable("select * from QLTaiKhoan");
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Tài Khoản";
            dtgvDanhsach.Columns[1].HeaderText = "Mật Khẩu";
            dtgvDanhsach.Columns[2].HeaderText = "Chức Vụ";
        }
        private void LoadChucVu()
        {
            try
            {
                string query = "SELECT Chucvu FROM QLTaiKhoan";
                SqlDataReader reader = KetNoiDL.LayDuLieu(query);
                cbChucVu.Items.Clear();
                while (reader.Read())
                {
                    string chucVu = reader["Chucvu"].ToString();
                    cbChucVu.Items.Add(chucVu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach.CurrentRow != null)
            {
                txtTenTK.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtMK.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                cbChucVu.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
            }
        }
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Xoatextbox();
            Vohieutextbox();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void QuanLyDangKyTK_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void luu_them()
        {
            string TK = txtTenTK.Text;
            string MK = txtMK.Text;
            string CV = cbChucVu.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(TK) || string.IsNullOrWhiteSpace(MK) || string.IsNullOrWhiteSpace(CV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Kiểm tra trùng lặp tên tài khoản
                string sqlTrungTK = "SELECT COUNT(*) FROM QLTaiKhoan WHERE Taikhoan = @TK";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TK", TK)
                };

                bool ktTK = KetNoiDL.TrungLap(sqlTrungTK, parameters);

                if (ktTK)
                {
                    DialogResult rs = MessageBox.Show("Tên Tài Khoản đã tồn tại. Bạn có muốn tiếp tục nhập thông tin mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (rs == DialogResult.No)
                    {
                        Vohieutextbox();
                        btnLuu.Visible = false;
                        return;
                    }
                    else
                    {
                        Xoatextbox();
                        return;
                    }
                }
                // Thêm tài khoản mới vào cơ sở dữ liệu
                string insertQuery = "INSERT INTO QLTaiKhoan (Taikhoan, Matkhau, Chucvu) VALUES (@TK, @MK, @CV)";
                SqlParameter[] insertParameters = new SqlParameter[]
                {
                    new SqlParameter("@TK", TK),
                    new SqlParameter("@MK", MK),
                    new SqlParameter("@CV", CV)
                };

                bool isAdded = KetNoiDL.AddEditDelete(insertQuery, insertParameters);

                if (isAdded)
                {
                    MessageBox.Show("Thêm Tài Khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();
                    Xoatextbox();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Tài Khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            chuyennut = "Them";
            Kichhoattextbox();
            Xoatextbox();
            MessageBox.Show("Bạn đã chọn chức năng Thêm Tài Khoản. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQuaylai.Visible = btnLuu.Visible = true;
        }
        private void luu_sua()
        {
            string TK = txtTenTK.Text;
            string MK = txtMK.Text;
            string CV = cbChucVu.Text;

            try
            {
                string updateQuery = "UPDATE QLTaiKhoan SET Matkhau = @MK, Chucvu = @CV WHERE Taikhoan = @TK";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TK", TK),
                    new SqlParameter("@MK", MK),
                    new SqlParameter("@CV", CV)
                };
                bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, parameters);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thông tin Tài Khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();  
                    txtTenTK.Enabled = false; 
                    btnLuu.Visible = btnQuaylai.Visible = false;
                    btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật thông tin Tài Khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chuyennut = "Sua";
            if (dtgvDanhsach.SelectedRows.Count > 0)
            {
                Kichhoattextbox();
                MessageBox.Show("Bạn đã chọn chức năng Sửa Tài Khoản. Vui lòng chỉnh sửa thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenTK.Enabled = false;
                btnLuu.Visible = btnQuaylai.Visible = true;
                btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Tài Khoản để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void luu_xoa()
        {

            if (dtgvDanhsach.SelectedRows.Count > 0)
            {
                string tenTaiKhoanDangNhap = F2_DangNhap.TenTaiKhoanDangNhap;
                string taikhoan = dtgvDanhsach.SelectedRows[0].Cells["Taikhoan"].Value.ToString();
                if (taikhoan == tenTaiKhoanDangNhap)
                {
                    MessageBox.Show("Bạn không thể xoá tài khoản đang đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Ngăn không cho phép xoá tài khoản đang đăng nhập
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin Tài Khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = KetNoiDL.KetNoi())
                        {
                            connection.Open();

                            string deleteQuery = "DELETE FROM QLTaiKhoan WHERE Taikhoan = @TK";
                            SqlCommand command = new SqlCommand(deleteQuery, connection);
                            command.Parameters.AddWithValue("@TK", taikhoan);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Đã xoá thông tin Tài Khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDS();
                            Xoatextbox();
                            btnLuu.Visible = btnQuaylai.Visible = false;
                            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Thông báo lỗi nếu có
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Thông báo nếu không có dòng nào được chọn
                MessageBox.Show("Vui lòng chọn một tài khoản để xoá thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            // Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dtgvDanhsach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Tài Khoản cần xoá trước khi thực hiện xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bạn đã chọn chức năng Xoá Tài Khoản. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnLuu.Visible = btnQuaylai.Visible = true;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (chuyennut == "Them")
            {
                luu_them();
            }
            else if (chuyennut == "Sua")
            {
                luu_sua();
            }
            else if (chuyennut == "Xoa")
            {
                luu_xoa();
            }
        }
    }
}
