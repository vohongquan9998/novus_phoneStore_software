using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class khachhang
    {
        private string makh;
        private string tenkh;
        private string diachi;
        private string sodt;
        private string loaikh;

        public khachhang() { }
        public khachhang(string makh, string tenkh, string diachi, string sodt, string loaikh)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Diachi = diachi;
            this.Sodt = sodt;
            this.Loaikh = loaikh;
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sodt { get => sodt; set => sodt = value; }
        public string Loaikh { get => loaikh; set => loaikh = value; }
    }
}
