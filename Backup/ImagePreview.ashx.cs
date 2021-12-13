using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    /// <summary>
    /// Summary description for ImagePreview
    /// </summary>
    public class ImagePreview : IHttpHandler
    {
        ConnectDB conDB = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        public void ProcessRequest(HttpContext context)
        {
            Int32 imgID;
            if (context.Request.QueryString["id"] != null)
                imgID = Convert.ToInt32(context.Request.QueryString["id"]);
            else
                imgID = 1;

            Stream strm = ShowAlbumImage(imgID);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }
        public Stream ShowAlbumImage(int imgID)
        {
            conn = conDB.connect_KhoHoSo();
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_SelectImg_ByDba", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AlbumID", imgID);
            object img = cmd.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}