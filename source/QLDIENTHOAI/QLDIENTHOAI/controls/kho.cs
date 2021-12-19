using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class kho
    {
        private string makho;
        private int Tongsl;
        public kho() { }

        public kho(string makho, int tongsl)
        {
            this.makho = makho;
            Tongsl = tongsl;
        }

        public string Makho { get => makho; set => makho = value; }
        public int Tongsl1 { get => Tongsl; set => Tongsl = value; }
    }
}
