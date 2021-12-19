using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class dienthoai
    {
        private string masp;
        private string tensp;
        private string baohanh;
        private int dungluong;
        private string xuatsu;
        private string chitiet;
        private bool trangthai;
        private float dongia;
        private string makm;
        private string makho;
        private byte[] image;
        public dienthoai() { }

        public dienthoai(string masp, string tensp, string baohanh, int dungluong, string xuatsu, string chitiet, bool trangthai, float dongia, string makm, string makho)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Baohanh = baohanh;
            this.Dungluong = dungluong;
            this.Xuatsu = xuatsu;
            this.Chitiet = chitiet;
            this.Trangthai = trangthai;
            this.Dongia = dongia;
            this.Makm = makm;
            this.Makho = makho;
        }

        public dienthoai(string masp, string tensp, string baohanh, int dungluong, string xuatsu, string chitiet, bool trangthai, float dongia, string makm, string makho, byte[] image)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.baohanh = baohanh;
            this.dungluong = dungluong;
            this.xuatsu = xuatsu;
            this.chitiet = chitiet;
            this.trangthai = trangthai;
            this.dongia = dongia;
            this.makm = makm;
            this.makho = makho;
            this.Hinhanh = image;
        }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Baohanh { get => baohanh; set => baohanh = value; }
        public int Dungluong { get => dungluong; set => dungluong = value; }
        public string Xuatsu { get => xuatsu; set => xuatsu = value; }
        public string Chitiet { get => chitiet; set => chitiet = value; }
        public bool Trangthai { get => trangthai; set => trangthai = value; }
        public float Dongia { get => dongia; set => dongia = value; }
        public string Makm { get => makm; set => makm = value; }
        public string Makho { get => makho; set => makho = value; }
        public byte[] Hinhanh { get => image; set => image = value; }
    }
}
