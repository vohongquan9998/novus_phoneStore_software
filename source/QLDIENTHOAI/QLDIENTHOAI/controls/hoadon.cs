using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class hoadon
    {
        private int sohd;
        private DateTime ngaylap;
        private string makh;
        private string manv;
        private float trigia;

        public hoadon() { }

        public hoadon(int sohd, DateTime ngaylap, string makh, string manv, float trigia)
        {
            this.sohd = sohd;
            this.ngaylap = ngaylap;
            this.makh = makh;
            this.manv = manv;
            this.trigia = trigia;
        }

        public int Sohd { get => sohd; set => sohd = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Manv { get => manv; set => manv = value; }
        public float Trigia { get => trigia; set => trigia = value; }
    }
}
