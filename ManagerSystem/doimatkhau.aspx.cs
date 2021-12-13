using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    public partial class doimatkhau : System.Web.UI.Page
    {
        EncryptionPass enc = new EncryptionPass();
        ConnectDB conDB = new ConnectDB();
        SqlCommand cmd;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_DoiMK_Click(object sender, EventArgs e)
        {
            try{
            conn = conDB.connectSQL();
            conn.Open();
            cmd = new SqlCommand("update dbo.QuanLyNguoidung set [Password] = '"+enc.mahoa(txtDoiMK.Text)+"' where Username = '"+Session["USER_ID"].ToString()+"'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Đổi mật khẩu thành công')</script>");
            //Response.Redirect("login.aspx");
            }
            catch
            {
                Response.Write("<script>alert('Lỗi! Không thể thay đổi mật khẩu')</script>");
            }
        }
    }
}