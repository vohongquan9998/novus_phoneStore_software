using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormTraCuu
{
    public partial class FormTraCuuKH : Form
    {
        public FormTraCuuKH(int value)
        {
            InitializeComponent();
            ctr = new control();
            switch(value)
            {
                case 0:
                    LoadKH();
                    break;
                case 1://ca nhan
                    dgvDSDT.DataSource = ctr.Search("Cá nhân", 0, "LOAIKH");
                    break;
                case 2://doanh nghiep
                    dgvDSDT.DataSource = ctr.Search("Doanh Nghiệp", 0, "LOAIKH");
                    break;
            }
            ctr.Disconnect();
            dgvDSDT.Columns[2].Width = 250;
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }
        control ctr;
        khachhang info;
        private void LoadKH()
        {
            ctr = new control();
            dgvDSDT.DataSource = ctr.Load("KH").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }
        private void Null()
        {
            if (dgvDSDT.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                LoadKH();
                cboDC.SelectedIndex = -1;
                cboLoai.SelectedIndex = -1;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            info = new khachhang();
            if(txtFindMa.TextLength==0&&txtFindTen.TextLength!=0)
            {
                cboDC.SelectedIndex = -1;
                cboLoai.SelectedIndex = -1;
                info.Tenkh = txtFindTen.Text;
                dgvDSDT.DataSource = ctr.Search(info.Tenkh, 0, "TENKH");
                Null();
                txtFindTen.Text = "";

                
            }
            else if (txtFindMa.TextLength != 0 && txtFindTen.TextLength == 0)
            {
                cboDC.SelectedIndex = -1;
                cboLoai.SelectedIndex = -1;
                info.Makh = txtFindMa.Text;
                dgvDSDT.DataSource = ctr.Search(info.Makh, 0, "MAKH");
                Null();
                txtFindMa.Text = "";
            }
            else if(cboDC.SelectedIndex>=0)
            {
                info.Diachi = cboDC.Text;
                dgvDSDT.DataSource = ctr.Search(info.Diachi, 0, "DIACHI");
                Null();
            }
            else if (cboLoai.SelectedIndex >= 0)
            {
                info.Loaikh = cboLoai.Text;
                dgvDSDT.DataSource = ctr.Search(info.Loaikh, 0, "LOAIKH");
                Null();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc tên vào khung tìm kiếm", "Thông báo");
            }    
            ctr.Disconnect();
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadKH();
            cboDC.SelectedIndex = -1;
            cboLoai.SelectedIndex = -1;
            txtNumItem.Text = dgvDSDT.RowCount.ToString();
        }

        private void cboDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLoai.SelectedIndex = -1;
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDC.SelectedIndex = -1;
        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(10, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("KHÁCH HÀNG", font, brush, 0, 0);
        }
        string makh;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSDT.RowCount > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xoá khách hàng này không?Việc này sẽ xoá tất cả tài khoản của khách hàng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    //if (Check())
                    //{
                        info = new khachhang();
                        ctr = new control();
                        info.Makh = makh;
                        string sohd = ctr.SoHD(info.Makh);
                        ctr.Delete(sohd, "CTHD_HD_KH");
                        ctr.Delete(info.Makh, "HD_KH");
                        ctr.Delete(info.Makh, "USER_MAKH");
                        ctr.Delete(info.Makh, "KH");

                    //}
                    //else
                    //{
                    //    info = new khachhang();
                    //    ctr = new control();
                    //    info.Makh = makh;
                    //    ctr.Delete(info.Makh, "USER_MAKH");
                    //    ctr.Delete(info.Makh, "KH");
                    //}
                    ctr.Disconnect();
                    LoadKH();
                }
            }
        }
        private int CheckHDExist()
        {
            int i;
            ctr = new control();
            info = new khachhang();
            info.Makh = makh;
            i = ctr.CheckExistByInt(info.Makh, "KH_CHECK_HOADON");
            return i;
        }
        private int CheckDDHExist()
        {
            int i;
            ctr = new control();
            info = new khachhang();
            info.Makh = makh;
            i = ctr.CheckExistByInt(info.Makh, "KH_CHECK_DDH");
            return i;
        }

        //private void btnXoa_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if(dgvDSDT.RowCount>0)
        //    {
        //        makh = dgvDSDT.CurrentRow.Cells[0].Value.ToString();
        //        toolTip1.SetToolTip(btnXoa, "Bạn sẽ xoá khách hàng với mã :" + makh);
        //    }    
            
        //}

        private void dgvDSDT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSDT.RowCount > 0)
                makh = dgvDSDT.CurrentRow.Cells[0].Value.ToString();
        }

        private void dgvDSDT_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvDSDT);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }
}
