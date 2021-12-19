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
    public partial class FormTraCuuNV : Form
    {
        public FormTraCuuNV(int value)
        {
            InitializeComponent();
            ctr = new control();
            switch(value)
            {
                case 0:
                    LoadNV();
                    break;
                case 1:
                    dgvDSNV.DataSource = ctr.Search("Manager", 0, "CHUCVU");
                    break;
                case 2:
                    dgvDSNV.DataSource = ctr.Search("Staff", 0, "CHUCVU");
                    break;
            }
            txtNumItem.Text = dgvDSNV.RowCount.ToString();
        }
        control ctr;
        nhanvien info;
        private void LoadNV()
        {
            ctr = new control();
            dgvDSNV.DataSource = ctr.Load("NV").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadNV();
            cboCV.SelectedIndex = -1;
            txtNumItem.Text = dgvDSNV.RowCount.ToString();
        }
        private void Null()
        {
            if (dgvDSNV.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                LoadNV();
                cboCV.SelectedIndex = -1;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            info = new nhanvien();
            if (txtFindMa.TextLength == 0 && txtFindTen.TextLength != 0)
            {
                cboCV.SelectedIndex = -1;
                info.Tennv = txtFindTen.Text;
                dgvDSNV.DataSource = ctr.Search(info.Tennv, 0, "TENNV");
                Null();
                txtFindTen.Text = "";

            }
            else if (txtFindMa.TextLength != 0 && txtFindTen.TextLength == 0)
            {
                cboCV.SelectedIndex = -1;
                info.Manv = txtFindMa.Text;
                dgvDSNV.DataSource = ctr.Search(info.Manv, 0, "MANV");
                Null();
                txtFindMa.Text = "";
            }
            else if (cboCV.SelectedIndex >= 0)
            {
                info.Chucvu = cboCV.Text;
                dgvDSNV.DataSource = ctr.Search(info.Chucvu, 0, "CHUCVU");
                Null();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc tên vào khung tìm kiếm", "Thông báo");
            }    
            ctr.Disconnect();
            txtNumItem.Text = dgvDSNV.RowCount.ToString();
        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(10, 165);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("NHÂN VIÊN", font, brush, 0, 0);
        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
        }

        private void btnFind_MouseMove(object sender, MouseEventArgs e)
        {
            btnFind.BackColor = Color.DarkSlateGray;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.DarkSlateGray;
        }

        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.BackColor = Color.DarkCyan;
        }

        private void btnFind_MouseLeave(object sender, EventArgs e)
        {
            btnFind.BackColor = Color.DarkCyan;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DarkCyan;
        }

        private void dgvDSNV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvDSNV);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }

}
