using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    public partial class quanlynguoidung : System.Web.UI.Page
    {
        ConnectDB dbconnect = new ConnectDB();
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUser();
        }
        public void loadUser()
        {
            con = dbconnect.connectSQL();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            }
            catch
            {
                Response.Write("<script>alert('lỗi kết nối')</script>");
            }
            cmd = new SqlCommand("select fullname, username, department, accesscounter from QuanLyNguoidung", con);
            grv_user.DataSource = cmd.ExecuteReader();
            grv_user.DataBind();
            con.Close();
        }
    }
}