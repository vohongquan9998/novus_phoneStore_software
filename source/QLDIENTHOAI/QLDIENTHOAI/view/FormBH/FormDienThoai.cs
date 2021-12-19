using QLDIENTHOAI.controls;
using QLDIENTHOAI.view.FormBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormBanHang
{
    public partial class FormDienThoai : Form
    {
        string username;
        public FormDienThoai(int value,string name)
        {
            InitializeComponent();
            username = name;
            switch(value)
            {
                case 0:
                    LoadDT();
                    break;
                case 1:
                    index = 0;
                    NhanHieu();
                    break;
                case 2:
                    index = 1;
                    NhanHieu();
                    break;
                case 3:
                    index = 2;
                    NhanHieu();
                    break;
                case 4:
                    index = 3;
                    NhanHieu();
                    break;
            }
            lbMinGia.Text = tbGia.Minimum.ToString();
            lbMaxGia.Text = tbGia.Maximum.ToString();
            num();
            dgvDSDT.Columns["MASP"].Visible = false;
        }
        control ctr;
        int index;
        dienthoai dt;

        private void num()
        {
            lbNum.Text = dgvDSDT.RowCount.ToString() + " Điện thoại";
        }

        private void LoadDT()
        {
            ctr = new control();
            dgvDSDT.DataSource = ctr.Load("DT_BH").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormMenu form = new FormMenu(username);
            form.ShowDialog();
        }

        private void dgvDSDT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSDT.RowCount > 0)
            {

            }
        }

        private void dgvDSDT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelMenu.Visible = true;
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int Xpoint = Cursor.Position.X - 400;
            int Ypoint = Cursor.Position.Y - 300;
            panelMenu.Location = new Point(Xpoint, Ypoint);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panelMenu.Visible = false;
        }

        private void btnAddSP_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnAddSP, "Thêm vào giỏ hàng");
        }

        private void btnInfoSP_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(btnInfoSP, "Thông tin cấu hình");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            find();
        }

        private void Null()
        {
            if (dgvDSDT.RowCount == 0)
            {
                MessageBox.Show("Kết quả tìm kiếm không tồn tại", "Thông báo");
                LoadDT();
            }
        }

        private void find()
        {
            ctr = new control();
            dt = new dienthoai();
            if(rad32.Checked||rad64.Checked||rad128.Checked||rad256.Checked)
            {
                if (rad32.Checked)
                    dt.Dungluong = 32;
                if (rad64.Checked)
                    dt.Dungluong = 64;
                if (rad128.Checked)
                    dt.Dungluong = 128;
                if (rad256.Checked)
                    dt.Dungluong = 256;

                dgvDSDT.DataSource = ctr.Search("", dt.Dungluong, "MENU_DUNGLUONG");
                MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
            }
            else if(cboHDH.SelectedIndex>=0&&cboRam.Text=="RAM")
            {
                dt.Chitiet = cboHDH.Text;
                dgvDSDT.DataSource = ctr.Search(dt.Chitiet, 0, "MENU_CAUHINH");
                cboHDH.Text = "Hệ điều hành";
                MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");

            }
            else if(cboRam.SelectedIndex>=0&&cboHDH.Text=="Hệ điều hành")
            {
                dt.Chitiet = cboRam.Text;
                dgvDSDT.DataSource = ctr.Search(dt.Chitiet, 0, "MENU_CAUHINH");
                cboHDH.Text = "RAM";
                MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
            }    
            else if(tbGia.Value!=tbGia.Maximum&&cboHDH.Text=="Hệ điều hành"&&cboRam.Text=="RAM"&&tbGia.Value>tbGia.Minimum)
            {
                int min = tbGia.Minimum;
                int max = tbGia.Value;
                if(min<max)
                {
                    dgvDSDT.DataSource = ctr.searchMM(min, max, "DT_DG_MENU");
                    tbGia.Value = tbGia.Maximum;
                    lbMaxGia.Text = tbGia.Maximum.ToString();                   
                    if (dgvDSDT.RowCount == 0)
                    {
                        MessageBox.Show("Kết quả tìm kiếm không tồn tại","Thông báo");
                        LoadDT();
                    }
                    else
                        MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
                }  
                else if(min >= max)
                    MessageBox.Show("Vui lòng nhập chính xác", "Thông báo");


            }   
            ctr.Disconnect();
            num();
        }

        private void btnIphone_Click(object sender, EventArgs e)
        {
            index = 0;
            NhanHieu();
            MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
        }

        private void btnSamsung_Click(object sender, EventArgs e)
        {
            index = 1;
            NhanHieu();
            MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
        }

        private void btnVsmart_Click(object sender, EventArgs e)
        {
            index = 2;
            NhanHieu();
            MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
        }

        private void btnOppo_Click(object sender, EventArgs e)
        {
            index = 3;
            NhanHieu();
            MessageBox.Show("Tìm được " + dgvDSDT.RowCount + " kết quả");
        }
        private void NhanHieu()
        {
            ctr = new control();
            dt = new dienthoai();
            switch (index)
            {
                case 0:
                    dgvDSDT.DataSource = ctr.Search("iphone", 0, "MENU_TENSP");
                    break;
                case 1:
                    dgvDSDT.DataSource = ctr.Search("Samsung", 0, "MENU_TENSP");
                    break;
                case 2:
                    dgvDSDT.DataSource = ctr.Search("Vsmart", 0, "MENU_TENSP");
                    break;
                case 3:
                    dgvDSDT.DataSource = ctr.Search("Oppo", 0, "MENU_TENSP");
                    break;
            }
            ctr.Disconnect();
            radAll.Checked = true;
            num();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDT();
            cboHDH.Text = "Hệ điều hành";
            cboRam.Text = "RAM";
            radAll.Checked = true;
            num();
            tbGia.Value = tbGia.Maximum;
            lbMaxGia.Text = tbGia.Maximum.ToString();
        }

        private void tbGia_Scroll(object sender, EventArgs e)
        {
            lbMaxGia.Text = tbGia.Value.ToString();
            radAll.Checked = true;
        }


        private void cboRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHDH.Text = "Hệ điều hành";
            radAll.Checked = true;
        }

        private void cboHDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRam.Text = "RAM";
            radAll.Checked = true;
        }

        private void cbosort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctr = new control();
            if(cbosort.SelectedIndex == 0)
            {
                dgvDSDT.DataSource = ctr.Load("DT_BH_DESC").Tables[0].DefaultView;
            }
            if (cbosort.SelectedIndex == 1)
            {
                dgvDSDT.DataSource = ctr.Load("DT_BH_ASC").Tables[0].DefaultView;
            }
            ctr.Disconnect();
        }

        private void btnInfoSP_Click(object sender, EventArgs e)
        {
            FormThongTinDT formThongTinDT = new FormThongTinDT(dgvDSDT.CurrentRow.Cells["MASP"].Value.ToString());
            formThongTinDT.ShowDialog();
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            FormCart formCart = new FormCart(dgvDSDT.CurrentRow.Cells["MASP"].Value.ToString());
            formCart.ShowDialog();
        }
    }
}
