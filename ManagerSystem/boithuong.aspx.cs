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
    public partial class boithuong : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataAdapter da;
        ConnectDB condb = new ConnectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadToDropdown(dropMaBoiThuong, "select mabt,chuthich from [dbo].[LyDoBoiThuong_Table] order by charindex('.',chuthich)-1,ChuThich", "mabt", "chuthich","BOITHUONG");
                LoadToDropdown(dropLoaiDon, "select LDon,ChuThich from [dbo].[Loai_Don_Table] order by ChuThich", "Ldon", "ldon", "Bang_Ke_Dieu_Chinh");
            }    
        }

        private void LoadToDropdown(DropDownList dropdownlist, string command, string datavalue, string datatextfield,string server)
        {
            conn = condb.ConnectToServer66(server);
            if(conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand(command, conn);
                dropdownlist.DataSource = cmd.ExecuteReader();
                dropdownlist.DataTextField = datatextfield;
                dropdownlist.DataValueField = datavalue;
                dropdownlist.DataBind();
            }
            conn.Close();
        }

    }
}