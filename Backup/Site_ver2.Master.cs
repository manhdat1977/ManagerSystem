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
    public partial class Site_ver2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    HttpCookie reqCookies = Request.Cookies["userinfo"];
                    //lblname.Text = Session["TenNhanVien"].ToString();
                    txtUsername.Text = reqCookies["USER_ID"].ToString().ToUpper();
                    lblSoDon.Text = SoDonMoi(reqCookies["USER_ID"].ToString()).ToString();
                    lblThongbao.Text = "Bạn có " + SoDonMoi(reqCookies["USER_ID"].ToString()).ToString() + " đơn mới";
                    if (reqCookies["p"].ToString() == "KTV")
                    {
                        mn_capnhatdonthu.Visible = true;
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_dontrongngay.Visible = true;
                        mn_hosokiemtra.Visible = true;
                        mn_nangsuatktv.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_vungdma.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "NVVP-CSKH")
                    {
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_thongkeloaidon.Visible = true;
                        mn_inbiendong.Visible = true;
                        mn_taoyeucausot.Visible = true;
                        mn_thongkeSOT.Visible = true;
                        mn_capnhatsuachua.Visible = true;
                        mn_hethan.Visible = true;
                        mn_capnhatbiendong.Visible = true;
                        mn_capnhatsdt.Visible = true;
                        mn_importimage.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "NVVP-KT")
                    {
                        mn_capnhatdonthu.Visible = true;
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_dontrongngay.Visible = true;
                        mn_hosokiemtra.Visible = true;
                        mn_nangsuatktv.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_vungdma.Visible = true;
                        mn_giaiquyetdon.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "TT-CSKH")
                    {
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_inbiendong.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_thongkeloaidon.Visible = true;
                        mn_taoyeucausot.Visible = true;
                        mn_hethan.Visible = true;
                        mn_capnhatbiendong.Visible = true;
                        mn_capnhatsdt.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "TT-KT")
                    {
                        mn_capnhatdonthu.Visible = true;
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_dontrongngay.Visible = true;
                        mn_duyethoso.Visible = true;
                        mn_giaiquyetdon.Visible = true;
                        mn_hosokiemtra.Visible = true;
                        mn_nangsuatktv.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_vungdma.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "TP-PP")
                    {
                        mn_capnhatdonthu.Visible = true;
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_dontrongngay.Visible = true;
                        mn_duyethoso.Visible = true;
                        mn_giaiquyetdon.Visible = true;
                        mn_hosokiemtra.Visible = true;
                        mn_nangsuatktv.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_vungdma.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "PBD")
                    {

                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_thongkeSOT.Visible = true;
                        mn_capnhatsuachua.Visible = true;
                    }
                    else if (reqCookies["p"].ToString() == "Admin")
                    {
                        mn_capnhatdonthu.Visible = true;
                        mn_cathuy.Visible = true;
                        mn_cattam.Visible = true;
                        mn_doimatkhau.Visible = true;
                        mn_dontrongngay.Visible = true;
                        mn_duyethoso.Visible = true;
                        mn_giaiquyetdon.Visible = true;
                        mn_hosokiemtra.Visible = true;
                        mn_inbiendong.Visible = true;
                        mn_nangsuatktv.Visible = true;
                        mn_sonhandon.Visible = true;
                        mn_taonguoidung.Visible = true;
                        mn_thongkeloaidon.Visible = true;
                        mn_vungdma.Visible = true;
                        mn_taoyeucausot.Visible = true;
                        mn_thongkeSOT.Visible = true;
                        mn_capnhatsuachua.Visible = true;
                        mn_hethan.Visible = true;
                        mn_capnhatbiendong.Visible = true;
                        mn_capnhatsdt.Visible = true;
                        mn_importimage.Visible = true;
                    }
                    //if (reqCookies["p"].ToString() == "PBD")
                    //{
                    //    imgUser.Src = "../../hinhnhanvien/logo.jpg";
                    //}
                    //else
                    //{
                    //    imgUser.Src = "../../hinhnhanvien/" + reqCookies["USER_ID"] + ".jpg";
                    //}
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
            string sql = "select * from dbo.DKN_Table1 where XuLy is null and convert(date,TTin,1111) >= '2018/11/01' and MaNVKTra='" + MaNV + "' and (LDon='KN' or LDon='OL') and KhongKiemTra='False' and NhomKT is null";
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