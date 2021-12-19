using QLDIENTHOAI.controls;
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
    public partial class FormQLHD : Form
    {
        public FormQLHD()
        {
            InitializeComponent();
            LoadCbo();
            txtSohd.Text = LoadSoHD();
            txtNgaylap.Text = DateTime.Now.ToString();
        }

        private string LoadSoHD()
        {
            ctr = new control();
            return ctr.getMaxSoDT();
        }

        control ctr;
        hoadon hoadon;
        cthd cthd;
        dienthoai dt;
        private void LoadCbo()
        {
            ctr = new control();
            cboTensp.DisplayMember = "TENSP";
            cboTensp.ValueMember = "MASP";
            cboTensp.DataSource = ctr.Load("DT_HD").Tables[0].DefaultView;

            cboNV.DisplayMember = "Họ tên NV";
            cboNV.ValueMember = "Mã nhân viên";
            cboNV.DataSource = ctr.Load("NV").Tables[0].DefaultView;

            cboMaKH.DisplayMember = "Mã khách hàng";
            cboMaKH.ValueMember = "Mã khách hàng";
            cboMaKH.DataSource = ctr.Load("KH").Tables[0].DefaultView;

            ctr.Disconnect();
        }
        string[] row;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSL.TextLength == 0)
            {
                MessageBox.Show("Số lượng không được bỏ trống", "Thông báo");
            }
            else
            {
                dgvDSSP.ColumnCount = 2;
                dgvDSSP.Columns[0].Name = "Dòng điện thoại";
                dgvDSSP.Columns[1].Name = "Số lượng";

                row = new string[] { cboTensp.Text,txtSL.Text };
                dgvDSSP.Rows.Add(row);

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgvDSSP.Columns.Add(btn);
                btn.HeaderText = "Actions";
                btn.Text = "Remove";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                btn.DefaultCellStyle.BackColor = Color.DarkCyan;
                btn.DefaultCellStyle.ForeColor = Color.WhiteSmoke;

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSSP.RowCount > 0)
            {
                if (e.ColumnIndex == 2)
                {
                    
                    if (MessageBox.Show("Bạn muốn xoá giá trị này không", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvDSSP.Rows.Count; i++)
                        {
                            if (i == e.RowIndex)
                            {
                                dgvDSSP.Rows.RemoveAt(i);
                                dgvDSSP.Refresh();
                            }
                        }
                    }
                }
            }
        }



        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctr = new control();
            if(ctr.Load("KH").Tables[0].Rows[cboMaKH.SelectedIndex]["Họ tên KH"].ToString()!="")
            {
                txtTenKH.Text = ctr.Load("KH").Tables[0].Rows[cboMaKH.SelectedIndex]["Họ tên KH"].ToString();
                txtDC.Text = ctr.Load("KH").Tables[0].Rows[cboMaKH.SelectedIndex]["Địa chỉ"].ToString();
                txtSdt.Text = ctr.Load("KH").Tables[0].Rows[cboMaKH.SelectedIndex]["Số đt"].ToString();
                cboLoaiKH.Text = ctr.Load("KH").Tables[0].Rows[cboMaKH.SelectedIndex]["Loại KH"].ToString();
            }    
        }

        private void btnthemhd_Click(object sender, EventArgs e)
        {
            if(txtNgaylap.TextLength == 0)
            {
                MessageBox.Show("Ngày lập hoá đơn không được để trống", "Thông báo");
            }
            else if(cboNV.Text == ""||cboMaKH.Text == ""||cboLoaiKH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một trong các lựa chọn trên", "Thông báo");
            }
            else if(dgvDSSP.RowCount==0)
            {
                MessageBox.Show("Danh sách sản phẩm đang trống", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn thêm dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                                     
                    LoadInfor();
                    ctr = new control();
                    ctr.HoaDon(hoadon.Sohd,hoadon.Ngaylap,hoadon.Makh,hoadon.Manv);
                    ctr.Disconnect();
                    InsertCTHD();
                    MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");                    
                    ResetAll();
                }
            }
        }

        private void ResetAll()
        {
            while(dgvDSSP.RowCount>0)
            {
                foreach (DataGridViewRow r in dgvDSSP.Rows)
                {
                    dgvDSSP.Rows.Remove(r);
                }
            }
 
            
        }

        private void InsertCTHD()
        {
            foreach(DataGridViewRow r in dgvDSSP.Rows)
            {
                ctr = new control();
                cthd = new cthd();
                dt = new dienthoai();

                dt.Tensp = r.Cells["Dòng điện thoại"].Value.ToString();
                cthd.Sl =Convert.ToInt32(r.Cells["Số lượng"].Value.ToString());
                cthd.Sohd = Convert.ToInt32(txtSohd.Text);
                ctr.CTHD(cthd.Sohd, dt.Tensp, cthd.Sl);
            }
            ctr.Disconnect();

        }

        private void LoadInfor()
        {
            hoadon = new hoadon();
            hoadon.Sohd = Convert.ToInt32(txtSohd.Text);
            hoadon.Ngaylap = Convert.ToDateTime(txtNgaylap.Text);
            hoadon.Makh = cboMaKH.SelectedValue.ToString();
            hoadon.Manv = cboNV.SelectedValue.ToString();
            
        }

        private void btnChinhSuaHD_Click(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
