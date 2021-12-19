using QLDIENTHOAI.view;
using QLDIENTHOAI.view.FormQuanLy;
using QLDIENTHOAI.view.FormTraCuu;
using QLDIENTHOAI.view.FormBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLDIENTHOAI.view.FormBH;

namespace QLDIENTHOAI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoading());
        }
    }
}
