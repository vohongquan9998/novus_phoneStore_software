using QLDIENTHOAI.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDIENTHOAI.controls
{
    class control
    {
        Database db;
        public control()
        {
            db = new Database();
        }
        public void Disconnect()
        {
            db.Disconnect();
        }
        public bool Login(string tentk, string pass)
        {
            return db.Login(tentk, pass);
        }
        public DataSet Load(string key)
        {
            return db.Load(key);
        }
        public DataTable LoadCTHD()
        {
            return db.LoadCTHD();
        }
        public DataTable Search(string giatri, int giatriInt, string key)
        {
            return db.Search(giatri, giatriInt, key);
        }
        public bool checkUser(string tentk)
        {
            return db.checkUser(tentk);

        }
        public bool Check(string ma, string key)
        {
            return db.Check(ma, key);

        }
        public void UpdateAdminToUser(string tentk, string makh)
        {
            db.UpdateAdminToUser(tentk, makh);
        }
        public bool CheckAdmin(string tentk, string pass, string chucvu)
        {
            return db.CheckAdmin(tentk, pass, chucvu);
        }

        public int CheckAdminOrUser(string tentk)
        {
            return db.CheckAdminOrUser(tentk);
        }
        public string SoHD(string makh)
        {
            return db.SoHD(makh);
        }
        public string SoHD_Check(string makh)
        {
            return db.SoHD_check(makh);
        }
        public string CheckSOHD(string ma,string key)
        {
            return db.CheckSOHD(ma,key);
        }
        public void UpdatePassword(string tentk, string mkcu, string mkmoi)
        {
           db.UpdatePassword(tentk, mkcu, mkmoi);
        }
        public string GetValueAccount(string makh, string key)
        {
            return db.GetValueAccount(makh, key);
        }
        public int CheckExistByInt(string ma, string key)
        {
            return db.CheckExistByInt(ma,key);
        }
        public void User(string tentk, string pass, int roleId,string makh, string key)
        {
            db.User(tentk, pass, roleId,makh, key);
        }
        public DataTable LoadUserFromRoleID(int roleID)
        {
            return db.LoadUserFromRole(roleID);
        }
        public void UpdateRoleID(string tentk, int roleID,string manv)
        {
            db.UpdateRole(tentk, roleID,manv);
        }

        public void UpdateRoleIDKH(string tentk, int roleID, string manv)
        {
            db.UpdateRole(tentk, roleID, manv);
        }
        //public string Username(string tentk)
        //{
        //    return db.Username(tentk);
        //}
        public DataTable searchMM(int min, int max, string key)
        {
            return db.searchMINMAX(min, max, key);
        }
        //public DataTable searchLONGMM(long min, long max, string key)
        //{
        //    return db.searchLONGMINMAX(min, max, key);
        //}
        public DataTable searchDate(DateTime min, DateTime max, string key)
        {
            return db.searchDate(min, max, key);
        }
        public DataTable searchBool(bool value, string key)
        {
            return db.searchBool(value, key);
        }
        public int Tongsl()
        {
            return db.Tongsl();
        }
        public void Delete(string ma, string key)
        {
            db.Delete(ma, key);
        }
        public DataTable searchUser(string ma, string mota)
        {
            return db.searchUser(ma, mota);
        }
        public void DienThoai(string masp, string tensp, string baohanh, int dungluong, string xuatxu, string chitiet, bool trangthai, float dongia, string makm, string makho, byte[] hinhanh, string key)
        {
            db.DienThoai(masp, tensp, baohanh, dungluong, xuatxu, chitiet, trangthai, dongia, makm, makho, hinhanh, key);
        }
        public void CTmau(string mamau, string masp)
        {
            db.CTmau(mamau, masp);
        }
        public void deleteCTmau(string mamau, string masp)
        {
            db.DeleteCTmau(mamau, masp);
        }
        public void KhachHang(string makh, string tenkh, string dc, string sdt, string loaikh, string key)
        {
            db.KhachHang(makh, tenkh, dc, sdt, loaikh, key);
        }
        public void Nhanvien(string manv, string tennv, string sdt, DateTime ngayvl, DateTime ngaysinh, bool gt, string chucvu, string dc, string key)
        {
            db.Nhanvien(manv, tennv,sdt, ngayvl, ngaysinh, gt, chucvu, dc, key);

        }

        public void Khuyenmai(string makm, string noidung, string loaikm, float giamgia, string key)
        {
            db.Khuyenmai(makm, noidung, loaikm, giamgia, key);
        }

        public void Quangcao(string id, string tencty, string thamkhao, DateTime ngaybd, DateTime ngaykt, byte[] anh, bool hethan, string key)
        {
            db.Quangcao(id, tencty, thamkhao, ngaybd, ngaykt, anh, hethan, key);
        }
        public void Kho(string makho, int tongsl)
        {
            db.Kho( makho, tongsl);
        }
        public void Phieunhap(string mapn, string mancc, int sl, DateTime ngaylap, DateTime ngaygiao, string makho, string key)
        {
            db.Phieunhap(mapn, mancc, sl, ngaylap, ngaygiao, makho, key);
        }
        public void NCC(string mancc, string tenncc, string dc, string key)
        {
            db.NCC(mancc, tenncc, dc, key);
        }

        public string Tooltip(DataGridView data)
        {
            string tooltip;
            List<string> list = new List<string>();
            tooltip = "";
            foreach (DataGridViewColumn c in data.Columns)
            {
                list.Add(c.HeaderText.ToString()+":");
            }
            string[] header = list.ToArray();
            string newline = Environment.NewLine;
            if (data.RowCount > 0)
            {
                for (int i = 0; i < data.ColumnCount; i++)
                {
                    tooltip += header[i] + data.CurrentRow.Cells[i].Value.ToString() + newline;
                }
            }
            return tooltip;
        }
        public DataSet ShowADsImage()
        {
            return db.ShowADsImage();
        }

        public String getMaxSoDT()
        {
            return db.getMaxSoDT();
        }
        public void HoaDon(int sohd, DateTime ngaylaphd, string makh, string manv)
        {
            db.HoaDon(sohd, ngaylaphd, makh, manv);
        }
        public void CTHD(int sohd, string tensp, int sl)
        {
            db.CTHD(sohd, tensp, sl);
        }
        public SqlDataReader SqlDataReaderThongTinDT(string masp)
        {
            return db.SqlDataReaderThongTinDT(masp);
        }
    }

}
