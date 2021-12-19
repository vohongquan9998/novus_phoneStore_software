using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


using QLDIENTHOAI.view;
using QLDIENTHOAI.controls;
using QLDIENTHOAI.view.FormTraCuu;
using QLDIENTHOAI.view.FormQuanLy;
using QLDIENTHOAI.view.FormBanHang;
using System.IO;
namespace QLDIENTHOAI
{
    public partial class Form1 : Form
    {
        int n = 0;
        control ctr;
        int numIndex;
        string username;
        public Form1()
        {

            InitializeComponent();
            LoadForm();              
        }
        private void LoadForm()
        {
            LoadKM();
            //LoadCTHD();
            lbDay.Text = "Ngày:" + Convert.ToString(DateTime.Now.ToShortDateString());
            timer2.Start();
            //panel8.Location = new Point(832, 194);
            timerADS.Start();
            loadADs();
            btnHiddenADS.Location = new Point(634, btnHiddenADS.Location.Y);
            //Chart();
            //DGV_CTHD_Design();
            //txtNumItem.Text = dgv_CTHD_Main.RowCount.ToString();
        }

        private void loadADs()
        {
            ctr = new control();
            if (ctr.ShowADsImage().Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[0]["Hinhanh"]);
                picADS.Image = new Bitmap(ms);
            }
        }

