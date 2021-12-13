using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
namespace ManagerSystem
{
    public partial class lichdulieu : System.Web.UI.Page
    {
        ConnectDB conDB = new ConnectDB();
        SqlConnection conn;
        SqlCommand cmd;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                try
                {
                    if (Info()["p"].ToString() == "Admin")
                    {
                        upload.Visible = true;
                    }
                    else
                    {
                        upload.Visible = false;
                    }
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
            }
            ac.CapNhatTruycap(9, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        private void BindGrid()
        {
            conn = conDB.connectSQL();
            conn.Open();
            cmd = new SqlCommand("select Id, Name from FilePDF order by Name", conn);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            conn.Close();

        }
       
        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    conn = conDB.connectSQL();
                    conn.Open();
                    string query = "insert into FilePDF values (@Name, @ContentType, @Data)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", filename);
                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.ExecuteNonQuery();
                    conn.Close();                   
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}