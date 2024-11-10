namespace TVSACH1
{
    partial class F2_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F2_DangNhap));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnDangnhap = new Button();
            checkBox1 = new CheckBox();
            txtTK = new TextBox();
            txtMK = new TextBox();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 30F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(272, 98);
            label1.Name = "label1";
            label1.Size = new Size(389, 46);
            label1.TabIndex = 1;
            label1.Text = "Đăng Nhập Hệ Thống";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(251, 208);
            label2.Name = "label2";
            label2.Size = new Size(135, 26);
            label2.TabIndex = 2;
            label2.Text = "Tài Khoản :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(251, 252);
            label3.Name = "label3";
            label3.Size = new Size(132, 26);
            label3.TabIndex = 3;
            label3.Text = "Mật Khẩu :";
            // 
            // btnDangnhap
            // 
            btnDangnhap.BackColor = SystemColors.Control;
            btnDangnhap.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangnhap.Location = new Point(351, 323);
            btnDangnhap.Name = "btnDangnhap";
            btnDangnhap.Size = new Size(150, 49);
            btnDangnhap.TabIndex = 4;
            btnDangnhap.Text = "Đăng Nhập";
            btnDangnhap.UseVisualStyleBackColor = false;
            btnDangnhap.Click += btnDangnhap_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Location = new Point(691, 264);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 5;
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtTK
            // 
            txtTK.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTK.Location = new Point(438, 199);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(223, 35);
            txtTK.TabIndex = 6;
            // 
            // txtMK
            // 
            txtMK.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMK.Location = new Point(438, 243);
            txtMK.Name = "txtMK";
            txtMK.Size = new Size(223, 35);
            txtMK.TabIndex = 7;
            txtMK.UseSystemPasswordChar = true;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.Control;
            btnThoat.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(539, 323);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 49);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // F2_DangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(txtMK);
            Controls.Add(txtTK);
            Controls.Add(checkBox1);
            Controls.Add(btnDangnhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F2_DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnDangnhap;
        private CheckBox checkBox1;
        private TextBox txtTK;
        private TextBox txtMK;
        private Button btnThoat;
    }
}