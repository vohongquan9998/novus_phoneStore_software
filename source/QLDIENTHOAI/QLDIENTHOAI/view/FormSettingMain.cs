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
    public partial class FormSettingMain : Form
    {
        public FormSettingMain()
        {
            InitializeComponent();
        }



        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
