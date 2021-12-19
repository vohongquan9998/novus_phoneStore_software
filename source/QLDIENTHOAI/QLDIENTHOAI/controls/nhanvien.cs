using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class nhanvien
    {
        private string manv;
        private string tennv;
        private string sodt;
        private DateTime ngayvl;
        private DateTime ngaysinh;
        private bool gt;
        private string chucvu;
        private string diachi;
        public nhanvien() { }

        public nhanvien(string manv, string tennv, string sodt, DateTime ngayvl, DateTime ngaysinh, bool gt, string chucvu)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.sodt = sodt;
            this.ngayvl = ngayvl;
            this.ngaysinh = ngaysinh;
            this.gt = gt;
            this.chucvu = chucvu;
        }

        public nhanvien(string manv, string tennv, string sodt, DateTime ngayvl, DateTime ngaysinh, bool gt, string chucvu, string diachi)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.sodt = sodt;
            this.ngayvl = ngayvl;
            this.ngaysinh = ngaysinh;
            this.gt = gt;
            this.chucvu = chucvu;
            this.diachi = diachi;
        }

        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Sodt { get => sodt; set => sodt = value; }
        public DateTime Ngayvl { get => ngayvl; set => ngayvl = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public bool Gt { get => gt; set => gt = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}
