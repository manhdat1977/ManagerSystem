using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class SHKhau
    {
        public SHKhau()
        { }
        public string TTin { get; set; }
        public string MaCTDKDM { get; set; }
        public string Dbo { get; set; }
        public string QP { get; set; }
        public string MaLoaiSo { get; set; }
        public string SoCTDKDM { get; set; }
        public int TSNKhau { get; set; }
        public int NKDCap { get; set; }
        public string NgayHetHan { get; set; }
        public string SoPhong { get; set; }
        public string DThoai { get; set; }
        public string GhiChu { get; set; }
        public string MaNV { get; set; }
        public int ID { get; set; }
        public DataTable LoadSHK(SHKhau objSHKhau)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            DataTable dt = new DataTable();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_Find_SHKhau_DBo",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dbo", objSHKhau.Dbo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void DelelteSHK(SHKhau objSHK)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_Delete_SHK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objSHK.ID);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public DataTable LoadSoHKBySoCTDKDM(SHKhau objSHK)
        {
            {
                SqlConnection conn = new SqlConnection();
                ConnectDB connectDB = new ConnectDB();
                DataTable dt = new DataTable();
                conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("proc_LoadSoHKBySoCTDKDM", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoCTDKDM", objSHK.SoCTDKDM);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                conn.Close();
                return dt;
            }
        }
        public int InsertSHK(SHKhau objSHK)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            int inserted = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_Insert_SHK]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("MaLoaiSo", objSHK.MaLoaiSo);
                cmd.Parameters.AddWithValue("@Dbo", objSHK.Dbo);
                cmd.Parameters.AddWithValue("@QP", objSHK.QP);
                cmd.Parameters.AddWithValue("@SoCTDKDM", objSHK.SoCTDKDM);
                cmd.Parameters.AddWithValue("@TSNKhau", objSHK.TSNKhau);
                cmd.Parameters.AddWithValue("@NKDCap", objSHK.NKDCap);
                cmd.Parameters.AddWithValue("@NgayHetHan", objSHK.NgayHetHan);
                cmd.Parameters.AddWithValue("@SoPhong", objSHK.SoPhong);
                cmd.Parameters.AddWithValue("@DThoai", objSHK.DThoai);
                cmd.Parameters.AddWithValue("@GChu", objSHK.GhiChu);
                cmd.Parameters.AddWithValue("@MaNV", objSHK.MaNV);
                inserted = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return inserted;
        }
    }
}