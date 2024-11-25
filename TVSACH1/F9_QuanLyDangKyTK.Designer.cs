namespace TVSACH1
{
    partial class F9_QuanLyDangKyTK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F9_QuanLyDangKyTK));
            groupBox2 = new GroupBox();
            label7 = new Label();
            dtgvDanhsach = new DataGridView();
            groupBox1 = new GroupBox();
            txtMK = new TextBox();
            cbChucVu = new ComboBox();
            txtTenTK = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnThem = new Button();
            btnThoat = new Button();
            btnQuaylai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            groupBox3 = new GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDanhsach).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dtgvDanhsach);
            groupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(17, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(592, 220);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "                             ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(6, -4);
            label7.Name = "label7";
            label7.Size = new Size(122, 28);
            label7.TabIndex = 17;
            label7.Text = "Danh Sách";
            // 
            // dtgvDanhsach
            // 
            dtgvDanhsach.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgvDanhsach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgvDanhsach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDanhsach.GridColor = SystemColors.ControlText;
            dtgvDanhsach.Location = new Point(14, 27);
            dtgvDanhsach.Name = "dtgvDanhsach";
            dtgvDanhsach.Size = new Size(566, 178);
            dtgvDanhsach.TabIndex = 0;
            dtgvDanhsach.CellClick += dtgvDanhsach_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtMK);
            groupBox1.Controls.Add(cbChucVu);
            groupBox1.Controls.Add(txtTenTK);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(17, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(592, 150);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đăng Ký Tài Khoản";
            // 
            // txtMK
            // 
            txtMK.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtMK.Location = new Point(138, 92);
            txtMK.Name = "txtMK";
            txtMK.Size = new Size(148, 26);
            txtMK.TabIndex = 20;
            // 
            // cbChucVu
            // 
            cbChucVu.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbChucVu.FormattingEnabled = true;
            cbChucVu.Location = new Point(415, 50);
            cbChucVu.Name = "cbChucVu";
            cbChucVu.Size = new Size(148, 27);
            cbChucVu.TabIndex = 19;
            // 
            // txtTenTK
            // 
            txtTenTK.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtTenTK.Location = new Point(138, 46);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(148, 26);
            txtTenTK.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(327, 53);
            label6.Name = "label6";
            label6.Size = new Size(73, 19);
            label6.TabIndex = 11;
            label6.Text = "Chức Vụ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(14, 101);
            label4.Name = "label4";
            label4.Size = new Size(87, 19);
            label4.TabIndex = 9;
            label4.Text = "Mật Khẩu :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(14, 51);
            label1.Name = "label1";
            label1.Size = new Size(118, 19);
            label1.TabIndex = 7;
            label1.Text = "Tên Tài Khoản :";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Control;
            btnThem.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.Black;
            btnThem.Location = new Point(6, 46);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(142, 49);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.Control;
            btnThoat.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(6, 343);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(142, 49);
            btnThoat.TabIndex = 24;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnQuaylai
            // 
            btnQuaylai.BackColor = SystemColors.Control;
            btnQuaylai.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnQuaylai.ForeColor = Color.Black;
            btnQuaylai.Location = new Point(6, 266);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(142, 49);
            btnQuaylai.TabIndex = 23;
            btnQuaylai.Text = "Quay lại";
            btnQuaylai.UseVisualStyleBackColor = false;
            btnQuaylai.Click += btnQuaylai_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.Control;
            btnXoa.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Black;
            btnXoa.Location = new Point(6, 156);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(142, 49);
            btnXoa.TabIndex = 22;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.Control;
            btnSua.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(6, 101);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(142, 49);
            btnSua.TabIndex = 21;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.Control;
            btnLuu.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.Black;
            btnLuu.Location = new Point(6, 211);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(142, 49);
            btnLuu.TabIndex = 19;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnQuaylai);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Controls.Add(btnLuu);
            groupBox3.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(629, 26);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(154, 398);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức Năng";
            // 
            // QuanLyDangKyTK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Name = "QuanLyDangKyTK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuanLyDangKyTK";
            FormClosed += QuanLyDangKyTK_FormClosed;
            Load += QuanLyDangKyTK_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDanhsach).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private Label label7;
        private DataGridView dtgvDanhsach;
        private GroupBox groupBox1;
        private ComboBox cbChucVu;
        private TextBox txtTenTK;
        private Label label6;
        private Label label4;
        private Label label1;
        private Button btnThem;
        private Button btnThoat;
        private Button btnQuaylai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private GroupBox groupBox3;
        private TextBox txtMK;
    }
}