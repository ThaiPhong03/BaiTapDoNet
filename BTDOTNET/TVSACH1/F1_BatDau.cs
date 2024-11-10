using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVSACH1
{
    public partial class F1_BatDau : Form
    {
        private System.Windows.Forms.Timer timer;
        public F1_BatDau()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            F2_DangNhap f = new F2_DangNhap();
            f.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
