using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                using (SqlConnection con = new SqlConnection("Server = 192.168.23.66; Database = Giai_Quyet_Don; User Id = admin; Password = Kh0ngBi3t;"))
                {
                    SqlCommand cmd = new SqlCommand("Update StatusImage set Image = '"+bytes+"' where ID = 2 ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Upload Successful";
                    hyperlink.Visible = true;
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                hyperlink.Visible = false;
            }
        }
    }
}
