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
                cmd = new SqlCommand("select * from BKDC_Table1 where dbo='"+danhba+"' order by TTin desc", conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }

        protected void grid_LichSuBienDong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(grid_LichSuBienDong.DataKeys[rowIndex].Values[0]);
            //string group = gridLoadHistory.DataKeys[rowIndex].Values[1].ToString();
            if (e.CommandName == "Select")
            {
                Response.Redirect("capnhatbiendong.aspx?id=" + id + "");
            }
        }


        private void DeleteData(int key)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[Del_BKDC]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", key);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            grid_LichSuBienDong.DataSource = GetHistory(Request.QueryString["id"]);
            grid_LichSuBienDong.DataBind();

        }

        protected void grid_LichSuBienDong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grid_LichSuBienDong.DataKeys[e.RowIndex].Values[0]);

            this.DeleteData(id);
        }
    }
}