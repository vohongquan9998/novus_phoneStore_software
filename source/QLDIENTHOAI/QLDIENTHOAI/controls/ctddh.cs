using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class ctddh
    {
        private string soddh;
        private string masp;
        private int soluong;
        private string hinhthuctt;

        public ctddh() { }

        public ctddh(string soddh, string masp, int soluong, string hinhthuctt)
        {
            this.soddh = soddh;
            this.masp = masp;
            this.soluong = soluong;
            this.hinhthuctt = hinhthuctt;
        }

        public string Soddh { get => soddh; set => soddh = value; }
        public string Masp { get => masp; set => masp = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Hinhthuctt { get => hinhthuctt; set => hinhthuctt = value; }
    }
}
