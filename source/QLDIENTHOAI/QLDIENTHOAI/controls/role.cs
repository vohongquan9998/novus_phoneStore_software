using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class role
    {
        private int iD;
        private string mota;

        public role(int iD, string mota)
        {
            this.iD = iD;
            this.mota = mota;
        }
        public role() { }

        public int ID { get => iD; set => iD = value; }
        public string Mota { get => mota; set => mota = value; }
    }
}
