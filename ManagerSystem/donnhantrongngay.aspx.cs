using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerSystem
{
    public partial class donnhantrongngay : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB db = new ConnectDB();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Tim_Click(object sender, EventArgs e)
        {
            gridData.DataSource = GetAllByDate();
            gridData.DataBind();
        }
        //public DataTable GetAllByFilter()
        //{
            //DataTable _dt = GetAllByDate().AsEnumerable()
            //     .Where(row => row.Field<String>("MaNV") == txtSearch.Text)
            //     .OrderBy(row => row.Field<String>("Sdon"))
            //     .CopyToDataTable();
            //return _dt;

        //}
        public DataTable GetAllByDate()
        {
            conn = db.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("procGetDataByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@from", datepicker.Text);
                cmd.Parameters.AddWithValue("@to", datepicker1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                gridData.DataSource = dt;
                gridData.DataBind();
            }
            conn.Close();
            return dt;
        }

        protected void txtFindByName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {

                DataView dtv = new DataView(GetAllByDate());
                dtv.RowFilter = "MaNV like '%" + txtSearch.Text + "%'";
                gridData.DataSource = dtv.ToTable();
                gridData.DataBind();

            }
        }
    }
}