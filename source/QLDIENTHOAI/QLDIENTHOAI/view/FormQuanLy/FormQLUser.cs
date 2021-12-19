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
    public partial class FormQLUser : Form
    {
        public FormQLUser()
        {
            InitializeComponent();
            LoadUserND();
            LoadUserQTV();
            btnChangeDelete.BackgroundImage = syncND;
            btnChangeFind.BackgroundImage = syncND;
            dgvND.Columns[0].Visible = false;
            dgvQTV.Columns[0].Visible = false;

        }
        //string _manv, _tennv, _sdt, _chucvu,_dc;
        //DateTime _ngayvl, _ngaysinh;
        //bool _gt, _isDone;
        //public FormQLUser(string manv,string tennv,string sdt,DateTime ngayvl,DateTime ngaysinh,bool gt,string chucvu,string dc,bool isDone)
        //{

        //    //LoadUserND();
        //    //LoadUserQTV();
        //    //btnChangeDelete.BackgroundImage = syncND;
        //    //btnChangeFind.BackgroundImage = syncND;
        //    _manv = manv;
        //    _tennv = tennv;
        //    _sdt = sdt;
        //    _dc = dc;
        //    _chucvu = chucvu;
        //    _ngayvl = ngayvl;
        //    _ngaysinh = ngaysinh;
        //    _gt = gt;
        //    _isDone = isDone;
        //    if (_isDone)
        //    {
        //        ctr = new control();
        //        ctr.Nhanvien(_manv, _tennv, _sdt, _ngayvl, _ngaysinh, _gt, _chucvu, _dc, "INSERT");
        //        ctr.UpdateRoleID(_manv, 1, _manv);
        //        ctr.Disconnect();                
        //        this.Visible = false;
        //        MessageBox.Show("Chuyển dữ liệu thành công.Vui lòng load lại thông tin dữ liệu", "Thông báo");
        //    }
        //}

        control ctr;
        user info;
        Image syncND = Image.FromFile(@"..\..\images\icon\sync.ico");
        Image syncQTV = Image.FromFile(@"..\..\images\icon\sync2.png");
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void LoadUserQTV()
        {
            ctr = new control();
            dgvQTV.DataSource = ctr.LoadUserFromRoleID(1);
            ctr.Disconnect();
        }
        private void LoadUserND()
        {
            ctr = new control();
            dgvND.DataSource = ctr.LoadUserFromRoleID(2);
            ctr.Disconnect();
        }

        private void btnND_Click(object sender, EventArgs e)
        {
            info = new user();
            ctr = new control();
            info.Tentk = dgvQTV.CurrentRow.Cells[1].Value.ToString();
            info.Makh = dgvQTV.CurrentRow.Cells[3].Value.ToString();
            //ctr.UpdateMota(info.Tentk, "User",info.Makh,"");
            ctr.Disconnect();
            LoadUserND();
            LoadUserQTV();
        }

        private void btnQTV_Click(object sender, EventArgs e)
        {
            info = new user();
            ctr = new control();
            if(dgvND.RowCount>0)
            {
                info.Tentk = dgvND.CurrentRow.Cells[1].Value.ToString();
                info.Manv = dgvND.CurrentRow.Cells[3].Value.ToString();
                FormThemNV formThemNV = new FormThemNV(info.Manv);
                formThemNV.ShowDialog();
            }    

            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadUserND();
            LoadUserQTV();
            txtFind.Text = "Nhập tên cần tìm";
            txtXoa.Text = "Nhập tên cần xoá";
        }

        private void txtFind_Click(object sender, EventArgs e)
        {
            txtFind.Text = "";
        }

        private void txtXoa_Click(object sender, EventArgs e)
        {
            txtXoa.Text = "";
        }

        private void Delete()
        {
            ctr = new control();
            info = new user();
            info.Tentk = txtXoa.Text;
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {            
                ctr.Delete(info.Tentk, "USER");
                ctr.Disconnect();
                MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                LoadUserND();
                LoadUserQTV(); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        int d1 = 0, d2 = 0;
        string xoa = "xoand", tim="timnd";

        private void btnND_Click_1(object sender, EventArgs e)
        {

            if (dgvND.RowCount > 0)
            {
                if (MessageBox.Show("Bạn muốn tiếp tục.Quá trình này sẽ không thể hoàn tác","Thông báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    ctr = new control();
                    info = new user();
                    info.Tentk = dgvQTV.CurrentRow.Cells[1].Value.ToString();
                    info.Makh = dgvQTV.CurrentRow.Cells[4].Value.ToString();
                    ctr.UpdateAdminToUser(info.Tentk, info.Makh);
                    ctr.Disconnect();
                }    

            }
        }

        private void XoaDK()
        {
            switch (xoa)
            {
                case "xoaqtv":
                    if (dgvQTV.Rows.Count > 0)
                        txtXoa.Text = dgvQTV.CurrentRow.Cells[1].Value.ToString();
                    else
                        txtXoa.Text = "";
                    break;
                case "xoand":
                    if(dgvND.Rows.Count>0)
                        txtXoa.Text = dgvND.CurrentRow.Cells[1].Value.ToString();
                    else
                        txtXoa.Text = "";
                    break;
            }
        }
        private void dgvND_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            XoaDK();
        }

        private void dgvQTV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            XoaDK();
        }

        private void btnChangeDelete_MouseHover(object sender, EventArgs e)
        {
            switch (xoa)
            {
                case "xoaqtv":
                    toolTip1.SetToolTip(btnChangeDelete, "Xoá QTV");
                    break;
                case "xoand":
                    toolTip1.SetToolTip(btnChangeDelete, "Xoá Người dùng");
                    break;
            }
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            info = new user();
            if(tim=="timqtv")
            {
                info.Tentk = txtFind.Text;
                dgvQTV.DataSource = ctr.searchUser(info.Tentk, "Administrator");
                if(dgvQTV.RowCount==0)
                {
                    MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                    LoadUserQTV();
                }    
            }
            if(tim=="timnd")
            {
                info.Tentk = txtFind.Text;
                dgvND.DataSource = ctr.searchUser(info.Tentk, "User");
                if (dgvND.RowCount == 0)
                {
                    MessageBox.Show("Thông tin tìm kiếm không tồn tại", "Thông báo");
                    LoadUserND();
                }
            }
            ctr.Disconnect();
        }

        private void btnChangeFind_MouseHover(object sender, EventArgs e)
        {
            switch (tim)
            {
                case "timqtv":
                    toolTip1.SetToolTip(btnChangeFind, "Tìm QTV");
                    break;
                case "timnd":
                    toolTip1.SetToolTip(btnChangeFind, "Tìm Người dùng");
                    break;
            }
        }

        private void btnChangeFind_Click(object sender, EventArgs e)
        {
            d2++;
            if (d2 == 1)
            {
                txtFind.Text = "Nhập tên QTV cần tìm";
                btnChangeFind.BackgroundImage = syncQTV;
                btnChangeFind.BackColor = Color.LightSeaGreen;
                tim = "timqtv";
            }
            if (d2 == 2)
            {
                txtFind.Text = "Nhập tên Người dùng cần tìm";
                d2 = 0;
                btnChangeFind.BackgroundImage = syncND;
                btnChangeFind.BackColor = Color.LightSeaGreen;
                tim = "timnd";

            }
        }

        private void btnChangeDelete_Click(object sender, EventArgs e)
        {
            d1++;
            if (d1 == 1)
            {
                btnChangeDelete.BackgroundImage = syncQTV;
                btnChangeDelete.BackColor = Color.LightSeaGreen;
                xoa = "xoaqtv";
            }
            if (d1 == 2)
            {
                
                d1 = 0;
                btnChangeDelete.BackgroundImage = syncND;
                btnChangeDelete.BackColor = Color.LightSeaGreen;
                xoa = "xoand";
            }

        }
    }
}
