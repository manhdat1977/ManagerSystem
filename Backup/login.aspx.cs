using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
namespace ManagerSystem
{
    public partial class login : System.Web.UI.Page
    {
        ConnectDB dbconnect = new ConnectDB();
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlDataAdapter da;
        EncryptionPass enc = new EncryptionPass();
        DataSet ds;
        HttpCookie userinfo = new HttpCookie("userinfo");
        string permission;
        string grp;
        string fname;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            //if (String.IsNullOrEmpty(Request.QueryString["logoff"]) == false && Request.QueryString["logoff"].ToLowerInvariant() == "true")
            //{
            //    FormsAuthentication.SignOut();
            //}
            if (userinfo != null)
            {
                userinfo.Value = null;
                //Response.Cookies.Add(userinfo);
                Response.Cookies.Set(userinfo);
            }
        }
        public void countUser()
        {
            con = dbconnect.connectSQL();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                cmd = new SqlCommand("update quanlynguoidung set accesscounter = accesscounter + 1 where username = '" + txtUser.Value + "'", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                Response.Write("<script>alert('lỗi kết nối')</script>");
            }
            con.Close();

        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            enc = new EncryptionPass();
            string username = Request.Form["txtUser"];
            string password = Request.Form["txtPass"];
            con = dbconnect.connectSQL();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    string getUser = "select Username,[Password],Fullname fname,[Group] grp,Permission p from dbo.QuanLyNguoidung where Username ='" + txtUser.Value + "' and [Password]='" + enc.mahoa(txtPass.Value) + "'";
                    cmd = new SqlCommand(getUser, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds = new DataSet();
                    da.Fill(ds, "QuanLyNguoidung");
                    if (ds.Tables["QuanLyNguoidung"].Rows.Count > 0)
                    {

                        da.Fill(dt);
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (dr.Read())
                        {
                            permission = dr["p"].ToString();
                            fname = dr["fname"].ToString();
                        }
                        //Session["p"] = permission.ToString();
                        //Session["USER_ID"] = username.ToString();
                        //Session["Fullname"] = fname.ToString();
                        //Session["allow"] = true;
                        userinfo["p"] = permission.ToString();
                        userinfo["USER_ID"] = username.ToString();
                        userinfo["Fullname"] = fname.ToString();
                        countUser();
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng')</script>");
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('lỗi kết nối')</script>");
            }

            con.Close();
        }
    }
}
