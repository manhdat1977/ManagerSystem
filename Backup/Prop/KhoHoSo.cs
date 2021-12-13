using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class KhoHoSo
    {
        public int ID { get; set; }
        public string DanhBa { get; set; }
        public string LoaiHoSo { get; set; }
        public byte Img_HoSo { get; set; }
        public string ContentType { get; set; }
        public KhoHoSo()
        { }

        public DataTable GetDataByDanhBa(KhoHoSo objKhohoso)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectKhoHoSo();
            if (conn.State != ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("proc_SelectKho_ByDanhba", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DanhBa", objKhohoso.DanhBa);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        //public SqlDataReader GetDataByID(KhoHoSo objKhohoso)
        //{
        //    //DataTable dt = new DataTable();
        //    SqlConnection conn = new SqlConnection();
        //    ConnectDB connectDB = new ConnectDB();
        //    SqlDataReader dr;
        //    conn = connectDB.ConntectToKhoHoSo();
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        SqlCommand cmd = new SqlCommand("proc_SelectKho_ByID", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ID", objKhohoso.ID);
        //        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //       // da.Fill(dt);
        //        dr = cmd.ExecuteReader();
        //    }
        //    conn.Close();
        //    return dr;
        //}
        public DataTable GetAllKhoHoSo()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connectKhoHoSo();
            if (conn.State != ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("proc_SelectAllKho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
    }
}