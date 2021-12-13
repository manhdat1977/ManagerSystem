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
    public partial class danhsachdon : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        ConnectDB conDB = new ConnectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDanhSach();
            }
        }
        private HttpCookie Cookies()
        {
            HttpCookie reqCookies = Request.Cookies["userinfo"];
            return reqCookies;
        }
        public void LoadDanhSach()
        {
            conn = conDB.connectSQL_Giai_Quyet_Don();
            conn.Open();
            if (Cookies()["p"].ToString() == "Admin" || Cookies()["p"].ToString() == "TT" || Cookies()["p"].ToString() == "TP" || Cookies()["p"].ToString() == "NVVP-KT" || Cookies()["p"].ToString() == "PBD")
            {
                cmd = new SqlCommand("select * from dbo.Thong_Tin_GQDon_Table where NTHSo between convert(date,GETDATE(),103) and convert(date,GETDATE(),103) order by SDon", conn);
                cmd.ExecuteNonQuery();
            }
            else if (Cookies()["p"].ToString() == "KTV")
            {
                cmd = new SqlCommand("select * from dbo.Thong_Tin_GQDon_Table where NTHSo between convert(date,GETDATE(),103) and convert(date,GETDATE(),103) and manvktra='" + Cookies()["USER_ID"].ToString() + "' order by SDon", conn);
                cmd.ExecuteNonQuery();
            }
            else if (Cookies()["p"].ToString() == "NVVP")
            {
                cmd = new SqlCommand("select * from dbo.Thong_Tin_GQDon_Table where NTHSo between convert(date,GETDATE(),103) and convert(date,GETDATE(),103) and manvktra='" + Cookies()["USER_ID"].ToString() + "'order by SDon", conn);
                cmd.ExecuteNonQuery();
            }
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gridDanhSach.DataSource = dt;
            gridDanhSach.DataBind();
            conn.Close();
        }

        protected void gridDanhSach_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gridDanhSach.DataKeys[index].Values[0]);
            if (e.CommandName.Equals("Sua"))
            {
                Response.Write("<script>");
                Response.Write("window.open('capnhatdonthu.aspx?id=" + id + "','_blank')");
                Response.Write("</script>");
            }
            else if (e.CommandName.Equals("Xoa"))
            {
                conn = conDB.connectSQL_Giai_Quyet_Don();
                conn.Open();
                cmd = new SqlCommand("delete form Thong_Tin_GQDon_Table where id='" + id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}