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
    public partial class FormThemNV : Form
    {
        string manv;
        public FormThemNV(string value)
        {
            InitializeComponent();
            manv = value;
            txtMa.Text = value;
            cboCV.SelectedIndex = 0;
            CustomDate();
        }
        control ctr;
        nhanvien nv;

        private void CustomDate()
        {
            dtpNgaysinh.Format = DateTimePickerFormat.Custom;
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";

            dtpNgayvl.Format = DateTimePickerFormat.Custom;
            dtpNgayvl.CustomFormat = "dd/MM/yyyy";
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtTen.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên NV", "Thông báo");
                txtTen.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtSDT.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo");
                txtSDT.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số nhà", "Thông báo");
                txtDC.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if(cboDC.Text == "Chọn tỉnh,thành phố")
            {
                MessageBox.Show("Vui lòng chọn tỉnh,thành phố", "Thông báo");
            }    
            else
            {

                if(MessageBox.Show("Bạn có chắc muốn thêm nhân viên?Dữ liệu này sẽ không được hoàn tác lại!", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    ctr = new control();
                    nv = new nhanvien();
                    nv.Manv = txtMa.Text;
                    nv.Tennv = txtTen.Text;
                    nv.Sodt = txtSDT.Text;
                    nv.Diachi = txtDC.Text + "," +cboDC.Text;
                    nv.Chucvu = cboCV.Text;
                    nv.Gt = (radNam.Checked) ? true : false;
                    nv.Ngaysinh =dtpNgaysinh.Value;
                    nv.Ngayvl = dtpNgayvl.Value;

                    ctr.Nhanvien(nv.Manv, nv.Tennv, nv.Sodt, nv.Ngayvl, nv.Ngaysinh, nv.Gt, nv.Chucvu, nv.Diachi, "INSERT");
                    ctr.UpdateRoleID(nv.Manv, 1, nv.Manv);
                    ctr.Disconnect();
                    MessageBox.Show("Chuyển dữ liệu thành công.Vui lòng load lại thông tin dữ liệu", "Thông báo");
                    this.Visible = false;
                    //FormQLUser formQLUser = new FormQLUser(nv.Manv, nv.Tennv, nv.Sodt, nv.Ngayvl, nv.Ngaysinh, nv.Gt, nv.Chucvu,nv.Diachi, true);
                    //this.Visible = false;
                }    
            }




        }

        private void btnResetTT_Click(object sender, EventArgs e)
        {
            foreach(Control c in panel2.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
                if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;
            }
            cboCV.SelectedIndex = 0;
        }

        private void Tooltip(Control control,string text)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(control, text);
        }

        private void txtTen_Enter(object sender, EventArgs e)
        {
            Tooltip(txtTen, "Vui lòng nhập đầy đủ họ tên");
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            Tooltip(txtSDT, "Vui lòng nhập đầy đủ số điện thoại");
        }

        private void txtDC_Enter(object sender, EventArgs e)
        {
            Tooltip(txtDC, "Vui lòng chỉ nhập số nhà thường trú");
        }
    }
}
