using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class LoaiChungTu
    {
        public LoaiChungTu()
        { }
        public int ID { get; set; }
        public string _LoaiChungTu { get; set; }
        public string ChuThich { get; set; }

        public DataTable LoadLoaiChungTu()
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            DataTable dt = new DataTable();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_LoadLoaiChungtu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }

        public DataTable LoadChuThich(LoaiChungTu objLoaiChungTu)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            DataTable dt = new DataTable();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_LoadLoaiChungtu_ChuThich", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoaiChungTu", objLoaiChungTu._LoaiChungTu);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
    }
}