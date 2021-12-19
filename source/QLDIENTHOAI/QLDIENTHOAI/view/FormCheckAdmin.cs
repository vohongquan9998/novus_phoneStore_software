using QLDIENTHOAI.controls;
using QLDIENTHOAI.view.FormQuanLy;
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
    public partial class FormCheckAdmin : Form
    {

        public FormCheckAdmin()
        {
            InitializeComponent();
        }
        public FormCheckAdmin(string name)
        {
            InitializeComponent();
            username = name;
            txtTK.Text = username;
        }
        control ctr;
        user user;
        string username;

        private bool CheckAdmin()
        {
            bool check;
            ctr = new control();
            user = new user();
            user.Tentk = txtTK.Text;
            user.Matkhau = user.MD5Hash(txtPass.Text);
            check = ctr.CheckAdmin(user.Tentk, user.Matkhau, "Manager");
            ctr.Disconnect();
            return check;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (CheckAdmin())
            {
                FormCheckAdmin formCheckAdmin = this;
                formCheckAdmin.Visible = false;
                FormQLUser formQLUser = new FormQLUser();
                formQLUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập dưới quyền quản lý thất bại");
                this.Visible = false;
            }    
        }
    }
}
