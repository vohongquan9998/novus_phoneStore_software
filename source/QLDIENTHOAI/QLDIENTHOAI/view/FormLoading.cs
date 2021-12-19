using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace QLDIENTHOAI.view.FormQuanLy
{
    public partial class FormLoading : Form
    {
        Random rand = new Random();
        int x;
        public FormLoading()
        {
            x = rand.Next(3, 7);
            InitializeComponent();

            this.BringToFront();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pbLoading.Value <=pbLoading.Maximum)
            {
                pbLoading.Value += x;
            }
            if (pbLoading.Value >= 10)
            {
                lbLoading.Text = "Kiểm tra kết nối...";
                lbLoading.Location = new Point(40, 21);
            }
            if (pbLoading.Value >= pbLoading.Maximum-5)
            {
                pbLoading.Value = 0;
                timer1.Stop();
                this.TopMost = false;
                this.Visible = false;
                FormLogin form = new FormLogin();
                form.ShowDialog();

            }
        }
    }
}
