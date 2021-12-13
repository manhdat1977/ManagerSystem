using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerSystem
{
    public partial class exportfiletobilling : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB db = new ConnectDB();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DataTable LoadDataToDataTable(string cmdstore)
        {
            conn = db.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand(cmdstore, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //gridData.DataSource = dt;
                //gridData.DataBind();
                conn.Close();
            }
            return dt;
        }
        public void ExportToText(string cmd)
        {
            if (LoadDataToDataTable(cmd).Rows.Count > 0 && LoadDataToDataTable(cmd).Columns.Count > 1)
            {
                //string FileFullPath = "~/file.txt";
                string FileFullPath = Server.MapPath("~/file.txt");
                StreamWriter sw = null;
                sw = new StreamWriter(FileFullPath, false);
                int ColumnCount = LoadDataToDataTable(cmd).Columns.Count;
                List<string> headerCols = new List<string>();
                for (int j = 0; j < LoadDataToDataTable(cmd).Columns.Count - 1; j++)
                {
                    headerCols.Add(LoadDataToDataTable(cmd).Columns[j].ColumnName);
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Join(",", headerCols));
                sw.Write(builder.ToString());
                foreach (DataRow dr in LoadDataToDataTable(cmd).Rows)
                {
                    for (int ir = 0; ir < ColumnCount; ir++)
                    {
                        if (!Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write(dr[ir].ToString());
                        }

                        if (Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write("");
                        }

                        if (ir < ColumnCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                //conn.Close();
                string FileName = "GD" + DateTime.Now.Year.ToString().Substring(2, 2) + "" + DateTime.Now.Month + ".txt"; // It's a file name displayed on downloaded file on client side.

                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/csv";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FileFullPath);
                response.Flush();
                response.End();
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToText("[SelectListToExport_Insert_CCCD]");
        }

        protected void btnViewData_Click(object sender, EventArgs e)
        {
            gridData.DataSource = LoadDataToDataTable("[SelectListToExport_Insert_CCCD]");
            gridData.DataBind();
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = db.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_UpdateUnCheckin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            ExportToText("[SelectListToExport_Delete_CCCD]");
        }

        protected void btnViewListDelete_Click(object sender, EventArgs e)
        {
            grdListDelete.DataSource = LoadDataToDataTable("[SelectListToExport_Delete_CCCD]");
            grdListDelete.DataBind();
        }

        protected void btnHuyCheckIn_Click(object sender, EventArgs e)
        {
            conn = db.connect_CSKH();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[proc_UpdateUnCheckin_Delete]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}