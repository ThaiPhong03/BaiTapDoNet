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

namespace TVSACH1
{
    public partial class F5_QuanLyTacGia : Form
    {
        private string chuyennut = ""; 
        public F5_QuanLyTacGia()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Vohieutextbox();
            HienThiDS();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void Vohieutextbox()
        {
            txtMaTG.Enabled = txtTenTG.Enabled = txtDiachi.Enabled = false;
        }
        private void Kichhoattextbox()
        {
            txtMaTG.Enabled = txtTenTG.Enabled = txtDiachi.Enabled = true;
        }
        private void Xoatextbox()
        {
            txtTenTG.Clear();
            txtMaTG.Clear();
            txtDiachi.Clear();
        }

        private void dtgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach.CurrentRow != null)
            {
                txtMaTG.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTenTG.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtDiachi.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Xoatextbox();
            Vohieutextbox();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void HienThiDS()
        {
            dtgvDanhsach.DataSource = KetNoiDL.GetTable("select * from QLTacGia");
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Mã Tác Giả";
            dtgvDanhsach.Columns[1].HeaderText = "Tên Tác Giả";
            dtgvDanhsach.Columns[2].HeaderText = "Địa Chỉ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void luu_them()
        {
            string maTG = txtMaTG.Text;
            string tenTG = txtTenTG.Text;
            string diaChi = txtDiachi.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maTG) || string.IsNullOrWhiteSpace(tenTG) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tác giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Kiểm tra mã tác giả trùng lặp
                string sqlTrungMaTG = "SELECT COUNT(*) FROM QLTacGia WHERE MaTG = @MaTG";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTG", maTG)
                };

                bool ktMaTG = KetNoiDL.TrungLap(sqlTrungMaTG, parameters);

                if (ktMaTG)
                {
                    DialogResult result = MessageBox.Show("Mã Tác Giả đã tồn tại. Bạn có muốn tiếp tục nhập thông tin mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
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

                // Thêm tác giả mới vào cơ sở dữ liệu
                string insertQuery = "INSERT INTO QLTacGia (MaTG, TenTG, DiaChi) VALUES (@MaTG, @TenTG, @DiaChi)";
                SqlParameter[] insertParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTG", maTG),
                    new SqlParameter("@TenTG", tenTG),
                    new SqlParameter("@DiaChi", diaChi)
                };

                bool isAdded = KetNoiDL.AddEditDelete(insertQuery, insertParameters);

                if (isAdded)
                {
                    MessageBox.Show("Thêm Tác Giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();
                    Xoatextbox();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Tác Giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Bạn đã chọn chức năng Thêm Tác Giả. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQuaylai.Visible = btnLuu.Visible = true;
        }

        private void luu_sua()
        {
            string maTG = txtMaTG.Text;
            string tenTG = txtTenTG.Text;
            string diaChi = txtDiachi.Text;

            try
            {
                // Câu truy vấn UPDATE
                string updateQuery = "UPDATE QLTacGia SET TenTG = @TenTG, DiaChi = @DiaChi WHERE MaTG = @MaTG";

                // Tạo các tham số để thay thế cho các giá trị trong câu truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaTG", maTG),
            new SqlParameter("@TenTG", tenTG),
            new SqlParameter("@DiaChi", diaChi)
                };

                // Gọi phương thức AddEditDelete để thực hiện câu truy vấn
                bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, parameters);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thông tin Tác Giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS(); // Gọi lại phương thức hiển thị danh sách sau khi cập nhật
                    Xoatextbox(); // Xóa dữ liệu trong textbox
                    btnLuu.Visible = btnQuaylai.Visible = false;
                    btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật thông tin Tác Giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Bạn đã chọn chức năng Sửa Tác Giả. Vui lòng chỉnh sửa thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaTG.Enabled = false;
                btnLuu.Visible = btnQuaylai.Visible = true;
                btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Tác Giả để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

        }
        private void luu_xoa()
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dtgvDanhsach.SelectedRows.Count > 0)
            {
                string maTG = dtgvDanhsach.SelectedRows[0].Cells["MaTG"].Value.ToString();

                // Hiển thị hộp thoại xác nhận trước khi xoá
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin Tác Giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string deleteQuery = "DELETE FROM QLTacGia WHERE MaTG = @MaTG";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaTG", maTG)
                        };

                        // Gọi phương thức AddEditDelete để thực hiện câu truy vấn
                        bool isDeleted = KetNoiDL.AddEditDelete(deleteQuery, parameters);

                        if (isDeleted)
                        {
                            MessageBox.Show("Đã xoá thông tin Tác Giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDS();
                            Xoatextbox();
                            btnLuu.Visible = btnQuaylai.Visible = false;
                            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi xoá thông tin Tác Giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

                MessageBox.Show("Vui lòng chọn một Tác Giả để xoá thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            // Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dtgvDanhsach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Tác Giả cần xoá trước khi thực hiện xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bạn đã chọn chức năng Xoá Sách. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
