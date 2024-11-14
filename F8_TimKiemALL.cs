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
    public partial class F8_TimKiemALL : Form
    {
        private string loaiTimKiemSach = "";
        private string loaiTimKiemDG = "";
        private string loaiTimKiemTG = "";

        private DataTable dt;
        public F8_TimKiemALL()
        {
            InitializeComponent();
            
            HienThiSach();
            HienThiDocGia();
            HienThiTacGia();

        }
        private void rdMasach_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMasach.Checked)
            {
                loaiTimKiemSach = "MaSach"; 
                lbThongbaoS.Text = "";
                txtTimkiem.Clear();
            }
        }
        private void rdTensach_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTensach.Checked)
            {
                loaiTimKiemSach = "TenSach";
                lbThongbaoS.Text = "";
                txtTimkiem.Clear();
            }
        }
        private void tabTkSach_Click(object sender, EventArgs e)
        {
            //capnhatdata(); làm thừa
        }
        private void HienThiSach()
        {
            dtgvDanhsach.DataSource = KetNoiDL.GetTable("SELECT * FROM QLSach");
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Mã Sách";
            dtgvDanhsach.Columns[1].HeaderText = "Tên Sách";
            dtgvDanhsach.Columns[2].HeaderText = "Mã LS";
            dtgvDanhsach.Columns[3].HeaderText = "Số Lượng";
            dtgvDanhsach.Columns[4].HeaderText = "Mã Tác Giả";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            TimKiemSach();
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemSach();
        }
        private void TimKiemSach()
        {
            if (string.IsNullOrEmpty(loaiTimKiemSach))
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm (theo Mã sách hoặc Tên sách).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string timKiem = txtTimkiem.Text.Trim();
            if (string.IsNullOrEmpty(timKiem))
            {
                HienThiSach();
                lbThongbaoS.Text = "";
                return;
            }
            // Truy vấn SQL dựa trên loại tìm kiếm bằng cách sử dụng tham số  
            string sql = loaiTimKiemSach == "MaSach"
                ? "SELECT * FROM QLSach WHERE MaSach LIKE @search"
                : "SELECT * FROM QLSach WHERE TenSach LIKE @search";
            // Sử dụng SqlParameter để xử lý ký tự đặc biệt  
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@search", $"%{timKiem}%")
            };
            DataTable dataTable = KetNoiDL.TimKiemm(sql, parameters);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dtgvDanhsach.DataSource = dataTable; // Cập nhật DataGridView với kết quả tìm kiếm  
                lbThongbaoS.Text = "Đã tìm thấy " + dataTable.Rows.Count + " kết quả.";
            }
            else
            {
                //dtgvDanhsach.DataSource = null; // Không tìm thấy kết quả  
                lbThongbaoS.Text = "Không tìm thấy kết quả.";
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void rdMaDG_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaDG.Checked)
            {
                loaiTimKiemDG = "MaDG"; // Cập nhật loại tìm kiếm là theo mã sách
                lbThongbaoDG.Text = "";
                txtTkDocgia.Clear();
            }
        }
        private void rdTenDG_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTenDG.Checked)
            {
                loaiTimKiemDG = "TenDocGia"; // Cập nhật loại tìm kiếm là theo tên sách
                lbThongbaoDG.Text = "";
                txtTkDocgia.Clear();
            }
        }

        private void HienThiDocGia()
        {
            dtgvDanhsachDG.DataSource = KetNoiDL.GetTable("SELECT * FROM QLNguoiMuon");
            dtgvDanhsachDG.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachDG.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachDG.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachDG.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachDG.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsachDG.Columns[0].HeaderText = "Mã DG";
            dtgvDanhsachDG.Columns[1].HeaderText = "Tên Độc Gỉa";
            dtgvDanhsachDG.Columns[2].HeaderText = "Giới Tính";
            dtgvDanhsachDG.Columns[3].HeaderText = "Ngày Tạo";
            dtgvDanhsachDG.Columns[4].HeaderText = "Địa Chỉ";
        }
        private void btnThoatDG_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void btnTkDocgia_Click(object sender, EventArgs e)
        {
            TimKiemDocGia();
        }
        private void txtTkDocgia_TextChanged(object sender, EventArgs e)
        {
            TimKiemDocGia();

        }
        private void TimKiemDocGia()
        {
            if (string.IsNullOrEmpty(loaiTimKiemDG))
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm (theo Mã Độc Giả hoặc Tên Độc Giả).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string timKiem = txtTkDocgia.Text.Trim();
            if (string.IsNullOrEmpty(timKiem))
            {
                HienThiDocGia();
                lbThongbaoDG.Text = "";
                return;
            }
            // Truy vấn SQL dựa trên loại tìm kiếm bằng cách sử dụng tham số  
            string sql = loaiTimKiemDG == "MaDG"
                ? "SELECT * FROM QLNguoiMuon WHERE MaDG LIKE @search"
                : "SELECT * FROM QLNguoiMuon WHERE TenDocGia LIKE @search";
            // Sử dụng SqlParameter để xử lý ký tự đặc biệt  
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@search", $"%{timKiem}%")
            };
            DataTable dataTable = KetNoiDL.TimKiemm(sql, parameters);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dtgvDanhsachDG.DataSource = dataTable; // Cập nhật DataGridView với kết quả tìm kiếm  
                lbThongbaoDG.Text = "Đã tìm thấy " + dataTable.Rows.Count + " kết quả.";
            }
            else
            {
                //dtgvDanhsach.DataSource = null; // Không tìm thấy kết quả  
                lbThongbaoDG.Text = "Không tìm thấy kết quả.";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdMaTG_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaTG.Checked)
            {
                loaiTimKiemTG = "MaTG"; // Cập nhật loại tìm kiếm là theo mã sách
                lbThongbaoTG.Text = "";
                txtTKTG.Clear();
            }
        }
        private void rdTenTG_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTenTG.Checked)
            {
                loaiTimKiemTG = "TenTG"; // Cập nhật loại tìm kiếm là theo tên sách
                lbThongbaoTG.Text = "";
                txtTKTG.Clear();
            }
        }
        private void HienThiTacGia()
        {
          
            dtgvDanhsachTG.DataSource = KetNoiDL.GetTable("SELECT * FROM QLTacGia");
            dtgvDanhsachTG.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachTG.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsachTG.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsachTG.Columns[0].HeaderText = "Mã Tác Giả";
            dtgvDanhsachTG.Columns[1].HeaderText = "Tên Độc Giả";
            dtgvDanhsachTG.Columns[2].HeaderText = "Địa Chỉ";
        }
        private void btnThoatTG_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void btnTKTG_Click(object sender, EventArgs e)
        {

            TimKiemTacGia();
        }
        private void txtTKTG_TextChanged(object sender, EventArgs e)
        {
            TimKiemTacGia();
        }

        private void TimKiemALL_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void TimKiemTacGia()
        {
            if (string.IsNullOrEmpty(loaiTimKiemTG))
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm (theo Mã Tác Giả hoặc Tên Tác Giả).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string timKiem = txtTKTG.Text.Trim();
            if (string.IsNullOrEmpty(timKiem))
            {
                HienThiTacGia();
                lbThongbaoTG.Text = "";
                return;
            }
            // Truy vấn SQL dựa trên loại tìm kiếm bằng cách sử dụng tham số  
            string sql = loaiTimKiemTG == "MaTG"
                ? "SELECT * FROM QLTacGia WHERE MaTG LIKE @search"
                : "SELECT * FROM QLTacGia WHERE TenTG LIKE @search";
            // Sử dụng SqlParameter để xử lý ký tự đặc biệt  
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@search", $"%{timKiem}%")
            };
            DataTable dataTable = KetNoiDL.TimKiemm(sql, parameters);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dtgvDanhsachTG.DataSource = dataTable; // Cập nhật DataGridView với kết quả tìm kiếm  
                lbThongbaoTG.Text = "Đã tìm thấy " + dataTable.Rows.Count + " kết quả.";
            }
            else
            {
                //dtgvDanhsachTG.DataSource = null; // Không tìm thấy kết quả  
                lbThongbaoTG.Text = "Không tìm thấy kết quả.";
            }
        }
    }
}
