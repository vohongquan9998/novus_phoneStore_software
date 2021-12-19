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
    public partial class FormTraCuuKho : Form
    {
        public FormTraCuuKho()
        {
            InitializeComponent();
            LoadKho();
            LoadPN();
            LoadNCC();
            loadPNWidth();

            txtNumItemPN.Text = dgvPN.Rows.Count.ToString();
            txtNumKho.Text = dgvDSKho.Rows.Count.ToString();
            txtNumNCC.Text = dgvNCC.Rows.Count.ToString();

            if (dgvDSKho.RowCount > 0)
                TongSl();
            else
                txtNumItem.Text = "0";
        }
        private void TongSl()
        {
            ctr = new control();
            txtNumItem.Text = ctr.Tongsl().ToString();
            ctr.Disconnect();
        }
        private void loadPNWidth()
        {
            dgvPN.Columns[0].Width = 150;
            dgvPN.Columns[1].Width = 70;
            dgvPN.Columns[2].Width = 100;
        }

        control ctr;
        kho kho;
        phieunhap phieunhap;
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void LoadKho()
        {
            ctr = new control();
            dgvDSKho.DataSource = ctr.Load("KHO").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void LoadPN()
        {
            ctr = new control();
            dgvPN.DataSource = ctr.Load("PN").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void LoadNCC()
        {
            ctr = new control();
            dgvNCC.DataSource = ctr.Load("NCC").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            kho = new kho();
            phieunhap = new phieunhap();
            if (txtFindMa.TextLength!=0&&txtPN.TextLength==0)
            {
                kho.Makho = txtFindMa.Text;
                dgvDSKho.DataSource = ctr.Search(kho.Makho, 0, "MAKHO");
                txtNumKho.Text = dgvDSKho.Rows.Count.ToString();
                Null(dgvDSKho);
                txtFindMa.Text = "";
            }
            else if (txtFindMa.TextLength == 0 && txtPN.TextLength != 0)
            {
                phieunhap.Mapn = txtPN.Text;
                dgvPN.DataSource = ctr.Search(phieunhap.Mapn, 0, "MAPN");
                txtNumItemPN.Text = dgvPN.Rows.Count.ToString();
                Null(dgvPN);
                txtPN.Text = "";
            }
            else if (numMin.Value >= numMax.Value && txtFindMa.TextLength == 0 && txtPN.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông số chính xác", "Thông báo");
            }
            else if (numMin.Value < numMax.Value && txtFindMa.TextLength == 0 && txtPN.TextLength == 0)
            {
                dgvPN.DataSource = ctr.searchMM(Convert.ToInt32(numMin.Value),Convert.ToInt32(numMax.Value),"PHIEUNHAP");
                Null(dgvPN);
            }
            else 
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc tên vào khung tìm kiếm", "Thông báo");
            }

            ctr.Disconnect();

        }
        private void Null(DataGridView gridView)
        {
            if (gridView.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                ResetAll();
            }
        }

        private void ResetAll()
        {
            LoadKho();
            LoadPN();
            LoadNCC();
            numMax.Value = 0;
            numMin.Value = 0;
            txtNumItemPN.Text = dgvPN.Rows.Count.ToString();
            txtNumKho.Text = dgvDSKho.Rows.Count.ToString();
            txtNumNCC.Text = dgvNCC.Rows.Count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void label16_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(9, 70);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("NCC", font, brush, 0, 0);
        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(11, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("PHIẾU NHẬP", font, brush, 0, 0);
        }

        private void label17_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(18, 105);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("KHO", font, brush, 0, 0);
        }
        private void keypressNum(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void btnTC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLKho formQLKho = new FormQLKho();
            formQLKho.ShowDialog();
        }

        private void Form(string tip)
        {
            FormToolTip formToolTip = new FormToolTip(tip);
            formToolTip.ShowDialog();
        }

        private void dgvDSKho_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string tooltip = ctr.Tooltip(dgvDSKho);
            Form(tooltip);
        }
        private void dgvPN_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string tooltip = ctr.Tooltip(dgvPN);
            Form(tooltip);
        }

        private void dgvNCC_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string tooltip = ctr.Tooltip(dgvNCC);
            Form(tooltip);
        }
    }
}
