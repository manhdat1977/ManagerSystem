using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace ManagerSystem
{
    public class ConnectDB
    {
     
        public SqlConnection connectHD()
        {
            //string constring = "Data Source=192.168.23.36;Network Library=DBMSSOCN;Initial Catalog=HOADON; User ID=dat; Password=135790";
            string constring = "Data Source=192.168.23.80;Network Library=DBMSSOCN;Initial Catalog=EINVOICE_PAY_GIADINH_Golive; User ID=sa; Password=123456";
            SqlConnection connect = new SqlConnection(constring);
            return connect;
        }
        public SqlConnection connectSQL_DieuChinhHoaDon()
        {
            string constring = "Server=192.168.23.66;Database=DieuChinhHoaDon;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection ConnectToServer66(string database)
        {
            string constring = "Server=192.168.23.66;Database="+database+";User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection connect = new SqlConnection(constring);
            return connect;
        }
        public SqlConnection connectKhoHoSo()
        {
            string constring = "Server=192.168.23.66;Database=KhoHoSo;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectDMA()
        {
            string constring = "Server=192.168.23.66;Database=PhanTichDMA;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectCatHuy()
        {
            string constring = "Server=192.168.23.66;Database=CATHUY;User Id=admin;Password=kh0ngbi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectGhiAm()
        {
            //string constring = "Server=CNGIADINH-KD01;Database=KiemTon;User Id=huuloc;Password=huuloc123456;";
            string constring = "Server=192.168.23.66;Database=GhiAm;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public OleDbConnection connectIndex()
        { 
            string constring =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\192.168.23.15\c$\Mdr\IndexMain.mdb;";
            //string constring =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Popup.mdb;";
            OleDbConnection conn = new OleDbConnection(constring);
            return conn;
        }
        public SqlConnection connectChiSo()
        {
            //string constring = "Server=CNGIADINH-KD01;Database=KiemTon;User Id=huuloc;Password=huuloc123456;";
            string constring = "Server=192.168.23.66;Database=KiemTon;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectBK()
        {
            string constring = "Server=192.168.23.66;Database=HoaDon;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectBanVe()
        {
            string constring = "Server=192.168.23.66;Database=Scan_HS;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }

        public SqlConnection connectSQL()
        {
            string constring = "Server=192.168.23.66;Database=ManagerSystem;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectSQL_Bang_Ke_Dieu_Chinh()
        {
            string constring = "Server=192.168.23.66;Database=Bang_Ke_Dieu_Chinh;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connectSQL_Giai_Quyet_Don()
        {
            string constring = "Server=192.168.23.66;Database=Giai_Quyet_Don;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connect_CallCenter()
        {
            string constring = "Server=192.168.23.5;Database=CallCenter;User Id=sa;Password=123giadinh!@#;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connect_DQLDHN()
        {
            string constring = @"Server=192.168.23.80;Database=L:\DATABASE.MDF;User Id=sa;Password=123456;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connect_KhoHoSo()
        {
            string constring = "Server=192.168.23.66;Database=KhoHoSo;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection connect_CSKH()
        {
            string constring = "Server=192.168.23.66;Database=ChamSocKhachHang;User Id=admin;Password=Kh0ngBi3t;";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
        public SqlConnection ConntectToQLTB()
        {
            SqlConnection conn = new SqlConnection("Server=192.168.23.66;Database=QuanLyThietBi;User Id=admin;Password=Kh0ngBi3t;");
            return conn;
        }
        public SqlConnection ConntectToSUAONGTRONG()
        {
            SqlConnection conn = new SqlConnection("Server=192.168.23.66;Database=SUAONGTRONG;User Id=admin;Password=Kh0ngBi3t;");
            return conn;
        }
       
    }
}