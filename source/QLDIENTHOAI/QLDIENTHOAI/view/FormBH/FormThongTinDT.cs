using QLDIENTHOAI.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view.FormBH
{
    public partial class FormThongTinDT : Form
    {
        string maSP;
        string[] title = {"Tên sản phẩm:", "Bảo hành:", "Dung lượng:", "Xuất xứ:", "Chi tiết:","Đơn giá:" };
        string[] value = { "TENSP", "BAOHANH", "DUNGLUONG", "XUATSU", "CHITIET", "DONGIA" };
        string[] footer = { "", "", " GB", "", "", " đồng" };
        public FormThongTinDT(string masp)
        {

            this.maSP = masp;
            InitializeComponent();
            string line = System.Environment.NewLine;
            control ctr = new control();
            SqlDataReader reader = ctr.SqlDataReaderThongTinDT(maSP);
            if(reader.Read())
            {

                string total ="";
                for(int i =0;i<title.Length;i++)
                {
                    total += title[i] + Convert.ToString(reader[value[i]])+footer[i]+line;
                }
                txtDetal.Text = total;
                if (Convert.ToBoolean(reader["TRANGTHAI"]) == true)
                {
                    radConhang.Checked = true;
                }
                else
                    radHethang.Checked = true;
            }
        }
    }
}
