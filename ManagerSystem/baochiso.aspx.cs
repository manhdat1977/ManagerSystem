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
    public partial class baochiso : System.Web.UI.Page
    {
        ConnectDB connect = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable Get_Data_DBO()
        {
            conn = connect.connect_CSKH();
            conn.Open();
            cmd = new SqlCommand("proc_Select_All_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Dbo", txtDbo.Text);
            da = new SqlDataAdapter(cmd);
            DataTable dt_SoDba = new DataTable();
            da.Fill(dt_SoDba);
            conn.Close();
            return dt_SoDba;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtKH.Text = Get_Data_DBO().Rows[0][10].ToString();
            txtDchi1.Text = Get_Data_DBO().Rows[0][11].ToString();
            txtDchi2.Text = Get_Data_DBO().Rows[0][12].ToString();
            txtMLT.Text = Get_Data_DBO().Rows[0][28].ToString();
            lblAlert.Visible = false;
        }

        public int Insert_Data_CSMoi()
        {
            conn = connect.connect_CSKH();
            conn.Open();
            cmd = new SqlCommand("proc_Insert_CSM", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (!String.IsNullOrEmpty(txtDbo.Text))
            {
                cmd.Parameters.AddWithValue("@Dbo", txtDbo.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@KH", txtKH.Text);
                cmd.Parameters.AddWithValue("@Dchi1", txtDchi1.Text);
                cmd.Parameters.AddWithValue("@Dchi2", txtDchi2.Text);
                cmd.Parameters.AddWithValue("@MLT", txtMLT.Text);
                cmd.Parameters.AddWithValue("@Cso_moi", txtCSoMoi.Text);
                int record = cmd.ExecuteNonQuery();
                conn.Close();
                return record;
            }
            else
            {
                return 0;
            }
            
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (Insert_Data_CSMoi() > 0)
            {
                txtCSoMoi.Text = "";
                txtDchi1.Text = "";
                txtDchi2.Text = "";
                txtKH.Text = "";
                txtMLT.Text = "";
                txtSDT.Text = "";
                lblAlert.Text = "Thêm mới thành công!!!";
                lblAlert.Visible = true;
            }
            else
            {
                lblAlert.Text = "Thêm mới thất bại!!!";
                lblAlert.Visible = true;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string tungay = this.Request.Form["datepicker"];
            string denngay = this.Request.Form["datepicker1"];
            conn = connect.connect_CSKH();
            conn.Open();
            cmd = new SqlCommand("proc_Filter_List_BaoChiSo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@from", tungay);
            cmd.Parameters.AddWithValue("@to",denngay);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            rp_BaoChiSo rp = new rp_BaoChiSo();
            rprv_BaoChiSo.Report = rp;
            rp.DataSource = dt;
            conn.Close();
            rp_BaoChiSo.topic = "TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay;
            rprv_BaoChiSo.Visible = true;
            ReportToolbar1.Visible = true;
        }

    }
}