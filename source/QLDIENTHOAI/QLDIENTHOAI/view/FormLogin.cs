using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace QLDIENTHOAI.view
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            timer1.Start();
            txtUser.Text = "Enter Username";
            txtPass.Text = "Enter Password";
            txtPass.UseSystemPasswordChar = false;
            txtUser.ForeColor = Color.Gray;
            txtPass.ForeColor = Color.Gray;
        }
        Image on = Image.FromFile(@"..\..\images\icon\visible.png");
        Image off = Image.FromFile(@"..\..\images\icon\visible-off.png");
        control ctr;
        user user;
        Image layer1 = Image.FromFile(@"..\..\images\img\layer1.png");
        Image layer2 = Image.FromFile(@"..\..\images\img\layer1_2.png");
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int d = 0;
        private void btnVisible_Click(object sender, EventArgs e)
        {
            if(txtPass.Text!="Enter Password")
            {
                d++;
                if (d == 1)
                {
                    txtPass.UseSystemPasswordChar = false;
                    btnVisible.BackgroundImage = on;
                }
                if (d == 2)
                {
                    txtPass.UseSystemPasswordChar = true;
                    d = 0;
                    btnVisible.BackgroundImage = off;
                }
            }   
        }


        private void txtUser_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtUser, "Your UserName");
        }

        private void txtPass_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtPass, "Your Password");
        }

        private void btnVisible_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnVisible, "Show Password/UnShow Password");
        }
        int Blockcount = 0,turn = 4;
        private void btnsignin_Click(object sender, EventArgs e)
        {

            if(txtUser.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên tài khoản", "Thông báo");
                txtUser.BackColor = Color.FromArgb(222,91,82);
            }
            else if (txtPass.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Password", "Thông báo");
                txtPass.BackColor = Color.FromArgb(222, 91, 82);
            }
            else
            {
                
                ctr = new control();
                user = new user();
                user.Tentk = txtUser.Text;
                user.Matkhau = user.MD5Hash(txtPass.Text);
                if (ctr.Login(user.Tentk,user.Matkhau))
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    this.Visible = false;
                    FormSplashScreen form = new FormSplashScreen(user.Tentk);
                    form.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại.Lượt thử lại:"+turn--, "Thông báo");
                    txtPass.Text = "";
                    txtUser.Text = "";
                    Blockcount++;
                    if(Blockcount == 5)
                    {
                        btnsignin.Enabled = false;
                        txtPass.Visible = false;
                        txtUser.Visible = false;
                        btnVisible.Visible = false;
                        lbReset.Visible = true;
                        lbReset.Text = "Xin hãy đợi 10s cho đến lần đăng nhập tiếp theo";
                        lbReset.Location = new Point(14, 28);
                        timerBlock.Start();
                    }    
                }

            }
        }

        int time = 10;
        private void timerBlock_Tick(object sender, EventArgs e)
        {
            time--;
            lbReset.Text = "Xin hãy đợi " + time.ToString() + "s cho đến lần đăng nhập tiếp theo";
            if(time == 0)
            {
                timerBlock.Stop();
                time = 10;
                Blockcount = 0;
                lbReset.Visible = false;
                btnsignin.Enabled = true;
                txtPass.Visible = true;
                txtUser.Visible = true;
                btnVisible.Visible = true;
                lbReset.Location = new Point(16, 5);
                txtPass_Leave(sender, e);
                txtUser_Leave(sender, e);
            }    
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.WhiteSmoke;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.WhiteSmoke;
        }


        private void btnsignup_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }
        int d1 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            d1++;
            if (d1 == 1)
            {
                pictureBox1.Image = layer2;
            }
            if (d1 == 2)
            {
                pictureBox1.Image = layer1;
                d1 = 0;
            }
        }

        private void btnsignin_MouseMove(object sender, MouseEventArgs e)
        {
            btnsignin.BackColor = Color.DarkSlateGray;
        }

        private void btnsignin_MouseLeave(object sender, EventArgs e)
        {
            btnsignin.BackColor = Color.DarkCyan;
        }

        private void btnsignup_MouseMove(object sender, MouseEventArgs e)
        {
            btnsignup.BackColor = Color.DarkSlateGray;
        }

        private void btnsignup_MouseLeave(object sender, EventArgs e)
        {
            btnsignup.BackColor = Color.LightSeaGreen;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtPass.TextLength !=0&&txtUser.TextLength!=0)
            {
                if(e.KeyChar ==Convert.ToChar(Keys.Enter))
                {
                    btnsignin_Click(sender, e);
                }
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Enter Username")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }                

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Enter Username";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Enter Password")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
                txtPass.ForeColor = Color.Black;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "Enter Password";
                txtPass.UseSystemPasswordChar = false;
                txtPass.ForeColor = Color.Gray;
            }

        }
    }
}
