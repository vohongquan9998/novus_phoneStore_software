using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormQuanLy
{
    public partial class FormQLDT : Form
    {
        public FormQLDT()
        {
            InitializeComponent();
            LoadDt();
            Loadcbo();
            FormLoad();

        }
        private void FormLoad()
        {
            dgvDSDT.Columns[1].Width = 150;
            picSP.AllowDrop = true;
            picSP.Image = BG;
            cboBaoHanh.SelectedIndex = 0;
            cboXuatXu.SelectedIndex = 0;
            dgvDSDT.Columns["MAMAU"].Visible = false;
        }

        control ctr;
        dienthoai dienthoai;
        ctmau ctmau;
        Image BG = Image.FromFile(@"..\..\images\img\pictureboxBG.png");
        Image NO = Image.FromFile(@"..\..\images\img\notImage.png");
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void LoadDt()
        {
            ctr = new control();
            dgvDSDT.DataSource = ctr.Load("DT").Tables[0].DefaultView;
            ctr.Disconnect();
        }
        private void Loadcbo()
        {
            ctr = new control();
            cbomaKho.DisplayMember = "Mã kho";
            cbomaKho.ValueMember = "Mã kho";
            cbomaKho.DataSource = ctr.Load("KHO").Tables[0].DefaultView;
            cboKhuyenMai.DisplayMember = "Nội dung";
            cboKhuyenMai.ValueMember = "Mã khuyến mãi";
            cboKhuyenMai.DataSource = ctr.Load("KM").Tables[0].DefaultView;
            cboMau.DisplayMember = "TENMAU";
            cboMau.ValueMember = "MAMAU";
            cboMau.DataSource = ctr.Load("MAU").Tables[0].DefaultView;
            ctr.Disconnect();
        }

        private void label15_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Constantia", 15, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.DarkCyan);
            e.Graphics.TranslateTransform(15,250);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("QUẢN LÝ ĐIỆN THOẠI", font, brush, 0, 0);
        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormTraCuuDT formDT = new FormTraCuuDT(0);
            formDT.ShowDialog();
        }

        private void cboKhuyenMai_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cboKhuyenMai, cboKhuyenMai.Text);
        }

        private void cboKhuyenMai_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cboKhuyenMai, cboKhuyenMai.Text);
        }
        Image img;
        private void picSP_DragDrop(object sender, DragEventArgs e)
        {
            foreach(string pic in(string[])e.Data.GetData(DataFormats.FileDrop))
            {
                img = Image.FromFile(pic);
                picSP.Image = img;                
                //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //filepath = files[0];
            }
        }

        public byte[] converImgToByte(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, img.RawFormat);
                return stream.ToArray();
            }
        }


        private void picSP_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        byte[] image;
        OpenFileDialog open;
        bool x = false;
        private void ImageCapture()
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:";
            open.FileName = "";
            open.Filter = "JPG image(*.jpg)|*.jpg|PNG image(*.png)|*.png|All files(*.*)|*.*";
            open.RestoreDirectory = true;
            open.ShowDialog();
            if(open.FileName!="")
            {
                x = true;
                imgname = open.SafeFileName.Substring(open.SafeFileName.LastIndexOf(@"\") + 1);
                filepath = open.FileName;
                picSP.Image = Image.FromFile(open.FileName);
                FileStream fileStream = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                image = new byte[fileStream.Length];
                fileStream.Read(image, 0, image.Length);
                fileStream.Close();
            }

        }
        string imgname;
        string filepath;
        //private void SaveImage()
        //{         
        //    save = new SaveFileDialog();
        //    string path =Application.StartupPath + @"\..\..\images\sanpham\";
        //    if (save.FileName != "")
        //    {
        //        switch (save.FilterIndex)
        //        {
        //            case 1:
        //                picSP.Image.Save(Imgname, ImageFormat.Jpeg);
        //                break;
        //            case 2:
        //                picSP.Image.Save(Imgname, ImageFormat.Bmp);
        //                break;
        //            case 3:
        //                picSP.Image.Save(Imgname, ImageFormat.Png);
        //                break;
        //            case 4:
        //                picSP.Image.Save(Imgname, ImageFormat.Gif);
        //                break;

        //        }
        //    }
        //}
        int i = 0;
        private void ImageSave()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\images\sanpham\";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            if(filepath==null)
            {

            }
            else
            {
                try
                {
                    File.Copy(filepath, path + imgname);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Đã tồn tại file ảnh này.Hệ thống sẽ đè lên file có sẵn"+e.ToString());
                }
            }


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ImageCapture();
        }

        private void btnResetCauHinh_Click(object sender, EventArgs e)
        {
            foreach(Control c in panel5.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
            }
        }

        private void btnResetTT_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
                if (c is RadioButton)
                    ((RadioButton)c).Checked = false;

            }
            rad32.Checked = true;
            radConhang.Checked = true;
            if (picSP.Image != null)
                picSP.Image = BG;

        }

        private void LoadInformation()
        {
            dienthoai = new dienthoai();
            ctmau = new ctmau(cboMau.SelectedValue.ToString(),txtMASP.Text);
            dienthoai.Masp = txtMASP.Text;
            dienthoai.Tensp = txtTenDT.Text;
            dienthoai.Baohanh = cboBaoHanh.Text;
            dienthoai.Xuatsu = cboXuatXu.Text;
            dienthoai.Makho = cbomaKho.SelectedValue.ToString();
            dienthoai.Makm = cboKhuyenMai.SelectedValue.ToString();
            dienthoai.Dungluong = (rad32.Checked) ? 32 : (rad64.Checked) ? 64 : (rad128.Checked) ? 128 : 256;
            dienthoai.Trangthai = true;
            if (image != null)
            {
                if (x)
                {
                    dienthoai.Hinhanh = image;
                    x = false;
                }
                else
                    dienthoai.Hinhanh = converImgToByte(img);
            }
            else
                dienthoai.Hinhanh = converImgToByte(NO);
            dienthoai.Chitiet = txtHeDH.Text + "," + txtRam.Text + "," + txtChip.Text + "," + txtSac.Text;
            dienthoai.Dongia = float.Parse(txtDonGia.Text.Replace("VNĐ", ""));
        }
        private void LoadInformationUpdate()
        {
            dienthoai = new dienthoai();
            dienthoai.Masp = txtMASP.Text;
            dienthoai.Tensp = txtTenDT.Text;
            dienthoai.Baohanh = cboBaoHanh.Text;
            dienthoai.Xuatsu = cboXuatXu.Text;
            dienthoai.Makho = cbomaKho.SelectedValue.ToString();
            dienthoai.Makm = cboKhuyenMai.SelectedValue.ToString();
            dienthoai.Dungluong = (rad32.Checked) ? 32 : (rad64.Checked) ? 64 : (rad128.Checked) ? 128 : 256;
            if (radHetHang.Checked)
            {
                dienthoai.Trangthai = false;
            }
            else
                dienthoai.Trangthai = true;

            dienthoai.Hinhanh = image;
            dienthoai.Chitiet = txtHeDH.Text + "," + txtRam.Text + "," + txtChip.Text + "," + txtSac.Text;

            dienthoai.Dongia = float.Parse(txtDonGia.Text.Replace("VNĐ",""));
        }

        private bool CheckExistValue()
        {
            bool check;
            ctr = new control();
            dienthoai = new dienthoai();
            dienthoai.Masp = txtMASP.Text;
            check = ctr.Check(dienthoai.Masp, "DT");
            ctr.Disconnect();
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMASP.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã SP", "Thông báo");
                txtMASP.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtTenDT.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên SP", "Thông báo");
                txtTenDT.BackColor = Color.FromArgb(222, 91, 82);
            }
            else if (txtHeDH.TextLength == 0 || txtChip.TextLength == 0 || txtRam.TextLength == 0 || txtSac.TextLength == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ cấu hình", "Thông báo");
            }
            else
            {
                
                switch (chedo)
                {
                    case "Luu":
                        if (MessageBox.Show("Bạn có chắc chắn thêm dữ liệu này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if(CheckExistValue())
                            {
                                LoadInformation();
                                if (picSP.Image != null)
                                    ImageSave();
                                else
                                {
                                    picSP.Image = BG;
                                }
                                ctr = new control();
                                ctr.DienThoai(dienthoai.Masp, dienthoai.Tensp, dienthoai.Baohanh, dienthoai.Dungluong, dienthoai.Xuatsu, dienthoai.Chitiet, dienthoai.Trangthai, dienthoai.Dongia, dienthoai.Makm, dienthoai.Makho, dienthoai.Hinhanh, "INSERT");
                                ctr.CTmau(ctmau.Mamau, ctmau.Masp);
                                MessageBox.Show("Đã thêm dữ liệu thành công", "Thông báo");
                            }    
                            else
                                MessageBox.Show("Dữ liệu đã tồn tại", "Thông báo");
                        }
                        break;
                    case "Sua":
                        if (MessageBox.Show("Bạn có chắc chắn sửa dữ liệu này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoadInformationUpdate();
                            ctr = new control();
                            ctr.DienThoai(dienthoai.Masp, dienthoai.Tensp, dienthoai.Baohanh, dienthoai.Dungluong, dienthoai.Xuatsu, dienthoai.Chitiet, dienthoai.Trangthai, dienthoai.Dongia, dienthoai.Makm, dienthoai.Makho, dienthoai.Hinhanh, "UPDATE");
                            MessageBox.Show("Đã chỉnh sửa dữ liệu thành công", "Thông báo");
                        }
                        break;
                }
                ctr.Disconnect();
                LoadDt();
                btnResetCauHinh_Click(sender, e);
                btnResetTT_Click(sender, e);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn xoá dữ liệu này!","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                ctr = new control();
                dienthoai = new dienthoai();
                dienthoai.Masp = txtMASP.Text;
                ctmau = new ctmau();
                ctmau.Mamau = cboMau.SelectedValue.ToString();
                ctmau.Masp = txtMASP.Text;

                ctr.deleteCTmau(ctmau.Mamau, ctmau.Masp);
                ctr.Delete(dienthoai.Masp, "CTHD_DT");
                ctr.Delete(dienthoai.Masp, "DT");
                ctr.Disconnect();
                MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                LoadDt();
            }    
                
        }

        private void dgvDSDT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDSDT.RowCount>0)
            {
                txtMASP.Text = dgvDSDT.CurrentRow.Cells["Mã điện thoại"].Value.ToString().Replace("-"+dgvDSDT.CurrentRow.Cells["MAMAU"].Value.ToString(),"");
                string ten = dgvDSDT.CurrentRow.Cells["Dòng điện thoại"].Value.ToString();
                txtTenDT.Text = ten.Substring(0, ten.IndexOf(" -"));
                cboBaoHanh.Text = dgvDSDT.CurrentRow.Cells["Bảo hành"].Value.ToString();

                if (dgvDSDT.CurrentRow.Cells["Dung lượng"].Value.ToString() == "32")
                    rad32.Checked = true;
                else if (dgvDSDT.CurrentRow.Cells["Dung lượng"].Value.ToString() == "64")
                    rad64.Checked = true;
                else if (dgvDSDT.CurrentRow.Cells["Dung lượng"].Value.ToString() == "128")
                    rad128.Checked = true;
                else
                    rad256.Checked = true;

                cboXuatXu.Text = dgvDSDT.CurrentRow.Cells["Xuất xứ"].Value.ToString();
                string mau = dgvDSDT.CurrentRow.Cells["Tên màu"].Value.ToString();
                cboMau.Text = mau.Substring(mau.IndexOf(",")+1);
                if (dgvDSDT.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Còn hàng")
                {
                    radConhang.Checked = true;
                    radHetHang.Checked = false;
                }
                else
                {
                    radHetHang.Checked = true;
                    radConhang.Checked = false;
                }

                txtDonGia.Text = dgvDSDT.CurrentRow.Cells["Đơn giá bán"].Value.ToString();
                cboKhuyenMai.Text = dgvDSDT.CurrentRow.Cells["Nội dung"].Value.ToString();
                cbomaKho.Text = dgvDSDT.CurrentRow.Cells["Mã kho"].Value.ToString();

                string sub = dgvDSDT.CurrentRow.Cells["Cấu hình"].Value.ToString();                
                txtHeDH.Text = sub.Substring(0, sub.IndexOf(","));
                txtRam.Text =sub.Substring(sub.IndexOf(",RAM:")+1, txtRam.MaxLength);
                SubstringChip(sub);
                txtSac.Text = sub.Substring(sub.IndexOf(",PinSạc:")+1, txtSac.MaxLength);

                if(dgvDSDT.CurrentRow.Cells["Hình ảnh"].Value.ToString()!="")
                {
                    byte[] ImImage;
                    ImImage = (byte[])dgvDSDT.CurrentRow.Cells[12].Value;
                    MemoryStream ms = new MemoryStream(ImImage);
                    picSP.Image = Image.FromStream(ms);
                    image = ImImage;
                }
                else
                {
                    picSP.Image = BG;
                }

            }    
            else
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox)
                        c.Text = "";
                }                    
            }    
        }


        private void SubstringChip(string s)
        {
            string end = s.Substring(s.IndexOf(",Chip:") + 1, txtChip.MaxLength);

            if (end.EndsWith(",PinSạc"))
                txtChip.MaxLength = 20;
            if (end.EndsWith(","))
                txtChip.MaxLength = 26;
            if (end.EndsWith(",PinS"))
                txtChip.MaxLength = 22;
            if (end.EndsWith(",PinSạ"))
                txtChip.MaxLength = 21;
            if (end.EndsWith(",Pi"))
                txtChip.MaxLength = 24;
            if (end.EndsWith(",Pin"))
                txtChip.MaxLength = 23;
            if (end.EndsWith(",P"))
                txtChip.MaxLength = 25;
            if (end.EndsWith(",PinSạc:"))
                txtChip.MaxLength = 19;
            txtChip.Text = s.Substring(s.IndexOf(",Chip:") + 1, txtChip.MaxLength);
            txtChip.MaxLength = 27;

        }
        int d = 0;
        string chedo = "Luu";
        private void btnChange_Click(object sender, EventArgs e)
        {
            d++;
            if(d == 1)
            {
                chedo = "Sua";
                txtMASP.Enabled = false;
                btnChange.Text = "Chế độ : Sửa";
                grTrangthai.Visible = true;
                cboMau.Enabled = false;
            }
            if(d == 2)
            {
                chedo = "Luu";
                txtMASP.Enabled = true;
                btnChange.Text = "Chế độ : Lưu";
                d = 0;
                grTrangthai.Visible =false;
                cboMau.Enabled = true;
            }    
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDt();
        }

        private void btnChange_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnChange, "Nhấp để đổi chế độ");
        }

        private void picSP_Click(object sender, EventArgs e)
        {
            btnBrowse_Click(sender, e);
        }

        private void txtMASP_Click(object sender, EventArgs e)
        {
            txtMASP.BackColor = Color.White;
        }

        private void txtTenDT_Click(object sender, EventArgs e)
        {
            txtTenDT.BackColor = Color.White;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnReset, "Cập nhật lại trang");
        }

        private void btnback_MouseMove(object sender, MouseEventArgs e)
        {
            btnback.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnback, "Trở về trang chính");
        }

        private void btnQL_MouseMove(object sender, MouseEventArgs e)
        {
            btnTC.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnTC, "Chuyển đến tính năng tra cứu");
        }


        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DarkCyan;
        }

        private void btnback_MouseLeave(object sender, EventArgs e)
        {
            btnback.BackColor = Color.DarkCyan;
        }

        private void btnQL_MouseLeave(object sender, EventArgs e)
        {
            btnTC.BackColor = Color.PaleTurquoise;
        }

        //private void btnDelete_MouseLeave(object sender, EventArgs e)
        //{
        //    btnDelete.BackColor = Color.DarkCyan;
        //}

        //private void btnDelete_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnDelete.BackColor = Color.DarkSlateGray;
        //    toolTip1.SetToolTip(btnDelete, "Xoá dữ liệu");
        //}

        private void btnResetCauHinh_MouseMove(object sender, MouseEventArgs e)
        {
            btnResetCauHinh.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnResetCauHinh, "Cập nhật cấu hình nhập vào");
        }

        private void btnResetCauHinh_MouseLeave(object sender, EventArgs e)
        {
            btnResetCauHinh.BackColor = Color.DarkCyan;
        }

        private void btnBrowse_MouseMove(object sender, MouseEventArgs e)
        {
            btnBrowse.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnBrowse, "Thêm ảnh");
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            btnBrowse.BackColor = Color.DarkCyan;
        }

        private void btnResetTT_MouseMove(object sender, MouseEventArgs e)
        {
            btnResetTT.BackColor = Color.DarkSlateGray;
            toolTip1.SetToolTip(btnResetTT, "Cập nhật dữ liệu nhập vào");
        }

        private void btnResetTT_MouseLeave(object sender, EventArgs e)
        {
            btnResetTT.BackColor = Color.DarkCyan;
        }

        private void btnSave_MouseMove(object sender, MouseEventArgs e)
        {
            btnSave.BackColor = Color.DarkSlateGray;
            switch(chedo)
            {
                case "Luu":
                    toolTip1.SetToolTip(btnSave, "Lưu dữ liệu");
                    break;
                case "Sua":
                    toolTip1.SetToolTip(btnSave, "Chỉnh sửa dữ liệu");
                    break;
            }    

        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DarkCyan;
        }
    }
}
