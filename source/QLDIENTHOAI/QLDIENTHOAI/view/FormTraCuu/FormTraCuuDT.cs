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
    public partial class FormTraCuuDT : Form
    {
        public FormTraCuuDT(int value)
        {
            InitializeComponent();
            ctrl = new control();
            switch (value)
            {
                case 0:
                    LoadDT();
                    LoadDGVWidth();
                    break;
                case 1: //iphone
                    dgvDSDT.DataSource = ctrl.Search("iPhone", 0, "TENSP");
                    break;
                case 2: //samsung
                    dgvDSDT.DataSource = ctrl.Search("Samsung", 0, "TENSP");
                    break;
                case 3: //vsmart
                    dgvDSDT.DataSource = ctrl.Search("Vsmart", 0, "TENSP");
                    break;
                case 4: //oppo
                    dgvDSDT.DataSource = ctrl.Search("Oppo", 0, "TENSP");
                    break;
                case 5: //32gb
                    dgvDSDT.DataSource = ctrl.Search("", 32, "DUNGLUONG");
                    rad32.Checked = true;
                    break;
                case 6: //64gb
                    dgvDSDT.DataSource = ctrl.Search("", 64, "DUNGLUONG");
                    rad64.Checked = true;
                    break;
                case 7: //128gb
                    dgvDSDT.DataSource = ctrl.Search("", 128, "DUNGLUONG");
                    rad128.Checked = true;
                    break;
                case 8: //256gb
                    dgvDSDT.DataSource = ctrl.Search("", 256, "DUNGLUONG");
                    rad256.Checked = true;
                    break;
            }
            ctrl.Disconnect();
            dgvDSDT.Columns["Mã khuyến mãi"].Visible = false;
            dgvDSDT.Columns["Mã kho"].Visible = false;
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }



        private void LoadDGVWidth()
        {
            dgvDSDT.Columns[1].Width = 150;
            dgvDSDT.Columns[6].Width = 400;
        }

        control ctrl;
        dienthoai info;

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }
        private void LoadDT()
        {
            ctrl = new control();
            dgvDSDT.DataSource = ctrl.Load("DT2").Tables[0].DefaultView;
            ctrl.Disconnect();
        }

        private void dgvDSDT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSDT.RowCount > 0)
            {

                txtCT.Text = dgvDSDT.CurrentRow.Cells[6].Value.ToString();

                //String col = "Mã SP:" + dgvDSDT.CurrentRow.Cells[0].Value.ToString() + ",";
                //col += "Tên SP:" + dgvDSDT.CurrentRow.Cells[1].Value.ToString() + ",";
                //col += "Bảo hành:" + dgvDSDT.CurrentRow.Cells[2].Value.ToString() + ",";
                //col += "Dung lượng:" + dgvDSDT.CurrentRow.Cells[3].Value.ToString() + ",";
                //col += "Xuất Sứ:" + dgvDSDT.CurrentRow.Cells[4].Value.ToString() + ",";
                //col += "Màu:" + dgvDSDT.CurrentRow.Cells[5].Value.ToString() + ",";
                //if (Convert.ToBoolean(dgvDSDT.CurrentRow.Cells[7].Value) == true)
                //    col += "Trạng thái:Còn hàng,";
                //else
                //    col += "Trạng thái:Hết hàng,";
                //col += "Đơn giá:" + dgvDSDT.CurrentRow.Cells[8].Value.ToString() + ",";
                //col += "Mã khuyến mãi:" + dgvDSDT.CurrentRow.Cells[9].Value.ToString() + ",";
                //col += "Khuyến mãi:" + dgvDSDT.CurrentRow.Cells[10].Value.ToString() + ",";
                //col += "Mã Kho:" + dgvDSDT.CurrentRow.Cells[11].Value.ToString();
                //txtThongtin.Text = col;
            }    
            else
            {
                //txtThongtin.Text = "";
                txtCT.Text = "";
            }    

        }
        private void Null()
        {
            if (dgvDSDT.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                LoadDT();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctrl = new control();
            info = new dienthoai();
            if(txtMASP.TextLength==0&&txtTenDT.TextLength!=0)
            {
                info.Tensp = txtTenDT.Text;
                dgvDSDT.DataSource = ctrl.Search(info.Tensp,0, "TENSP");
                Null();
                txtTenDT.Text = "";
            }
            else if(txtMASP.TextLength != 0 && txtTenDT.TextLength == 0)
            {
                info.Masp = txtMASP.Text;
                dgvDSDT.DataSource = ctrl.Search(info.Masp, 0, "MASP");
                Null();
                txtMASP.Text = "";
            }
            else if(txtDonGiaMin.TextLength!=0 && txtDonGiaMax.TextLength != 0 && txtTenDT.TextLength == 0&& txtMASP.TextLength == 0)
            {
                int min, max;
                min = Convert.ToInt32(txtDonGiaMin.Text);
                max = Convert.ToInt32(txtDonGiaMax.Text);
                if(min<max)
                {
                    dgvDSDT.DataSource = ctrl.searchMM(min, max, "DT_DG");
                    Null();
                    txtDonGiaMin.Text = "";
                    txtDonGiaMax.Text = "";
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập Đơn giá chính xác", "Thông báo");
                }    

            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc tên vào khung tìm kiếm", "Thông báo");
            }
            ctrl.Disconnect();
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {     
            foreach(Control c in groupBox2.Controls)
            {
                if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
            }
            radAll.Checked = true;
            LoadDT();
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }
        
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            ctrl = new control();
            info = new dienthoai();
            if(rad32.Checked||rad64.Checked||rad256.Checked||rad128.Checked)
            {
                if (rad32.Checked)
                    info.Dungluong = 32;
                if (rad64.Checked)
                    info.Dungluong = 64;
                if (rad128.Checked)
                    info.Dungluong = 128;
                if (rad256.Checked)
                    info.Dungluong = 256;
                dgvDSDT.DataSource = ctrl.Search("", info.Dungluong, "DUNGLUONG");
                txtNumItem.Text = dgvDSDT.RowCount.ToString();
                ctrl.Disconnect();
            }
            else if(radAll.Checked)
            {
                LoadDT();
                txtNumItem.Text = dgvDSDT.RowCount.ToString();
            }

        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(15, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("ĐIỆN THOẠI", font, brush, 0, 0);
        }

        private void keypressNum(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar)||char.IsSymbol(e.KeyChar)||char.IsWhiteSpace(e.KeyChar)||char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLDT formQLDT = new FormQLDT();
            formQLDT.ShowDialog();
        }

        private void btnFind_MouseMove(object sender, MouseEventArgs e)
        {
            btnFind.BackColor = Color.DarkSlateGray;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.DarkSlateGray;
        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
        }

        private void btnQL_MouseMove(object sender, MouseEventArgs e)
        {
            btnQL.BackColor = Color.DarkSlateGray;
        }

        private void btnFind_MouseLeave(object sender, EventArgs e)
        {
            btnFind.BackColor = Color.DarkCyan;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DarkCyan;
        }

        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.BackColor = Color.DarkCyan;
        }

        private void btnQL_MouseLeave(object sender, EventArgs e)
        {
            btnQL.BackColor = Color.PaleTurquoise;
        }

        private void rad32_MouseMove(object sender, MouseEventArgs e)
        {
            rad32.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void rad64_MouseMove(object sender, MouseEventArgs e)
        {
            rad64.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void rad256_MouseMove(object sender, MouseEventArgs e)
        {
            rad256.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void rad128_MouseMove(object sender, MouseEventArgs e)
        {
            rad128.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void rad32_MouseLeave(object sender, EventArgs e)
        {
            rad32.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void rad64_MouseLeave(object sender, EventArgs e)
        {
            rad64.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void rad128_MouseLeave(object sender, EventArgs e)
        {
            rad128.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void rad256_MouseLeave(object sender, EventArgs e)
        {
            rad256.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void chkTrangThai(object sender, EventArgs e)
        {
            if(radConhang.Checked || radHetHang.Checked)
            {
                ctrl = new control();
                info = new dienthoai();

                if (radConhang.Checked)
                    info.Trangthai = true;
                else
                    info.Trangthai = false;
                dgvDSDT.DataSource = ctrl.searchBool(info.Trangthai, "DT");
                txtNumItem.Text = dgvDSDT.RowCount.ToString();
                ctrl.Disconnect();
                Null();
            }   
            else
            {
                LoadDT();
            }    
        }

        private void dgvDSDT_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctrl = new control();
            string a = ctrl.Tooltip(dgvDSDT);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }
}
