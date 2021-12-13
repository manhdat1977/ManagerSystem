using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class DuyetHoSo
    {
        public int ID { get; set; }
        public string NguoiDuyet { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string MaSNDon { get; set; }
        public string NguoiChuyenHS { get; set; }
        public string NgayChuyenHS { get; set; }

        public DuyetHoSo() { }

        SqlConnection conn = new SqlConnection();
        ConnectDB conDB = new ConnectDB();
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;
        public DataTable GetAll_CheckFile(DuyetHoSo objDuyetHS)
        {
            conn = conDB.connect_CSKH();
            cmd = new SqlCommand("[proc_GetAll_CheckFile]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NguoiDuyet", objDuyetHS.NguoiDuyet);
            if(conn.State !=ConnectionState.Open)
            {
                conn.Open();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            else
            {

            }
            conn.Close();
            return dt;
        }
        public DataTable Filter_Dbo_CheckFile(DuyetHoSo objDuyetHS)
        {
            conn = conDB.connect_CSKH();
            conn.Open();
            cmd = new SqlCommand("proc_Filter_Dbo_CheckFile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dbo", objDuyetHS.MaSNDon);
            cmd.Parameters.AddWithValue("@nguoiduyet", objDuyetHS.NguoiDuyet);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable Filter_Dbo_UnCheckFile(DuyetHoSo objDuyetHS)
        {
            conn = conDB.connect_CSKH();
            conn.Open();
            cmd = new SqlCommand("proc_Filter_Dbo_UnCheckFile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dbo", objDuyetHS.MaSNDon);
            cmd.Parameters.AddWithValue("@nguoiduyet", objDuyetHS.NguoiDuyet);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable GetAll_UnCheckFile(DuyetHoSo objDuyetHS)
        {
            conn = conDB.connect_CSKH();
            cmd = new SqlCommand("proc_GetAll_UnCheckFile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NguoiDuyet", objDuyetHS.NguoiDuyet);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            else
            {

            }
            conn.Close();
            return dt;
        }
        public int InsertContentFile(DuyetHoSo objDuyetHS)
        {
            int inserted = 0;
            conn = conDB.connect_CSKH();
            cmd = new SqlCommand("proc_insert_DuyetHoSo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSNDon", objDuyetHS.MaSNDon);
            cmd.Parameters.AddWithValue("@NguoiChuyenHS", objDuyetHS.NguoiChuyenHS);
            cmd.Parameters.AddWithValue("@NguoiDuyet", objDuyetHS.NguoiDuyet);
            if(conn.State!=ConnectionState.Open)
            {
                conn.Open();
                inserted = cmd.ExecuteNonQuery();
            }
            else { }
            conn.Close();
            return inserted;
        }
        public DataTable ShowContent(DuyetHoSo objDuyetHS)
        {
            conn = conDB.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[proc_Find_DonDaDuyet]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon", objDuyetHS.MaSNDon);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            else
            {

            }
            conn.Close();
            return dt;

        }
        public int UpdateContentFile(DuyetHoSo objDuyetHS)
        {
            int updated = 0;
            conn = conDB.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[proc_GetAll_UpdateFile]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon", objDuyetHS.MaSNDon);
                cmd.Parameters.AddWithValue("@NoiDung", objDuyetHS.NoiDung);
                updated = cmd.ExecuteNonQuery();
            }
            else
            {

            }
            conn.Close();
            return updated;
        }
    } 
}