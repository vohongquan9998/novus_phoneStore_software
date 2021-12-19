using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        control ctr;
        user info;
        Random rand;
        int x,y;
        Image on = Image.FromFile(@"..\..\images\icon\visible.png");
        Image off = Image.FromFile(@"..\..\images\icon\visible-off.png");
        private void chDongyDK_CheckedChanged(object sender, EventArgs e)
        {
            if(chDongyDK.Checked)
                btnsignup.Enabled = true;
            else
                btnsignup.Enabled = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormLogin form = new FormLogin();
            form.ShowDialog();

        }

        private bool CheckUserExist()
        {
            bool check;
            ctr = new control();
            info = new user();
            info.Tentk = txtUser.Text;
            check = ctr.checkUser(info.Tentk);
            return check;
        }
        private void btnsignup_Click(object sender, EventArgs e)
        {
            if(txtUser.TextLength==0)
            {
                MessageBox.Show("Vui lòng nhập Tên tài khoản", "Thông báo");
                txtUser.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtPass.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Password", "Thông báo");
                txtPass.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if(txtPass.TextLength <6)
            {
                MessageBox.Show("Password của bạn quá ngắn", "Thông báo");
                txtPass.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtRePass.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập lại Password", "Thông báo");
                txtRePass.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if(!txtPass.Text.Equals(txtRePass.Text))
            {
                MessageBox.Show("Password và Re-enter Password phải gióng nhau", "Thông báo");
                txtPass.BackColor = Color.FromArgb(222, 91, 82);
                txtRePass.BackColor = Color.FromArgb(222, 91, 82);
            }
            else
            {
                rand = new Random();
                ctr = new control();
                info = new user();

                if(CheckUserExist())
                {
                    byte[] encoding = Encoding.Unicode.GetBytes(txtUser.Text);
                    string m = BitConverter.ToString(encoding);
                    if (MessageBox.Show("Bạn cần nhập đầy đủ thông tin để hoàn thành việc khởi tạo tài khoản", "Thông báo", MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        this.Visible = false;
                        FormTTTaiKhoan form = new FormTTTaiKhoan(txtUser.Text,txtPass.Text);
                        form.ShowDialog();
                    }    
                    else
                    {
                        this.Visible = false;
                        FormLogin form = new FormLogin();
                        form.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                    txtUser.BackColor = Color.FromArgb(222, 91, 82);
                }
            }   
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.WhiteSmoke;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.WhiteSmoke;
            int n = txtPass.TextLength;
            if(n<=7)
            {
                lbPass.Text = "WEAK";
                lbPass.ForeColor = Color.Black;
                lbPass.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            }
            else if(n<=9)
            {
                lbPass.Text = "NORMAL";
                lbPass.ForeColor = Color.Green;
                lbPass.Font = new Font("Microsoft Sans Serif", 7);
            }
            else if (n <= 15)
            {
                lbPass.Text = "STRONG";
                lbPass.Font = new Font("Microsoft Sans Serif",7);
                lbPass.ForeColor = Color.Red;
            }
            else
            {
                lbPass.Text = "MAKE SURE YOU REMEMBER IT";
                lbPass.Font = new Font("Microsoft Sans Serif", 6);
                lbPass.ForeColor = Color.Red;
            }
        }
        int d1, d2;
        private void btnVisible_Click(object sender, EventArgs e)
        {
            d1++;
            if (d1 == 1)
            {
                txtPass.UseSystemPasswordChar = false;
                btnVisible.BackgroundImage = on;
            }
            if (d1 == 2)
            {
                txtPass.UseSystemPasswordChar = true;
                d1 = 0;
                btnVisible.BackgroundImage = off;
            }
        }

        private void btnRandomName_Click(object sender, EventArgs e)
        {
            String[] name = { 
                "Kevin", "Jessica", "Mali", "Uspa", "Michacal","Jason","Balfour","Brook","Howie","Delmar","Maxie",
                "Trix", "Brenda", "Betsy", "Hyram", "Cherish","Maxene","Sommeer","Gresha","Norton","Topaz","Adelyn",
                "Corrien","Adam","Zoey","Nive", "Jessi", "Mamina", "Pasu", "Michel","Zaron","Lossy","Brooky","Howier",
                "Delmarica","Maxie"
            };
            Random r = new Random();
            int z = r.Next(100, 1000);
            int num = r.Next(0, 36);
            txtUser.Text = name[num] + z.ToString();
        }

        private void btnsignup_MouseMove(object sender, MouseEventArgs e)
        {
            btnsignup.BackColor = Color.DarkSlateGray;
        }

        private void btnsignup_MouseLeave(object sender, EventArgs e)
        {
            btnsignup.BackColor = Color.LightSeaGreen;
        }

        private void btnBack_MouseMove(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.DarkSlateGray;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.DarkCyan;
        }

        private void btnVisibleRepass_Click(object sender, EventArgs e)
        {
            d2++;
            if (d2 == 1)
            {
                txtRePass.UseSystemPasswordChar = false;
                btnVisibleRepass.BackgroundImage = on;
            }
            if (d2 == 2)
            {
                txtRePass.UseSystemPasswordChar = true;
                d2 = 0;
                btnVisibleRepass.BackgroundImage = off;
            }
        }

        private void txtRePass_TextChanged(object sender, EventArgs e)
        {
            txtRePass.BackColor = Color.WhiteSmoke;
        }
    }
}
