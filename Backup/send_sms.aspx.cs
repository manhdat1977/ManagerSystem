using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;

namespace ManagerSystem
{
    public partial class send_sms : System.Web.UI.Page
    {
        SqlCommand cmd;
        ConnectDB conDB = new ConnectDB();


        SqlConnection conn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadDataToGrid()
        {
            gridData.DataSource = DT_SMS();
            gridData.DataBind();
        }
        public DataTable DT_SMS()
        {
            conn = conDB.connectDMA();
            DataTable dt = new DataTable();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[proc_send_sms]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QP", "");
                cmd.Parameters.AddWithValue("@DMA", txtKhuVuc.Value);
                cmd.Parameters.AddWithValue("@ThoiGian_CupNuoc", txtNoiDung.Value);
                cmd.Parameters.AddWithValue("@Table", txtHoaDon.Value);
                //cmd = new SqlCommand("select khang,vungdma from hd_42021 where VungDMA='BT1402'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }
        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(DT_SMS(),"SMS");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=FileTemp.xlsx");
            ///
            MemoryStream MyMemoryStream = new MemoryStream();
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        public static void WriteAttachment(string FileName, string FileType, string content)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.ContentType = FileType;
            Response.Write(content);
            Response.End();
        }
    }
}