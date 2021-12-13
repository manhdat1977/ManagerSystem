using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerSystem
{
    public partial class hoadondieuchinh : System.Web.UI.Page
    {
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            ac.CapNhatTruycap(5, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            GetAll();
        }
        public void GetAll()
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB db = new ConnectDB();
            conn = db.connectSQL_DieuChinhHoaDon();
            if(conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllHoaDonDieuChinh",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sodanhba", txtSearch.Text);
                SqlDataAdapter da;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_HoaDonDieuChinh.DataSource = dt;
                grid_HoaDonDieuChinh.DataBind();
                grid_HoaDonDieuChinh.Visible = true;
            }
            conn.Close();
        }
    }
}