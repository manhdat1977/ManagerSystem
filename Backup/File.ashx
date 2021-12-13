<%@ WebHandler Language="C#" Class="FileCS" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
public class FileCS : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["id"]);
        byte[] bytes;
        
        string strConnString = "Server=192.168.23.66;Database=GhiAm;User Id=admin;Password=Kh0ngBi3t;";
        string Ngaycapnhat;
        string Giocapnhat;
        string kenh;
        string loaicuocgoi;
        string sodienthoai;
        string mucdo;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "select Name, Data, ContentType from tblFiles where Id=@Id";
                cmd.CommandText = "select sdt,ten_nguoi_goi,thoi_gian_goi_toi,noi_dung_cuoc_goi,b.FileGhiAm,id from dbo.thongtin_cuocgoi a join dbo.GhiAm_Table b on a.FullKey = b.IdKey where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                bytes = (byte[])sdr["fileghiam"];
                //Ngaycapnhat = sdr["Ngaycapnhat"].ToString();
                //Giocapnhat = sdr["Giocapnhat"].ToString();
                //kenh = sdr["kenh"].ToString();
                //loaicuocgoi = sdr["loaicuocgoi"].ToString();
                sodienthoai = sdr["sdt"].ToString();
                //mucdo = sdr["mucdo"].ToString();
                con.Close();
            }
        }
        context.Response.Clear();
        context.Response.Buffer = true;
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + sodienthoai);
        context.Response.ContentType = sodienthoai;
        context.Response.BinaryWrite(bytes);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}