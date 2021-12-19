using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class cthd
    {
        private int sohd;
        private string masp;
        private int sl;

        public cthd() { }

        public cthd(int sohd, string masp, int sl)
        {
            this.Sohd = sohd;
            this.Masp = masp;
            this.Sl = sl;
        }

        public int Sohd { get => sohd; set => sohd = value; }
        public string Masp { get => masp; set => masp = value; }
        public int Sl { get => sl; set => sl = value; }
    }
}
