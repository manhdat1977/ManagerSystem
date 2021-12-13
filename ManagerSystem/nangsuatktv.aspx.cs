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
    public partial class nangsuatktv : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;

        DataSet ds;
        SqlDataAdapter da;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Info()["p"].ToString() == "KTV")
                {
                    print.Visible = false;
                    view.Visible = true;
                }
                else if (Info()["p"].ToString() == "" || Info()["p"].ToString() == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    print.Visible = true;
                    view.Visible = true;
                    }
            }
            ac.CapNhatTruycap(3, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        protected void btn_NangSuat_Click(object sender, EventArgs e)
        {
            ConnectDB conDB = new ConnectDB();
            //string tungay = this.Request.Form["datepicker"];
            //string denngay = this.Request.Form["datepicker1"];
            string tungay = datepicker.Text;
            string denngay = datepicker1.Text;
            string query_drop_table = "Drop table productivity";
            string query = "SELECT MaNVKTra, LDon, MaBPYeuCau, Count(MaSNDon) AS SLDon into productivity"
                            + " FROM Thong_Tin_GQDon_Table  "
                            + " WHERE ((NTHSo Between '" + tungay + "' And '" + denngay + "') AND (MaNVKTra Is Not Null  And MaNVKTra <>'thuynn' And MaNVKTra <>'PHUONGNTN' And MaNVKTra <>'VANNTT') AND KhongKiemTra=0 AND NhaDCua=0)"
                            + " GROUP BY MaNVKTra, LDon, MaBPYeuCau";
            string query1 = "insert into productivity (MaNVKtra,LDon,MaBPYeuCau,SLDon) SELECT NVKTPhoiHop,LDon, MaBPYeuCau, Count(MaSNDon) AS SLDon"
                            + " FROM Thong_Tin_GQDon_Table"
                            + " WHERE ((NTHSo Between '" + tungay + "' And '" + denngay + "') AND (NVKTPhoiHop Is Not Null And MaNVKTra <>'thuynn' And MaNVKTra <>'PHUONGNTN' And MaNVKTra <>'VANNTT') AND KhongKiemTra=0 AND NhaDCua=0)"
                            + " GROUP BY NVKTPhoiHop, LDon, MaBPYeuCau";
            //
            conn = conDB.connectSQL_Giai_Quyet_Don();
            conn.Open();
            //
            cmd = new SqlCommand(query_drop_table, conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query1, conn);
            cmd.ExecuteNonQuery();
            //
            string query_update_dp;
            string[] manvktra = new string[] { "BINHTV", "CUONGLM", "HIEULT", "LOCPV", "NAMHQ", "SIPH", "THUANNB", "PHUCDN", "DIENTT", "LONGNP", "HUNGVV","THANHTT" };
            for (int i = 0; i < manvktra.Length; i++)
            {
                query_update_dp = "UPDATE details_productivity"
                                         + " SET KDDVKH_KCSD = (SELECT sum(sldon) FROM productivity WHERE ldon = 'KCSD' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH_KTDM = (SELECT sum(sldon) FROM productivity WHERE ldon = 'KTDM' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH_CTDS = (SELECT sum(sldon) FROM productivity WHERE ldon = 'CTDS' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KhachHang = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'01- Khách hàng' and Ldon!='DC' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " DonThuTrenWeb = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'02- Đơn thư trên WEB' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " QLDHN = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'03- Quản lý đồng hồ nước' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TCHC = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'04- Phòng Tổ chức - Hành Chánh' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " BGD = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'05- Ban Giám đốc' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PTN = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'06- Phòng Thu ngân' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'07- Kinh doanh - Dịch vụ khách hàng' AND LDON=N'GM' AND manvktra ='" + manvktra[i].ToString() + "' OR MaBPYeuCau='KDDVKH' AND Ldon='KN' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND Ldon='KN' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND Ldon='dc' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'01- Khách hàng' AND Ldon='dc' AND manvktra = '" + manvktra[i].ToString() + "'),"
                    //+ " KDDVKH = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'07- Kinh doanh - Dịch vụ khách hàng' AND manvktra ='" + manvktra[i].ToString() + "'),"
                                       + " QLGNKDT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'08- Quản lí giảm nước không doanh thu' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PKT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'09- Phòng Ký thuật' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " DuyTu = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'10- Duy tu' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PKHVT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'11- Phòng kế hoạch vật tư' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " BQLDA = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'12- Ban Quản lý dự án' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TC1 = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'13- Thi công 1' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TC2 = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'14- Thi công 2' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " SuaBe = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'15- Sửa bể' AND manvktra ='" + manvktra[i].ToString() + "'),"
                                       + " TuKtra = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'16- Tự Kiểm tra trên địa bàn' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KHO = (SELECT sum(sldon) FROM productivity WHERE ldon in ('KH','PLT') and MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND manvktra = '" + manvktra[i].ToString() + "')"
                                       + " WHERE MaNVKtra = '" + manvktra[i].ToString() + "'";

                //cmd = new SqlCommand("sp_Update_details_productivity", conn);
                cmd = new SqlCommand(query_update_dp, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@ten_nv",manvktra[i].ToString()));
                cmd.ExecuteNonQuery();
            }
            string[] Ldon = new string[] { "KDDVKH_KCSD", "KDDVKH_KTDM", "KDDVKH_CTDS", "KhachHang", "DonThuTrenWeb", "QLDHN", "TCHC", "BGD", "PTN", "KDDVKH", "QLGNKDT", "PKT", "DuyTu", "PKHVT", "BQLDA", "TC1", "TC2", "SuaBe", "TuKtra", "KHO" };
            string query_update_null;
            for (int i = 0; i < Ldon.Length; i++)
            {
                query_update_null = "UPDATE details_productivity SET " + Ldon[i].ToString() + " = 0 WHERE " + Ldon[i].ToString() + " is NULL";
                //cmd = new SqlCommand("sp_update_value_null", conn);
                cmd = new SqlCommand(query_update_null, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@Ldon", Ldon[i].ToString()));
                cmd.ExecuteNonQuery();
            }
            string select_data = " alter view v_NangSuat as SELECT manvktra,ten_nvkt,(khachhang+donthutrenweb) AS donKH, (QLDHN+TCHC+BGD+PTN+QLGNKDT+PKT+DuyTu+PKHVT+BQLDA+TC1+TC2+SuaBe) AS PBD, (KDDVKH_KCSD+KDDVKH_KTDM+TuKtra+KDDVKH+KHO)AS KH_Phong, KDDVKH_CTDS, (KDDVKH_KCSD + KDDVKH_KTDM + KDDVKH_CTDS + KhachHang + DonThuTrenWeb + QLDHN + TCHC + BGD + PTN + KDDVKH + QLGNKDT + PKT + DuyTu + PKHVT + BQLDA + TC1 + TC2 + SuaBe + TuKtra+KHO) as sum  FROM details_productivity";
            cmd = new SqlCommand(select_data, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter("select * from dbo.v_NangSuat order by manvktra", conn);
            ds = new dsNangSuat();
            da.Fill(ds, "v_NangSuat");
            reportNangSuat rp = new reportNangSuat();
            rprvNangSuat.Report = rp;
            rp.DataSource = ds.Tables["v_NangSuat"];
            rptoolbarNangSuat.Visible = true;
            rprvNangSuat.Visible = true;
            reportNangSuat.topic = "Từ ngày " + Convert.ToDateTime(datepicker.Text).ToString("dd/MM/yyy") + " đến ngày " + Convert.ToDateTime(datepicker1.Text).ToString("dd/MM/yyy");
            box_grid.Visible = true;
            box_view.Visible = false;
            conn.Close();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ConnectDB conDB = new ConnectDB();
            string tungay = datepicker.Text;
            string denngay = datepicker1.Text;
            string query_drop_table = "Drop table productivity";
            string query = "SELECT MaNVKTra, LDon, MaBPYeuCau, Count(MaSNDon) AS SLDon into productivity"
                            + " FROM Thong_Tin_GQDon_Table  "
                            + " WHERE ((NTHSo Between '" + tungay + "' And '" + denngay + "') AND (MaNVKTra Is Not Null  And MaNVKTra <>'thuynn' And MaNVKTra <>'PHUONGNTN' And MaNVKTra <>'VANNTT') AND KhongKiemTra=0 AND NhaDCua=0)"
                            + " GROUP BY MaNVKTra, LDon, MaBPYeuCau";
            string query1 = "insert into productivity (MaNVKtra,LDon,MaBPYeuCau,SLDon) SELECT NVKTPhoiHop,LDon, MaBPYeuCau, Count(MaSNDon) AS SLDon"
                            + " FROM Thong_Tin_GQDon_Table"
                            + " WHERE ((NTHSo Between '" + tungay + "' And '" + denngay + "') AND (NVKTPhoiHop Is Not Null And MaNVKTra <>'thuynn' And MaNVKTra <>'PHUONGNTN' And MaNVKTra <>'VANNTT') AND KhongKiemTra=0 AND NhaDCua=0)"
                            + " GROUP BY NVKTPhoiHop, LDon, MaBPYeuCau";
            //
            conn = conDB.connectSQL_Giai_Quyet_Don();
            conn.Open();
            //
            cmd = new SqlCommand(query_drop_table, conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query1, conn);
            cmd.ExecuteNonQuery();
            //
            string query_update_dp;
            string[] manvktra = new string[] { "BINHTV", "CUONGLM", "HIEULT", "LOCPV", "NAMHQ", "SIPH", "THUANNB", "PHUCDN", "DIENTT", "LONGNP", "HUNGVV","THANHTT" };
            for (int i = 0; i < manvktra.Length; i++)
            {
                query_update_dp = "UPDATE details_productivity"
                                         + " SET KDDVKH_KCSD = (SELECT sum(sldon) FROM productivity WHERE ldon = 'KCSD' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH_KTDM = (SELECT sum(sldon) FROM productivity WHERE ldon = 'KTDM' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH_CTDS = (SELECT sum(sldon) FROM productivity WHERE ldon = 'CTDS' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KhachHang = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'01- Khách hàng' and Ldon!='DC' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " DonThuTrenWeb = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'02- Đơn thư trên WEB' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " QLDHN = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'03- Quản lý đồng hồ nước' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TCHC = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'04- Phòng Tổ chức - Hành Chánh' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " BGD = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'05- Ban Giám đốc' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PTN = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'06- Phòng Thu ngân' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KDDVKH = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'07- Kinh doanh - Dịch vụ khách hàng' AND LDON=N'GM' AND manvktra ='" + manvktra[i].ToString() + "' OR MaBPYeuCau='KDDVKH' AND Ldon='KN' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND Ldon='KN' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND Ldon='dc' AND manvktra = '" + manvktra[i].ToString() + "' OR MaBPYeuCau=N'01- Khách hàng' AND Ldon='dc' AND manvktra = '" + manvktra[i].ToString() + "'),"
                    //+ " KDDVKH = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'07- Kinh doanh - Dịch vụ khách hàng' AND manvktra ='" + manvktra[i].ToString() + "'),"
                                       + " QLGNKDT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'08- Quản lí giảm nước không doanh thu' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PKT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'09- Phòng Ký thuật' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " DuyTu = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'10- Duy tu' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " PKHVT = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'11- Phòng kế hoạch vật tư' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " BQLDA = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'12- Ban Quản lý dự án' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TC1 = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'13- Thi công 1' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " TC2 = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'14- Thi công 2' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " SuaBe = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'15- Sửa bể' AND manvktra ='" + manvktra[i].ToString() + "'),"
                                       + " TuKtra = (SELECT sum(sldon) FROM productivity WHERE MaBPYeuCau = N'16- Tự Kiểm tra trên địa bàn' AND manvktra = '" + manvktra[i].ToString() + "'),"
                                       + " KHO = (SELECT sum(sldon) FROM productivity WHERE ldon in ('KH','PLT') and MaBPYeuCau=N'07- Kinh doanh - Dịch vụ khách hàng' AND manvktra = '" + manvktra[i].ToString() + "')"
                                       + " WHERE MaNVKtra = '" + manvktra[i].ToString() + "'";

                //cmd = new SqlCommand("sp_Update_details_productivity", conn);
                cmd = new SqlCommand(query_update_dp, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@ten_nv",manvktra[i].ToString()));
                cmd.ExecuteNonQuery();
            }
            string[] Ldon = new string[] { "KDDVKH_KCSD", "KDDVKH_KTDM", "KDDVKH_CTDS", "KhachHang", "DonThuTrenWeb", "QLDHN", "TCHC", "BGD", "PTN", "KDDVKH", "QLGNKDT", "PKT", "DuyTu", "PKHVT", "BQLDA", "TC1", "TC2", "SuaBe", "TuKtra", "KHO" };
            string query_update_null;
            for (int i = 0; i < Ldon.Length; i++)
            {
                query_update_null = "UPDATE details_productivity SET " + Ldon[i].ToString() + " = 0 WHERE " + Ldon[i].ToString() + " is NULL";
                //cmd = new SqlCommand("sp_update_value_null", conn);
                cmd = new SqlCommand(query_update_null, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@Ldon", Ldon[i].ToString()));
                cmd.ExecuteNonQuery();
            }
            string select_data = " alter view v_NangSuat as SELECT manvktra,ten_nvkt,(khachhang+donthutrenweb) AS donKH, (QLDHN+TCHC+BGD+PTN+QLGNKDT+PKT+DuyTu+PKHVT+BQLDA+TC1+TC2+SuaBe) AS PBD, (KDDVKH_KCSD+KDDVKH_KTDM+TuKtra+KDDVKH+KHO)AS KH_Phong, KDDVKH_CTDS, (KDDVKH_KCSD + KDDVKH_KTDM + KDDVKH_CTDS + KhachHang + DonThuTrenWeb + QLDHN + TCHC + BGD + PTN + KDDVKH + QLGNKDT + PKT + DuyTu + PKHVT + BQLDA + TC1 + TC2 + SuaBe + TuKtra+KHO) as sum  FROM details_productivity";
            cmd = new SqlCommand(select_data, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter("select ten_nvkt ,donKH ,PBD ,KH_Phong ,KDDVKH_CTDS , sum from v_NangSuat", conn);
            ds = new dsNangSuat();
            DataTable dt = new DataTable();
            da.Fill(ds, "v_NangSuat");
            da.Fill(dt);
            gridThongtinchiso.DataSource = ds.Tables["v_NangSuat"];
            gridThongtinchiso.DataBind();
            //Total
            int total = 0;
            gridThongtinchiso.FooterRow.Cells[0].Text = "Tổng cộng";
            gridThongtinchiso.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            gridThongtinchiso.FooterRow.Cells[0].Font.Bold = true;
            for (int k = 1; k < dt.Columns.Count; k++)
            {
                total = dt.AsEnumerable().Sum(row => row.Field<Int32>(dt.Columns[k].ToString()));
                gridThongtinchiso.FooterRow.Cells[k].Text = total.ToString("N0");
                gridThongtinchiso.FooterRow.Cells[k].Font.Bold = true;
                gridThongtinchiso.FooterRow.BackColor = System.Drawing.Color.Beige;
            }  
            box_grid.Visible = false;
            box_view.Visible = true;
            conn.Close();
        }
    }
}