using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    public class access
    {
        ConnectDB connect = new ConnectDB();
        SqlConnection conn;
        SqlCommand cmd;
        public void CapNhatTruycap(int id_truy_cap, string manv)
        {
            conn = connect.connectSQL();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                string sql_capnhat = "insert into luottruycap values ('"+id_truy_cap+"','" + manv + "',getdate())";
                cmd = new SqlCommand(sql_capnhat, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}