        int ADScount = 0;
        private void timerADS_Tick(object sender, EventArgs e)
        {
            ADScount++;
            MemoryStream ms;
            ctr = new control();
            if (ctr.ShowADsImage().Tables[0].Rows.Count > 0)
            {  
                if (ADScount == ctr.ShowADsImage().Tables[0].Rows.Count)
                {
                    ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[0]["Hinhanh"]);
                    picADS.Image = new Bitmap(ms);
                    ADScount = 0;
                }
                ms = new MemoryStream((byte[])ctr.ShowADsImage().Tables[0].Rows[ADScount]["Hinhanh"]);
                picADS.Image = new Bitmap(ms);
            }   
        }
        private void picADS_Click(object sender, EventArgs e)
        {
            ctr = new control();
            string link = Convert.ToString(ctr.ShowADsImage().Tables[0].Rows[ADScount]["thamkhao"]);
            System.Diagnostics.Process.Start(link);
        }
        public Form1(string value)
        {

            InitializeComponent();
            LoadForm();
            username = value;
            lbName.Text = value;
            if (lbName.Text.Length <= 7)
                lbName.Location = new Point(29, 64);
            else
            {
                lbName.Font = new Font("Microsoft Sans Serif", 10);
            }

        }

        //private void DGV_CTHD_Design()
        //{
        //    dgv_CTHD_Main.Columns[0].Width = 40;
        //    dgv_CTHD_Main.Columns[1].Width = 40;
        //    dgv_CTHD_Main.Columns[2].Width = 180;
        //    dgv_CTHD_Main.Columns[3].Width = 80;
        //    dgv_CTHD_Main.Columns[6].Width = 40;
        //    ////dgv_CTHD_Main.Columns[5].Width = 180;
        //    ////dgvKM_Main.Columns[0].Width = 60;
        //}

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            Application.Exit();

        }
        


        private void btnPhone_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnPhone, "Quản lý Điện thoại");
        }

        private void btnStorage_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnKho, "Quản lý Kho");
        }


        private void btnDeal_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnKM, "Quản lý Khuyến mãi");
        }

        private void btnBill_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnHDCTHD, "Quản lý Hoá đơn");
        }

        private void btnproduct_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnNCC, "Quản lý Nhà cung cấp");
        }

        private void LoadKM()
        {
            ctr = new control();
            dgvKM_Main.DataSource = ctr.Load("KM2").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        //private void LoadCTHD()
        //{
        //    ctr = new control();
        //    dgv_CTHD_Main.DataSource = ctr.LoadCTHD();
        //    ctr.Disconnect();
        //}

        private void dgvKM_Main_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lbKM.Text = dgvKM_Main.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            numIndex = 0;
            this.Visible = false;
            switch (n)
            {
                case 1:
                    FormTraCuuDT formDT = new FormTraCuuDT(numIndex);
                    formDT.ShowDialog();
                    break;
                case 2:
                    FormTraCuuKH formKH = new FormTraCuuKH(numIndex);
                    formKH.ShowDialog();
                    break;
                case 3:
                    FormTraCuuNV formNV = new FormTraCuuNV(numIndex);
                    formNV.ShowDialog();
                    break;
                case 4:
                    FormTraCuuKM formKM = new FormTraCuuKM(numIndex);
                    formKM.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD formHD = new FormTraCuuHD(numIndex);
                    formHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }

        }

        private void btnResetPage_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnResetPage_MouseHover(object sender, EventArgs e)
        {
            btnUIBanHang.Location = new Point(20, 478);
        }

        private void btnResetPage_MouseLeave(object sender, EventArgs e)
        {
            btnUIBanHang.Location = new Point(15, 483);
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            btnKNDL.Location = new Point(20, 539);
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            btnKNDL.Location = new Point(15, 544);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckAdmin formCheckAdmin = new FormCheckAdmin(username);
            formCheckAdmin.TopMost = true;
            formCheckAdmin.ShowDialog();
        }

        private void btnMenu2_Click(object sender, EventArgs e) //Menu button thứ 2
        {
            numIndex = 1; //Iphone ,ca nhan ,giamgia,1ngay truoc
            this.Visible = false;
            switch (n)
            {
                case 1: // form dien thoai
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 2: //form khach hang
                    FormTraCuuKH traCuuKH = new FormTraCuuKH(numIndex);
                    traCuuKH.ShowDialog();
                    break;
                case 3: //form khach hang
                    FormTraCuuNV traCuuNV = new FormTraCuuNV(numIndex);
                    traCuuNV.ShowDialog();
                    break;
                case 4: //form khuyen mai
                    FormTraCuuKM traCuuKM = new FormTraCuuKM(numIndex);
                    traCuuKM.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;

            }

        }

        private void btnMenu3_Click(object sender, EventArgs e) //Menu button thứ 3
        {
            numIndex = 2; //Samsung , doanh nghiep ,dinhkem,1 thang truoc
            this.Visible = false;
            switch (n)
            {
                case 1: // form dien thoai
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 2: //form khach hang
                    FormTraCuuKH traCuuKH = new FormTraCuuKH(numIndex);
                    traCuuKH.ShowDialog();
                    break;
                case 3: //form khach hang
                    FormTraCuuNV traCuuNV = new FormTraCuuNV(numIndex);
                    traCuuNV.ShowDialog();
                    break;
                case 4: //form khuyen mai
                    FormTraCuuKM traCuuKM = new FormTraCuuKM(numIndex);
                    traCuuKM.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }

        }

        private void btnMenu4_Click(object sender, EventArgs e)
        {
            numIndex = 3;
            this.Visible = false;
            switch(n)  //1 nam truoc , da giao
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }    

        }

        private void btnMenu5_Click(object sender, EventArgs e)
        {
            numIndex = 4;
            this.Visible = false;
            switch (n) //chua giao ,oppo
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }


        }

        private void btnMenu6_Click(object sender, EventArgs e) //32GB
        {
            numIndex = 5;
            this.Visible = false;
            switch (n) //dien thoai,kho,hoa don   (ALL)
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 4:
                    FormTraCuuKho traCuuKho = new FormTraCuuKho();
                    traCuuKho.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }

        }

        private void btnMenu7_Click(object sender, EventArgs e)
        {
            numIndex = 6;
            this.Visible = false;
            switch (n)  ///Soluong
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }
        }

        private void btnMenu8_Click(object sender, EventArgs e)
        {
            numIndex = 7;
            this.Visible = false;
            switch (n)  ///Soluong
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;
                case 6:
                    FormTraCuuDDH traCuuDDH = new FormTraCuuDDH(numIndex);
                    traCuuDDH.ShowDialog();
                    break;
            }
        }

        private void btnMenu9_Click(object sender, EventArgs e)
        {
            numIndex = 8;
            this.Visible = false;
            switch (n)  //Soluong 
            {
                case 1:
                    FormTraCuuDT traCuuDT = new FormTraCuuDT(numIndex);
                    traCuuDT.ShowDialog();
                    break;
                case 5:
                    FormTraCuuHD traCuuHD = new FormTraCuuHD(numIndex);
                    traCuuHD.ShowDialog();
                    break;

            }
        }
        int hover;
        int value = 0;
        int cursor = 0;
        private void BH(Button b, int x, int y)
        {
            b.Location = new Point(x, y);
        }
        Random r = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
            cursor++;
            if (value == 1)
            {
                switch (hover)
                {
                    case 0:
                        BH(btnAll, 6, 54);                  
                        break;
                    case 1:
                        BH(btnMenu2, 6, 117);
                        break;
                    case 2:
                        BH(btnMenu3, 6, 179);
                        break;
                    case 3:
                        BH(btnMenu4, 6, 242);
                        break;
                    case 4:
                        BH(btnMenu5, 6, 304);
                        break;
                    case 5:
                        BH(btnMenu6, 6, 391);
                        break;
                    case 6:
                        BH(btnMenu7, 6, 453);
                        break;
                    case 7:
                        BH(btnMenu8, 6, 516);
                        break;
                    case 8:
                        BH(btnMenu9, 6, 578);
                        break;
                }
            }
            if (value == 2)
            {
                switch (hover)
                {
                    case 0:
                        BH(btnAll, 6, 57); 
                        break;
                    case 1:
                        BH(btnMenu2, 6, 120);
                        break;
                    case 2:
                        BH(btnMenu3, 6, 181);
                        break;
                    case 3:
                        BH(btnMenu4, 6, 245);
                        break;
                    case 4:
                        BH(btnMenu5, 6, 307);
                        break;
                    case 5:
                        BH(btnMenu6, 6, 394);
                        break;
                    case 6:
                        BH(btnMenu7, 6, 456);
                        break;
                    case 7:
                        BH(btnMenu8, 6, 519);
                        break;
                    case 8:
                        BH(btnMenu9, 6, 581);
                        break;
                }
                value = 0;
            }
            if (cursor == 20)
            {
                int _rand = r.Next(300,500);
                switch (hover)
                {
                    case 0:
                        BH(btnAll, 10, 57);
                        Thread.Sleep(100);
                        BH(btnAll, 0, 57);
                        break;
                    case 1:
                        BH(btnMenu2, 10, 120);
                        Thread.Sleep(100);
                        BH(btnMenu2, 0, 120);
                        break;
                    case 2:
                        BH(btnMenu3, 10, 181);
                        Thread.Sleep(100);
                        BH(btnMenu3, 0, 181);
                        break;
                    case 3:
                        BH(btnMenu4, 10, 245);
                        Thread.Sleep(100);
                        BH(btnMenu4, 0, 245);
                        break;
                    case 4:
                        BH(btnMenu5, 10, 307);
                        Thread.Sleep(100);
                        BH(btnMenu5, 0, 307);
                        break;
                    case 5:
                        BH(btnMenu6, 10, 394);
                        Thread.Sleep(100);
                        BH(btnMenu6, 0, 394);
                        break;
                    case 6:
                        BH(btnMenu7, 10, 456);
                        Thread.Sleep(100);
                        BH(btnMenu7, 0, 456);
                        break;
                    case 7:
                        BH(btnMenu8, 10, 519);
                        Thread.Sleep(100);
                        BH(btnMenu8, 0, 519);
                        break;
                    case 8:
                        BH(btnMenu9, 10, 581);
                        Thread.Sleep(100);
                        BH(btnMenu9, 0, 581);
                        break;
                }
                cursor = 0;
                this.Cursor = new Cursor(Cursor.Current.Handle);
                
                Cursor.Position = new Point(_rand,_rand);
            }
        }


        private void btnAll_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
            hover = 0;
        }

        private void btnAll_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            BH(btnAll, 6, 57);
            cursor = 0;
        }

        private void btnMenu2_MouseHover(object sender, EventArgs e)
        {
            hover = 1; 
            timer1.Start();
        }

        private void btnMenu2_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            BH(btnMenu2, 6, 120);
            cursor = 0;
        }

        private void btnMenu3_MouseHover(object sender, EventArgs e)
        {
            hover = 2; timer1.Start();

        }

        private void btnMenu3_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu3, 6, 181);
            cursor = 0;
        }

        private void btnMenu4_MouseHover(object sender, EventArgs e)
        {
            hover = 3; timer1.Start();

        }

        private void btnMenu4_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu4, 6, 245); cursor = 0;
        }

        private void btnMenu5_MouseHover(object sender, EventArgs e)
        {
            hover = 4; timer1.Start();

        }

        private void btnMenu5_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu5, 6, 307); cursor = 0;
        }

        private void btnMenu6_MouseHover(object sender, EventArgs e)
        {
            hover = 5; timer1.Start();

        }

        private void btnMenu6_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu6, 6, 394); cursor = 0;
        }

        private void btnMenu7_MouseHover(object sender, EventArgs e)
        {
            hover = 6; timer1.Start();

        }

        private void btnMenu7_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu7, 6, 456); cursor = 0;
        }

        private void btnMenu8_MouseHover(object sender, EventArgs e)
        {
            hover = 7; timer1.Start();

        }

        private void btnMenu8_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop(); BH(btnMenu8, 6, 519); cursor = 0;
        }

        private void btnMenu9_MouseHover(object sender, EventArgs e)
        {
            hover = 8; timer1.Start();
        }

        private void btnMenu9_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            BH(btnMenu9, 6, 581); cursor = 0;
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLDT formQLDT = new FormQLDT();
            formQLDT.ShowDialog();
        }

        private void btnUIBanHang_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormMenu formBanHang = new FormMenu();
            formBanHang.ShowDialog();

        }

        private void btnDsdt_Click(object sender, EventArgs e)
        {
            n = 1;
            btnDsdt.Location = new Point(0, 154);
            btnDsdt.Size = new Size(205, 60);
            btnDSKH.Size = new Size(159, 60);
            btnDSNV.Size = new Size(159, 60);
            btnDSKM.Size = new Size(159, 60);
            btnHD.Size = new Size(159, 60);
            btnDSDDH.Size = new Size(159, 60);
            grMenu.Visible = true;
            grMenu2.Visible = true;
            btnMenu2.Text = "iPhone";
            btnMenu3.Text = "Samsung";
            btnMenu4.Visible = true;
            btnMenu5.Visible = true;
  
            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = true;
                }
                if (d is Panel)
                {
                    d.Visible = true;
                }
            }
            lbDialogMenu2.Visible = true;
            lbDialogMenu1.Text = "Nhãn hiệu";
            btnMenu4.Text = "Vsmart";
            btnMenu8.Text = "128GB";
            btnMenu6.Text = "32GB";
            btnMenu7.Text = "64GB";
            btnMenu9.Text = "256GB";
            lbDialogMenu2.Text = "Dung lượng";
            btnMenu5.Text = "Oppo";
        }

        private void btnDSKH_Click(object sender, EventArgs e)
        {
            n = 2;
            btnDSKH.Location = new Point(0, 214);
            btnDSKH.Size = new Size(205, 60);
            btnDsdt.Size = new Size(159, 60);
            btnDSNV.Size = new Size(159, 60);
            btnDSKM.Size = new Size(159, 60);
            btnHD.Size = new Size(159, 60);
            btnDSDDH.Size = new Size(159, 60);
            grMenu.Visible = true;
            btnMenu2.Text = "Cá nhân";
            btnMenu3.Text = "Doanh nghiệp";
            panelMenu2.Visible = true;

            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = false;
                }
                if (d is Panel)
                {
                    d.Visible = false;
                }
            }
            btnAll.Visible = true;
            btnMenu2.Visible = true;
            btnMenu3.Visible = true;
            btnMenu4.Visible = false;
            btnMenu5.Visible = false;
            panelAll.Visible = true;
            panelMenu2.Visible = true;
            lbDialogMenu2.Visible = false;
            lbDialogMenu1.Text = "Khách hàng";
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            n = 3;
            btnDSNV.Location = new Point(0, 274);
            btnDSNV.Size = new Size(205, 60);
            btnDsdt.Size = new Size(159, 60);
            btnDSKH.Size = new Size(159, 60);
            btnDSKM.Size = new Size(159, 60);
            btnHD.Size = new Size(159, 60);
            btnDSDDH.Size = new Size(159, 60);
            grMenu.Visible = true;

            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = false;
                }
                if (d is Panel)
                {
                    d.Visible = false;
                }
            }
            btnAll.Visible = true;
            btnMenu2.Visible = true;
            btnMenu3.Visible = true;
            panelMenu2.Visible = true;
            panelMenu3.Visible = true;
            panelAll.Visible = true;
            btnMenu4.Visible = false;
            btnMenu5.Visible = false;
            lbDialogMenu1.Text = "Nhân viên";
            btnMenu2.Text = "Quản lý";
            btnMenu3.Text = "Nhân viên";
            lbDialogMenu2.Visible = false;
        }

        private void btnDSKM_Click(object sender, EventArgs e)
        {
            n = 4;
            btnDSKM.Location = new Point(0, 334);
            btnDSKM.Size = new Size(205, 60);
            btnDSNV.Size = new Size(159, 60);
            btnDsdt.Size = new Size(159, 60);
            btnDSKH.Size = new Size(159, 60);
            btnHD.Size = new Size(159, 60);
            btnDSDDH.Size = new Size(159, 60);
            grMenu.Visible = true;
            grMenu2.Visible = true;
            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = false;
                }
                if (d is Panel)
                {
                    d.Visible = false;
                }
            }
            btnAll.Visible = true;
            btnMenu2.Visible = true;
            btnMenu3.Visible = true;
            btnMenu6.Visible = true;
            panelMenu2.Visible = true;
            panelMenu6.Visible = true;
            panelAll.Visible = true;
            btnMenu4.Visible = false;
            btnMenu5.Visible = false;
            panelMenu8.Visible = true;
            btnMenu2.Text = "Giảm giá";
            btnMenu3.Text = "Hàng đính kèm";
            lbDialogMenu1.Text = "Khuyến mãi";
            lbDialogMenu2.Visible = true;
            lbDialogMenu2.Text = "Kho,PN,NCC";
            btnMenu6.Text = "Tất cả";
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            
            n = 5;
            btnHD.Location = new Point(0, 394);
            btnHD.Size = new Size(205, 60);
            btnDSNV.Size = new Size(159, 60);
            btnDsdt.Size = new Size(159, 60);
            btnDSKH.Size = new Size(159, 60);
            btnDSKM.Size = new Size(159, 60);
            btnDSDDH.Size = new Size(159, 60);
            grMenu.Visible = true;
            grMenu2.Visible = true;
            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = false;
                }
                if (d is Panel)
                {
                    d.Visible = false;
                }
            }
            btnAll.Visible = true;
            btnMenu2.Visible = true;
            btnMenu3.Visible = true;
            btnMenu4.Visible = true;
            btnMenu8.Visible = true;
            btnMenu6.Visible = true;
            btnMenu7.Visible = true;
            btnMenu9.Visible = true;
            btnMenu5.Visible = false;
            panelMenu2.Visible = true;
            panelMenu3.Visible = true;
            panelMenu6.Visible = true;
            panelMenu7.Visible = true;
            panelMenu8.Visible = true;
            panelMenu9.Visible = true;
            panelAll.Visible = true;
            lbDialogMenu2.Visible = true;
            btnMenu2.Text = "1 ngày trước";
            btnMenu3.Text = "1 tháng trước";
            btnMenu4.Text = "1 năm trước";
            lbDialogMenu1.Text = "Hoá đơn";
            lbDialogMenu2.Text = "CTHD";
            btnMenu6.Text = "Tất cả";
            btnMenu7.Text = "SL > 10";
            btnMenu8.Text = "SL > 50";
            btnMenu9.Text = "SL > 150";
        }
        private void btnDSDDH_Click(object sender, EventArgs e)
        {
            n = 6;
            btnDSDDH.Location = new Point(0, 454);
            btnDSDDH.Size = new Size(205, 60);
            btnDSNV.Size = new Size(159, 60);
            btnDsdt.Size = new Size(159, 60);
            btnDSKH.Size = new Size(159, 60);
            btnDSKM.Size = new Size(159, 60);
            btnHD.Size = new Size(159, 60);
            grMenu.Visible = true;
            grMenu2.Visible = true;
            foreach (Control d in grMenu2.Controls)
            {
                if (d is Button)
                {
                    d.Visible = false;
                }
                if (d is Panel)
                {
                    d.Visible = false;
                }
            }
            btnAll.Visible = true;
            btnMenu2.Visible = true;
            btnMenu3.Visible = true;
            btnMenu4.Visible = true;
            btnMenu8.Visible = true;
            btnMenu6.Visible = true;
            btnMenu7.Visible = true;
            btnMenu9.Visible =false;
            btnMenu5.Visible = true;
            panelMenu2.Visible = true;
            panelMenu3.Visible = true;
            panelMenu6.Visible = true;
            panelMenu7.Visible = true;
            panelMenu8.Visible = true;
            panelMenu9.Visible = false;
            panelAll.Visible = true;
            lbDialogMenu2.Visible = true;
            btnMenu2.Text = "1 ngày trước";
            btnMenu3.Text = "1 tháng trước";
            btnMenu4.Text = "Đã giao";
            btnMenu5.Text = "Chưa giao";
            lbDialogMenu1.Text = "Đơn đặt hàng";
            lbDialogMenu2.Text = "CTDDH";
            btnMenu6.Text = "Tất cả";
            btnMenu7.Text = "Thanh toán khi nhận hàng";
            btnMenu8.Text = "Thanh toán thẻ";
        }
        private void b(Button btn,Color color1)
        {
            btn.BackColor = color1;
        }



        private void btnPhone_MouseMove(object sender, MouseEventArgs e)
        {
            b(btnPhone, Color.WhiteSmoke);
        }

        private void btnPhone_MouseLeave(object sender, EventArgs e)
        {
            b(btnPhone, Color.PaleTurquoise);
        }
        private void btnKM_MouseMove(object sender, MouseEventArgs e)
        {
            b(btnKM, Color.WhiteSmoke);
        }

        private void btnKM_MouseLeave(object sender, EventArgs e)
        {
            b(btnKM, Color.PaleTurquoise);
        }

        private void btnHDCTHD_MouseMove(object sender, MouseEventArgs e)
        {
            b(btnHDCTHD, Color.WhiteSmoke);
        }

        private void btnHDCTHD_MouseLeave(object sender, EventArgs e)
        {
            b(btnHDCTHD, Color.PaleTurquoise);
        }

        private void btnKho_MouseMove(object sender, MouseEventArgs e)
        {
            b(btnKho, Color.WhiteSmoke);
        }

        private void btnKho_MouseLeave(object sender, EventArgs e)
        {
            b(btnKho, Color.PaleTurquoise);
        }

        private void btnNCC_MouseMove(object sender, MouseEventArgs e)
        {
            b(btnNCC, Color.WhiteSmoke);
        }

        private void btnNCC_MouseLeave(object sender, EventArgs e)
        {
            b(btnNCC, Color.PaleTurquoise);
        }


        private void btnKM_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLKM formQLKM = new FormQLKM();
            formQLKM.ShowDialog();

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormSettingMain formsetting = new FormSettingMain();
            formsetting.TopMost = true;
            formsetting.ShowDialog();
        }

        private void btnSuco_Click(object sender, EventArgs e)
        {

        }
        //int dMore = 0;
        //private void btnMore_Click(object sender, EventArgs e)
        //{
        //    dMore++;
        //    if (dMore == 1)
        //    {
        //        panel8.Visible = true;
        //    }
        //    if (dMore == 2)
        //    {
        //        panel8.Visible = false;dMore = 0;
        //    }
            
        //}
        private void btnInfo_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.ShowDialog();
        }

        private void btnUIBanHang_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FormMenuUser formQuangCao = new FormMenuUser();
            formQuangCao.ShowDialog();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLKho formQLKho = new FormQLKho();
            formQLKho.ShowDialog();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLNCC formQLNCC = new FormQLNCC();
            formQLNCC.ShowDialog();
        }
        private void btnQLKH_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLKH formQLKH = new FormQLKH();
            formQLKH.ShowDialog();
        }
        string time;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time = "Giờ:" + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes + ":" + DateTime.Now.TimeOfDay.Seconds;
            lbtime.Text = time;          
        }

        private void dgvKM_Main_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvKM_Main);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
        //private void panel3_MouseLeave(object sender, EventArgs e)
        //{
        //    isStart = true;
        //    btnHiddenADS.Location = new Point(634, btnHiddenADS.Location.Y);
        //    btnHiddenADS.Visible = false;
        //}
        bool isStart = true,button=false;
        int x;

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (button)
            {
                btnHiddenADS.Visible = false;
                x = panel3.Location.X;
                x += 20;
                panel3.Location = new Point(x, panel3.Location.Y);
                if(x>=1300)
                {
                    timer3.Stop();
                    button = false;
                    groupBox1.Location = new Point(groupBox1.Location.X, 210);
                    groupBox1.Size = new Size(440, 507);
                    dgvKM_Main.Size = new Size(415, 414);
                    
                }    
            }
            else
            {
                x = btnHiddenADS.Location.X;
                x -= 20;
                btnHiddenADS.Location = new Point(x, btnHiddenADS.Location.Y);
                if (x <= 560)
                {
                    timer3.Stop();

                }
            }
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://facebook.com/");
        }



        private void panel3_MouseHover(object sender, EventArgs e)
        {
            if (isStart)
            {
                timer3.Start();
                btnHiddenADS.Visible = true;
                isStart = false;
            }
        }

        private void btnKNDL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn sẽ được điều hướng sang giao diện bán hàng của khách hàng.Bạn sẽ phải đăng nhập lại để trờ về giao diện quản lý", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.Visible = false;
                FormMenu formMenu = new FormMenu();
                formMenu.ShowDialog();
            } 
        }

        private void btnHDCTHD_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"..\..\VoHongQuan_19C1_LTM1_De7\report\BaoCaoCNPM.docx");
        }

        private void btnHiddenADS_Click(object sender, EventArgs e)
        {
            button = true;
            timer3.Start();
        }

    }
}
