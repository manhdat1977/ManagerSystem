using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class SoDBo
    {
        public string DB { get; set; }
        public string HD { get; set; }
        public string KH { get; set; }
        public string DC1 { get; set; }
        public string DC2 { get; set; }
        public string DC { get; set; }
        public string GB { get; set; }
        public int DM { get; set; }
        public string QTT { get; set; }
        public string PTT { get; set; }
        public string MaLT { get; set; }
        public string VungDMA { get; set; }
        public string MaNVKtra { get; set; }
        public int DM_HoNgheo { get; set; }
        public string DThoai_SMS { get; set; }

        public SoDBo() { }
        SqlCommand cmd = new SqlCommand();
        public DataTable dtDbo(SoDBo objSoDbo)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[proc_Select_All_KH]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DBo", objSoDbo.DB);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        public int Update_SDT(SoDBo objSoDbo)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectBK();
            int i = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_Update_SDT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dbo", objSoDbo.DB);
                cmd.Parameters.AddWithValue("@DThoai_SMS", objSoDbo.DThoai_SMS);
                i = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return i;
        }
    }
}