using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class nhacungcap
    {
        private string mancc;
        private string tenncc;
        private string diachi;

        public nhacungcap()
        { }
        public nhacungcap(string mancc, string tenncc, string diachi)
        {
            this.Mancc = mancc;
            this.Tenncc = tenncc;
            this.Diachi = diachi;
        }

        public string Mancc { get => mancc; set => mancc = value; }
        public string Tenncc { get => tenncc; set => tenncc = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}
