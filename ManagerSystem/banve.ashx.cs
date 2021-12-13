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
    /// Summary description for banve
    /// </summary>
    public class banve : IHttpHandler
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB conDB = new ConnectDB();

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                String empno;
                Stream strm;
                if (context.Request.QueryString["id"] != null)
                    empno = Convert.ToString(context.Request.QueryString["id"].Replace(" ", ""));
                else
                    throw new ArgumentException("No parameter specified");
                context.Response.ContentType = "text/image";
                strm = ShowEmpImage(empno);               
                byte[] buffer;
                buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);
                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }
            }
            catch
            {
                var msg = string.Format(
                    @"<script language='javascript'>alert('Danh bạ này hiện chưa cập nhật bản vẽ')</script>");
                context.Response.Write(msg);
            }
            //context.Response.BinaryWrite(buffer);
        }
        public Stream ShowEmpImage(String banve)
        {

            conn = conDB.connectBanVe();
            string sql = "SELECT banve FROM BanVe_Table WHERE dbo = replace(@dbo,' ','')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@dbo", banve);
            conn.Open();
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