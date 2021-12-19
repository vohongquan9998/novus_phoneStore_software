using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QLDIENTHOAI.models
{
    class DataProvider
    {
        public DataProvider() { }
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dap;
        string connectionString = ConfigurationManager.ConnectionStrings["KN"].ConnectionString.ToString();

        public void Connect()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            con.Close();
        }

        public bool Login(string strStore, string tentk, string pass)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt.Rows.Count > 0;
        }

        public DataSet LoadThongTin(string strStore, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "KM":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI";
                    break;
                case "KM2":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI_MAIN";
                    break;
                case "DT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    break;
                case "DT2":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI_2";
                    break;
                case "DT_HD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DT_HD";
                    break;
                case "KH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    break;
                case "NV":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHANVIEN";
                    break;
                case "KHO":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO";
                    break;
                case "MAKHO":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO_MAKHO";
                    break;
                case "PN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PHIEUNHAP";
                    break;
                case "NCC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHACUNGCAP";
                    break;
                case "HD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON";
                    break;
                case "CTHD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    break;
                case "MAU":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "MAU";
                    break;
                case "DDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH";
                    break;
                case "CTDDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    break;
                case "ADS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "QUANGCAO";
                    break;
                case "DT_BH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI_MENU";
                    break;
                case "DT_BH_ASC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI_MENU_ASC";
                    break;
                case "DT_BH_DESC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI_MENU_DESC";
                    break;
            }
            dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }
        public DataTable LoadCTHD(string strStore)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;

        }

        public DataTable LoadUserFromRole(string strStore, int roleID)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("roleid", SqlDbType.NVarChar).Value = roleID;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public int CheckAdminOrUser(string strStore,string tentk)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return t;
        }

        public string SoHD(string strStore, string makh)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            string t = cmd.ExecuteScalar().ToString();
            return t;
        }
        public string SoHD_check(string strStore, string makh)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            string t = (string)cmd.ExecuteScalar();
            return t;
        }
        public string CheckSOHD(string strStore, string ma,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch(key)
            {
                case "CTHD":
                    cmd.Parameters.Add("tenbang", SqlDbType.VarChar).Value = "CTHD";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "CTDDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.VarChar).Value = "CTDDH";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
            }    
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            string a = cmd.ExecuteScalar().ToString();
            return a;
        }

        public string GetValueAccount(string strStore, string makh, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch(key)
            {
                case "TENKH":
                    cmd.Parameters.Add("col", SqlDbType.VarChar).Value = "tenkh";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    break;
                case "DC":
                    cmd.Parameters.Add("col", SqlDbType.VarChar).Value = "DC";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    break;
                case "SDT":
                    cmd.Parameters.Add("col", SqlDbType.VarChar).Value = "sodt";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    break;
                case "LOAIKH":
                    cmd.Parameters.Add("col", SqlDbType.VarChar).Value = "loaikh";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    break;
                case "PASS":
                    cmd.Parameters.Add("col", SqlDbType.VarChar).Value = "password";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    break;
            }    
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            string t = (string)cmd.ExecuteScalar();
            return t;
        }

        public bool CheckAdmin(string strStore, string tentk, string pass,string chucvu)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
            cmd.Parameters.Add("loaicv", SqlDbType.VarChar).Value = chucvu;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt.Rows.Count > 0;
        }


        public void UpdatePassword(string StrStore,string tentk,string mkcu,string mkmoi)
        {
            cmd = new SqlCommand(StrStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("mkmoi", SqlDbType.VarChar).Value = mkmoi;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("mkcu", SqlDbType.VarChar).Value = mkcu;
            cmd.ExecuteNonQuery();
        }

        public DataTable SearchThongTin(string strStore, string giatri, int giatriInt, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "MASP": // Dien thoai masp
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MASP";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "TENSP":// Dien thoai tensp
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENSP";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "DUNGLUONG": // Dien thoai dung luong
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "DUNGLUONG";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatriInt;
                    break;
                case "DONGIA":// Dien thoai don gia
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "DONGIA";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatriInt;
                    break;
                case "MAKH":// Khach hang makh
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MAKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "TENKH":// Khach hang tenkh
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "DIACHI":// Khach hang dia chi
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "DIACHI";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "LOAIKH":// Khach hang loai kh
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "LOAIKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MANV":// Nhan vien manv
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHANVIEN";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MANV";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "TENNV"://Nhan vien ten nv
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHANVIEN";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENNV";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CHUCVU"://Nhan vien chuc vu
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHANVIEN";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "CHUCVU";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "NGAYVL"://Ngay vao lam 
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NHANVIEN";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "NGAYVL";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MAKM":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MAKM";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "LOAIKM":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "LOAIKM";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MAKHO":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MAKHO";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "TONGSL":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TONGSL";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatriInt;
                    break;
                case "MAPN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PHIEUNHAP";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MAPHIEUNHAP";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "HD_SOHD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "SOHOADON_HD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "HD_TENKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "HD_TENNV":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENNV";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_SOHD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "SOHOADON_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_TENKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENKH_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_TENNV":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENNV_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_MASP":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MADT_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_TENSP":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENDT_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTHD_SL":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "SL_CTHD";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatriInt;
                    break;
                case "DDH_SODDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "SODDH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "DDH_TENKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTDDH_SODDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "SODDH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTDDH_TENKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENKH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTDDH_TENSP":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENSP";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "CTDDH_HINHTHUCTT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "HINHTHUCTT";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "ADS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "ADS";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "TENCTY";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "ADS_ID":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "ADS";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "ID";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MENU_TENSP":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MENU_TENSP";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MENU_CAUHINH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MENU_CAUHINH";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatri;
                    break;
                case "MENU_DUNGLUONG":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("loaitk", SqlDbType.NVarChar).Value = "MENU_DUNGLUONG";
                    cmd.Parameters.Add("giatri", SqlDbType.NVarChar).Value = giatriInt;
                    break;
            }
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataTable SearchMINMAX(string strStore, int min, int max, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "PHIEUNHAP":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PHIEUNHAP";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "DT_DG":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI_DONGIA";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "HD_TG":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON_TRIGIA";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "CTHD_TT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD_THANHTIEN";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "DDH_TG":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH_TRIGIA";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "CTDDH_TT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH_THANHTIEN";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
                case "DT_DG_MENU":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "MENU_DONGIA";
                    cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
                    cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
                    break;
            }
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        //public DataTable searchLongMM(string strStore, long min, long max, string key)
        //{
        //    cmd = new SqlCommand(strStore, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    switch (key)
        //    {
        //        case "HD_TG":
        //            cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON_TRIGIA";
        //            cmd.Parameters.Add("giatriMin", SqlDbType.Int).Value = min;
        //            cmd.Parameters.Add("giatriMax", SqlDbType.Int).Value = max;
        //            break;
        //    }
        //    dap = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    dap.Fill(dt);
        //    return dt;
        //}

        public DataTable searchDate(string strStore, DateTime min, DateTime max, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "HD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON";
                    cmd.Parameters.Add("minDate", SqlDbType.Date).Value = min;
                    cmd.Parameters.Add("maxDate", SqlDbType.Date).Value = max;
                    break;
                case "CTHD":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD";
                    cmd.Parameters.Add("minDate", SqlDbType.Date).Value = min;
                    cmd.Parameters.Add("maxDate", SqlDbType.Date).Value = max;
                    break;
                case "DDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH";
                    cmd.Parameters.Add("minDate", SqlDbType.Date).Value = min;
                    cmd.Parameters.Add("maxDate", SqlDbType.Date).Value = max;
                    break;
                case "CTDDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTDDH";
                    cmd.Parameters.Add("minDate", SqlDbType.Date).Value = min;
                    cmd.Parameters.Add("maxDate", SqlDbType.Date).Value = max;
                    break;
            }

            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataTable searchBool(string strStore,bool value, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "DT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("giatri", SqlDbType.Bit).Value = value;
                    break;
                case "DDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DDH";
                    cmd.Parameters.Add("giatri", SqlDbType.Bit).Value = value;
                    break;
                case "ADS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "ADS";
                    cmd.Parameters.Add("giatri", SqlDbType.Bit).Value = value;
                    break;
            }

            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public bool checkExist(string strStore, string tentk)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (t == 1)
            {
                return false;
            }
            return true;
        }

        public void UpdateAdminToUser(string strStore, string tentk ,string makh)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            cmd.ExecuteNonQuery();
        }



        public void Users(string strStore,string tentk, string matkhau, int roleID,string makh, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT_ND":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
                    cmd.Parameters.Add("matkhau", SqlDbType.VarChar).Value = matkhau;
                    cmd.Parameters.Add("roleid", SqlDbType.NVarChar).Value = roleID;
                    cmd.Parameters.Add("makh", SqlDbType.NVarChar).Value = makh;
                    break;
                case "UPDATE_ND":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
                    cmd.Parameters.Add("matkhau", SqlDbType.VarChar).Value = matkhau;
                    cmd.Parameters.Add("roleid", SqlDbType.NVarChar).Value = roleID;
                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public void Updateroleid(string strStore, string tentk, int roleID,string manv)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("roleid", SqlDbType.VarChar).Value = roleID;
            cmd.Parameters.Add("manv", SqlDbType.VarChar).Value = manv;
            cmd.ExecuteNonQuery();
        }

        public void UpdateroleidKH(string strStore, string tentk, int roleID, string makh)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
            cmd.Parameters.Add("roleid", SqlDbType.VarChar).Value = roleID;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            cmd.ExecuteNonQuery();
        }


        //public string Username(string strStore,string tentk)
        //{
        //    cmd = new SqlCommand(strStore, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("tentk", SqlDbType.NVarChar).Value = tentk;
        //    cmd.ExecuteNonQuery();
        //    return tentk;
        //}
        public int Tongsl(string strStore)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return t;

        }

        public int CheckExistByInt(string strStore,string ma,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            dap = new SqlDataAdapter(cmd);
            switch (key)
            {
                case "PN_CHECK":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PN_CHECK";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "PN_CHECK_NCC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PN_CHECK_NCC";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "KH_CHECK_HOADON":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KH_CHECK_HOADON";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "KH_CHECK_DDH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KH_CHECK_DDH";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
            }
            DataTable dt = new DataTable();
            dap.Fill(dt);
            int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return t;
        }


        public void Delete(string strStore, string ma, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "USER":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "USERS";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "DT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "CTHD_DT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD_MADT";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "KH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "HD_KH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON_KH";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "CTHD_HD_KH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "CTHD_KH_HOADON";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "USER_MAKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "USER_MAKH";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "KM":                    
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "ADS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "ADS";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "PN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PN";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "KHO":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "KHO_PN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO_PN";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "NCC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NCC";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
                case "NCC_PN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NCC_PN";
                    cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
                    break;
            }
            cmd.ExecuteNonQuery();
        }

        public void DeleteCTMAU(string strStore,string mamau,string masp)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("mamau", SqlDbType.VarChar).Value = mamau;
            cmd.Parameters.Add("masp", SqlDbType.VarChar).Value = masp;
            cmd.ExecuteNonQuery();
        }

        public DataTable searchUser(string strStore, string ma, string mota)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
            cmd.Parameters.Add("mota", SqlDbType.NVarChar).Value = mota;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public void CTmau(string strStore, string mamau, string masp)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("mamau", SqlDbType.VarChar).Value = mamau;
            cmd.Parameters.Add("masp", SqlDbType.VarChar).Value = masp;
            cmd.ExecuteNonQuery();
        }

        public void DienThoai(string strStore,string masp,string tensp,string baohanh,int dungluong,string xuatxu,string chitiet,bool trangthai,float dongia,string makm,string makho,byte[] hinhanh,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch(key)
            {
                case "INSERT":
                    cmd.Parameters.Add("Store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("masp", SqlDbType.VarChar).Value = masp;
                    cmd.Parameters.Add("tensp", SqlDbType.NVarChar).Value = tensp;
                    cmd.Parameters.Add("baohanh", SqlDbType.VarChar).Value = baohanh;
                    cmd.Parameters.Add("dungluong", SqlDbType.Int).Value = dungluong;
                    cmd.Parameters.Add("xuatxu", SqlDbType.NVarChar).Value = xuatxu;
                    cmd.Parameters.Add("chitiet", SqlDbType.NVarChar).Value = chitiet;
                    cmd.Parameters.Add("trangthai", SqlDbType.Bit).Value = trangthai;
                    cmd.Parameters.Add("dongia", SqlDbType.Float).Value = dongia;
                    cmd.Parameters.Add("makm", SqlDbType.VarChar).Value = makm;
                    cmd.Parameters.Add("makho", SqlDbType.VarChar).Value = makho;
                    cmd.Parameters.Add("hinhanh", SqlDbType.Image).Value = hinhanh;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("Store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("masp", SqlDbType.VarChar).Value = masp;
                    cmd.Parameters.Add("tensp", SqlDbType.NVarChar).Value = tensp;
                    cmd.Parameters.Add("baohanh", SqlDbType.VarChar).Value = baohanh;
                    cmd.Parameters.Add("dungluong", SqlDbType.Int).Value = dungluong;
                    cmd.Parameters.Add("xuatxu", SqlDbType.NVarChar).Value = xuatxu;
                    cmd.Parameters.Add("chitiet", SqlDbType.NVarChar).Value = chitiet;
                    cmd.Parameters.Add("trangthai", SqlDbType.Bit).Value = trangthai;
                    cmd.Parameters.Add("dongia", SqlDbType.Float).Value = dongia;
                    cmd.Parameters.Add("makm", SqlDbType.VarChar).Value = makm;
                    cmd.Parameters.Add("makho", SqlDbType.VarChar).Value = makho;
                    cmd.Parameters.Add("hinhanh", SqlDbType.Image).Value = hinhanh;
                    break;
            }
            cmd.ExecuteNonQuery();
        }

        public bool Check(string strStore,string ma,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch(key)
            {
                case "DT":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "DIENTHOAI";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "KH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHACHHANG";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "KM":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHUYENMAI";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "USERS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "USER";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "HD_MAKH":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "HOADON_MAKH";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "ADS":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "ADS";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "KHO":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "KHO";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "PN":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "PN";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
                case "NCC":
                    cmd.Parameters.Add("tenbang", SqlDbType.NVarChar).Value = "NCC";
                    cmd.Parameters.Add("ma", SqlDbType.NVarChar).Value = ma;
                    break;
            }        
            int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (t == 1)
            {
                return false;
            }
            return true;
        }

        public void Khachhang(string strStore,string makh,string tenkh,string dc,string sdt,string loaikh,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    cmd.Parameters.Add("tenkh", SqlDbType.NVarChar).Value = tenkh;
                    cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = dc;
                    cmd.Parameters.Add("sodt", SqlDbType.VarChar).Value = sdt;
                    cmd.Parameters.Add("loaikh", SqlDbType.NVarChar).Value = loaikh;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
                    cmd.Parameters.Add("tenkh", SqlDbType.NVarChar).Value = tenkh;
                    cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = dc;
                    cmd.Parameters.Add("sodt", SqlDbType.VarChar).Value = sdt;
                    cmd.Parameters.Add("loaikh", SqlDbType.NVarChar).Value = loaikh;
                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public void Nhanvien(string strStore, string manv, string tennv, string sdt, DateTime ngayvl,DateTime ngaysinh,bool gt,string chucvu, string dc, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("manv", SqlDbType.VarChar).Value = manv;
                    cmd.Parameters.Add("tennv", SqlDbType.NVarChar).Value = tennv;
                    cmd.Parameters.Add("sdt", SqlDbType.VarChar).Value = sdt;
                    cmd.Parameters.Add("ngayvl", SqlDbType.Date).Value = ngayvl;
                    cmd.Parameters.Add("ngaysinh", SqlDbType.Date).Value = ngaysinh;
                    cmd.Parameters.Add("gt", SqlDbType.Bit).Value = gt;
                    cmd.Parameters.Add("chucvu", SqlDbType.NVarChar).Value = chucvu;
                    cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = dc;
                    break;
                //case "UPDATE":
                //    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                //    cmd.Parameters.Add("manv", SqlDbType.VarChar).Value = makh;
                //    cmd.Parameters.Add("tenkh", SqlDbType.NVarChar).Value = tenkh;
                //    cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = dc;
                //    cmd.Parameters.Add("sodt", SqlDbType.VarChar).Value = sdt;
                //    cmd.Parameters.Add("loaikh", SqlDbType.NVarChar).Value = loaikh;
                //    break;
            }
            cmd.ExecuteNonQuery();
        }

        public void Khuyenmai(string strStore, string makm, string noidung, string loaikm, float giamgia, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("makm", SqlDbType.VarChar).Value = makm;
                    cmd.Parameters.Add("noidung", SqlDbType.NVarChar).Value = noidung;
                    cmd.Parameters.Add("loaikm", SqlDbType.NVarChar).Value = loaikm;
                    cmd.Parameters.Add("giamgia", SqlDbType.Float).Value = giamgia;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("makm", SqlDbType.VarChar).Value = makm;
                    cmd.Parameters.Add("noidung", SqlDbType.NVarChar).Value = noidung;
                    cmd.Parameters.Add("loaikm", SqlDbType.NVarChar).Value = loaikm;
                    cmd.Parameters.Add("giamgia", SqlDbType.Float).Value = giamgia;
                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public void Quangcao(string strStore, string id, string tencty, string thamkhao, DateTime ngaybd, DateTime ngaykt,byte[] anh,bool hethan,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "INSERT";
                    cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
                    cmd.Parameters.Add("tencty", SqlDbType.NVarChar).Value = tencty;
                    cmd.Parameters.Add("hinhanh", SqlDbType.Image).Value = anh;
                    cmd.Parameters.Add("thamkhao", SqlDbType.NVarChar).Value = thamkhao;
                    cmd.Parameters.Add("ngaybatdau", SqlDbType.Date).Value = ngaybd;
                    cmd.Parameters.Add("ngayketthuc", SqlDbType.Date).Value = ngaykt;
                    cmd.Parameters.Add("hethan", SqlDbType.Bit).Value = hethan;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
                    cmd.Parameters.Add("tencty", SqlDbType.NVarChar).Value = tencty;
                    cmd.Parameters.Add("hinhanh", SqlDbType.Image).Value = anh;
                    cmd.Parameters.Add("thamkhao", SqlDbType.NVarChar).Value = thamkhao;
                    cmd.Parameters.Add("ngaybatdau", SqlDbType.Date).Value = ngaybd;
                    cmd.Parameters.Add("ngayketthuc", SqlDbType.Date).Value = ngaykt;
                    cmd.Parameters.Add("hethan", SqlDbType.Bit).Value = hethan;
                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public void Kho(string strStore, string makho,int tongsl)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("makho", SqlDbType.VarChar).Value =makho ;
            cmd.Parameters.Add("tongsl", SqlDbType.Int).Value = tongsl;
            cmd.ExecuteNonQuery();
        }
        public void Phieunhap(string strStore, string mapn, string mancc,int sl, DateTime ngaylap, DateTime ngaygiao,string makho,string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.VarChar).Value = "INSERT";
                    cmd.Parameters.Add("mapn", SqlDbType.VarChar).Value = mapn;
                    cmd.Parameters.Add("mancc", SqlDbType.VarChar).Value = mancc;
                    cmd.Parameters.Add("soluong", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("ngaylap", SqlDbType.Date).Value = ngaylap;
                    cmd.Parameters.Add("ngaygiao", SqlDbType.Date).Value = ngaygiao;
                    cmd.Parameters.Add("makho", SqlDbType.VarChar).Value = makho;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("mapn", SqlDbType.VarChar).Value = mapn;
                    cmd.Parameters.Add("mancc", SqlDbType.VarChar).Value = mancc;
                    cmd.Parameters.Add("soluong", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("ngaylap", SqlDbType.Date).Value = ngaylap;
                    cmd.Parameters.Add("ngaygiao", SqlDbType.Date).Value = ngaygiao;
                    cmd.Parameters.Add("makho", SqlDbType.VarChar).Value = makho;
                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public void NCC(string strStore, string mancc, string tenncc, string dc, string key)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            switch (key)
            {
                case "INSERT":
                    cmd.Parameters.Add("store", SqlDbType.VarChar).Value = "INSERT";
                    cmd.Parameters.Add("mancc", SqlDbType.VarChar).Value = mancc;
                    cmd.Parameters.Add("ncc", SqlDbType.NVarChar).Value = tenncc;
                    cmd.Parameters.Add("dc", SqlDbType.NVarChar).Value =dc;
                    break;
                case "UPDATE":
                    cmd.Parameters.Add("store", SqlDbType.NVarChar).Value = "UPDATE";
                    cmd.Parameters.Add("mancc", SqlDbType.VarChar).Value = mancc;
                    cmd.Parameters.Add("ncc", SqlDbType.NVarChar).Value = tenncc;
                    cmd.Parameters.Add("dc", SqlDbType.NVarChar).Value = dc;

                    break;
            }
            cmd.ExecuteNonQuery();
        }
        public DataSet ShowADsImage(string strStore)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }
        public String getMaxSoDT(String strStore)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            string t =cmd.ExecuteScalar().ToString();
            return t;
        }
        public void HoaDon(string strStore, int sohd,DateTime ngaylaphd,string makh,string manv)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("sohd", SqlDbType.Int).Value = sohd;
            cmd.Parameters.Add("ngaylaphd", SqlDbType.Date).Value = ngaylaphd;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            cmd.Parameters.Add("manv", SqlDbType.VarChar).Value = manv;
            cmd.ExecuteNonQuery();
        }
        public void CTHD(string strStore,int sohd,string tensp,int sl)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("sohd", SqlDbType.Int).Value = sohd;
            cmd.Parameters.Add("tensp", SqlDbType.NVarChar).Value = tensp;
            cmd.Parameters.Add("sl", SqlDbType.Int).Value = sl;
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader SqlDataReaderThongTinDT(string strStore,string masp)
        {
            cmd = new SqlCommand(strStore, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("masp", SqlDbType.VarChar).Value = masp;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
