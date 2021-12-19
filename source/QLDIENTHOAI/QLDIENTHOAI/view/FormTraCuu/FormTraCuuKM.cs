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

namespace QLDIENTHOAI.view.FormTraCuu
{
    public partial class FormTraCuuKM : Form
    {
        public FormTraCuuKM(int value)
        {
            InitializeComponent();
            ctr = new control();
            switch (value)
            {
                case 0:
                    LoadKM();
                    break;
                case 1:
                    dgvDSKM.DataSource = ctr.Search("Giảm Giá", 0, "LOAIKM");
                    break;
                case 2:
                    dgvDSKM.DataSource = ctr.Search("Tặng", 0, "LOAIKM");
                    break;

            }
            //dgvDSKM.Columns[1].Width = 300;
            txtNumItem.Text = dgvDSKM.RowCount.ToString();
        }
        control ctr;
        khuyenmai khuyenmai;
        private void LoadKM()
        {
            ctr = new control();
            dgvDSKM.DataSource = ctr.Load("KM").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void dgvDSKM_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSKM.RowCount>0)
            {
                txtNoiDung.Text = dgvDSKM.CurrentRow.Cells[1].Value.ToString();
            }    
            else
            {
                txtNoiDung.Text = "";
            }    
            
        }
        private void Null()
        {
            if (dgvDSKM.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                LoadKM();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            khuyenmai = new khuyenmai();
            if(txtFindMa.TextLength!=0)
            {
                khuyenmai.Makm = txtFindMa.Text;
                dgvDSKM.DataSource = ctr.Search(khuyenmai.Makm, 0, "MAKM");
                Null();
                txtFindMa.Text = "";
            }
            else if(cboLoai.SelectedIndex>=0)
            {
                khuyenmai.Loaikm = cboLoai.Text;
                Null();
                dgvDSKM.DataSource = ctr.Search(khuyenmai.Loaikm, 0, "LOAIKM");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã vào khung tìm kiếm", "Thông báo");
            }    
            ctr.Disconnect();
            txtNumItem.Text = dgvDSKM.RowCount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadKM();
            cboLoai.SelectedIndex = -1;
            txtNumItem.Text = dgvDSKM.RowCount.ToString();
        }

        private void lbtitle_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(11, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("KHUYẾN MÃI", font, brush, 0, 0);
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.DarkSlateGray;
        }

        private void btnFind_MouseMove(object sender, MouseEventArgs e)
        {
            btnFind.BackColor = Color.DarkSlateGray;
        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
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

        private void btnTC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLKM form = new FormQLKM();
            form.ShowDialog();
        }
        //string[] header = { "Mã khuyến mãi:", "Nội dung:", "Loại khuyến mãi:", "Số tiền giảm giá:" };

        private void dgvDSKM_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string tooltip = ctr.Tooltip(dgvDSKM);
            FormToolTip formToolTip = new FormToolTip(tooltip);
            formToolTip.ShowDialog();
        }
    }
}
