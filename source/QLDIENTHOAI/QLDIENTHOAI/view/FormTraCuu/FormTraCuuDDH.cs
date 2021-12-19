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
    public partial class FormTraCuuDDH : Form
    {
        public FormTraCuuDDH(int num)
        {
            InitializeComponent();
            DateTime dateTime;
            ctr = new control();
            number = num;
            switch(num)
            {
                case 0:
                    DDH();
                    break;
                case 1:
                    dateTime = DateTime.Now.AddDays(-1);
                    dgvDDH.DataSource = ctr.searchDate(dateTime, DateTime.Now, "DDH");
                    rad1day.Checked = true;
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case 2:
                    dateTime = DateTime.Now.AddMonths(-1);
                    dgvDDH.DataSource = ctr.searchDate(dateTime, DateTime.Now, "DDH");
                    rad1m.Checked = true;
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case 3:
                    dgvDDH.DataSource = ctr.searchBool(true, "DDH");
                    radDagiao.Checked = true;
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case 4:
                    dgvDDH.DataSource = ctr.searchBool(false, "DDH");
                    radChuagiao.Checked = true;
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case 5:
                    CTDDH();
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case 6:
                    CTDDH();
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case 7:
                    CTDDH();
                    tabControl1.SelectedTab = tabPage2;
                    break;
            }
            
        }
        int number;
        control ctr;
        string tab;
        dondathang dondathang;
        ctddh ctddh;
        khachhang khachhang;
        dienthoai dienthoai;

        private void LoadDDH()
        {
            ctr = new control();
            dgvDDH.DataSource = ctr.Load("DDH").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void LoadCTDDH()
        {
            ctr = new control();
            dgvCTDDH.DataSource = ctr.Load("CTDDH").Tables[0].DefaultView;
            ctr.Disconnect();
        }



        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                DDH();
            if(tabControl1.SelectedIndex == 1)
                CTDDH();

        }
        private void DDH()
        {
            LoadDDH();
            tab = "ddh";
            txtNumItem.Text = dgvDDH.RowCount.ToString();
            btnDDHTab.Size = new Size(130, 92);
            btnCTDDHTab.Size = new Size(130, 59);
            groupBox1.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            txtSP.Visible = false;
            cboThanhToan.Visible = false;
            panelCTHD.Location = new Point(8, 246);
            panel2.Size = new Size(261, 249);
            btnFind.Location = new Point(582, 413);
            btnReset.Location = new Point(704, 413);
            label2.Text = "Trị giá";
        }

        private void CTDDH()
        {
            switch (number)
            {
                case 5:
                    LoadCTDDH();
                    break;
                case 6:
                    dgvCTDDH.DataSource = ctr.Search("Thanh toán khi nhận hàng", 0, "CTDDH_HINHTHUCTT");
                    break;
                case 7:
                    dgvCTDDH.DataSource = ctr.Search("Thanh toán thẻ", 0, "CTDDH_HINHTHUCTT");
                    break;
            }
            tab = "ctddh";
            txtNumItem.Text = dgvCTDDH.RowCount.ToString();
            btnDDHTab.Size = new Size(130, 59);
            btnCTDDHTab.Size = new Size(130, 92);
            groupBox1.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            txtSP.Visible = true;
            cboThanhToan.Visible = true;
            panelCTHD.Location = new Point(15, 183);
            panel2.Size = new Size(261, 273);
            btnFind.Location = new Point(582, 436);
            btnReset.Location = new Point(704, 436);
            label2.Text = "Thành tiền";
        }

        private void btnDDHTab_Click(object sender, EventArgs e)
        {
            DDH();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnCTDDHTab_Click(object sender, EventArgs e)
        {
            CTDDH();
            LoadCTDDH();
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
            switch(tab)
            {
                case "ddh":
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case "ctddh":
                    txtNumItem.Text = dgvCTDDH.RowCount.ToString();
                    break;
            }    
        }
        private void Core(TextBox text, DataGridView grid, string str, string key)
        {
            grid.DataSource = ctr.Search(str, 0, key);
            text.Text = "";
        }
        private void Null(DataGridView gridView)
        {
            if (gridView.RowCount == 0)
            {
                MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                ResetAll();
            }
        }
        private void Find()
        {
            ctr = new control();
            dondathang = new dondathang();
            ctddh = new ctddh();

                
            if (txtFindMa.TextLength != 0
                && txttenkh.TextLength == 0
                && txtMaxTG_TT.TextLength == 0
                && txtMinTG_TT.TextLength == 0
                && txtSP.TextLength == 0)
            {
                dondathang.Soddh = txtFindMa.Text;
                switch (tab)
                {
                    case "ddh":
                        Core(txtFindMa, dgvDDH, dondathang.Soddh, "DDH_SODDH");
                        Null(dgvDDH);
                        break;
                    case "ctddh":
                        Core(txtFindMa, dgvCTDDH, dondathang.Soddh, "CTDDH_SODDH");
                        Null(dgvCTDDH);
                        break;
                }
                txtFindMa.Text = "";
            }
            else if (txtFindMa.TextLength == 0
                && txttenkh.TextLength != 0
                && txtMaxTG_TT.TextLength == 0
                && txtMinTG_TT.TextLength == 0
                && txtSP.TextLength == 0)
            {
                khachhang = new khachhang();
                khachhang.Tenkh = txttenkh.Text;
                switch (tab)
                {
                    case "ddh":
                        Core(txttenkh, dgvDDH, khachhang.Tenkh, "DDH_TENKH");
                        break;
                    case "ctddh":
                        Core(txttenkh, dgvCTDDH, khachhang.Tenkh, "CTDDH_TENKH");
                        break;
                }
                txtFindMa.Text = "";
            }
            else if (txtFindMa.TextLength == 0
                 && txttenkh.TextLength == 0
                 && txtMaxTG_TT.TextLength != 0
                 && txtMinTG_TT.TextLength != 0
                 && txtSP.TextLength == 0)
            {
                int min = Convert.ToInt32(txtMinTG_TT.Text);
                int max = Convert.ToInt32(txtMaxTG_TT.Text);
                if (min < max)
                {
                    switch (tab)
                    {
                        case "ddh":
                            dgvDDH.DataSource = ctr.searchMM(min, max, "DDH_TG");
                            Null(dgvDDH);
                            break;
                        case "ctddh":
                            dgvCTDDH.DataSource = ctr.searchMM(min, max, "CTDDH_TT");
                            Null(dgvCTDDH);
                            break;
                    }
                    txtMaxTG_TT.Text = "";
                    txtMinTG_TT.Text = "";
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập chính xác", "Thông báo");
                }

            }
            else if (txtFindMa.TextLength == 0
                 && txttenkh.TextLength == 0
                 && txtMaxTG_TT.TextLength == 0
                 && txtMinTG_TT.TextLength == 0
                 && txtSP.TextLength != 0)
            {

                dienthoai = new dienthoai();
                dienthoai.Tensp = txtSP.Text;
                Core(txtSP, dgvCTDDH, dienthoai.Tensp, "CTDDH_TENSP");
                Null(dgvCTDDH);
                    
            }
            else if(cboThanhToan.SelectedIndex>=0)
            {
                ctddh.Hinhthuctt = cboThanhToan.Text;
                dgvCTDDH.DataSource = ctr.Search(ctddh.Hinhthuctt, 0, "CTDDH_HINHTHUCTT");                    
            }
                ctr.Disconnect();
        }

        private void rad_ngaydat(object sender, EventArgs e)
        {
            if(rad1day.Checked||rad1m.Checked||rad1y.Checked)
            {
                switch(tab)
                {
                    case "ddh":
                        DateTimeCheck(rad1day, rad1m, rad1y, dgvDDH, "DDH");
                        txtNumItem.Text = dgvDDH.RowCount.ToString();
                        break;
                    case "ctddh":
                        DateTimeCheck(rad1day, rad1m, rad1y, dgvCTDDH, "DDH");
                        txtNumItem.Text = dgvCTDDH.RowCount.ToString();
                        break;
                }
            }
            else
            {
                ResetAll();
            }
        }

        private void ResetAll()
        {
            switch (tab)
            {
                case "ddh":
                    LoadDDH();
                    radAlltrangthai.Checked = true;
                    txtNumItem.Text = dgvDDH.RowCount.ToString();
                    break;
                case "ctddh":
                    LoadCTDDH();
                    cboThanhToan.SelectedIndex = -1;
                    txtNumItem.Text = dgvCTDDH.RowCount.ToString();
                    break;
            }
           
        }

        private void DateTimeCheck(RadioButton rad1day, RadioButton rad1m, RadioButton rad1y, DataGridView gridView, string key)
        {
            ctr = new control();
            DateTime date;
            if (rad1day.Checked)
            {
                date = DateTime.Now.AddDays(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            if (rad1m.Checked)
            {
                date = DateTime.Now.AddMonths(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            if (rad1y.Checked)
            {
                date = DateTime.Now.AddYears(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            ctr.Disconnect();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void radTrangThai(object sender, EventArgs e)
        {
            ctr = new control();
            dondathang = new dondathang();
            if(radDagiao.Checked||radChuagiao.Checked)
            {
                if (radDagiao.Checked)
                    dondathang.Dagiao = true;
                else
                    dondathang.Dagiao = false;
                dgvDDH.DataSource = ctr.searchBool(dondathang.Dagiao, "DDH");
                ctr.Disconnect();
                txtNumItem.Text = dgvDDH.RowCount.ToString();
            }
            else
            {
                ResetAll();
            }
        }

        private void dgvDDH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvDDH);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }

        private void dgvCTDDH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvCTDDH);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }
}
