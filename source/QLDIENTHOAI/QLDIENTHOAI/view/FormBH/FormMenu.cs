using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using QLDIENTHOAI.controls;
using QLDIENTHOAI.view;
using QLDIENTHOAI.view.FormBanHang;
using QLDIENTHOAI.view.FormBH;

namespace QLDIENTHOAI.view
{
    public partial class FormMenu : Form
    {
        string username;
        control ctr;
        public FormMenu()
        {
            InitializeComponent();
            timerR.Start();          
            timerDeal.Start();
            LoadImage();
            timerADS.Start();
            loadADs();
            btnAccount.Enabled = false;
        }
        public FormMenu(string name)
        {
            InitializeComponent();
            username = name;
            timerR.Start();
            timerDeal.Start();
            timerADS.Start();
            loadADs();
            LoadImage();
        }
        private void LoadImage()
        {
            image = new Image[imgSrc.Length];
            for(int i =0;i<image.Length;i++)
            {
                image[i] = Image.FromFile(@"..\..\images\img\" + imgSrc[i]);
            }
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string[] imgSrc = { "hotdeal.jpg", "hotdeal2.jpg", "iphonedeal.jpg","SamVA.jpeg", "fold.jpg","huaweip30.png" };
        Image[] image = new Image[0];
        //Image layer1 = Image.FromFile(@"..\..\images\img\hotdeal.jpg");
        //Image layer2 = Image.FromFile(@"..\..\images\img\hotdeal2.jpg");
        //Image layer3 = Image.FromFile(@"..\..\images\img\iphonedeal.jpg");
        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAll, "Tất cả điện thoại");
        }

        private void btnIphone_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnIphone, "Tất cả điện thoại nhãn hiệu Iphone");
        }

        private void btnSamsung_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSamsung, "Tất cả điện thoại nhãn hiệu Samsung");
        }

        private void btnOppo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnOppo, "Tất cả điện thoại nhãn hiệu Oppo");
        }

        private void btnVsmars_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnVsmars, "Tất cả điện thoại nhãn hiệu Vsmart");
        }

        private void btnAccount_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAccount, "Quản lý tài khoản của bạn");
        }

        private void btnHelp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHelp, "Hướng dẫn sử dụng chương trình");
        }


        private void btnReport_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnReport, "Báo cáo sự cố với chúng tôi");
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnExit, "Đây là nút thoát");
        }

        private void getButton()
        {
            foreach(Control c in panel2.Controls)
            {
                if(c is Button)
                {
                    c.BackColor = Color.FromArgb(r, g, b);
                }
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.DarkCyan;
                }
            }
            this.BackColor = Color.FromArgb(r,g,b);
        }

        int r = 160;
        int g = 100;
        int b = 100;
        private void timerR_Tick(object sender, EventArgs e)
        {
            if(b>=160)
            {
                r -= 1;
                getButton();
                if(r<=100)
                {
                    timerR.Stop();
                    timerG.Start();

                }
            }
            if(b<=100)
            {
                r += 1;
                getButton();
                if (r>=160)
                {
                    timerR.Stop();
                    timerG.Start();

                }
            }
        }

        private void timerG_Tick(object sender, EventArgs e)
        {
            if (r <= 100)
            {
                g += 1;
                getButton();
                if (g >= 160)
                {
                    timerG.Stop();
                    timerB.Start();
                }
            }

            if(r>=160)
            {
                g -= 1;
                getButton();
                if (g<=100)
                {
                    timerG.Stop();
                    timerB.Start();
                }
            }
        }

        private void timerB_Tick(object sender, EventArgs e)
        {
            if(g <= 100)
            {
                b += 1;
                //panel1.BackColor = Color.FromArgb(r, g, b);
                getButton();
                if (b >= 160)
                {
                    timerB.Stop();
                    timerR.Start();
                }    
            }    
            if(g >= 160)
            {
                b -= 1;
                getButton();
                if (b<=255)
                {
                    timerB.Start();
                    timerR.Start();

                }
            }
        }
        int d = 0;
        private void timerDeal_Tick(object sender, EventArgs e)
        {
            d++;
            if(d==image.Length)
            {
                d = 0;
                pictureBox1.Image = image[0];
            }
            for(int i =0;i<image.Length;i++)
            {
                if (d == i)
                {
                    pictureBox1.Image = image[i];
                }
            }
        }
        int n;
        private void ChangeFrom()
        {
            this.Visible = false;
            FormDienThoai formDienThoai = new FormDienThoai(n,username);
            formDienThoai.ShowDialog();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            n = 0; ChangeFrom();
        }

        private void btnIphone_Click(object sender, EventArgs e)
        {
            n = 1; ChangeFrom();
        }
        private void btnSamsung_Click(object sender, EventArgs e)
        {
            n = 2; ChangeFrom();
        }
        private void btnVsmars_Click(object sender, EventArgs e)
        {
            n =3; ChangeFrom();
        }

        private void btnOppo_Click(object sender, EventArgs e)
        {
            n = 4; ChangeFrom();
        }
        string ten, dc, sdt,loaikh;
        
        private void btnAccount_Click(object sender, EventArgs e)
        {
            ctr = new control();
            ten = ctr.GetValueAccount(username, "TENKH");
            dc = ctr.GetValueAccount(username, "DC");
            sdt = ctr.GetValueAccount(username, "SDT");
            loaikh = ctr.GetValueAccount(username, "LOAIKH");
            ctr.Disconnect();
            FormAccount formAccount = new FormAccount(username,ten,dc,sdt,loaikh);
            formAccount.ShowDialog();
        }

        private void btnSupport_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSupport, "Chào " + username + ".Bạn cần gì?Hãy click vào tôi để được trợ giúp nhé");
        }
        private void loadADs()
        {
            ctr = new control();
            if (ctr.ShowADsImage().Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[0]["Hinhanh"]);
                picADS.Image = new Bitmap(ms);
            }
        }
        int ADScount = 0;
        private void timerADS_Tick(object sender, EventArgs e)
        {
            ADScount++;
            MemoryStream ms;
            ctr = new control();
            if (ctr.ShowADsImage().Tables[0].Rows.Count > 0)
            {
                if (ADScount == ctr.ShowADsImage().Tables[0].Rows.Count)
                {
                    ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[0]["Hinhanh"]);
                    picADS.Image = new Bitmap(ms);
                    ADScount = 0;
                }
                ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[ADScount]["Hinhanh"]);
                picADS.Image = new Bitmap(ms);
            }
        }
        private void picADS_Click(object sender, EventArgs e)
        {
            ctr = new control();
            string link = Convert.ToString(ctr.ShowADsImage().Tables[0].Rows[ADScount]["thamkhao"]);
            System.Diagnostics.Process.Start(link);
        }
    }
}
