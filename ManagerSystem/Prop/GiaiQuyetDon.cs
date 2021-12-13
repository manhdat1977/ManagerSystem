using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class GiaiQuyetDon
    {
        public string MaSNDon { get; set; }
        public string dbo { get; set; }
        public int SDon { get; set; }
        public string LDon { get; set; }
        public DateTime NNDon { get; set; }
        public string NDDon { get; set; }
        public string BPYeuCau { get; set; }
        public string SoCVBP { get; set; }
        public string NgayLapCVBP { get; set; }
        public string NhomKN { get; set; }
        public string Qtt { get; set; }
        public string Ptt { get; set; }
        public string MNNghe { get; set; }
        public string MLTrinh { get; set; }
        public int CoDHN { get; set; }
        public string HDong { get; set; }
        public string KHang { get; set; }
        public string DChi { get; set; }
        public string GBieu { get; set; }
        public int DMuc { get; set; }
        public string MSThue { get; set; }
        public string Dot { get; set; }
        public string DThoaiKh { get; set; }
        public string MaNV { get; set; }
        public string MaNVKtra { get; set; }
        public int DMuc_HoNgheo { get; set; }
        public string TTin_Dso { get; set; }
        public string MaKQ { get; set; }
        public string KQGQuyet { get; set; }
        public string ThaiDoPhucVu { get; set; }
        public Boolean GQDHan { get; set; }
        public Boolean PhoiHopCacDVi { get; set; }
        public string YeuCauDeXuat { get; set; }
        public GiaiQuyetDon() { }

        public DataTable FindMaSoDon(GiaiQuyetDon objdkn)
        {
            ConnectDB condb = new ConnectDB();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_select_manhandon]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon", MaSNDon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public int UpdateYeuCauDeXuat(GiaiQuyetDon objdkn)
        {
            ConnectDB condb = new ConnectDB();
            SqlConnection conn = new SqlConnection();
            int updated = 0;
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_Update_YeuCauDexuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon", objdkn.MaSNDon);
                cmd.Parameters.AddWithValue("@YeuCauDeXuat", objdkn.YeuCauDeXuat);
                cmd.Parameters.AddWithValue("@ThaiDoPhucVu", objdkn.ThaiDoPhucVu);
                cmd.Parameters.AddWithValue("@PhoiHopCacDVi", objdkn.PhoiHopCacDVi);
                updated = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return updated;
        }
        public int UpdateKQGuyet(GiaiQuyetDon objdkn)
        {
            ConnectDB condb = new ConnectDB();
            SqlConnection conn = new SqlConnection();
            int updated = 0 ;
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_update_KQGQuyet", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon", MaSNDon);
                cmd.Parameters.AddWithValue("@TTin_DSo", TTin_Dso);
                cmd.Parameters.AddWithValue("@MaKQ", MaKQ);
                cmd.Parameters.AddWithValue("@KQGQuyet", KQGQuyet);
                cmd.Parameters.AddWithValue("@ThaiDoPhucVu", ThaiDoPhucVu);
                cmd.Parameters.AddWithValue("@PhoiHopCacDVi_", PhoiHopCacDVi);
                cmd.Parameters.AddWithValue("@GQDhanXepDon_", GQDHan);
                updated = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return updated;
        }
        public DataTable DonChuaGiaiQuyet()
        {
            ConnectDB condb = new ConnectDB();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_DonChuaGQ]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public DataTable LichSuKiemTra(GiaiQuyetDon objdkn)
        {
            ConnectDB condb = new ConnectDB();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_getInfo_KQGQD]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dbo", objdkn.dbo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }

    }
}