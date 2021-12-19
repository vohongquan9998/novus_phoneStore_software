using QLDIENTHOAI.controls;
using QLDIENTHOAI.view.FormTraCuu;
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
    public partial class FormQLKho : Form
    {

        control ctr;
        kho kho;
        phieunhap phieunhap;
        public FormQLKho()
        {
            InitializeComponent();
            CustomDate();
            LoadKho();
            LoadPN();
            LoadMakho();
            LoadCbo();
        }
        private void CustomDate()
        {
            dtpNgaygiao.Format = DateTimePickerFormat.Custom;
            dtpNgaygiao.CustomFormat = "dd/MM/yyyy";
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void DGVLoad(DataGridView gridView,string key)
        {
            ctr = new control();
            gridView.DataSource = ctr.Load(key).Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void CBOLoad(ComboBox cbo,string display,string value,string key)
        {
            ctr = new control();
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = ctr.Load(key).Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void LoadCbo()
        {
            CBOLoad(cboMakho, "Mã kho", "Mã kho", "MAKHO");
            CBOLoad(cboNCC, "Nhà cung cấp", "Mã nhà cung cấp", "NCC");
        }

        private void LoadKho()
        {
            DGVLoad(dgvDSKho, "KHO");
        }
        private void LoadPN()
        {
            DGVLoad(dgvPN, "PN");
        }
        private void LoadMakho()
        {
            DGVLoad(dgvMakho, "MAKHO");
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadKho();
            LoadPN();
        }
        private bool checkkho()
        {
            bool check;
            ctr = new control();
            kho = new kho();
            kho.Makho = txtMakho.Text;
            check = ctr.Check(kho.Makho, "KHO");
            ctr.Disconnect();
            return check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMakho.TextLength==0)
            {
                MessageBox.Show("Vui lòng nhập mã kho", "Thông báo");
            }    
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn thêm dữ liệu không?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if(checkkho())
                    {
                        ctr = new control();
                        kho = new kho();
                        kho.Makho = txtMakho.Text;
                        ctr.Kho(kho.Makho, 0);
                        ctr.Disconnect();
                        MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");

                        LoadMakho();
                        LoadCbo();
                        txtMakho.Text = "";
                    }  
                    else
                        MessageBox.Show("Dữ liệu đã tồn tại", "Thông báo");
                }    

            }    
        }
        private void btnDeleteKho_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xoá dữ liệu không?Những dữ liệu liên quan cũng sẽ bị xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (CheckSoPN() != 0)
                {
                    ctr = new control();
                    kho = new kho();
                    phieunhap = new phieunhap();
                    kho.Makho = txtMakho.Text;
                    phieunhap.Makho = txtMakho.Text;

                    ctr.Delete(phieunhap.Makho, "KHO_PN");
                    ctr.Delete(kho.Makho, "KHO");
                    LoadPN();
                    LoadKho();
                }
                else
                {
                    ctr = new control();
                    kho = new kho();
                    kho.Makho = txtMakho.Text;
                    ctr.Delete(kho.Makho, "KHO");
                }
                MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                LoadMakho();
            }    

            
        }

        private int CheckSoPN()
        {
            int i;
            ctr = new control();
            phieunhap = new phieunhap();
            phieunhap.Makho = txtMakho.Text;
            i = ctr.CheckExistByInt(phieunhap.Makho, "PN_CHECK");
            ctr.Disconnect();
            return i;
        }
        /// <summary>
        /// 
        /// </summary>

        private void btnFixPN_Click(object sender, EventArgs e)
        {
            if (txtPN.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập", "Thông báo");
            }
            else if (txtSL.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo");
            }
            else if (dtpNgayLap.Value > dtpNgaygiao.Value)
            {
                MessageBox.Show("Vui lòng nhập ngày chính xác", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadInforPN();
                    ctr = new control();
                    ctr.Phieunhap(phieunhap.Mapn, phieunhap.Mancc, phieunhap.Soluong, phieunhap.Ngaylap, phieunhap.Ngaygiao, phieunhap.Makho, "UPDATE");
                    ctr.Disconnect();
                    LoadPN();
                    LoadKho();
                    ResetAll();
                }
            }
        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            ResetAll();
            btnLuuPN.Enabled = true;
            btnFixPN.Enabled = false;
            btnDeletePN.Enabled = false;
            txtPN.Enabled = true;

        }

        private void ResetAll()
        {
            foreach (Control c in panel3.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
                if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;
                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;
            }
        }

        private void btnDeletePN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctr = new control();
                phieunhap = new phieunhap();
                phieunhap.Mapn = txtPN.Text;
                ctr.Delete(phieunhap.Mapn, "PN");
                ctr.Disconnect();
                LoadPN();
                LoadKho();
            }

        }
        private bool checkpn()
        {
            bool check;
            ctr = new control();
            phieunhap = new phieunhap();
            phieunhap.Mapn = txtPN.Text;
            check = ctr.Check(phieunhap.Mapn, "PN");
            ctr.Disconnect();
            return check;
        }
        private void LoadInforPN()
        {
            phieunhap = new phieunhap(txtPN.Text,cboNCC.SelectedValue.ToString(),int.Parse(txtSL.Text),dtpNgayLap.Value,dtpNgaygiao.Value,cboMakho.SelectedValue.ToString());
        }
        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            if(txtPN.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập", "Thông báo");
            }
            else if(txtSL.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo");
            }    
            else if(dtpNgayLap.Value > dtpNgaygiao.Value)
            {
                MessageBox.Show("Vui lòng nhập ngày chính xác", "Thông báo");
            }  
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(checkpn())
                    {
                        LoadInforPN();
                        ctr = new control();
                        ctr.Phieunhap(phieunhap.Mapn, phieunhap.Mancc, phieunhap.Soluong, phieunhap.Ngaylap, phieunhap.Ngaygiao, phieunhap.Makho, "INSERT");
                        ctr.Disconnect();
                        LoadPN();
                        LoadKho();
                        ResetAll();

                    }   
                    else
                        MessageBox.Show("Dữ liệu đã tồn tại", "Thông báo");
                }    
            }    
                
        }

        private void dgvPN_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPN.RowCount>0)
            {
                txtPN.Text = dgvPN.CurrentRow.Cells[0].Value.ToString();
                cboNCC.Text = dgvPN.CurrentRow.Cells[1].Value.ToString();
                txtSL.Text = dgvPN.CurrentRow.Cells[2].Value.ToString();
                dtpNgayLap.Value = Convert.ToDateTime(dgvPN.CurrentRow.Cells[3].Value.ToString());
                dtpNgaygiao.Value =Convert.ToDateTime(dgvPN.CurrentRow.Cells[4].Value.ToString());
                btnFixPN.Enabled = true;
                btnDeletePN.Enabled = true;
                txtPN.Enabled = false;
            }    
        }

        private void dgvMakho_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSKho.RowCount>0)
            {
                txtMakho.Text = dgvMakho.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormTraCuuKho formTraCuuKho = new FormTraCuuKho();
            formTraCuuKho.ShowDialog();
        }
    }
}
