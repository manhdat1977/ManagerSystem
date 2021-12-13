using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ManagerSystem
{
    public partial class hethan : System.Web.UI.Page
    {
        ConnectDB connnectDB = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ExportGridView()
        {
            string attachment = "attachment; filename=Contacts.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_DS_HetHan.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void OK_Click(object sender, EventArgs e)
        {
            conn = connnectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if(conn.State !=ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_DS_HetHan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NCNhat",datepicker1.Text);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                grd_DS_HetHan.DataSource = ds;
                grd_DS_HetHan.DataBind();
                
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridView();
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            conn = connnectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_DS_HetHan_Search", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayHetHan", txtNgayHetHan.Text);
                cmd.Parameters.AddWithValue("@Dbo", txtDbo.Text);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                grd_DS_HetHan.DataSource = ds;
                grd_DS_HetHan.DataBind();

            }
        }

        protected void dropTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropTimKiem.Text == "Danh bạ")
            {
                iconDate.Visible = false;
                txtNgayHetHan.Visible = false;
                txtDbo.Visible = true;
                txtNgayHetHan.Text = "";
            }
            else if (dropTimKiem.Text == "Ngày hết hạn")
            {
                iconDate.Visible = true;
                txtNgayHetHan.Visible = true;
                txtDbo.Visible = false;
                txtDbo.Text = "";
            }
        }
    }
}