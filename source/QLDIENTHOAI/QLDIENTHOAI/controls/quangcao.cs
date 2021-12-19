using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class quangcao
    {
        private string macty;
        private string tencty;
        private byte[] image;
        private string thamkhao;
        private DateTime ngaybd;
        private DateTime ngaykt;
        private bool trangthaisd;

        public quangcao() { }
        public quangcao(string tencty, byte[] image, string thamkhao, DateTime ngaybd, DateTime ngaykt)
        {
            this.tencty = tencty;
            this.image = image;
            this.thamkhao = thamkhao;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
        }

        public quangcao(string macty, string tencty, byte[] image, string thamkhao, DateTime ngaybd, DateTime ngaykt)
        {
            this.macty = macty;
            this.tencty = tencty;
            this.image = image;
            this.thamkhao = thamkhao;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
        }

        public string Tencty { get => tencty; set => tencty = value; }
        public byte[] Anh { get => image; set => image = value; }
        public string Thamkhao { get => thamkhao; set => thamkhao = value; }
        public DateTime Ngaybd { get => ngaybd; set => ngaybd = value; }
        public DateTime Ngaykt { get => ngaykt; set => ngaykt = value; }
        public string Macty { get => macty; set => macty = value; }
        public bool Trangthaisd { get => trangthaisd; set => trangthaisd = value; }
    }
}
