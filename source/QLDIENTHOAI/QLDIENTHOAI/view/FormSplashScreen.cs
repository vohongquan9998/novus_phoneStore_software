using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLDIENTHOAI.view.FormBanHang;

namespace QLDIENTHOAI.view
{
    
    public partial class FormSplashScreen : Form
    {
        Random rand = new Random();
        int x;
        string name;
        control ctr;
        public FormSplashScreen(string username)
        {
            InitializeComponent();

            name = username;
            lbName.Text = username;
            loadForm();

        }
        private void loadForm()
        {
                x = rand.Next(3, 7);
                timer1.Start();
                if (lbName.Text.Length > 8)
                {
                    if(lbName.Text.Length > 14)
                        lbName.Location = new Point(30, 105);
                    else
                        lbName.Location = new Point(96, 105);
                }
                else if (lbName.Text.Length <= 5)
                    lbName.Location = new Point(159, 109);
                else if(lbName.Text.Length <= 8)
                {
                    lbName.Location = new Point(130, 105);
                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbLoading.Value <= pbLoading.Maximum)
            {
                pbLoading.Value += x;
            }
            if (pbLoading.Value >= pbLoading.Maximum - 5)
            {
                ctr = new control();
                pbLoading.Value = 0;
                timer1.Stop();
                this.TopMost = false;
                this.Visible = false;
                if(ctr.CheckAdminOrUser(name) == 1)
                {
                    Form1 form1 = new Form1(name);
                    form1.ShowDialog();
                }
                else
                {
                    FormMenu form = new FormMenu(name);
                    form.ShowDialog();

                }
            }
        }
    }
}
