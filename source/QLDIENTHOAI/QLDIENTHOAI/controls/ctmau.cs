using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class ctmau
    {
        private string mamau;
        private string masp;

        public ctmau() { }

        public ctmau(string mamau, string masp)
        {
            this.mamau = mamau;
            this.masp = masp;
        }

        public string Mamau { get => mamau; set => mamau = value; }
        public string Masp { get => masp; set => masp = value; }
    }
}
