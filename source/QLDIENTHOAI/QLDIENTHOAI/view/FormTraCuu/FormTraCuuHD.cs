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
    public partial class FormTraCuuHD : Form
    {
        control ctr;
        hoadon hd;
        cthd cthd;
        khachhang kh;
        nhanvien nv;
        dienthoai dt;
        int index;
        public FormTraCuuHD(int value)
        {

            InitializeComponent();
            ctr = new control();
            DateTime dateTime;
            index = value;
            switch(value)
            {
                case 0:
                    HD();
                    break;
                case 1:
                    dateTime = DateTime.Now.AddDays(-1);
                    dgvDSHD.DataSource = ctr.searchDate(dateTime, DateTime.Now, "HD");
                    rad1day.Checked = true;
                    txtNumItem.Text = dgvDSHD.RowCount.ToString();
                    break;
                case 2:
                    dateTime = DateTime.Now.AddMonths(-1);
                    dgvDSHD.DataSource = ctr.searchDate(dateTime, DateTime.Now, "HD");
                    rad1m.Checked = true;
                    txtNumItem.Text = dgvDSHD.RowCount.ToString();
                    break;
                case 3:
                    dateTime = DateTime.Now.AddYears(-1);
                    dgvDSHD.DataSource = ctr.searchDate(dateTime, DateTime.Now, "HD");
                    rad1y.Checked = true;
                    txtNumItem.Text = dgvDSHD.RowCount.ToString();
                    break;
                case 5:
                    CTHD();
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case 6:
                    SL(10);
                    CTHD();
                    break;
                case 7:
                    SL(50);
                    CTHD();
                    break;
                case 8:
                    SL(150);
                    CTHD();
                    break;
            }
            ctr.Disconnect();
            txtNumItem.Text = dgvDSHD.RowCount.ToString();
        }

        string tab = "";
        private void LoadHD()
        {
            ctr = new control();
            dgvDSHD.DataSource = ctr.Load("HD").Tables[0].DefaultView;
            ctr.Disconnect();

        }

        private void SL(int sl)
        {
            tab = "cthd";
            tabControl1.SelectedTab = tabPage2;
            dgvCTHD.DataSource = ctr.Search("", sl, "CTHD_SL");
            txtNumItem.Text = dgvCTHD.RowCount.ToString();
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
                HD();
            if (tabControl1.SelectedIndex == 1)
                CTHD();

        }

        private void LoadCTHD()
        {
            ctr = new control();
            dgvCTHD.DataSource = ctr.Load("CTHD").Tables[0].DefaultView;
            ctr.Disconnect();
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
            hd = new hoadon();
            cthd = new cthd();
            kh = new khachhang();
            nv = new nhanvien();
            dt = new dienthoai();
            if (txtFindMa.TextLength != 0
            && txttenkh.TextLength == 0
            && txtNV.TextLength == 0
            && txtTGia_MaSP_Min.TextLength == 0
            && txtTGia_Max.TextLength == 0 
            && txtTenSP.TextLength == 0
            && txtTTmax.TextLength==0
            && txtTTmin.TextLength==0)
            {
                hd.Sohd =Convert.ToInt32(txtFindMa.Text);
                switch (tab)
                {
                    case "hd":
                        Core(txtFindMa, dgvDSHD, hd.Sohd.ToString(), "HD_SOHD");
                        Null(dgvDSHD);
                        break;
                    case "cthd":
                        Core(txtFindMa, dgvCTHD, hd.Sohd.ToString(), "CTHD_SOHD");
                        Null(dgvCTHD);
                        break;
                }

            }
            else if (txtFindMa.TextLength == 0
            && txttenkh.TextLength != 0
            && txtNV.TextLength == 0
            && txtTGia_MaSP_Min.TextLength == 0
            && txtTGia_Max.TextLength == 0
            && txtTenSP.TextLength == 0
            && txtTTmax.TextLength == 0
            && txtTTmin.TextLength == 0)
            {
                kh.Tenkh = txttenkh.Text;
                switch (tab)
                {
                    case "hd":
                        Core(txttenkh, dgvDSHD, kh.Tenkh, "HD_TENKH"); 
                        Null(dgvDSHD);
                        break;
                    case "cthd":
                        Core(txttenkh, dgvCTHD, kh.Tenkh, "CTHD_TENKH");
                        Null(dgvCTHD);
                        break;
                }
            }
            else if (txtFindMa.TextLength == 0
            && txttenkh.TextLength == 0
            && txtNV.TextLength != 0
            && txtTGia_MaSP_Min.TextLength == 0
            && txtTGia_Max.TextLength == 0
            && txtTenSP.TextLength == 0
            && txtTTmax.TextLength == 0
            && txtTTmin.TextLength == 0)
            {
                nv.Tennv = txtNV.Text;
                switch (tab)
                {
                    case "hd":
                        Core(txtNV, dgvDSHD, nv.Tennv, "HD_TENNV");
                        Null(dgvDSHD);
                        break;
                    case "cthd":
                        Core(txtNV, dgvDSHD, nv.Tennv, "CTHD_TENNV");
                        Null(dgvCTHD);
                        break;
                }
            }
            else if (txtFindMa.TextLength == 0
            && txttenkh.TextLength == 0
            && txtNV.TextLength == 0
            && txtTGia_MaSP_Min.TextLength != 0
            && txtTenSP.TextLength == 0
            && txtTTmax.TextLength == 0
            && txtTTmin.TextLength == 0)
            {
                if (txtTGia_Max.TextLength != 0 && txtTGia_MaSP_Min.TextLength != 0)
                {
                    int min = Convert.ToInt32(txtTGia_MaSP_Min.Text);
                    int max = Convert.ToInt32(txtTGia_Max.Text);
                    if (min < max)
                    {
                        dgvDSHD.DataSource = ctr.searchMM(min, max, "HD_TG");
                        Null(dgvDSHD);
                        txtTGia_MaSP_Min.Text = "";
                        txtTGia_Max.Text = "";
                    }
                    else
                        MessageBox.Show("Vui lòng nhập giá trị chính xác", "Thông báo");
                }
                else if (txtTGia_MaSP_Min.TextLength != 0 && tab == "cthd")
                {
                    dt.Masp = txtTGia_MaSP_Min.Text;
                    Core(txtTGia_MaSP_Min, dgvCTHD, dt.Masp, "CTHD_MASP");
                    Null(dgvCTHD);
                }
            }
            else if(txtFindMa.TextLength == 0
            && txttenkh.TextLength == 0
            && txtNV.TextLength == 0
            && txtTGia_MaSP_Min.TextLength == 0
            && txtTGia_Max.TextLength == 0
            && txtTenSP.TextLength != 0
            && txtTTmax.TextLength == 0
            && txtTTmin.TextLength == 0)
            {
                dt.Tensp = txtTenSP.Text;
                Core(txtTenSP, dgvCTHD, dt.Tensp, "CTHD_TENSP");
                Null(dgvCTHD);
            }
            else if (txtFindMa.TextLength == 0
            && txttenkh.TextLength == 0
            && txtNV.TextLength == 0
            && txtTGia_MaSP_Min.TextLength == 0
            && txtTGia_Max.TextLength == 0
            && txtTenSP.TextLength == 0
            && txtTTmax.TextLength != 0
            && txtTTmin.TextLength != 0)
            {
                int min = Convert.ToInt32(txtTTmin.Text);
                int max = Convert.ToInt32(txtTTmax.Text);
                if(min < max)
                {
                    dgvCTHD.DataSource = ctr.searchMM(min, max, "CTHD_TT");
                    Null(dgvCTHD);
                    txtTTmax.Text = "";
                    txtTTmin.Text = "";
                }
                else
                    MessageBox.Show("Vui lòng nhập giá trị chính xác", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập gì đó vào khung tìm kiếm", "Thông báo");
            }
            ctr.Disconnect();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
            switch (tab)
            {
                case "hd":
                    txtNumItem.Text = dgvDSHD.RowCount.ToString();
                    break;
                case "cthd":
                    txtNumItem.Text = dgvCTHD.RowCount.ToString();
                    break;
            }
        }
        private void ResetAll()
        {
            switch (tab)
            {
                case "hd":
                    LoadHD();
                    txtNumItem.Text = dgvDSHD.RowCount.ToString();
                    break;
                case "cthd":
                    LoadCTHD();
                    txtNumItem.Text = dgvCTHD.RowCount.ToString();
                    break;
            }
            radAll.Checked = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void DatetimeCheck(RadioButton d,RadioButton m,RadioButton y,DataGridView gridView,string key)
        {
            ctr = new control();
            DateTime date;
            if (d.Checked)
            {
                date = DateTime.Now.AddDays(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            if (m.Checked)
            {
                date = DateTime.Now.AddMonths(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            if (y.Checked)
            {
                date = DateTime.Now.AddYears(-1);
                gridView.DataSource = ctr.searchDate(date, DateTime.Now, key);
            }
            ctr.Disconnect();
        }

        private void chk_change(object sender, EventArgs e)
        {
            
            if (rad1day.Checked || rad1m.Checked || rad1y.Checked)
            {
                switch (tab)
                {
                    case "hd":
                        DatetimeCheck(rad1day, rad1m, rad1y, dgvDSHD,"HD");
                        break;
                    case "cthd":
                        DatetimeCheck(rad1day, rad1m, rad1y, dgvCTHD,"CTHD");
                        break;
                }
            }
            else if(radAll.Checked)
            {
                ResetAll();          
            }
        }
        private void keypressNum(object sender, KeyPressEventArgs e)
        {
            if(tab == "hd")
            {
                if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }    

        }


        private void dgvDSHD_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ShowTT(dgvDSHD);
            if (dgvDSHD.RowCount > 0)
            {
                string tt = "";
                string[] HD = { "Số hoá đơn:", "Ngày lập:", "Mã khách hàng", "Tên khách hàng:", "Mã nhân viên:", "Tên nhân viên:", "Trị giá:" };
                for (int i = 0; i < dgvDSHD.Columns.Count; i++)
                {
                    tt += HD[i] + dgvDSHD.CurrentRow.Cells[i].Value.ToString() + ",";
                    if (i == dgvDSHD.Columns.Count - 1)
                    {
                        tt += HD[dgvDSHD.Columns.Count - 1] + dgvDSHD.CurrentRow.Cells[i].Value.ToString();
                    }
                }
                txtTT.Text = tt;
            }   

        }

        private void dgvCTHD_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ShowTT(dgvCTHD);
            if (dgvCTHD.RowCount > 0)
            {
                string tt = "";
                string[] CTHD = { "Số hoá đơn:", "Mã điện thoại:", "Tên điện thoại:", "Ngày lập:", "Tên khách hàng:", "Tên nhân viên:", "Số lượng:", "Đơn giá:", "Thành tiền:" };
                for (int i = 0; i < dgvCTHD.Columns.Count; i++)
                {
                    tt += CTHD[i] + dgvCTHD.CurrentRow.Cells[i].Value.ToString() + ",";
                    if (i == dgvCTHD.Columns.Count - 1)
                    {
                        tt += CTHD[dgvCTHD.Columns.Count - 1] + dgvCTHD.CurrentRow.Cells[i].Value.ToString();
                    }
                }
                txtTT.Text = tt;
            }    

        }
        private void btnFind_MouseMove(object sender, MouseEventArgs e)
        {
            btnFind.BackColor = Color.DarkSlateGray;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.DarkSlateGray;
        }
        private void btnFind_MouseLeave(object sender, EventArgs e)
        {
            btnFind.BackColor = Color.DarkCyan;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DarkCyan;
        }
        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
        }
        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.BackColor = Color.DarkCyan;
        }

        private void HD()
        {
            LoadHD();
            tab = "hd";
            txtNumItem.Text = dgvDSHD.RowCount.ToString();
            grthongtin.Size = new Size(309, 360);
            grthongtin.Location = new Point(572, 318);
            pnlbutton.Location = new Point(569, 248);
            grtimkiem.Size = new Size(311, 187);
            label6.Text = "Trị giá";
            label6.Location = new Point(26, 164);
            txtTGia_MaSP_Min.Size = new Size(64, 20);
            txtTGia_Max.Visible = true;
            label9.Visible = true;
            txtTTmax.Visible = false;
            txtTTmin.Visible = false;
            label9.Location = new Point(196, 169);
            btnHDTab.Size = new Size(130, 92);
            btnCTHDTab.Size = new Size(130, 59);

        }

        private void CTHD()
        {
            if(index==5)
                LoadCTHD();
            tab = "cthd";
            txtNumItem.Text = dgvCTHD.RowCount.ToString();
            grthongtin.Size = new Size(309, 286);
            grthongtin.Location = new Point(572, 389);
            pnlbutton.Location = new Point(569, 318);
            grtimkiem.Size = new Size(311, 250);
            label6.Text = "Mã điện thoại";
            label6.Location = new Point(16, 164);
            label7.Visible = true;
            txtTenSP.Visible = true;
            label8.Visible = true;
            txtTTmin.Visible = true;
            //label7.Location = new Point(26, 184);
            //txtTenSP.Location = new Point(121, 184);
            txtTGia_MaSP_Min.Size = new Size(154, 20);
            txtTGia_Max.Visible = false;
            label9.Location = new Point(199, 222);
            txtTTmax.Visible = true;
            txtTTmin.Visible = true;
            btnCTHDTab.Size = new Size(130, 92);
            btnHDTab.Size = new Size(130, 59);
        }


        private void btnHDTab_Click(object sender, EventArgs e)
        {
            HD();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnCTHDTab_Click(object sender, EventArgs e)
        {
            CTHD();
            LoadCTHD();
            tabControl1.SelectedTab = tabPage2;
        }

        private void dgvDSHD_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvDSHD);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }

        private void dgvCTHD_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvCTHD);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }
}
