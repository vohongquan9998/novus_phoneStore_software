using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormQuanLy
{
    public partial class FormQLKH : Form
    {
        public FormQLKH()
        {
            InitializeComponent();
            LoadForm();
            LoadKH();
        }

        private void LoadForm()
        {
            cboLoai.SelectedIndex = 0;
        }
        control ctr;
        khachhang khachhang;
        user user;

        private void LoadKH()
        {
            ctr = new control();
            dgvDSKH.DataSource = ctr.Load("KH").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(15, 250);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("QUẢN LÝ KHÁCH HÀNG", font, brush, 0, 0);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void btnResetInfo_Click(object sender, EventArgs e)
        {
            foreach(Control c in panel1.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
            }
            cboLoai.SelectedIndex = 0;
            btnSave.Enabled = true;
            btnSua.Enabled = false;
            //btnDelete.Enabled = false;
        }

        private void LoadInformation()
        {
            khachhang = new khachhang(txtMa.Text, txtTen.Text, txtDC.Text + "," + cboDC.Text, txtSdt.Text, cboLoai.Text);
            //khachhang.Makh = txtMa.Text;
            //khachhang.Tenkh = txtTen.Text;
            //khachhang.Diachi = txtDC.Text+","+cboDC.Text;
            //khachhang.Sodt = txtSdt.Text;
            //khachhang.Loaikh = cboLoai.Text;
        }

        private void btnSave_Fix_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ctr = new control();
        }

        private void dgvDSKH_MouseEnter(object sender, EventArgs e)
        {

        }
        private bool CheckValueExist()
        {
            bool check;
            ctr = new control();
            khachhang = new khachhang();
            khachhang.Makh = txtMa.Text;
            check = ctr.Check(khachhang.Makh, "KH");
            ctr.Disconnect();
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMa.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
            }
            else if (txtTen.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo");
            }
            else if (txtSdt.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại", "Thông báo");
            }
            else if (txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo");
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn thêm dữ liệu", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {

                    if (CheckValueExist())
                    {
                        LoadInformation();
                        ctr = new control();
                        ctr.KhachHang(khachhang.Makh, khachhang.Tenkh, khachhang.Diachi, khachhang.Sodt, khachhang.Loaikh, "INSERT");
                        ctr.Disconnect();
                        LoadKH();
                    }
                    else
                        MessageBox.Show("Dữ liệu đã tồn tại", "Thông báo");
                }    
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
            }
            else if (txtTen.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo");
            }
            else if (txtSdt.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại", "Thông báo");
            }
            else if (txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadInformation();
                    ctr = new control();
                    ctr.KhachHang(khachhang.Makh, khachhang.Tenkh, khachhang.Diachi, khachhang.Sodt, khachhang.Loaikh, "UPDATE");
                    ctr.Disconnect();
                    LoadKH();
                }
            }
        }

        private void dgvDSKH_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSKH.RowCount>0)
            {
                btnSave.Enabled = true;
                btnSua.Enabled = false;
                //btnDelete.Enabled = false;
                txtMa.Text = dgvDSKH.CurrentRow.Cells[0].Value.ToString();
                txtTen.Text = dgvDSKH.CurrentRow.Cells[1].Value.ToString();
                string dc = dgvDSKH.CurrentRow.Cells[2].Value.ToString();
                txtDC.Text = dc.Substring(0, dc.LastIndexOf(","));
                //cboDC.Text = dc.Substring(dc.LastIndexOf(",")+1, 21);
                txtSdt.Text = dgvDSKH.CurrentRow.Cells[3].Value.ToString();
                cboLoai.Text = dgvDSKH.CurrentRow.Cells[4].Value.ToString();
            }    
        }
    }
}
