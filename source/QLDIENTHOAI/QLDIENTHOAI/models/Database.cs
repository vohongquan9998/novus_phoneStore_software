using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLDIENTHOAI.models
{
    class Database
    {
        DataProvider provider = new DataProvider();
        public Database()
        {
            provider.Connect();
        }
        public void Disconnect()
        {
            provider.Disconnect();
        }
        public bool Login(string tentk, string pass)
        {
            return provider.Login("sp_login", tentk, pass);
        }

        public DataSet Load(string key)
        {
            return provider.LoadThongTin("sp_selectAll", key);
        }
        public DataTable LoadCTHD()
        {
            return provider.LoadCTHD("sp_select_CTHD_MAIN");
        }
        public DataTable Search(string giatri, int giatriInt, string key)
        {
            return provider.SearchThongTin("sp_search", giatri, giatriInt, key);
        }
        public bool checkUser(string tentk)
        {
            return provider.checkExist("sp_checkUser", tentk);
        }
        public bool Check(string ma, string key)
        {
            return provider.Check("sp_checkExist", ma, key);
        }

        public bool CheckAdmin(string tentk, string pass, string chucvu)
        {
            return provider.CheckAdmin("sp_checkQL", tentk, pass, chucvu);
        }
        public string SoHD(string makh)
        {
            return provider.SoHD("sp_selectHD", makh);
        }
        public string SoHD_check(string makh)
        {
            return provider.SoHD_check("sp_selectHD", makh);
        }
        public string CheckSOHD(string ma,string key)
        {
            return provider.CheckSOHD("sp_checkSOHD", ma,key);
        }

        public string GetValueAccount(string makh, string key)
        {
            return provider.GetValueAccount("sp_ChangeAccount", makh, key);
        }
        public void UpdatePassword(string tentk, string mkcu, string mkmoi)
        {
            provider.UpdatePassword("sp_changePass", tentk, mkcu, mkmoi);
        }
        public int CheckExistByInt(string ma, string key)
        {
            return provider.CheckExistByInt("sp_checkExist",ma,key);
        }
        public void UpdateAdminToUser(string tentk, string makh)
        {
            provider.UpdateAdminToUser("sp_UpdateAdminToUser", tentk, makh);
        }
        public void User(string tentk, string pass, int roleid, string makh, string key)
        {
            provider.Users("sp_User",tentk, pass, roleid, makh, key);
        }
        public DataTable LoadUserFromRole(int roleID)
        {
            return provider.LoadUserFromRole("sp_selectUser", roleID);
        }
        public void UpdateRole(string tentk,int roleId, string manv)
        {
            provider.Updateroleid("sp_updateMota", tentk, roleId, manv);
        }
        public void UpdateRoleKH(string tentk, int roleId, string makh)
        {
            provider.UpdateroleidKH("sp_updateRoleIdAdminToUser", tentk, roleId, makh);
        }
        public DataTable searchMINMAX(int min, int max, string key)
        {
            return provider.SearchMINMAX("sp_searchSLPN", min, max, key);
        }
        //public DataTable searchLONGMINMAX(long min, long max, string key)
        //{
        //    return provider.searchLongMM("sp_searchSLPN", min, max, key);
        //}
        public DataTable searchDate(DateTime min, DateTime max, string key)
        {
            return provider.searchDate("sp_searchDate", min, max, key);
        }
        public int Tongsl()
        {
            return provider.Tongsl("sp_selectKho_tongSL");
        }
        public void Delete(string ma, string key)
        {
            provider.Delete("sp_Delete", ma, key);
        }
        public DataTable searchUser(string ma, string mota)
        {
            return provider.searchUser("sp_searchUser", ma, mota);
        }

        public void DienThoai(string masp, string tensp, string baohanh, int dungluong, string xuatxu, string chitiet, bool trangthai, float dongia, string makm, string makho, byte[] hinhanh, string key)
        {
            provider.DienThoai("sp_dienthoai", masp, tensp, baohanh, dungluong, xuatxu, chitiet, trangthai, dongia, makm, makho, hinhanh, key);
        }
        public void CTmau(string mamau, string masp)
        {
            provider.CTmau("sp_ctmau", mamau, masp);
        }
        public void DeleteCTmau(string mamau, string masp)
        {
            provider.DeleteCTMAU("sp_deleteCTMAU", mamau, masp);
        }
        public DataTable searchBool(bool value, string key)
        {
            return provider.searchBool("sp_searchBool", value, key);
        }
        public void KhachHang(string makh, string tenkh, string dc, string sdt, string loaikh, string key)
        {
            provider.Khachhang("sp_khachhang", makh, tenkh, dc, sdt, loaikh, key);
        }
        public void Nhanvien(string manv, string tennv, string sdt, DateTime ngayvl, DateTime ngaysinh, bool gt, string chucvu, string dc, string key)
        {
            provider.Nhanvien("sp_nhanvien", manv, tennv, sdt, ngayvl, ngaysinh, gt, chucvu, dc, key);

        }

        public int CheckAdminOrUser(string tentk)
        {
            return provider.CheckAdminOrUser("sp_CheckAdminOrUser", tentk);
        }

        public void Khuyenmai(string makm, string noidung, string loaikm, float giamgia, string key)
        {
            provider.Khuyenmai("sp_khuyenmai", makm, noidung, loaikm, giamgia, key);
        }
        public void Quangcao(string id, string tencty, string thamkhao, DateTime ngaybd, DateTime ngaykt, byte[] anh, bool hethan, string key)
        {
            provider.Quangcao("sp_quangcao", id, tencty, thamkhao, ngaybd, ngaykt, anh, hethan, key);
        }
        public void Kho(string makho, int tongsl)
        {
            provider.Kho("sp_kho", makho, tongsl);
        }
        public void Phieunhap(string mapn, string mancc, int sl, DateTime ngaylap, DateTime ngaygiao, string makho, string key)
        {
            provider.Phieunhap("sp_phieunhap", mapn, mancc, sl, ngaylap, ngaygiao, makho, key);
        }
        public void NCC(string mancc, string tenncc, string dc, string key)
        {
            provider.NCC("sp_nhacungcap", mancc, tenncc, dc, key);
        }

        public DataSet ShowADsImage()
        {
            return provider.ShowADsImage("sp_selectImgADS");
        }
        public String getMaxSoDT()
        {
            return provider.getMaxSoDT("sp_maxSOHD");
        }

        public void HoaDon(int sohd, DateTime ngaylaphd, string makh, string manv)
        {
            provider.HoaDon("sp_hoadon", sohd, ngaylaphd, makh, manv);
        }
        public void CTHD(int sohd, string tensp, int sl)
        {
            provider.CTHD("sp_cthd", sohd, tensp, sl);
        }
        public SqlDataReader SqlDataReaderThongTinDT(string masp)
        {
            return provider.SqlDataReaderThongTinDT("selectThongTinDT", masp);
        }
    }
}
