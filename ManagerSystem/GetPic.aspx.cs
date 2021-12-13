using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace ManagerSystem
{
    public partial class GetPic : System.Web.UI.Page
    {
        ConnectDB conDB = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        private void Page_Load(object sender, System.EventArgs e)
        {
            //if (Page.IsPostBack) return;
            //int id = int.Parse(Request.QueryString["ID"]);
            //conn =  conDB.connect_KhoHoSo();
            //conn.Open();
            //string sql = "SELECT [BienBanKiemTraVien] FROM [tbl_HoSoKiemTra] WHERE ID = @ID";
            //SqlCommand cm = new SqlCommand(sql,conn);
            //cm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            //SqlDataReader dr = cm.ExecuteReader();
            //if (dr.Read())
            //{
            //    //Response.ContentType = (string)dr["[DBo]"];
            //    Response.ContentType = "image/jpeg";
            //    byte[] b = (byte[])dr["BienBanKiemTraVien"];
            //    Response.BinaryWrite(b);
            //}

            //conn.Close();
            if(!IsPostBack)
            {
                LoadImage();
            }
        }
        protected void tmp_Click(object sender, EventArgs e)
        {
            byte[] largePhoto = Convert.FromBase64String(Image1.ImageUrl.Substring(23));
            MemoryStream memoryStream = new MemoryStream(largePhoto, 0, largePhoto.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            string base64String = Convert.ToBase64String(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
            Image1.ImageUrl = "data:image/jpeg;base64," + base64String;
        }

        protected void btn_Zoom_Click(object sender, EventArgs e)
        {
            Image1.Width = Unit.Percentage(Convert.ToDouble(txt_Zoom.Value));
            Image1.Height = Unit.Percentage(Convert.ToDouble(txt_Zoom.Value));
        }
        public void LoadImage()
        {
            int id = int.Parse(Request.QueryString["ID"]);
            conn = conDB.connect_KhoHoSo();
            conn.Open();
            string sql = "SELECT [BienBanKiemTraVien] FROM [tbl_HoSoKiemTra] WHERE ID = @ID";
            SqlCommand cm = new SqlCommand(sql, conn);
            cm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            byte[] largePhoto = (byte[])cm.ExecuteScalar();
            conn.Close();
            string base64String = Convert.ToBase64String(largePhoto, 0, largePhoto.Length);
            Image1.ImageUrl = "data:image/jpeg;base64," + base64String;
        }
    }


    }
