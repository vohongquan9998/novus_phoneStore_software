using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class dondathang
    {
        private string soddh;
        private DateTime ngaygiao;
        private DateTime ngaydat;
        private float trigia;
        private bool dagiao;
        private string makh;

        public dondathang() { }
        public dondathang(string soddh, DateTime ngaygiao, DateTime ngaydat, float trigia, bool dagiao, string makh)
        {
            this.soddh = soddh;
            this.ngaygiao = ngaygiao;
            this.ngaydat = ngaydat;
            this.trigia = trigia;
            this.dagiao = dagiao;
            this.makh = makh;
        }

        public string Soddh { get => soddh; set => soddh = value; }
        public DateTime Ngaygiao { get => ngaygiao; set => ngaygiao = value; }
        public DateTime Ngaydat { get => ngaydat; set => ngaydat = value; }
        public float Trigia { get => trigia; set => trigia = value; }
        public bool Dagiao { get => dagiao; set => dagiao = value; }
        public string Makh { get => makh; set => makh = value; }
    }
}
