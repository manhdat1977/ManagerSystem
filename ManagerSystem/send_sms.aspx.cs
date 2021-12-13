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

        const string binhthanh = "2401,2402,2403,2404,2405,2406,2407,2411,2412,2413,2414,2415,2417,2419,2421,2422,2425,2426,2427,2428";
        const string phunhuan = "2201,2202,2203,2204,2205,2207,2208,2209,2210,2211,2212,2213,2214,2215,2217";
        const string quan3 = "0312,0313,0314";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadDataToGrid()
        {
            //gridData.DataSource = DT_SMS().Rows.Count;
            //gridData.DataBind();
            DataTable dt_ = DT_SMS().AsEnumerable()
                            .GroupBy(r => new { Col1 = r["vungdma"], Col2 = r["qtt"],col3 = r["ptt"] })
                            .Select(g => g.OrderBy(r => r["vungdma"]).First())
                            .CopyToDataTable();
            gridData.DataSource = dt_;
            gridData.DataBind();
        }
        public string KhuVuc(string dieukien)
        {
            string rs = "";
            string[] tachchuoi = dieukien.Split(',');
            if (tachchuoi.Length < 0)
            {
                return dieukien;
            }
            else
            {
                for (int i = 0; i < tachchuoi.Length; i++)
                {
                    if (tachchuoi[i].Length == 2)
                    {
                        if (tachchuoi[i].ToString() == "24")
                        {
                            dieukien = dieukien + "," + binhthanh;
                        }
                        else if (tachchuoi[i].ToString() == "22")
                        {
                            dieukien = dieukien + "," + phunhuan;
                        }
                        else if (tachchuoi[i].ToString() == "03")
                        {
                            dieukien = dieukien + "," + quan3;
                        }
                    }
                }
                rs = dieukien.Replace(",", "','");
            }
            return rs;
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
                if (dropLoaiKhuVuc.SelectedValue == "VungDMA")
                {
                    cmd.Parameters.AddWithValue("@QP", "");
                    cmd.Parameters.AddWithValue("@DMA", KhuVuc(txtKhuVuc.Value));
                }
                else if (dropLoaiKhuVuc.SelectedValue == "QuanPhuong")
                {
                    cmd.Parameters.AddWithValue("@QP", KhuVuc(txtKhuVuc.Value));
                    cmd.Parameters.AddWithValue("@DMA", "");
                }
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
            wb.Worksheets.Add(DT_SMS(), "SMS");
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