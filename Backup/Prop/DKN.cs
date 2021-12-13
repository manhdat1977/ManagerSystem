using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class DKN
    {
        public string danhba { get; set; }
        public string loaidon { get; set; }
        public string ngaynhandon { get; set; }
        public string noidung { get; set; }
        public string hieuluc { get; set; }
        public string phongbandoi { get; set; }
        public string sovanban { get; set; }
        public string ngaylapcv {get;set;}
        public string nhomthongtin { get; set; }
        public string quan { get; set; }
        public string phuong { get; set; }
        public string khachhang { get; set; }
        public string diachi { get; set; }
        public string ghichu { get; set; }
        public Boolean hoadon { get; set; }
        public Boolean HDThueNha { get; set; }
        public Boolean GDKKD { get; set; }
        public Boolean HKKT3 { get; set; }
        public Boolean STTru { get; set; }   
        public Boolean giaycapsonha { get; set; }
        public Boolean xacnhansonha { get; set; }
        public Boolean giayungthuan { get; set; }
        public Boolean masothue { get; set; }
        public string manhanvien { get; set; }
        public string dienthoai1 { get; set; }
        public string manhanvienkiemtra { get; set; }
        public Boolean ganmoi { get; set; }
        public Boolean khongkiemtra { get; set; }
        public Boolean sms { get; set; }
        public string xacnhanno { get; set; }
        public int sodon { get; set; }
        public int ID { get; set; }

        public DKN()
        { }
        public DataTable FindMaSNDon(DKN objDKN)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_TimDKN_MSNDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dbo", objDKN.danhba);
                cmd.Parameters.AddWithValue("@NNDon", objDKN.ngaynhandon);
                cmd.Parameters.AddWithValue("@SDon", objDKN.sodon);
                cmd.Parameters.AddWithValue("@LDon", objDKN.loaidon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);    
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}
