using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
namespace ManagerSystem
{
    public partial class rpNhanDon : System.Web.UI.Page
    {
        ConnectDB connectDB = new ConnectDB();
        SoNhanDonBLL sonhandon = new SoNhanDonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpDonThu_KH rpnhandon = new rpDonThu_KH();
                rpnhandon.DataSource = sonhandon.LoadDataReport().Tables["v_DataNhanDon"];
            }
        }
        //public void LoadDataReport(string MaNhanDon)
        //{
        //    conn = connectDB.ConnectToBKDC();
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        conn.Open();
        //        cmd = new SqlCommand("sp_SelectSoNhanDon", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MaNhanDon", MaNhanDon);            
        //        da = new SqlDataAdapter(cmd);
        //        ds = new dsSoNhanDon();
        //        da.Fill(ds, "v_DataNhanDon");
        //        rpDonThuKH rpnhandon = new rpDonThuKH();           
        //        rprvNhanDon.Report = rpnhandon;
        //        rpnhandon.DataSource = ds.Tables["v_DataNhanDon"];
        //        //rpnhandon.Parameters["param"].Value = "KN";
        //        //rpnhandon.Parameters["param"].Visible = true;
        //    }
        //    conn.Close();
        //}
    }
}