using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormBH
{
    public partial class FormAccount : Form
    {
        string username,ten,dc,sdt,loaikh;
        public FormAccount(string _name,string _ten,string _dc,string _sdt,string _loaikh)
        {
            InitializeComponent();
            username = _name;
            ten = _ten;
            dc = _dc;
            sdt = _sdt;
            loaikh = _loaikh;
            txtTenTK.Text = username;
            txtTenND.Text = ten;
            txtDC.Text = dc;
            txtSDT.Text = sdt;
            cboLoai.Text = loaikh;
        }
        control ctr;
        khachhang kh;
        user user;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void Message(string mess1,string mess2)
        {
            switch(chedo)
            {
                case 1:
                    MessageBox.Show(mess1, "Thông báo");
                    break;
                case 3:
                    MessageBox.Show(mess2, "Thông báo");
                    break;
            }    
        }
        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            
            if (txtTenND.TextLength == 0)
            {
                Message("Vui lòng nhập tên của bạn", "Vui lòng nhập mật khẩu cũ");
                txtTenND.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtDC.TextLength == 0)
            {
                Message("Vui lòng nhập địa chỉ của bạn", "Vui lòng nhập mật khẩu mới");
                txtDC.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtSDT.TextLength == 0)
            {
                Message("Vui lòng nhập số điện thoại của bạn", "Vui lòng nhập lại mật khẩu mới");
                txtSDT.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtTenND.Text!=getPass()&&chedo==3)
            {
                Message("", "Mật khẩu cũ không trùng khớp");
                txtTenND.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (!txtDC.Text.Equals(txtSDT.Text)&&chedo == 3)
            {
                Message("", "Mật khẩu mới và nhập lại mật khẩu không trùng khớp");
                txtSDT.BackColor = Color.FromArgb(222, 91, 82);
                txtDC.BackColor = Color.FromArgb(222, 91, 82);
            }                
            else
            {
                if (MessageBox.Show("Xác nhận thay đổi", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ctr = new control();
                    switch (chedo)
                    {
                        case 1:
                            LoadInfo();
                            ctr.KhachHang(kh.Makh, kh.Tenkh, kh.Diachi, kh.Sodt, kh.Loaikh, "UPDATE");
                            break;
                        case 3:
                            LoadInfoUser();
                            ctr.UpdatePassword(user.Tentk, user.Matkhau, mkmoi);
                            break;
                    }
                    ctr.Disconnect();
                    MessageBox.Show("Thay đổi thành công", "Thông báo");
                    this.Visible = false;
                }
            }
        }

        private string getPass()
        {
            string pass;
            ctr = new control();
            user = new user();
            user.Tentk = txtTenTK.Text;
            pass = ctr.GetValueAccount(user.Tentk, "PASS");
            ctr.Disconnect();
            return pass;
        }

        string mkmoi;
        private void LoadInfoUser()
        {
            user = new user();
            user.Tentk = txtTenTK.Text;
            user.Matkhau = txtTenND.Text;
            mkmoi = txtDC.Text;

        }

        int chedo =1;
        private void btnTTAcc_Click(object sender, EventArgs e)
        {
            chedo = 1;
            setCheDo();
        }
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            chedo = 2;
            setCheDo();
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            chedo = 3;
            setCheDo();
        }


        private void setCheDo()
        {
            switch(chedo)
            {
                case 1:
                    foreach(Control c in panel3.Controls)
                    {
                        if (c is TextBox)
                            c.Visible = true;
                        if (c is ComboBox)
                            c.Visible = true;
                    }
                    txtDC.Text = dc;
                    txtSDT.Text = sdt;
                    txtTenND.Text = ten;
                    label2.Text = "Tên người dùng:";
                    label3.Text = "Địa chỉ:";
                    label4.Text = "Số điện thoại:";
                    label5.Visible = true;
                    label6.Visible = true;
                    label2.Font = new Font("Microsoft Sans Serif", 11);
                    label3.Font = new Font("Microsoft Sans Serif", 11);
                    label4.Font = new Font("Microsoft Sans Serif", 11);
                    txtDC.Location = new Point(67, 74);
                    txtDC.Size = new Size(173, 20);
                    txtSDT.Location = new Point(97, 99);
                    txtSDT.Size = new Size(143, 20);
                    btnChangeInfo.Text = "Thay đổi thông tin";
                    txtTenND.BackColor = Color.White;
                    txtDC.BackColor = Color.White;
                    txtSDT.BackColor = Color.White;
                    txtDC.UseSystemPasswordChar = false;
                    txtSDT.UseSystemPasswordChar = false;
                    txtTenND.UseSystemPasswordChar = false;
                    break;
                case 2:
                    break;
                case 3:
                    txtDC.Text = "";
                    txtSDT.Text = "";
                    txtTenND.Text = "";
                    label2.Text = "Mật khẩu cũ:";
                    label3.Text = "Mật khẩu mới:";
                    label4.Text = "Nhập lại mật khẩu:";
                    label2.Font = new Font("Microsoft Sans Serif", 10);
                    label3.Font = new Font("Microsoft Sans Serif", 10);
                    label4.Font = new Font("Microsoft Sans Serif",10);
                    txtDC.Location = new Point(118, 74);
                    txtDC.Size = new Size(123, 20);
                    txtSDT.Location = new Point(118, 99);
                    txtSDT.Size = new Size(123, 20);
                    cboLoai.Visible = false;
                    label6.Visible = false;
                    txtTongHD.Visible = false;
                    label5.Visible = false;
                    btnChangeInfo.Text = "Cập nhật mật khẩu";
                    txtTenND.BackColor = Color.White;
                    txtDC.BackColor = Color.White;
                    txtSDT.BackColor = Color.White;
                    txtDC.UseSystemPasswordChar = true;
                    txtSDT.UseSystemPasswordChar = true;
                    txtTenND.UseSystemPasswordChar = true;
                    break;
            }    
        }
        private void LoadInfo()
        {
            kh = new khachhang();
            kh.Makh = txtTenTK.Text;
            kh.Tenkh = txtTenND.Text;
            kh.Diachi = txtDC.Text;
            kh.Sodt = txtSDT.Text;
            kh.Loaikh = cboLoai.Text;
        }

        private void txtTenND_Click(object sender, EventArgs e)
        {
            txtTenND.BackColor = Color.White;
        }

        private void txtDC_Click(object sender, EventArgs e)
        {
            txtDC.BackColor = Color.White;
        }

        private void txtSDT_Click(object sender, EventArgs e)
        {
            txtSDT.BackColor = Color.White;
        }

    }
}
