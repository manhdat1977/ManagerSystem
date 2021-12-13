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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    HttpCookie reqCookies = Request.Cookies["userinfo"];
                    //lblname.Text = Session["TenNhanVien"].ToString();
                    txtUsername.Text = reqCookies["Fullname"].ToString();
                    lblSoDon.Text = SoDonMoi(reqCookies["USER_ID"].ToString()).ToString();
                    lblThongbao.Text = "Bạn có " + SoDonMoi(reqCookies["USER_ID"].ToString()).ToString() + " đơn mới";
                }
                catch
                {
                    Response.Write("<script>alert('Phiên làm việc hết hạn. Vui lòng đăng nhập lại!')</script>");
                    Response.Redirect("login.aspx");
                }
            }
        }
        public int SoDonMoi(string MaNV)
        {
            ConnectDB connect = new ConnectDB();
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            conn = connect.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            string sql = "select * from dbo.DKN_Table1 where XuLy is null and convert(date,TTin,1111) >= '2018/11/01' and MaNVKTra='"+MaNV+"' and (LDon='KN' or LDon='OL') and KhongKiemTra='False' and NhomKT is null";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt); 
            int i = 0;
            conn.Close();
            return i = dt.Rows.Count;
        }
    }
}