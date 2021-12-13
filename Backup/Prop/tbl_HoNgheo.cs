using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ManagerSystem.Prop
{
    public class tbl_HoNgheo
    {
        public string DB { get; set; }
        public string KH { get; set; }
        public string DC { get; set; }
        public string GB { get; set; }
        public string LoaiSo { get; set; }
        public string MaSo { get; set; }
        public int TongNK { get; set; }
        public int NKDCap { get; set; }
        public string SoQD { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayNhap { get; set; }

        public tbl_HoNgheo() { }


        public int InsertHoNgheo(tbl_HoNgheo objHoNgheo)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.connect_CSKH();
            int inserted = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_insert_hongheo]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DB", objHoNgheo.DB);
                cmd.Parameters.AddWithValue("@KH", objHoNgheo.KH);
                cmd.Parameters.AddWithValue("@Dc", objHoNgheo.DC);
                cmd.Parameters.AddWithValue("@GB", objHoNgheo.GB);
                cmd.Parameters.AddWithValue("@LoaiSo", objHoNgheo.LoaiSo);
                cmd.Parameters.AddWithValue("@MaSo", objHoNgheo.MaSo);
                cmd.Parameters.AddWithValue("@TongNK", objHoNgheo.TongNK);
                cmd.Parameters.AddWithValue("@NKDCap", objHoNgheo.NKDCap);
                cmd.Parameters.AddWithValue("@SoQD", objHoNgheo.SoQD);
                cmd.Parameters.AddWithValue("@GhiChu", objHoNgheo.GhiChu);
                inserted = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return inserted;
        } 
    }
}