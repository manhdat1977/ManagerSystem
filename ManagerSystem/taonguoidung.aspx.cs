using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace ManagerSystem
{
    public partial class taonguoidung : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        SqlCommand cmd;
        EncryptionPass enc = new EncryptionPass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                success.Visible = false;
                error.Visible = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
          
            try
            {
                string insertUser = "insert into dbo.QuanLyNguoidung (Username,[Password],[Fullname],[Permission]) values('" + txtUser.Text + "','" + enc.mahoa(txtPass.Text) + "',N'" + txtHoTen.Text + "','" + dropPermission.Text + "')";
                conn = condb.connectSQL();
                conn.Open();
                cmd = new SqlCommand(insertUser, conn);
                cmd.ExecuteNonQuery();
                success.Visible = true;
                error.Visible = false;
                txtHoTen.Text = "";
                txtPass.Text = "";
                txtUser.Text = "";
                conn.Close();
            }
            catch
            {
                success.Visible = false;
                error.Visible = true;
            }

        }
    }
}