using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    public class DBConnect
    {
        public SqlConnection connect()
        {
            string constring = "";
            SqlConnection conn = new SqlConnection(constring);
            return conn;
        }
    }
}