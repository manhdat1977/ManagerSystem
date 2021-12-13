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
    public partial class thongkeSOT : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectDB condb = new ConnectDB();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
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
            gridThongKe.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridView();
        }
        protected void btnThongKe_Click(object sender, EventArgs e)
        {
            conn = condb.ConntectToSUAONGTRONG();
            conn.Open();
            if (dropLoaiThongKe.Text == "Chưa hoàn công")
            {
                cmd = new SqlCommand("proc_Chua_Hoan_Cong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tungay", datepicker.Text);
                cmd.Parameters.AddWithValue("@denngay", datepicker1.Text);
                //cmd = new SqlCommand("select * from dbo.ThongTinSuaChua where hoancong is null and convert(date,ThoiGianNhanHS,103) between convert(date,'"+tungay.value+"',103) and convert(date,'"+denngay.ToString()+"',103)", conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                gridThongKe.DataSource = dt;
                gridThongKe.DataBind();
            }
            else if (dropLoaiThongKe.Text == "Hoàn công")
            {
                if (dropFindTieuChi.Text != "Chọn loại tiêu chí")
                {
                    cmd = new SqlCommand("proc_Hoan_Cong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tungay", datepicker.Text);
                    cmd.Parameters.AddWithValue("@denngay", datepicker1.Text);
                    cmd.Parameters.AddWithValue("@tieuchi", dropFindTieuChi.Text);
                    //cmd = new SqlCommand("select * from dbo.ThongTinSuaChua where hoancong = 'true' and convert(date,ThoiGianNhanHS,103) between convert(date,'" + tungay.ToString() + "',103) and convert(date,'" + denngay.ToString() + "',103)", conn);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    gridThongKe.DataSource = dt;
                    gridThongKe.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Bạn chưa chọn tiêu chí')</script>");
                }

            }
            else if (dropLoaiThongKe.Text == "Tất cả")
            {
                cmd = new SqlCommand("[proc_Tat_Ca]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tungay", datepicker.Text);
                cmd.Parameters.AddWithValue("@denngay", datepicker1.Text);
                //cmd = new SqlCommand("select * from dbo.ThongTinSuaChua where hoancong = 'true' and convert(date,ThoiGianNhanHS,103) between convert(date,'" + tungay.ToString() + "',103) and convert(date,'" + denngay.ToString() + "',103)", conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                gridThongKe.DataSource = dt;
                gridThongKe.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Vui lòng chọn loại thống kê')</script>");
            }
            conn.Close();
        }
    }
}