namespace TVSACH1
{
    partial class F5_QuanLyTacGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F5_QuanLyTacGia));
            btnThoat = new Button();
            txtMatacgia = new TextBox();
            label6 = new Label();
            label5 = new Label();
            btnQuaylai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            label7 = new Label();
            groupBox2 = new GroupBox();
            dtgvDanhsach = new DataGridView();
            label1 = new Label();
            btnThem = new Button();
            groupBox1 = new GroupBox();
            txtDiachi = new TextBox();
            txtTenTG = new TextBox();
            txtMaTG = new TextBox();
            groupBox3 = new GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDanhsach).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.Control;
            btnThoat.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(6, 343);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(148, 49);
            btnThoat.TabIndex = 32;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtMatacgia
            // 
            txtMatacgia.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtMatacgia.Location = new Point(139, 34);
            txtMatacgia.Name = "txtMatacgia";
            txtMatacgia.Size = new Size(197, 26);
            txtMatacgia.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(104, 100);
            label6.Name = "label6";
            label6.Size = new Size(101, 19);
            label6.TabIndex = 11;
            label6.Text = "Tên Tác Giả :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Transparent;
            label5.Location = new Point(104, 151);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 10;
            label5.Text = "Địa Chỉ :";
            // 
            // btnQuaylai
            // 
            btnQuaylai.BackColor = SystemColors.Control;
            btnQuaylai.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnQuaylai.ForeColor = Color.Black;
            btnQuaylai.Location = new Point(6, 264);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(148, 49);
            btnQuaylai.TabIndex = 31;
            btnQuaylai.Text = "Quay lại";
            btnQuaylai.UseVisualStyleBackColor = false;
            btnQuaylai.Click += btnQuaylai_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.Control;
            btnXoa.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Black;
            btnXoa.Location = new Point(6, 151);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(148, 49);
            btnXoa.TabIndex = 30;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.Control;
            btnSua.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(6, 93);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(148, 49);
            btnSua.TabIndex = 29;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.Control;
            btnLuu.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.Black;
            btnLuu.Location = new Point(6, 209);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(148, 49);
            btnLuu.TabIndex = 28;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(7, -4);
            label7.Name = "label7";
            label7.Size = new Size(122, 28);
            label7.TabIndex = 17;
            label7.Text = "Danh Sách";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dtgvDanhsach);
            groupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(65, 255);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(507, 172);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "                             ";
            // 
            // dtgvDanhsach
            // 
            dtgvDanhsach.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgvDanhsach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgvDanhsach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDanhsach.GridColor = SystemColors.ControlText;
            dtgvDanhsach.Location = new Point(16, 30);
            dtgvDanhsach.Name = "dtgvDanhsach";
            dtgvDanhsach.Size = new Size(471, 124);
            dtgvDanhsach.TabIndex = 0;
            dtgvDanhsach.CellClick += dtgvDanhsach_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(104, 49);
            label1.Name = "label1";
            label1.Size = new Size(99, 19);
            label1.TabIndex = 7;
            label1.Text = "Mã Tác Giả :";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Control;
            btnThem.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.Black;
            btnThem.Location = new Point(6, 35);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(148, 49);
            btnThem.TabIndex = 27;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtDiachi);
            groupBox1.Controls.Add(txtTenTG);
            groupBox1.Controls.Add(txtMaTG);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(65, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(507, 203);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Tác Giả";
            // 
            // txtDiachi
            // 
            txtDiachi.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDiachi.Location = new Point(230, 143);
            txtDiachi.Name = "txtDiachi";
            txtDiachi.Size = new Size(183, 26);
            txtDiachi.TabIndex = 14;
            // 
            // txtTenTG
            // 
            txtTenTG.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTenTG.Location = new Point(230, 93);
            txtTenTG.Name = "txtTenTG";
            txtTenTG.Size = new Size(183, 26);
            txtTenTG.TabIndex = 13;
            // 
            // txtMaTG
            // 
            txtMaTG.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMaTG.Location = new Point(230, 42);
            txtMaTG.Name = "txtMaTG";
            txtMaTG.Size = new Size(107, 26);
            txtMaTG.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(btnLuu);
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnQuaylai);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = SystemColors.Control;
            groupBox3.Location = new Point(628, 35);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(160, 403);
            groupBox3.TabIndex = 33;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức Năng";
            // 
            // QuanLyTacGia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "QuanLyTacGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Tác Giả";
            FormClosed += Form5_FormClosed;
            Load += Form5_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDanhsach).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnThoat;
        private TextBox txtMatacgia;
        private TextBox txtSoluong;
        private TextBox txtMaloaisach;
        private TextBox txtTensach;
       
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnQuaylai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Label label3;
        private Label label7;
        private GroupBox groupBox2;
        private DataGridView dtgvDanhsach;
        private Label label1;
        private Button btnThem;
        private GroupBox groupBox1;
        private TextBox txtDiachi;
        private TextBox txtTenTG;
        private TextBox txtMaTG;
        private GroupBox groupBox3;
    }
}