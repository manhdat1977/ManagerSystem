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
    public partial class inbiendong : System.Web.UI.Page
    {
        SqlConnection conn;
        ConnectDB conbd = new ConnectDB();
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            conn = conbd.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            cmd = new SqlCommand("proc_InBienDong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SBKeBD", txtSoBKe.Text);
            cmd.Parameters.AddWithValue("@HLucBD", txtKyIn.Text);
            cmd.Parameters.AddWithValue("@NguoiKy", dropNguoiKy.SelectedValue);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Columns.Count > 1)
            {
                //string FileFullPath = "~/file.txt";
                string FileFullPath = Server.MapPath("~/file.txt");
                StreamWriter sw = null;
                sw = new StreamWriter(FileFullPath, false);
                int ColumnCount = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    for (int ir = 0; ir < ColumnCount; ir++)
                    {
                        if (!Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write("\"" + dr[ir].ToString() + "\"");
                        }

                        if (Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write("\"" + "\"");
                        }

                        if (ir < ColumnCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                conn.Close();
                lblMess.Visible = false;
                string FileName = txtSoBKe.Text + "/" + txtKyIn.Text + ".txt"; // It's a file name displayed on downloaded file on client side.

                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/csv";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FileFullPath);
                response.Flush();
                response.End();
            }
            else
            {
                try
                {
                    lblMess.Text = dt.Rows[0][0].ToString();
                    lblMess.Visible = true;
                }
                catch
                {
                    lblMess.Text = "Bảng kê đã hủy check in";
                    lblMess.Visible = true;
                }
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //TextWriter writer = new StreamWriter(@"D:\file.txt");
            //for (int i = 0; i < grdLoadData.Rows.Count - 1; i++)
            //{
            //    //int t = grdLoadData.Rows[0].Cells.Count;
            //    for (int j = 0; j < grdLoadData.Rows[0].Cells.Count; j++)
            //    {
            //        writer.Write("\"" + grdLoadData.Rows[i].Cells[j].Text + "\"" + ",");
            //    }
            //    writer.Write("\n");
            //}
            //writer.Close();

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            conn = conbd.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            cmd = new SqlCommand("proc_List_In_Bien_dong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SBKeBD", txtSoBKe.Text);
            cmd.Parameters.AddWithValue("@HLucBD", txtKyIn.Text);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            grdLoadData.DataSource = dt;
            grdLoadData.DataBind();
            conn.Close();
        }

        public string GetSoNha(string diachifull)
        {
            string[] arrayDiachi = diachifull.Split(',');
            string sonha = arrayDiachi[0].ToString();
            return sonha;
        }

        public string GetTenDuong(string diachifull)
        {
            string[] arrayDiachi = diachifull.Split(',');
            string tenduong = arrayDiachi[1].ToString();
            return tenduong;
        }

        public void UpdateDiaChi()
        {
            conn = conbd.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            cmd = new SqlCommand("select danh_ba,duong FROM in_bien_dong WHERE (DUONG IS NOT NULL)", conn);
            SqlDataAdapter dadc = new SqlDataAdapter();
            dadc = new SqlDataAdapter(cmd);
            DataTable dtDiaChi = new DataTable();
            dadc.Fill(dtDiaChi);
            for (int i = 0; i < dtDiaChi.Rows.Count; i++)
            {
                string diachifull = dtDiaChi.Rows[i][1].ToString();
                string[] arrayDiaChi = diachifull.Split(',');
                if (arrayDiaChi.Length > 1)
                {
                    try
                    {
                        cmd = new SqlCommand("proc_UpdateDiaChi", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@So_nha", arrayDiaChi[0].ToString());
                        cmd.Parameters.AddWithValue("@Duong", arrayDiaChi[1].ToString());
                        cmd.Parameters.AddWithValue("@Ma_Quan", arrayDiaChi[2].Replace(" ", "").Substring(0, 2).ToString());
                        cmd.Parameters.AddWithValue("@Ma_Phuong", arrayDiaChi[2].Substring(3, 2).ToString());
                        cmd.Parameters.AddWithValue("@SBKeBD", txtSoBKe.Text);
                        cmd.Parameters.AddWithValue("@HLucBD", txtKyIn.Text);
                        cmd.Parameters.AddWithValue("@dbo", dtDiaChi.Rows[i][0].ToString());
                        cmd.ExecuteNonQuery();
                    }
                   catch
                    {
                        lblMess.Text = "Địa chỉ/Địa chỉ điều chỉnh lớn hơn 100 ký tự";
                        lblMess.Visible = true;
                    }
                }
                else
                {
                    continue;
                }
            }
            conn.Close();
        }

        protected void btnCapNhatDC_Click(object sender, EventArgs e)
        {
            UpdateDiaChi();
        }
    }
}