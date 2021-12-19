using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class phieunhap
    {
        private string mapn;
        private string mancc;
        private int soluong;
        private DateTime ngaylap;
        private DateTime ngaygiao;
        private string makho;

        public phieunhap() { }

        public phieunhap(string mapn, string mancc, int soluong, DateTime ngaylap, DateTime ngaygiao, string makho)
        {
            this.Mapn = mapn;
            this.Mancc = mancc;
            this.Soluong = soluong;
            this.Ngaylap = ngaylap;
            this.Ngaygiao = ngaygiao;
            this.Makho = makho;
        }

        public string Mapn { get => mapn; set => mapn = value; }
        public string Mancc { get => mancc; set => mancc = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public DateTime Ngaygiao { get => ngaygiao; set => ngaygiao = value; }
        public string Makho { get => makho; set => makho = value; }
    }
}
