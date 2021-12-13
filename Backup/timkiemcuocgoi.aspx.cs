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
    public partial class timkiemcuocgoi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        private void BindGrid()
        {
            string strConnString = "Server=192.168.23.66;Database=GhiAm;User Id=admin;Password=Kh0ngBi3t;";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select sdt,ten_nguoi_goi,thoi_gian_goi_toi,noi_dung_cuoc_goi,b.FileGhiAm,id from dbo.thongtin_cuocgoi a join dbo.GhiAm_Table b on a.FullKey = b.IdKey where sdt='"+txtSearch.Text+"'";
                    cmd.Connection = con;
                    con.Open();
                    grvListData.DataSource = cmd.ExecuteReader();
                    grvListData.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnTimCG_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}