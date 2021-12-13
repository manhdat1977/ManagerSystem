using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class HoSoKiemTra
    {
        public string MaSNDon { get; set; }
        public string Dbo { get; set; }
        public string NgayCapNhat { get; set; }
        public byte BienBanKiemTraVien { get; set; }

        public HoSoKiemTra() { }

        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllTable(HoSoKiemTra objhskt)
        {
            conn = condb.connect_KhoHoSo();
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_select_image_byMSNDon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MSNdon", MaSNDon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}