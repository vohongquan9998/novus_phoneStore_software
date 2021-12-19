using QLDIENTHOAI.controls;
using QLDIENTHOAI.view.FormTraCuu;
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
    public partial class FormQLKM : Form
    {
        public FormQLKM()
        {
            InitializeComponent();
            cboLoai.SelectedIndex = 0;
            LoadKM();
        }
        control ctr;
        khuyenmai khuyenmai;
        private void LoadKM()
        {
            ctr = new control();
            dgvDSKM.DataSource = ctr.Load("KM").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
            }
            txtNoidung.Text = "";
            txtMakm.Enabled = true;
            btnSave.Enabled = true;
            btnSua.Enabled = false;
            btnDelete.Enabled = false;
            cboLoai.Text = "Giảm giá";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboLoai.SelectedIndex == 0)
            {
                txtGiam.Enabled = true;
            }    
            else
            {
                txtGiam.Enabled = false;
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xoá?Dữ liệu sẽ không được phục hồi","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                ctr = new control();
                khuyenmai = new khuyenmai();
                khuyenmai.Makm = txtMakm.Text;
                ctr.Delete(khuyenmai.Makm, "KM");
                ctr.Disconnect();
                MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                LoadKM();
            }    
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadKM();
        }
        
        private void dgvDSKM_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSKM.RowCount>0)
            {
                
                lbNoidung.Text = dgvDSKM.CurrentRow.Cells[1].Value.ToString();
                txtNoidung.Text = lbNoidung.Text;
                txtMakm.Text = dgvDSKM.CurrentRow.Cells[0].Value.ToString();
                cboLoai.Text = dgvDSKM.CurrentRow.Cells[2].Value.ToString();
                txtGiam.Text = dgvDSKM.CurrentRow.Cells[3].Value.ToString();
                txtMakm.Enabled = false;
                btnSave.Enabled = false;
                btnSua.Enabled = true;
                btnDelete.Enabled = true;
            }    
        }
        private bool CheckExistValue()
        {
            bool check;
            ctr = new control();
            khuyenmai = new khuyenmai();
            khuyenmai.Makm = txtMakm.Text;
            check = ctr.Check(khuyenmai.Makm, "KM");
            ctr.Disconnect();
            return check;
        }
        private void LoadInfor()
        {
            khuyenmai = new khuyenmai(txtMakm.Text,txtNoidung.Text,cboLoai.Text,(cboLoai.SelectedIndex==0)?float.Parse(txtGiam.Text):0f);
            //khuyenmai.Makm = txtMakm.Text;
            //khuyenmai.Noidung = txtNoidung.Text;
            //khuyenmai.Loaikm = cboLoai.Text;
            //if (cboLoai.SelectedIndex == 0)
            //    khuyenmai.Giamgia = float.Parse(txtGiam.Text);
            //else
            //    khuyenmai.Giamgia = 0f;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtMakm.TextLength==0)
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo");
                txtMakm.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtNoidung.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập nội dung khuyến mãi", "Thông báo");
                txtNoidung.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if(cboLoai.SelectedIndex == 0 && txtGiam.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền giảm giá của khuyến mãi", "Thông báo");
                txtGiam.BackColor = Color.FromArgb(222, 91, 82);
            }    
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn thêm khuyến mãi này", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (CheckExistValue())
                    {
                        ctr = new control();
                        LoadInfor();

                        ctr.Khuyenmai(khuyenmai.Makm, khuyenmai.Noidung, khuyenmai.Loaikm, khuyenmai.Giamgia, "INSERT");
                        ctr.Disconnect();
                        MessageBox.Show("Đã thêm thành công!", "Thông báo");
                        LoadKM();
                    }  
                    else
                        MessageBox.Show("Mã khuyến mãi này đã tồn tại", "Thông báo");
                }                   
            }    
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMakm.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo");
                txtMakm.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtNoidung.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập nội dung khuyến mãi", "Thông báo");
                txtNoidung.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (cboLoai.SelectedIndex == 0 && txtGiam.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền giảm giá của khuyến mãi", "Thông báo");
                txtGiam.BackColor = Color.FromArgb(222, 91, 82);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa khuyến mãi này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctr = new control();
                    LoadInfor();

                    ctr.Khuyenmai(khuyenmai.Makm, khuyenmai.Noidung, khuyenmai.Loaikm, khuyenmai.Giamgia, "UPDATE");
                    ctr.Disconnect();
                    MessageBox.Show("Đã chỉnh sửa thành công!", "Thông báo");
                    LoadKM();

                }
            }
        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormTraCuuKM traCuuKM = new FormTraCuuKM(0);
            traCuuKM.ShowDialog();
        }

        private void btnResetText_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnResetText, "Cập nhật dữ liệu nhập vào");
            btnResetText.BackColor = Color.DarkSlateGray;
        }

        private void btnSua_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnSua, "Chỉnh sửa dữ liệu");
            btnSua.BackColor = Color.DarkSlateGray;
        }

        private void btnSave_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnSave, "Lưu dữ liệu");
            btnSave.BackColor = Color.DarkSlateGray;
        }

        private void btnDelete_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnDelete, "Xoá dữ liệu");
            btnDelete.BackColor = Color.DarkSlateGray;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnReset, "Cập nhật lại trang");
            btnReset.BackColor = Color.DarkSlateGray;
        }

        private void btnTC_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnTC, "Chuyển đến tính năng tra cứu");
            btnTC.BackColor = Color.DarkSlateGray;
        }

        private void txtMakm_Click(object sender, EventArgs e)
        {
            txtMakm.BackColor = Color.White;

        }

        private void txtGiam_Click(object sender, EventArgs e)
        {
            txtGiam.BackColor = Color.White;
        }

        private void txtNoidung_Click(object sender, EventArgs e)
        {
            txtNoidung.BackColor = Color.White;

        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
        }

        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.BackColor = Color.DarkCyan;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkCyan;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DarkCyan;
        }

        private void btnTC_MouseLeave(object sender, EventArgs e)
        {
            btnTC.BackColor = Color.PaleTurquoise;
        }

        private void btnResetText_MouseLeave(object sender, EventArgs e)
        {
            btnResetText.BackColor = Color.DarkCyan;
        }

        private void btnSua_MouseLeave(object sender, EventArgs e)
        {
            btnSua.BackColor = Color.DarkCyan;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DarkCyan;
        }
    }
}
