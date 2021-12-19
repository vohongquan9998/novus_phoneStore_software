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
    public partial class FormToolTip : Form
    {
        bool btn;
        public FormToolTip(string tooltip)
        {
            InitializeComponent();
            txtDetal.Text = tooltip;
            timer1.Start();

        }
        int count = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count--; 
            label1.Text = "Tự động tắt sau " + count + " giây";
            if (count == 9)
            {
                timer2.Start();
            }
            if (count==0)
            {
                timer1.Stop();
                this.Visible = false;
            }  
            if(count <= 6)
            {
                if(count==6)
                    timer3.Start();
                button1.Visible = true;
                if (btn)
                {
                    timer1.Stop();
                    count = 10;
                    label1.Visible = false;
                    button1.Visible = false;
                    panel1.Visible = false;
                }
            }    
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn = true;
        }
        int xLabel,xbutton;
        private void timer2_Tick(object sender, EventArgs e)
        {
                xLabel = panel1.Location.X;
                xLabel += 22;
                panel1.Location = new Point(xLabel, panel1.Location.Y);
                if (xLabel > -10)
                    timer2.Stop();
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            xbutton = button1.Location.X;
            xbutton -= 20;
            button1.Location = new Point(xbutton,button1.Location.Y);
            if (xbutton <= 196)
                timer3.Stop();
        }
    }
}
