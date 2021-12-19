using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class khuyenmai
    {
        private string makm;
        private string noidung;
        private string loaikm;
        private float giamgia;

        public khuyenmai(string makm, string noidung, string loaikm, float giamgia)
        {
            this.makm = makm;
            this.noidung = noidung;
            this.loaikm = loaikm;
            this.giamgia = giamgia;
        }

        public khuyenmai() { }
        public string Makm { get => makm; set => makm = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public string Loaikm { get => loaikm; set => loaikm = value; }
        public float Giamgia { get => giamgia; set => giamgia = value; }
    }
}
