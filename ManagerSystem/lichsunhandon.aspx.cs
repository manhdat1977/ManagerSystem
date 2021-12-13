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
    public partial class lichsunhandon : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        ConnectDB condb = new ConnectDB();
        SqlDataAdapter da;
        SoNhanDon nhandon;
        //ThamSo thamso = new ThamSo();

        protected void Page_Load(object sender, EventArgs e)
        {        
            try
            {
                gridLoadHistory.DataSource = GetHistory(Request.QueryString["id"]);
                gridLoadHistory.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Thời gian truy cập hết hạn. Vui lòng đăng nhập lại!')</script>");
                Response.Redirect("sonhandon.aspx");
            }
        }
        protected DataTable GetHistory(string danhba)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            DataTable dt = new DataTable();
            if (conn.State != ConnectionState.Open)
            {
                cmd = new SqlCommand("proc_LichSuDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dbo", danhba);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
       
        protected void gridLoadHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gridLoadHistory.DataKeys[e.RowIndex].Values[0]);

            this.DeleteData(id);
            //this.DeleteData(key);
        }

        protected void DeleteData(int key)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[Proc_Ins_Upt_Del]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID",key);
                cmd.Parameters.AddWithValue("@LoaiCapNhat", "DEL");
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            gridLoadHistory.DataSource = GetHistory(Request.QueryString["id"]);
            gridLoadHistory.DataBind();
        }

        protected void gridLoadHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(gridLoadHistory.DataKeys[rowIndex].Values[0]);
            //string group = gridLoadHistory.DataKeys[rowIndex].Values[1].ToString();
            if (e.CommandName == "Select")
            {
                Response.Redirect("sonhandon.aspx?id=" + id + "");
            }
        }

       
    }
}