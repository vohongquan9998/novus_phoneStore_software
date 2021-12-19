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
    public partial class FormQLNCC : Form
    {
        public FormQLNCC()
        {
            InitializeComponent();
            LoadNCC();
        }
        control ctr;
        nhacungcap ncc;
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void LoadNCC()
        {
            ctr = new control();
            dgvNCC.DataSource = ctr.Load("NCC").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadNCC();
            txtMaNCC.Text = "";
            txtNCC.Text = "";
            txtDC.Text = "";
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnFix.Enabled = false;
            txtMaNCC.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo");
            }
            else if(txtNCC.TextLength==0)
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo");
            }   
            else if(txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp", "Thông báo");
            }  
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn thêm dữ liệu?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (CheckValueExist())
                    {
                        ctr = new control();
                        LoadInfo();
                        ctr.NCC(ncc.Mancc, ncc.Tenncc, ncc.Diachi, "INSERT");
                        ctr.Disconnect();
                        MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                        LoadNCC();
                    }
                    else
                        MessageBox.Show("Dữ liệu đã tồn tại", "Thông báo");
                }    
 
                
            }    
        }

        private void LoadInfo()
        {
            ncc = new nhacungcap();
            ncc.Mancc = txtMaNCC.Text;
            ncc.Tenncc = txtNCC.Text;
            ncc.Diachi = txtDC.Text;

        }

        private bool CheckValueExist()
        {
            bool check;
            ctr = new control();
            ncc = new nhacungcap();
            ncc.Mancc = txtMaNCC.Text;
            check = ctr.Check(ncc.Mancc, "NCC");
            ctr.Disconnect();
            return check;
        }

        private int CheckPN()
        {
            int i;
            ctr = new control();
            ncc = new nhacungcap();
            ncc.Mancc = txtMaNCC.Text;
            i = ctr.CheckExistByInt(ncc.Mancc, "PN_CHECK_NCC");
            ctr.Disconnect();
            return i;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo");
            }
            else if (txtNCC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo");
            }
            else if (txtDC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctr = new control();
                    LoadInfo();
                    ctr.NCC(ncc.Mancc, ncc.Tenncc, ncc.Diachi, "UPDATE");
                    ctr.Disconnect();
                    MessageBox.Show("Sửa dữ liệu thành công", "Thông báo");
                    LoadNCC();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu?Những dữ liệu liên quan cũng sẽ bị xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (CheckPN() != 0)
                {
                    ctr = new control();
                    ncc = new nhacungcap();
                    ncc.Mancc = txtMaNCC.Text;
                    ctr.Delete(ncc.Mancc, "NCC_PN");
                    ctr.Delete(ncc.Mancc, "NCC");
                    MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                    LoadNCC();
                }
                else
                {
                    ctr = new control();
                    ncc = new nhacungcap();
                    ncc.Mancc = txtMaNCC.Text;
                    ctr.Delete(ncc.Mancc, "NCC");
                    MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                    LoadNCC();
                }
            } 
        }

        private void dgvNCC_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvNCC.RowCount>0)
            {
                txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                txtNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                txtDC.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
                btnDelete.Enabled = true;
                btnFix.Enabled = true;
                btnAdd.Enabled = false;
                txtMaNCC.Enabled = false;
            }    

        }
    }
}
