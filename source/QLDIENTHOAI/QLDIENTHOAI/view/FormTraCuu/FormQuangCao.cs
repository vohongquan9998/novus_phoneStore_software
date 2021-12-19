using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormTraCuu
{
    public partial class FormMenuUser : Form
    {
        public FormMenuUser()
        {
            InitializeComponent();
            LoadQC();
            CustomDate();
            
        }

        private void CustomDate()
        {
            dtpNgayBD.Format = DateTimePickerFormat.Custom;
            dtpNgayBD.CustomFormat = "dd/MM/yyyy";
            dtpNgayKT.Format = DateTimePickerFormat.Custom;
            dtpNgayKT.CustomFormat = "dd/MM/yyyy";
        }

        control ctr;
        quangcao ads;
        Image BG = Image.FromFile(@"..\..\images\img\pictureboxBG.png");
        private void LoadQC()
        {
            ctr = new control();
            dgvDSQC.DataSource = ctr.Load("ADS").Tables[0].DefaultView;
            ctr.Disconnect();       
        }
        byte[] image;
        OpenFileDialog open;
        string imgname;
        private void picQC_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:";
            open.FileName = "";
            open.Filter = "JPG image(*.jpg)|*.jpg|PNG image(*.png)|*.png|All files(*.*)|*.*";
            open.RestoreDirectory = true;
            open.ShowDialog();
            if (open.FileName != "")
            {
                imgname = open.SafeFileName.Substring(open.SafeFileName.LastIndexOf(@"\") + 1);
                picQC.Image = Image.FromFile(open.FileName);
                FileStream fileStream = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                image = new byte[fileStream.Length];
                fileStream.Read(image, 0, image.Length);
                fileStream.Close();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void dgvDSQC_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSQC.RowCount > 0)
            {
                txtMaCT.Text = dgvDSQC.CurrentRow.Cells[0].Value.ToString();
                txtCty.Text = dgvDSQC.CurrentRow.Cells[1].Value.ToString();
                txtThamKhao.Text = dgvDSQC.CurrentRow.Cells[2].Value.ToString();
                dtpNgayBD.Value = Convert.ToDateTime(dgvDSQC.CurrentRow.Cells[3].Value.ToString());
                dtpNgayKT.Value = Convert.ToDateTime(dgvDSQC.CurrentRow.Cells[4].Value.ToString());
                if (Convert.ToBoolean(dgvDSQC.CurrentRow.Cells[5].Value.ToString()) == true)
                {
                    radHetHan.Checked = true;
                }
                else
                    radCon.Checked = true;
                if(dgvDSQC.CurrentRow.Cells[6].Value.ToString()!="")
                {
                    byte[] ImImage;
                    ImImage = (byte[])dgvDSQC.CurrentRow.Cells[6].Value;
                    MemoryStream ms = new MemoryStream(ImImage);
                    picQC.Image = Image.FromStream(ms);
                    image = ImImage;

                }
                else
                {
                    picQC.Image = BG;
                }
                btnLuu.Enabled = false;
                btnDelete.Enabled = true;
                btnSua.Enabled = true;
                txtMaCT.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            
        }

        private void ResetAll()
        {
            LoadQC();
            foreach (Control c in panel13.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
            }
            foreach (Control c in panel2.Controls)
            {
                if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;
            }
            btnLuu.Enabled = true;
            btnDelete.Enabled = false;
            btnSua.Enabled = false;
            if (picQC.Image != null)
                picQC.Image = BG;
            txtMaCT.Enabled = true;
            radAll.Checked = true;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            ctr = new control();
            if (txtCty.TextLength!=0)
            {

                ads = new quangcao();
                ads.Tencty = txtCty.Text;
                dgvDSQC.DataSource = ctr.Search(ads.Tencty, 0, "ADS");
                ctr.Disconnect();
                Null();
            }     
            else
            {
                MessageBox.Show("Hãy đợi bản cập nhật tiếp theo để tìm kiếm được nhiều hơn", "Thông báo");
            }

        }

        private void Null()
        {
            if (dgvDSQC.RowCount == 0)
            {
                MessageBox.Show("Kết quả tìm kiếm không tồn tại", "Thông báo");
                ResetAll();
            }
        }
        private void LoadInfor()
        {
            ads = new quangcao();
            ads.Macty = txtMaCT.Text;
            ads.Tencty = txtCty.Text;
            ads.Thamkhao = txtThamKhao.Text;
            ads.Anh = image;
            ads.Ngaybd = dtpNgayBD.Value;
            ads.Ngaykt = dtpNgayKT.Value;
            ads.Trangthaisd = false;
        }
        private void LoadInforUpdate()
        {
            ads = new quangcao();
            ads.Macty = txtMaCT.Text;
            ads.Tencty = txtCty.Text;
            ads.Thamkhao = txtThamKhao.Text;
            ads.Anh = image;
            ads.Ngaybd = dtpNgayBD.Value;
            ads.Ngaykt = dtpNgayKT.Value;
            if(radCon.Checked)
                ads.Trangthaisd = false;
            else
                ads.Trangthaisd = true;
        }
        private bool CheckExistValue()
        {
            bool check;
            ctr = new control();
            ads = new quangcao();
            ads.Macty = txtMaCT.Text;
            check = ctr.Check(ads.Macty, "ADS");
            ctr.Disconnect();
            return check;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtCty.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên công ty", "Thông báo");
            }
            else if (txtThamKhao.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập Đường link tham khảo", "Thông báo");
            }
            else if (picQC.Image == BG)
            {
                MessageBox.Show("Vui lòng Thêm ảnh", "Thông báo");
            }
            else if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Vui lòng chọn ngày chính xác", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CheckExistValue())
                    {
                        LoadInfor();
                        ctr = new control();
                        ctr.Quangcao(ads.Macty, ads.Tencty, ads.Thamkhao, ads.Ngaybd, ads.Ngaykt, ads.Anh, ads.Trangthaisd, "INSERT");
                        ctr.Disconnect();
                        MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                        LoadQC();

                    }
                    else
                    {
                        MessageBox.Show("Quảng cáo đã tồn tại", "Thông báo");
                    }
                }
            }    
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Vui lòng chọn ngày chính xác", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn chỉnh sửa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadInforUpdate();
                    ctr = new control();
                    ctr.Quangcao(ads.Macty, ads.Tencty, ads.Thamkhao, ads.Ngaybd, ads.Ngaykt, ads.Anh, ads.Trangthaisd, "UPDATE");
                    ctr.Disconnect();
                    MessageBox.Show("Chỉnh sửa thành công", "Thông báo");
                    LoadQC();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xoá dữ liệu này", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                ctr = new control();
                ads = new quangcao();
                ads.Macty = txtMaCT.Text;
                ctr.Delete(ads.Macty, "ADS");
                ctr.Disconnect();
                MessageBox.Show("Xoá dữ liệu thành công", "Thông báo");
                LoadQC();
            }    

        }

        private void dgvDSQC_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ctr = new control();
            string a = ctr.Tooltip(dgvDSQC);
            FormToolTip formToolTip = new FormToolTip(a);
            formToolTip.ShowDialog();
        }
    }
}
