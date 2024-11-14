using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TVSACH1
{
    public partial class F3_TrangChu : Form
    {
        private string chucvu;
        private DataTable dt;

        public F3_TrangChu(string chucvu)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            Vohieutextbox();
           
        }

        private void Vohieutextbox()
        {
            txtMasach.Enabled = txtTensach.Enabled = txtMaloaisach.Enabled = txtSoluong.Enabled = txtMatacgia.Enabled = false;
        }

        private void Kichhoattextbox()
        {
            txtMasach.Enabled = txtTensach.Enabled = txtMaloaisach.Enabled = txtSoluong.Enabled = txtMatacgia.Enabled = true;
        }

        private void ClearTextBoxes()
        {
            txtMasach.Clear();
            txtTensach.Clear();
            txtMaloaisach.Clear();
            txtSoluong.Clear();
            txtMatacgia.Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dt = KetNoiDL.GetTable("select * from QLSach");
            HienThiDS();
            HienThiLV();
            Vohieutextbox();

            btntaikhoan.Enabled = (chucvu == "Giám đốc" || chucvu == "Chủ tịch");

            
        }

        private void HienThiLV()
        {
            lvLoaisach.View = View.List;
            AddCategory("Sách giáo khoa", "SGK");
            AddCategory("Truyện tranh", "TT");
            AddCategory("Lịch sử", "LS");
            AddCategory("Khoa học", "KH");
            AddCategory("Kinh tế", "KT");
            AddCategory("Chính Trị", "CT");
        }

        private void AddCategory(string categoryName, string categoryCode)
        {
            ListViewItem item = new ListViewItem($"{categoryName} ({categoryCode})") { Tag = categoryCode };
            lvLoaisach.Items.Add(item);
        }

        private void HienThiDS()
        {
            dtgvDanhsach.DataSource = dt;
            dtgvDanhsach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhsach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhsach.Columns[0].HeaderText = "Mã Sách";
            dtgvDanhsach.Columns[1].HeaderText = "Tên Sách";
            dtgvDanhsach.Columns[2].HeaderText = "Mã LSách";
            dtgvDanhsach.Columns[3].HeaderText = "SL";
            dtgvDanhsach.Columns[4].HeaderText = "Tác Giả";
        }

        private void lvLoaisach_ItemActivate(object sender, EventArgs e)
        {
            if (lvLoaisach.SelectedItems.Count > 0)
            {
                string maLoaiSach = lvLoaisach.SelectedItems[0].Tag.ToString();
                dtgvDanhsach.DataSource = KetNoiDL.GetTable($"SELECT * FROM QLSach WHERE MaLoaiSach = N'{maLoaiSach}'");

                if (dtgvDanhsach.Rows.Count == 1)
                {
                    MessageBox.Show("Thông tin sách chưa có.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhsach.CurrentRow != null)
            {
                txtMasach.Text = dtgvDanhsach.CurrentRow.Cells[0].Value.ToString();
                txtTensach.Text = dtgvDanhsach.CurrentRow.Cells[1].Value.ToString();
                txtMaloaisach.Text = dtgvDanhsach.CurrentRow.Cells[2].Value.ToString();
                txtSoluong.Text = dtgvDanhsach.CurrentRow.Cells[3].Value.ToString();
                txtMatacgia.Text = dtgvDanhsach.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            F6_CapNhat f = new F6_CapNhat();
            f.ShowDialog();
        }

        private void btnQLdocgia_Click(object sender, EventArgs e)
        {
            F4_QuanLyDocGia f = new F4_QuanLyDocGia();
            f.ShowDialog();
        }

        private void btnQLtacgia_Click(object sender, EventArgs e)
        {
            F5_QuanLyTacGia f = new F5_QuanLyTacGia();
            f.ShowDialog();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            F8_TimKiemALL f = new F8_TimKiemALL();
            f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnQLmuontra_Click(object sender, EventArgs e)
        {
            F7_MuonTra f = new F7_MuonTra();
            f.ShowDialog();
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            F9_QuanLyDangKyTK f = new F9_QuanLyDangKyTK();
            f.ShowDialog();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            new F2_DangNhap().Show();
            this.Hide();
        }
    }
}
