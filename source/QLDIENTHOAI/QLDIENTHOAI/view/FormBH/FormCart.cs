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

    public partial class FormCart : Form
    {
        string maSP;
        int count = 0;
        string[] row;
        public FormCart(string masp)
        {
            InitializeComponent();
            this.maSP = masp;

            dgvDSSP.ColumnCount = 2;
            dgvDSSP.Columns[0].Name = "STT";
            dgvDSSP.Columns[1].Name = "Tên sản phẩm";
            string line = System.Environment.NewLine;
            control ctr = new control();
            SqlDataReader reader = ctr.SqlDataReaderThongTinDT(maSP);

            if(reader.Read())
            {
                count = dgvDSSP.Rows.Count+1;
                row = new string[] {count.ToString(),Convert.ToString(reader["TENSP"]),""};
                dgvDSSP.Rows.Add(row);

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgvDSSP.Columns.Add(btn);
                btn.HeaderText = "Actions";
                btn.Text = "Del";
                btn.Name = "btn";
                lbTT.Text = Convert.ToInt32(reader["DONGIA"]).ToString();
                btn.UseColumnTextForButtonValue = true;
                dgvDSSP.Columns[0].Width = 30;
                dgvDSSP.Columns[2].Width = 40;
                btn.DefaultCellStyle.BackColor = Color.DarkCyan;
                btn.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }


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
                                lbTT.Text = "0";
                            }
                        }
                    }
                }
            }
        }
    }
}
