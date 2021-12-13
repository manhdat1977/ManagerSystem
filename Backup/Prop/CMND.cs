using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class CMND
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB connDB = new ConnectDB();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public string MaCTDKDM { get; set; }
        public string SoCTDKDM { get; set; }
        public string LoaiCMND { get; set; }
        public string SoCMND { get; set; }
        public Boolean KhongCMND { get; set; }
        public string SoPhong { get; set; }
        public string GhiChu { get; set; }
        public string MaNV { get; set; }

        public CMND()
        { }

        public DataTable LoadListCMND(CMND objCMND)
        {
            conn = connDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_LoadCMND_BySHK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCTDKDM", objCMND.MaCTDKDM);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void DeleteCMND(CMND objCMND)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_Delete_CMND]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CMND", objCMND.SoCMND);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        } 
        public int InsertCMND(CMND objCMND)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            int inserted = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_Ins_CMND]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCTDKDM", objCMND.MaCTDKDM);
                cmd.Parameters.AddWithValue("@LoaiCMND", objCMND.LoaiCMND);
                cmd.Parameters.AddWithValue("@CMND", objCMND.SoCMND);
                cmd.Parameters.AddWithValue("@KhongCMND", objCMND.KhongCMND);
                cmd.Parameters.AddWithValue("@SoPhong", objCMND.SoPhong);
                cmd.Parameters.AddWithValue("@GhiChu", objCMND.GhiChu);
                cmd.Parameters.AddWithValue("@MaNV", objCMND.MaNV);
                inserted = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return inserted;
        } 
    }
}