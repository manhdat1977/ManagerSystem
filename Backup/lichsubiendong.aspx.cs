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
    public partial class lichsubiendong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                grid_LichSuBienDong.DataSource = GetHistory(Request.QueryString["id"]);
                grid_LichSuBienDong.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Thời gian truy cập hết hạn. Vui lòng đăng nhập lại!')</script>");
                Response.Redirect("sonhandon.aspx");
            }
        }
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        protected DataTable GetHistory(string danhba)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            DataTable dt = new DataTable();
            if (conn.State != ConnectionState.Open)
            {
                cmd = new SqlCommand("select * from BKDC_Table1 where dbo='"+danhba+"' and SBKeBD is not null order by TTin desc", conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
    }
}