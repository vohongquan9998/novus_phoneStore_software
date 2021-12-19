using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.view
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void txtreport_Click(object sender, EventArgs e)
        {
            txtreport.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(txtreport.Text!= "Hãy cho tôi biết sự cố của bạn")
            {
                MessageBox.Show("Xin cảm ơn về ý kiến của bạn,chúng tôi sẽ sớm xử lý sự cố này");
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Xin hãy cho chúng tôi biết sự cố của bạn");
            }

        }
    }
}
