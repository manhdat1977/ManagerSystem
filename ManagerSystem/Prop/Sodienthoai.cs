using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ManagerSystem.Prop
{
    public class Sodienthoai
    {
        public int ID { get; set; }
        public string dba { get; set; }
        public string MaLT { get; set; }
        public string DChi { get; set; }
        public string SDT_ChuNha { get; set; }
        public string SDT_NguoiThue { get; set; }
        public string GhiChu { get; set; }
        public string MaNV { get; set; }
        public Sodienthoai() { }

        public int InsertSDT(Sodienthoai objsdt)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connect_CSKH();
            int inserted = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_insert_SDT]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dba", objsdt.dba);
                cmd.Parameters.AddWithValue("@MaLT", objsdt.MaLT);
                cmd.Parameters.AddWithValue("@DChi", objsdt.DChi);
                cmd.Parameters.AddWithValue("@SDT_ChuNha", objsdt.SDT_ChuNha);
                cmd.Parameters.AddWithValue("@SDT_NguoiThue", objsdt.SDT_NguoiThue);
                cmd.Parameters.AddWithValue("@GhiChu", objsdt.GhiChu);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                inserted = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return inserted;
        }
        public int DeleteSDT(Sodienthoai objsdt)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connect_CSKH();
            int deleted = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_DeleteSDT]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objsdt.ID);
                deleted = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return deleted;
        }
        public DataTable DT_List_SDT(Sodienthoai objsdt)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connect_CSKH();
            SqlCommand cmd = new SqlCommand("proc_DS_NhapSDT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", objsdt.MaNV);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}