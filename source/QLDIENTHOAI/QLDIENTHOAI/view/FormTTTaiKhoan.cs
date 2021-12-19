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
    public partial class FormTTTaiKhoan : Form
    {
        string username, strid,strpass;
        int roleID;

        public FormTTTaiKhoan(string username,string pass)
        {
            InitializeComponent();
            this.username = username;
            strpass = pass;
            txtMa.Text = username;
            cboLoai.SelectedIndex = 0;
        }
        control ctr;
        khachhang khachhang;
        user user;

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Nếu thoát tài khoản sẽ không được lưu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void btnResetInfo_MouseLeave(object sender, EventArgs e)
        {
            btnResetInfo.BackColor = Color.DarkCyan;
        }

        private void btnResetInfo_MouseMove(object sender, MouseEventArgs e)
        {
            btnResetInfo.BackColor = Color.DarkSlateGray;
        }

        private void btnSave_Fix_MouseMove(object sender, MouseEventArgs e)
        {
            btnSave_Fix.BackColor = Color.DarkSlateGray;
        }

        private void btnSave_Fix_MouseLeave(object sender, EventArgs e)
        {
            btnSave_Fix.BackColor = Color.DarkCyan;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMa.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
                txtMa.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtTen.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo");
                txtTen.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số nhà", "Thông báo");
                txtDC.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if(cboDC.SelectedIndex<0)
            {
                MessageBox.Show("Vui lòng chọn tỉnh thành phố", "Thông báo");
            }    
            else
            {
                user = new user();
                khachhang = new khachhang();
                if (MessageBox.Show("Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctr = new control();
                    user.Tentk = username;
                    user.Matkhau = strpass;
                    user.RoleID = 2;
                    user.Makh = txtMa.Text;
                    khachhang.Makh = txtMa.Text;
                    khachhang.Tenkh = txtTen.Text;
                    khachhang.Sodt = txtSdt.Text;
                    khachhang.Diachi = txtDC.Text+" ,"+cboDC.Text;
                    khachhang.Loaikh = cboLoai.Text;

                    ctr.KhachHang(khachhang.Makh, khachhang.Tenkh, khachhang.Diachi, khachhang.Sodt, khachhang.Loaikh, "INSERT");

                    ctr.User(user.Tentk,user.MD5Hash(user.Matkhau).ToUpper(), user.RoleID ,user.Makh, "INSERT_ND");
                    if (MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        this.Visible = false;
                        FormSplashScreen form = new FormSplashScreen(user.Tentk);
                        form.ShowDialog();
                    }    
                    ctr.Disconnect();
                }
            }
        }


        private bool CheckID()
        {
            bool check;
            ctr = new control();
            user = new user();
            user.Id = strid;
            check = ctr.Check(user.Id, "USERS");
            ctr.Disconnect();
            return check;
        }


        private void btnResetInfo_Click(object sender, EventArgs e)
        {
            foreach(Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
            }
            cboLoai.SelectedIndex = 0;
        }
    }
}
