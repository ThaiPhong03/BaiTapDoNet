using System;
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
    public partial class F7_MuonTra : Form
    {
        //private string ketnoi = "Data Source=NờTêPê\\THAIPHONG;Initial Catalog=QLTVS;Integrated Security=True;Encrypt=False";
        private string chuyennut = ""; // Biến để xác định chức năng đang được thực hiện
        public F7_MuonTra()
        {
            InitializeComponent();


            HienThiDanhSach();
            LoadCbTenSach();
            LoadCbMaDG();
            Vohieutextbox();
            HienThiTraSach();

        }
        private void Vohieutextbox()
        {
            txtMasach.Enabled = txtMaloaisach.Enabled =txtSoluong.Enabled=txtMatacgia.Enabled= cbMadocgia.Enabled= txtMaSachChoMuon.Enabled= txtSLMuon.Enabled = false;
        }
        private void Xoatextbox()
        {
            txtSLMuon.Clear();
            dtpkNgaymuon.Value = DateTime.Today;
            dtpkNgayhentra.Value = DateTime.Today;

        }
        //11111111111111111111111111111111111111111111111111//
        private void btnThoatMuonSach_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void LoadCbTenSach()
        {
            try
            {
                string query = "SELECT TenSach FROM QLSach";
                SqlDataReader reader = KetNoiDL.LayDuLieu(query);
                cbTensach.Items.Clear();
                while (reader.Read())
                {
                    string maTG = reader["TenSach"].ToString();
                    cbTensach.Items.Add(maTG);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCbMaDG()
        {
            try
            {
                string query = "SELECT MaDG FROM QLNguoiMuon";
                SqlDataReader reader = KetNoiDL.LayDuLieu(query);
                cbMadocgia.Items.Clear();
                while (reader.Read())
                {
                    string maTG = reader["MaDG"].ToString();
                    cbMadocgia.Items.Add(maTG);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTensach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTenSach = cbTensach.SelectedItem.ToString();

            try
            {
                // Prepare the query with a parameter placeholder
                string query = "SELECT * FROM QLSach WHERE TenSach = @TenSach";

                // Use an SqlParameter for the TenSach value
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSach", selectedTenSach)
                };

                // Retrieve data using GetTable with parameterized query
                DataTable dt = KetNoiDL.TimKiemm(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Populate the text boxes with data from the first row
                    DataRow row = dt.Rows[0];
                    txtMasach.Text = row["MaSach"].ToString();
                    txtMaloaisach.Text = row["MaLoaiSach"].ToString();
                    txtSoluong.Text = row["SoLuong"].ToString();
                    txtMatacgia.Text = row["MaTG"].ToString();
                    txtMaSachChoMuon.Text = row["MaSach"].ToString(); // Hiển thị MaSach vào txtMasachChomuon
                }
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
                    cbMadocgia.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                    txtMaSachChoMuon.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                    txtSLMuon.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
                    DateTime ngayMuon = Convert.ToDateTime(dtgvDanhsach.CurrentRow.Cells[3].Value);
                    dtpkNgaymuon.Value = ngayMuon;
                    DateTime ngayHenTra = Convert.ToDateTime(dtgvDanhsach.CurrentRow.Cells[4].Value);
                    dtpkNgayhentra.Value = ngayHenTra;
                } 
        }
        private void HienThiDanhSach()
        {
            try
            {
                // Query to check for records with NgayTra as NULL
                string query = "SELECT MaDG, MaSach, SoLuong, NgayMuon, NgayHenTra FROM QLMuonTraSach WHERE NgayTra IS NULL";

                // Retrieve data using GetTable method
                DataTable dataTable = KetNoiDL.GetTable(query);

                // Check if there are no rows with NgayTra as NULL
                if (dataTable.Rows.Count == 0)
                {
                    // If no results with NgayTra NULL, fetch all records
                    query = "SELECT MaDG, MaSach, SoLuong, NgayMuon, NgayHenTra FROM QLMuonTraSach";
                    dataTable = KetNoiDL.GetTable(query);
                }

                // Assign the DataTable to the DataGridView
                dtgvDanhsach.DataSource = dataTable;

                // Adjust column widths and headers
                dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtgvDanhsach.Columns[0].HeaderText = "Mã ĐG";
                dtgvDanhsach.Columns[1].HeaderText = "Mã Sách";
                dtgvDanhsach.Columns[2].HeaderText = "SL";
                dtgvDanhsach.Columns[3].HeaderText = "Ngày Mượn";
                dtgvDanhsach.Columns[4].HeaderText = "Ngày Hẹn Trả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void luu_chomuon()
        {
            // Retrieve information from the interface controls
            string maDG = cbMadocgia.Text;
            string maSach = txtMasach.Text;
            string soLuongMuonStr = txtSLMuon.Text;
            string ngayMuon = dtpkNgaymuon.Value.ToString("yyyy-MM-dd");
            string ngayHenTra = dtpkNgayhentra.Value.ToString("yyyy-MM-dd");

            // Validate and convert borrowing quantity from string to integer
            if (!int.TryParse(soLuongMuonStr, out int soLuongMuon) || soLuongMuon <= 0)
            {
                MessageBox.Show("Số lượng mượn không hợp lệ. Vui lòng nhập số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Check the current quantity of the book in the inventory
                string checkQuery = "SELECT SoLuong FROM QLSach WHERE MaSach = @MaSach";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", maSach)
                };
                DataTable resultTable = KetNoiDL.TimKiemm(checkQuery, checkParameters);

                if (resultTable.Rows.Count == 0 || !int.TryParse(resultTable.Rows[0]["SoLuong"].ToString(), out int soLuongHienCo))
                {
                    MessageBox.Show("Không tìm thấy sách hoặc dữ liệu số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verify if the requested quantity exceeds the available quantity
                if (soLuongMuon > soLuongHienCo)
                {
                    MessageBox.Show("Số lượng sách trong kho không đủ để cho mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update the quantity of books in the QLSach table
                string updateQuery = "UPDATE QLSach SET SoLuong = SoLuong - @SoLuongMuon WHERE MaSach = @MaSach";
                SqlParameter[] updateParameters = new SqlParameter[]
                {
            new SqlParameter("@SoLuongMuon", soLuongMuon),
            new SqlParameter("@MaSach", maSach)
                };
                bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, updateParameters);

                if (!isUpdated)
                {
                    MessageBox.Show("Có lỗi khi cập nhật số lượng sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add borrowing information to the QLMuonTraSach table
                string insertQuery = "INSERT INTO QLMuonTraSach (MaDG, MaSach, SoLuong, NgayMuon, NgayHenTra) VALUES (@MaDG, @MaSach, @SoLuongMuon, @NgayMuon, @NgayHenTra)";
                SqlParameter[] insertParameters = new SqlParameter[]
                {
            new SqlParameter("@MaDG", maDG),
            new SqlParameter("@MaSach", maSach),
            new SqlParameter("@SoLuongMuon", soLuongMuon),
            new SqlParameter("@NgayMuon", ngayMuon),
            new SqlParameter("@NgayHenTra", ngayHenTra)
                };
                bool isInserted = KetNoiDL.AddEditDelete(insertQuery, insertParameters);

                if (isInserted)
                {
                    // Update remaining quantity in the interface
                    txtSoluong.Text = (soLuongHienCo - soLuongMuon).ToString();
                    MessageBox.Show("Cho mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HienThiDanhSach(); 
                    Xoatextbox();
                    HienThiTraSach();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm thông tin mượn sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện cho mượn sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            chuyennut = "Them";
            cbMadocgia.Enabled = txtSLMuon.Enabled = true;
            Xoatextbox();
            MessageBox.Show("Bạn đã chọn chức năng Cho Mượn. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQuaylai.Visible = btnLuu.Visible = true;
        }
        private void capnhatSoLuongSach(string maSach, int soLuongMuonCu, int soLuongMuonMoi)
        {
            try
            {
                using (SqlConnection conn = KetNoiDL.KetNoi())
                {
                    conn.Open();

                    // Lấy số lượng hiện tại của sách
                    string sql = "SELECT SoLuong FROM QLSach WHERE MaSach = @MaSach";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    int soLuongHienTai = Convert.ToInt32(cmd.ExecuteScalar());

                    // Tính toán sự thay đổi số lượng mượn
                    int soLuongThayDoi = soLuongMuonMoi - soLuongMuonCu;

                    // Tính toán số lượng mới của sách
                    int soLuongMoi = soLuongHienTai + (soLuongMuonCu - soLuongMuonMoi);

                    // Đảm bảo số lượng mới không nhỏ hơn 0 và số lượng mượn mới là số dương lớn hơn 0
                    if (soLuongMoi >= 0 && soLuongMuonMoi > 0)
                    {
                        string updateQuery = "UPDATE QLSach SET SoLuong = @SoLuongMoi WHERE MaSach = @MaSach";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@SoLuongMoi", soLuongMoi),
                    new SqlParameter("@MaSach", maSach)
                        };
                        KetNoiDL.AddEditDelete(updateQuery, parameters);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng sách không đủ hoặc số lượng mượn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật số lượng sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void luu_sua()
        {
            string maDG = cbMadocgia.Text;
            string maSach = txtMaSachChoMuon.Text;
            int soLuongMuonMoi = Convert.ToInt32(txtSLMuon.Text);
            string ngayMuon = dtpkNgaymuon.Value.ToString("yyyy-MM-dd");
            string ngayHenTra = dtpkNgayhentra.Value.ToString("yyyy-MM-dd");

            try
            {
                using (SqlConnection conn = KetNoiDL.KetNoi())
                {
                    conn.Open();

                    // Lấy số lượng đã mượn hiện tại cho MaDG và MaSach cụ thể từ bảng QLMuonTraSach
                    string sql = "SELECT SoLuong FROM QLMuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaDG", maDG);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    object result = cmd.ExecuteScalar();
                    int soLuongMuonCu = (result == DBNull.Value) ? 0 : Convert.ToInt32(result);

                    // Kiểm tra nếu số lượng mượn mới là số nguyên dương lớn hơn 0
                    if (soLuongMuonMoi > 0)
                    {
                        // Cập nhật thông tin mượn sách trong bảng QLMuonTraSach
                        string updateQuery = "UPDATE QLMuonTraSach SET SoLuong = @SoLuong, NgayMuon = @NgayMuon, NgayHenTra = @NgayHenTra WHERE MaDG = @MaDG AND MaSach = @MaSach";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@SoLuong", soLuongMuonMoi),
                            new SqlParameter("@NgayMuon", ngayMuon),
                            new SqlParameter("@NgayHenTra", ngayHenTra),
                            new SqlParameter("@MaDG", maDG),
                            new SqlParameter("@MaSach", maSach)
                        };

                        bool isUpdated = KetNoiDL.AddEditDelete(updateQuery, parameters);

                        if (isUpdated)
                        {
                            // Cập nhật lại số lượng sách trong bảng QLSach
                            capnhatSoLuongSach(maSach, soLuongMuonCu, soLuongMuonMoi);

                            MessageBox.Show("Cập nhật thông tin cho mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Xoatextbox();
                            btnLuu.Visible = btnQuaylai.Visible = false;
                            btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = btnThoatMuonSach.Visible = true;
                            HienThiDanhSach();
                            LoadCbTenSach();
                            HienThiTraSach();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi cập nhật thông tin cho mượn sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mượn phải là số nguyên dương lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            txtSLMuon.Enabled = true;
            if (dtgvDanhsach.SelectedRows.Count > 0)
             {
                 MessageBox.Show("Bạn đã chọn chức năng Sửa Mượn Sách. Vui lòng chỉnh sửa thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 cbMadocgia.Enabled = txtMaSachChoMuon.Enabled = false;
                 btnLuu.Visible = btnQuaylai.Visible = true;
                 btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = false;
                
            }
             else
             {
                 MessageBox.Show("Vui lòng chọn một sách để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }
        private void luu_xoa()
        {
            string maDG = cbMadocgia.Text;
            string maSach = txtMaSachChoMuon.Text;
            int soLuongMuonMoi = Convert.ToInt32(txtSLMuon.Text);
            string ngayMuon = dtpkNgaymuon.Value.ToString("yyyy-MM-dd");
            string ngayHenTra = dtpkNgayhentra.Value.ToString("yyyy-MM-dd");

            try
            {
                using (SqlConnection conn = KetNoiDL.KetNoi())
                {
                    conn.Open();

                    // Lấy số lượng đã mượn hiện tại cho MaDG và MaSach từ bảng QLMuonTraSach
                    string sql = "SELECT SoLuong FROM QLMuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaDG", maDG);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    object result = cmd.ExecuteScalar();
                    int soLuongMuonCu = (result == DBNull.Value) ? 0 : Convert.ToInt32(result);

                    // Kiểm tra nếu có bản ghi mượn sách
                    if (soLuongMuonCu > 0)
                    {
                        // Xoá bản ghi trong bảng QLMuonTraSach
                        string deleteQuery = "DELETE FROM QLMuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach AND SoLuong = @SoLuong AND NgayMuon = @NgayMuon AND NgayHenTra = @NgayHenTra";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaDG", maDG),
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@SoLuong", soLuongMuonCu),
                            new SqlParameter("@NgayMuon", ngayMuon),
                            new SqlParameter("@NgayHenTra", ngayHenTra),
                        };

                        bool isDeleted = KetNoiDL.AddEditDelete(deleteQuery, parameters);

                        if (isDeleted)
                        {
                            // Cập nhật lại số lượng sách trong bảng QLSach (tăng số lượng sách sau khi xóa)
                            capnhatSoLuongSach(maSach, soLuongMuonCu+soLuongMuonMoi, soLuongMuonMoi); // Tăng số lượng sách trong kho

                            MessageBox.Show("Xóa thông tin mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Xoatextbox();
                            btnLuu.Visible = btnQuaylai.Visible = false;
                            btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = btnThoatMuonSach.Visible = true;
                            HienThiDanhSach();
                            HienThiTraSach();
                            //LoadCbTenSach();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi xóa thông tin mượn sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có thông tin mượn sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            // Kiểm tra xem người dùng đã chọn dòng nào trên DataGridView chưa
            if (dtgvDanhsach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Độc Giả Mượn Sách cần xoá trước khi thực hiện xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bạn đã chọn chức năng Xoá Độc Giả Mượn Sách . Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnLuu.Visible = btnQuaylai.Visible = true;
            btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = false;
        }
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Xoatextbox();
            Vohieutextbox();
            btnLuu.Visible = btnQuaylai.Visible = false;
            btnChoMuon.Visible = btnSua.Visible = btnXoa.Visible = btnThoatMuonSach.Visible = true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chuyennut == "Them")
            {
                luu_chomuon();
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


        //222222222222222222222222222222222222222222222//
        
        private void HienThiTraSach()
        {
            try
            {
                // Query để lấy dữ liệu từ bảng QLMuonTraSach với thông tin liên kết từ bảng QLSach
                string query = @"SELECT m.MaDG, m.MaSach, m.SoLuong, m.NgayMuon, m.NgayHenTra, m.NgayTra, s.TenSach
                                 FROM QLMuonTraSach m
                                 INNER JOIN QLSach s ON m.MaSach = s.MaSach";

                // Lấy dữ liệu từ phương thức GetTable
                DataTable dataTable = KetNoiDL.GetTable(query);

                // Gán DataTable vào DataGridView
                dtgvDanhsach_TS.DataSource = dataTable;

                // Điều chỉnh chiều rộng cột và các tiêu đề
                dtgvDanhsach_TS.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhsach_TS.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Đổi tên tiêu đề cho các cột
                dtgvDanhsach_TS.Columns["MaDG"].HeaderText = "Mã ĐG";
                dtgvDanhsach_TS.Columns["MaSach"].HeaderText = "Mã Sách";
                dtgvDanhsach_TS.Columns["TenSach"].HeaderText = "Tên Sách";
                dtgvDanhsach_TS.Columns["SoLuong"].HeaderText = "SL";
                dtgvDanhsach_TS.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                dtgvDanhsach_TS.Columns["NgayHenTra"].HeaderText = "Ngày Hẹn Trả";
                dtgvDanhsach_TS.Columns["NgayTra"].HeaderText = "Ngày Trả";

                // Xác định chỉ số cột của TenSach trong DataGridView
                int tenSachColumnIndex = dtgvDanhsach_TS.Columns["TenSach"].Index;

                // Di chuyển cột TenSach đến vị trí mong muốn (ví dụ: sau cột SoLuong)
                dtgvDanhsach_TS.Columns["TenSach"].DisplayIndex = 2; // Ví dụ: hiển thị sau cột số lượng (chỉ số 2)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgvDanhsach_TS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach_TS.CurrentRow != null)
            {
                txtMaDG_TS.Text = dtgvDanhsach_TS.CurrentRow.Cells["MaDG"].Value.ToString();
                txtMaSach_TS.Text = dtgvDanhsach_TS.CurrentRow.Cells["MaSach"].Value.ToString();
                txtTenSach_TS.Text = dtgvDanhsach_TS.CurrentRow.Cells["TenSach"].Value.ToString();
                txtSoLuong_TS.Text = dtgvDanhsach_TS.CurrentRow.Cells["SoLuong"].Value.ToString();
                DateTime ngayMuon = Convert.ToDateTime(dtgvDanhsach_TS.CurrentRow.Cells["NgayMuon"].Value);
                dtpkNgayMuon_TS.Value = ngayMuon;
                DateTime ngayHenTra = Convert.ToDateTime(dtgvDanhsach_TS.CurrentRow.Cells["NgayHenTra"].Value);
                dtpkNgayHenTra_TS.Value = ngayHenTra;
                // Kiểm tra Ngày Trả
                if (dtgvDanhsach_TS.CurrentRow.Cells["NgayTra"].Value != DBNull.Value && dtgvDanhsach_TS.CurrentRow.Cells["NgayTra"].Value != null)
                {
                    DateTime ngayTra;
                    if (DateTime.TryParse(dtgvDanhsach_TS.CurrentRow.Cells[6].Value.ToString(), out ngayTra))
                    {
                        dtpkNgayTra_TS.Value = ngayTra;
                    }
                }
                else
                {
                    // Nếu NgayTra là null, đặt giá trị mặc định
                    dtpkNgayTra_TS.Value = DateTime.Now; // Hoặc ngày mặc định khác
                }
            }
        }
        /*private void btnTraSach_TS_Click(object sender, EventArgs e)
        {
            if (dtgvDanhsach_TS.CurrentRow != null)
            {
                string maDG = txtMaDG_TS.Text; // Get MaDG from the TextBox
                string maSach = txtMaSach_TS.Text; // Get MaSach from the TextBox
                int soLuongMuonMoi = Convert.ToInt32(txtSoLuong_TS.Text); // Get new quantity from the TextBox
                string ngayMuon = dtpkNgayMuon_TS.Value.ToString("yyyy-MM-dd"); // Get NgayMuon from DatePicker
                string ngayHenTra = dtpkNgayHenTra_TS.Value.ToString("yyyy-MM-dd"); // Get NgayHenTra from DatePicker

                try
                {
                    using (SqlConnection connection = KetNoiDL.KetNoi())
                    {
                        connection.Open();

                        // Kiểm tra nếu NgayTra đã có giá trị
                        string sql = "SELECT NgayTra, SoLuong FROM QLMuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach AND NgayMuon = @NgayMuon AND NgayHenTra = @NgayHenTra";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@MaDG", maDG);
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        cmd.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            DateTime? ngayTra = reader.IsDBNull(reader.GetOrdinal("NgayTra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgayTra"));
                            if (ngayTra.HasValue)
                            {
                                // Nếu đã có ngày trả, thông báo và không xử lý tiếp
                                txtThongBao_TS.Text = "Sách đã được trả.";
                                return;
                            }
                        }
                        reader.Close();

                        // Nếu chưa có ngày trả, thực hiện các bước tiếp theo
                        DateTime ngayTraMoi = dtpkNgayTra_TS.Value;

                        // Cập nhật ngày trả trong bảng QLMuonTraSach
                        string updateNgayTraQuery = "UPDATE QLMuonTraSach SET NgayTra = @NgayTra WHERE MaDG = @MaDG AND MaSach = @MaSach AND NgayMuon = @NgayMuon AND NgayHenTra = @NgayHenTra";
                        SqlCommand cmd1 = new SqlCommand(updateNgayTraQuery, connection);
                        cmd1.Parameters.AddWithValue("@NgayTra", ngayTraMoi);
                        cmd1.Parameters.AddWithValue("@MaDG", maDG);
                        cmd1.Parameters.AddWithValue("@MaSach", maSach);
                        cmd1.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        cmd1.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);
                        cmd1.ExecuteNonQuery();

                        // Lấy số lượng sách hiện tại trong kho
                        string selectSoLuongSachQuery = "SELECT SoLuong FROM QLSach WHERE MaSach = @MaSach";
                        SqlCommand cmd2 = new SqlCommand(selectSoLuongSachQuery, connection);
                        cmd2.Parameters.AddWithValue("@MaSach", maSach);
                        int soLuongSachHienTai = Convert.ToInt32(cmd2.ExecuteScalar());

                        // Cập nhật số lượng sách trong kho sau khi trả sách
                        int soLuongMoiTrongKho = soLuongSachHienTai + soLuongMuonMoi;

                        // Cập nhật lại số lượng sách trong kho
                        string updateSoLuongQuery = "UPDATE QLSach SET SoLuong = @SoLuongMoi WHERE MaSach = @MaSach";
                        SqlCommand cmd3 = new SqlCommand(updateSoLuongQuery, connection);
                        cmd3.Parameters.AddWithValue("@SoLuongMoi", soLuongMoiTrongKho);
                        cmd3.Parameters.AddWithValue("@MaSach", maSach);
                        cmd3.ExecuteNonQuery();

                        // Thông báo thành công
                        MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiTraSach();

                        // Kiểm tra xem ngày trả có đúng hạn không
                        txtThongBao_TS.Text = ngayTraMoi <= DateTime.Parse(ngayHenTra) ? "Đúng hạn!" : "Quá hạn!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HienThiDanhSach(); // Cập nhật lại danh sách sau khi trả sách
        }
        */
        private void btnTraSach_TS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dtgvDanhsach_TS.CurrentRow != null)
            {
                string maDG = txtMaDG_TS.Text; // Get MaDG from the TextBox
                string maSach = txtMaSach_TS.Text; // Get MaSach from the TextBox
                int soLuongMuonMoi = Convert.ToInt32(txtSoLuong_TS.Text); // Get new quantity from the TextBox
                string ngayMuon = dtpkNgayMuon_TS.Value.ToString("yyyy-MM-dd"); // Get NgayMuon from DatePicker
                string ngayHenTra = dtpkNgayHenTra_TS.Value.ToString("yyyy-MM-dd"); // Get NgayHenTra from DatePicker

                try
                {
                    using (SqlConnection connection = KetNoiDL.KetNoi())
                    {
                        connection.Open();

                        // Kiểm tra nếu NgayTra đã có giá trị
                        string sql = "SELECT NgayTra, SoLuong FROM QLMuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach AND NgayMuon = @NgayMuon AND NgayHenTra = @NgayHenTra";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@MaDG", maDG);
                        cmd.Parameters.AddWithValue("@MaSach", maSach);
                        cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        cmd.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            DateTime? ngayTra = reader.IsDBNull(reader.GetOrdinal("NgayTra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgayTra"));
                            if (ngayTra.HasValue)
                            {
                                // Nếu đã có ngày trả, thông báo và không xử lý tiếp
                                txtThongBao_TS.Text = "Sách đã được trả.";
                                return;
                            }
                        }
                        reader.Close();

                        // Nếu chưa có ngày trả, thực hiện các bước tiếp theo
                        DateTime ngayTraMoi = dtpkNgayTra_TS.Value;

                        // Cập nhật ngày trả trong bảng QLMuonTraSach
                        string updateNgayTraQuery = "UPDATE QLMuonTraSach SET NgayTra = @NgayTra WHERE MaDG = @MaDG AND MaSach = @MaSach AND NgayMuon = @NgayMuon AND NgayHenTra = @NgayHenTra";
                        SqlCommand cmd1 = new SqlCommand(updateNgayTraQuery, connection);
                        cmd1.Parameters.AddWithValue("@NgayTra", ngayTraMoi);
                        cmd1.Parameters.AddWithValue("@MaDG", maDG);
                        cmd1.Parameters.AddWithValue("@MaSach", maSach);
                        cmd1.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        cmd1.Parameters.AddWithValue("@NgayHenTra", ngayHenTra);
                        cmd1.ExecuteNonQuery();

                        // Lấy số lượng sách hiện tại trong kho
                        string selectSoLuongSachQuery = "SELECT SoLuong FROM QLSach WHERE MaSach = @MaSach";
                        SqlCommand cmd2 = new SqlCommand(selectSoLuongSachQuery, connection);
                        cmd2.Parameters.AddWithValue("@MaSach", maSach);
                        int soLuongSachHienTai = Convert.ToInt32(cmd2.ExecuteScalar());

 
                        int soLuongMoiTrongKho = soLuongSachHienTai + soLuongMuonMoi;

                        string updateSoLuongQuery = "UPDATE QLSach SET SoLuong = @SoLuongMoi WHERE MaSach = @MaSach";
                        SqlCommand cmd3 = new SqlCommand(updateSoLuongQuery, connection);
                        cmd3.Parameters.AddWithValue("@SoLuongMoi", soLuongMoiTrongKho);
                        cmd3.Parameters.AddWithValue("@MaSach", maSach);
                        cmd3.ExecuteNonQuery();

                        MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiTraSach();
                        DateTime ngayHenTraDate = DateTime.Parse(ngayHenTra); 
                        if (ngayTraMoi <= ngayHenTraDate)
                        {
                            txtThongBao_TS.Text = "Trả đúng hạn!";
                        }
                        else
                        {
                            txtThongBao_TS.Text = "Quá hạn!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HienThiDanhSach(); 
        }















    }
}
