using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVSACH1
{
    public partial class F6_CapNhat : Form
    {
        private string chuyennut = ""; 
        public F6_CapNhat()
        {
            InitializeComponent();
            
        }
        private void Form4Capnhat_Load(object sender, EventArgs e)
        {
            Vohieutextbox();
            LoadCbMaTG();
            HienThiDS();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void Vohieutextbox()
        {
            txtMasach.Enabled = txtTensach.Enabled = txtMaloaisach.Enabled = txtSoluong.Enabled = cbTG.Enabled = false;
        }
        private void Kichhoattextbox()
        {
            txtMasach.Enabled = txtTensach.Enabled = txtMaloaisach.Enabled = txtSoluong.Enabled = cbTG.Enabled = true;
        }
        private void Xoatextbox()
        {
            txtMasach.Clear();
            txtTensach.Clear();
            txtMaloaisach.Clear();
            txtSoluong.Clear();
            //cbTG.Items.Clear();
        }
        private void dtgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach.CurrentRow != null)
            {
                txtMasach.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTensach.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtMaloaisach.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
                txtSoluong.Text = dtgvDanhsach.CurrentRow.Cells[3].Value.ToString();
                cbTG.Text = dtgvDanhsach.CurrentRow.Cells[4].Value.ToString();

            }
        }
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Xoatextbox();
            Vohieutextbox();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }
        private void LoadCbMaTG()
        {
            try
            {
                string query = "SELECT MaTG FROM QLTacGia";
                SqlDataReader reader = KetNoiDL.LayDuLieu(query);
                cbTG.Items.Clear();
                while (reader.Read())
                {
                    string maTG = reader["MaTG"].ToString();
                    cbTG.Items.Add(maTG);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDS()
        {
            dtgvDanhsach.DataSource = KetNoiDL.GetTable("select * from QLSach");
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Mã Sách";
            dtgvDanhsach.Columns[1].HeaderText = "Tên Sách";
            dtgvDanhsach.Columns[2].HeaderText = "Mã LS";
            dtgvDanhsach.Columns[3].HeaderText = "SL";
            dtgvDanhsach.Columns[4].HeaderText = "Mã TG";
        }
        private void luu_them()
        {
            string maSach = txtMasach.Text;
            string tenSach = txtTensach.Text;
            string maLoaiSach = txtMaloaisach.Text;
            string soLuong = txtSoluong.Text;
            string maTacGia = cbTG.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maSach) || string.IsNullOrWhiteSpace(tenSach) ||
                string.IsNullOrWhiteSpace(maLoaiSach) || string.IsNullOrWhiteSpace(soLuong) ||
                string.IsNullOrWhiteSpace(maTacGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                // Kiểm tra mã sách trùng lặp
                string sqlTrungMaSach = "SELECT COUNT(*) FROM QLSach WHERE MaSach = @MaSach";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", maSach)
                };

                bool ktMaSach = KetNoiDL.TrungLap(sqlTrungMaSach, parameters);

                if (ktMaSach)
                {
                    DialogResult result = MessageBox.Show("Mã sách đã tồn tại. Bạn có muốn tiếp tục nhập thông tin mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                string insertQuery = "INSERT INTO QLSach (MaSach, TenSach, MaLoaiSach, SoLuong, MaTG) " +
                                     "VALUES (@MaSach, @TenSach, @MaLoaiSach, @SoLuong, @MaTG)";

                SqlParameter[] insertParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", maSach),
                    new SqlParameter("@TenSach", tenSach),
                    new SqlParameter("@MaLoaiSach", maLoaiSach),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@MaTG", maTacGia)
                };

                bool isAdded = KetNoiDL.AddEditDelete(insertQuery, insertParameters);

                if (isAdded)
                {
                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();
                    Xoatextbox();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Bạn đã chọn chức năng Thêm Sách. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQuaylai.Visible = btnLuu.Visible = true;
        }
        private void luu_sua()
        {
            string maSach = txtMasach.Text;
            string tenSach = txtTensach.Text;
            string maLoaiSach = txtMaloaisach.Text;
            string soLuong = txtSoluong.Text;
            string maTacGia = cbTG.Text;

            try
            {
                // Câu truy vấn UPDATE
                string updateQuery = "UPDATE QLSach SET TenSach = @TenSach, MaLoaiSach = @MaLoaiSach, SoLuong = @SoLuong, MaTG = @MaTG WHERE MaSach = @MaSach";

                // Tạo các tham số để thay thế cho các giá trị trong câu truy vấn
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", maSach),
                    new SqlParameter("@TenSach", tenSach),
                    new SqlParameter("@MaLoaiSach", maLoaiSach),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@MaTG", maTacGia)
                };

                // Gọi phương thức AddEditDelete để thực hiện câu truy vấn
                bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, parameters);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDS();  // Cập nhật lại dữ liệu sau khi chỉnh sửa
                    Xoatextbox();  // Xóa dữ liệu trong các textbox
                    btnLuu.Visible = btnQuaylai.Visible = false;
                    btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật thông tin sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Bạn đã chọn chức năng Sửa Sách. Vui lòng chỉnh sửa thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMasach.Enabled = false;
                btnLuu.Visible = btnQuaylai.Visible = true;
                btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Sách để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void luu_xoa()
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dtgvDanhsach.SelectedRows.Count > 0)
            {
                string maSach = dtgvDanhsach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                // Hiện thị hộp thoại xác nhận trước khi xoá
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá thông tin sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = KetNoiDL.KetNoi())
                        {
                            connection.Open();

                            // Truy vấn xoá thông tin sách
                            string deleteQuery = "DELETE FROM QLSach WHERE MaSach = @MaSach";
                            SqlCommand command = new SqlCommand(deleteQuery, connection);
                            command.Parameters.AddWithValue("@MaSach", maSach);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Đã xoá thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn một sách để xoá thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            // Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dtgvDanhsach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Sách cần xoá trước khi thực hiện xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {   
                this.Hide();
            }  

        }

        private void Form4Capnhat_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
//DisableInputFields    vo o hiệu txtx
//EnableInputFields     kich hoạt txt
//ClearInputFields xoá txt