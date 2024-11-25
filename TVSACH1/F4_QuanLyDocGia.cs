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
    public partial class F4_QuanLyDocGia : Form
    {
        private string chuyennut = "";
        private DataTable dt;
        public F4_QuanLyDocGia()
        {
            InitializeComponent();
        }
        public void HienThiCB()
        {
            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbGioiTinh.SelectedIndex = 0;
        }
        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            Vohieutextbox();
            HienThiCB();
            HienThiDS();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void Vohieutextbox()
        {

            txtMaDG.Enabled = txtTenDG.Enabled = cbGioiTinh.Enabled = dtpkNgaymuon.Enabled = txtDiachi.Enabled = false;
        }
        private void Kichhoattextbox()
        {
            // Kích hoạt các ô nhập liệu
            txtMaDG.Enabled = txtTenDG.Enabled = cbGioiTinh.Enabled = dtpkNgaymuon.Enabled = txtDiachi.Enabled = true;
        }
        private void Xoatextbox()
        {
            txtMaDG.Clear();
            txtTenDG.Clear();
            //txtGioitinh.Clear();
            dtpkNgaymuon.Value = DateTime.Today;
            txtDiachi.Clear();
        }
        private void HienThiDS()
        {
            dtgvDanhsach.DataSource =  KetNoiDL.GetTable("select * from QLNguoiMuon");
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Mã DG";
            dtgvDanhsach.Columns[1].HeaderText = "Tên DG";
            dtgvDanhsach.Columns[2].HeaderText = "GT";
            dtgvDanhsach.Columns[3].HeaderText = "Ngày Tạo";
            dtgvDanhsach.Columns[4].HeaderText = "Địa Chỉ";
        }
        private void dtgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach.CurrentRow != null)
            {
                txtMaDG.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTenDG.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                cbGioiTinh.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
                DateTime ngayMuon = Convert.ToDateTime(dtgvDanhsach.CurrentRow.Cells[3].Value);
                dtpkNgaymuon.Value = ngayMuon;
                txtDiachi.Text = dtgvDanhsach.CurrentRow.Cells[4].Value.ToString();
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
        private void QuanLyDocGia_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void luu_them()
        {
            string maDG = txtMaDG.Text;
            string tenDG = txtTenDG.Text;
            string GT = cbGioiTinh.Text;
            string ngayMuon = dtpkNgaymuon.Value.ToString("yyyy-MM-dd");
            string Diachi = txtDiachi.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maDG) || string.IsNullOrWhiteSpace(tenDG) || string.IsNullOrWhiteSpace(GT) || string.IsNullOrWhiteSpace(ngayMuon) || string.IsNullOrWhiteSpace(Diachi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Kiểm tra mã độc giả trùng lặp
                string sqlTrungMaDG = "SELECT COUNT(*) FROM QLNguoiMuon WHERE MaDG = @MaDG";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaDG", maDG)
                };

                bool ktMaDG = KetNoiDL.TrungLap(sqlTrungMaDG, parameters);

                if (ktMaDG)
                {
                    DialogResult rs = MessageBox.Show("Mã Độc Giả đã tồn tại. Bạn có muốn tiếp tục nhập thông tin mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                // Thêm độc giả mới vào cơ sở dữ liệu
                string insertQuery = "INSERT INTO QLNguoiMuon (MaDG, TenDocGia, GioiTinh, NgayMuon, DiaChi) " +
                                     "VALUES (@MaDG, @TenDocGia, @GioiTinh, @NgayMuon, @DiaChi)";

                SqlParameter[] insertParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDG", maDG),
                    new SqlParameter("@TenDocGia", tenDG),
                    new SqlParameter("@GioiTinh", GT),
                    new SqlParameter("@NgayMuon", ngayMuon),
                    new SqlParameter("@DiaChi", Diachi)
                };

                bool isAdded = KetNoiDL.AddEditDelete(insertQuery, insertParameters);

                if (isAdded)
                {
                    MessageBox.Show("Thêm Độc Giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();
                    Xoatextbox();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm Độc Giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Bạn đã chọn chức năng Thêm Độc Giả. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQuaylai.Visible = btnLuu.Visible = true;
        }
        private void luu_sua()
        {
            string maDG = txtMaDG.Text;
            string tenDG = txtTenDG.Text;
            string GT = cbGioiTinh.Text;
            string ngayMuon = dtpkNgaymuon.Value.ToString("yyyy-MM-dd"); // Định dạng ngày thành chuỗi yyyy-MM-dd
            string Diachi = txtDiachi.Text;

            try
            {
                // Câu truy vấn UPDATE
                string updateQuery = "UPDATE QLNguoiMuon SET TenDocGia = @TenDocGia, GioiTinh = @GioiTinh, NgayMuon = @NgayMuon, DiaChi = @DiaChi WHERE MaDG = @MaDG";

                // Tạo các tham số để thay thế cho các giá trị trong câu truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDG", maDG),
                    new SqlParameter("@TenDocGia", tenDG),
                    new SqlParameter("@GioiTinh", GT),
                    new SqlParameter("@NgayMuon", ngayMuon),
                    new SqlParameter("@DiaChi", Diachi)
                };

                // Gọi phương thức AddEditDelete để thực hiện câu truy vấn
                bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, parameters);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();  // Gọi lại phương thức hiển thị danh sách sau khi cập nhật
                    Xoatextbox();  // Xóa dữ liệu trong textbox
                    btnLuu.Visible = btnQuaylai.Visible = false;
                    btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật thông tin độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Lấy giá trị từ các ô của dòng đó và hiển thị lên các TextBox tương ứng
                MessageBox.Show("Bạn đã chọn chức năng Sửa Độc Giả. Vui lòng chỉnh sửa thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaDG.Enabled = false;
                btnLuu.Visible = btnQuaylai.Visible = true;
                btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Độc Giả để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }
        private void luu_xoa()
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dtgvDanhsach.SelectedRows.Count > 0)
            {
                string maDG = dtgvDanhsach.SelectedRows[0].Cells["MaDG"].Value.ToString();

                // Hiện thị hộp thoại xác nhận trước khi xoá
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin độc giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = KetNoiDL.KetNoi())
                        {
                            connection.Open();

                            // Truy vấn xoá thông tin độc giả
                            string deleteQuery = "DELETE FROM QLNguoiMuon WHERE MaDG = @MaDG";
                            SqlCommand command = new SqlCommand(deleteQuery, connection);
                            command.Parameters.AddWithValue("@MaDG", maDG);
                            command.ExecuteNonQuery();

                            // Thông báo thành công
                            MessageBox.Show("Đã xoá thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại danh sách
                            HienThiDS();

                            // Xoá các TextBox và nút hiển thị
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
                MessageBox.Show("Vui lòng chọn một độc giả để xoá thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            // Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dtgvDanhsach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Độc Giả cần xoá trước khi thực hiện xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bạn đã chọn chức năng Xoá Độc Giả. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
