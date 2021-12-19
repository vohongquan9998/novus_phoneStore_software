using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QLDIENTHOAI.controls
{
    class user
    {
        private string id;
        private string tentk;
        private string matkhau;
        private int roleID;
        private string makh;
        private string manv;
        public user() { }


        public user(string id, string tentk, string matkhau, int roleID, string makh, string manv)
        {
            this.id = id;
            this.tentk = tentk;
            this.matkhau = matkhau;
            this.RoleID = roleID;
            this.makh = makh;
            this.manv = manv;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public string Tentk { get => tentk; set => tentk = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Id { get => id; set => id = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Manv { get => manv; set => manv = value; }
        public int RoleID { get => roleID; set => roleID = value; }

    }
}
