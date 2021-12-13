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
    public partial class xemtatca : System.Web.UI.Page
    {
        ConnectDB connect = new ConnectDB();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                box_grid.Visible = false;
                getYear();
                loadDaTa();
                grvData.Visible = true;
                //conn.Close();
                Image1.Visible = false;
                toolsearch.Visible = false;
                box_HDN.Visible = false;
                rpDsDon.Visible = false;
                ReportToolbar1.Visible = false;
            }
            //CapNhatTruycap();
            try
            {
                ac.CapNhatTruycap(1, Info()["USER_ID"].ToString());
            }
            catch
            {
                Response.Redirect("login.aspx");
            }
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        public void getYear()
        {
            //int y = DateTime.Now.Year;
            for (int i = DateTime.Now.Year; i >= 2007; i--)
            {
                dropNam.Items.Add(i.ToString());
            }
        }
        public void loadDaTa()
        {
            conn = connect.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            //string tungay = this.Request.Form["datepicker"];
            //string denngay = this.Request.Form["datepicker1"];
            cmd = new SqlCommand("[proc_DS_DKN_KTV_ChuaXuLy]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNVKtra", Info()["USER_ID"].ToString());
            //cmd.Parameters.AddWithValue("@den_ngay", denngay);
            cmd.ExecuteNonQuery();
            if (Info()["p"].ToString() == "Admin" || Info()["p"].ToString() == "TT" || Info()["p"].ToString() == "TP" || Info()["p"].ToString() == "NVVP-KT" || Info()["p"].ToString() == "PBD")
            {
                da = new SqlDataAdapter("select masndon,left(dbo,4)+' '+SUBSTRING(dbo,5,3)+' '+RIGHT(dbo,4) as dbo,left(MLTrinh,2)+' '+SUBSTRING(MLTrinh,3,2)+' '+RIGHT(MLTrinh,3) as MLTrinh ,KHang ,DChi,bpyeucau,convert(nvarchar,SDon) +' - '+convert(nvarchar,NNDon,103) as SDon,LDon,NDDon,replace(DThoaiKH,' ','') + ' - ' + isnull(replace(DThoaiKH1,' ',''),'/') + ' - ' + isnull(replace(DThoaiKH2,' ',''),'/') as DThoaiKH ,CONVERT(VARCHAR(10),NNDon,105) as NNDon, MaNV + ' - ' + MaNVKTra as 'MaNV',GChu,XuLy,NgayXuLy from DS_DKN_KTV order by SDon", conn);
                ds = new DataSet();
                da.Fill(ds, "DS_DKN_KTV");
            }
            else if (Info()["p"].ToString() == "KTV")
            {
                //da = new SqlDataAdapter("select left(dbo,4)+' '+SUBSTRING(dbo,5,3)+' '+RIGHT(dbo,4) as dbo,left(MLTrinh,2)+' '+SUBSTRING(MLTrinh,3,2)+' '+RIGHT(MLTrinh,3) as MLTrinh ,KHang ,DChi,bpyeucau,convert(nvarchar,SDon) +' - '+convert(nvarchar,NNDon,103) as SDon,LDon,NDDon,LEFT(DThoaiKH,4)+' '+SUBSTRING(replace(DThoaiKH,' ',''),5,3)+' '+RIGHT(DThoaiKH,3) AS DThoaiKH,CONVERT(VARCHAR(10),NNDon,105) as NNDon from DS_DKN_KTV where manvktra='" + Info()["USER_ID"].ToString() + "' order by SDon ", conn);
                da = new SqlDataAdapter("select masndon,left(dbo,4)+' '+SUBSTRING(dbo,5,3)+' '+RIGHT(dbo,4) as dbo,left(MLTrinh,2)+' '+SUBSTRING(MLTrinh,3,2)+' '+RIGHT(MLTrinh,3) as MLTrinh ,KHang ,DChi,bpyeucau,convert(nvarchar,SDon) +' - '+convert(nvarchar,NNDon,103) as SDon,LDon,NDDon,replace(DThoaiKH,' ','') + ' - ' + isnull(replace(DThoaiKH1,' ',''),'/') + ' - ' + isnull(replace(DThoaiKH2,' ',''),'/') as DThoaiKH,CONVERT(VARCHAR(10),NNDon,105) as NNDon, MaNV + ' - ' + MaNVKTra as 'MaNV',GChu,XuLy,NgayXuLy from DS_DKN_KTV where manvktra='" + Info()["USER_ID"].ToString() + "' order by SDon ", conn);
                ds = new DataSet();
                da.Fill(ds, "DS_DKN_KTV");
            }
            else if (Info()["p"].ToString() == "NVVP")
            {
                da = new SqlDataAdapter("select masndon,left(dbo,4)+' '+SUBSTRING(dbo,5,3)+' '+RIGHT(dbo,4) as dbo,left(MLTrinh,2)+' '+SUBSTRING(MLTrinh,3,2)+' '+RIGHT(MLTrinh,3) as MLTrinh ,KHang ,DChi,bpyeucau,convert(nvarchar,SDon) +' - '+convert(nvarchar,NNDon,103) as SDon,LDon,NDDon,replace(DThoaiKH,' ','') + ' - ' + isnull(replace(DThoaiKH1,' ',''),'/') + ' - ' + isnull(replace(DThoaiKH2,' ',''),'/') as DThoaiKH,CONVERT(VARCHAR(10),NNDon,105) as NNDon,MaNV + ' - ' + MaNVKTra as 'MaNV',GChu,XuLy,NgayXuLy from dbo.DKN_Table1 where where XuLy is null and convert(date,TTin,1111) > '2018/11/01' and MaNVKTra='" + Info()["USER_ID"].ToString() + "' and (LDon='KN' or LDon='OL') and KhongKiemTra='False' and NhomKT is null order by SDon", conn);
                ds = new DataSet();
                da.Fill(ds, "DKN_Table1");
            }
            grvData.DataSource = null;
            grvData.SelectedIndex = -1;
            grvData.DataSource = ds.Tables[0];
            grvData.DataBind();
            box_grid.Visible = true;
            conn.Close();

        }
        protected void btnChiso_Click(object sender, EventArgs e)
        {
            conn = connect.connectChiSo();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query;
            int k;
            if (dropNam.Text == "")
            {
                Response.Write("<script>alert('Bạn vui lòng chọn năm để xem chỉ số')</script>");
            }
            else
            {
                string queryClear = "delete from temp_hd";
                cmd = new SqlCommand(queryClear, conn);
                cmd.ExecuteNonQuery();
                for (int y = Convert.ToInt32(dropNam.Text); y >= Convert.ToInt32(dropNam.Text) - 2; y--)
                {
                    for (k = 1; k <= 12; k++)
                    {
                        query = "insert into temp_HD (nam,ndso_kn,code,ky,Cso_cu, Cso_moi, Tthu, Tnuoc, TGTGT, PBVMT,GBieu,DMuc) select '20'+''+nam,ndso_kn,code+''+isnull(Codefu,''),ky, Cso_cu, Cso_moi, Tthu,Tnuoc, TGTGT, PBVMT,GBieu,DMuc from HD_" + k + "" + y + " where Dbo=replace('" + txtDba.Text + "',' ','')";

                        cmd = new SqlCommand(query, conn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            break;
                        }
                        finally
                        {

                        }
                    }
                }
                cmd = new SqlCommand("select nam as 'Năm',ky as 'Kỳ',code as 'Code', cso_cu as 'Chỉ số cũ', cso_moi as 'Chỉ số mới', TThu as 'Tiêu thụ',CONVERT(VARCHAR(10),ndso_kn,105) as 'Ngày đọc số', GBieu as 'GB', DMuc as 'ĐM'  from temp_hd order by ndso_kn,ky", conn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Temp_HD");
                gridChiSo.Visible = true;
                gridChiSo.DataSource = ds.Tables["Temp_HD"];
                gridChiSo.DataBind();
                conn.Close();
            }
        }
        protected void grvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = grvData.Rows[index];
            TableCell Dbo = selectedRow.Cells[1];
            TableCell MLT = selectedRow.Cells[2];
            TableCell DT = selectedRow.Cells[3];
            TableCell KH = selectedRow.Cells[4];
            TableCell DC = selectedRow.Cells[5];
            TableCell PBD = selectedRow.Cells[6];
            TableCell SD = selectedRow.Cells[7];
            TableCell ND = selectedRow.Cells[8];
            string dba_ = Dbo.Text;
            string mlt_ = MLT.Text;
            string kh_ = KH.Text;
            string dc_ = DC.Text;
            string pbd = PBD.Text;
            string sd = SD.Text;
            string nd = ND.Text;
            string dt_ = DT.Text;
            if (e.CommandName == "Select")
            {
                //Response.Write("<script>alert('" + contact + "')</script>");
                Image1.ImageUrl = "~/banve.ashx?id=" + dba_;
                Image1.Visible = true;
                toolsearch.Visible = false;
                box_HDN.Visible = false;
            }
            //else if (e.CommandName == "Click")
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('giadinhGIS.htm','_newtab');", true);
            //}
            else if (e.CommandName == "View")
            {

                txtDba.Text = dba_;
                Image1.Visible = false;
                toolsearch.Visible = true;
                box_HDN.Visible = false;
                grvData.SelectedIndex = 11;
            }
            else if (e.CommandName == "HoaDon")
            {
                box_HDN.Visible = true;
                gridChiSo.Visible = false;
                Image1.Visible = false;
                conn = connect.connectHD();
                conn.Open();
                string query = "Select hd.kyHD as Kỳ, hd.namHD as Năm, REPLACE(CONVERT(varchar(20), (CAST(hd.tnuoc AS money)), 1), '.00', '') as 'Tiền nước', REPLACE(CONVERT(varchar(20), (CAST(hd.TGTGT AS money)), 1), '.00', '') as TGTGT, REPLACE(CONVERT(varchar(20), (CAST(hd.PBVMT AS money)), 1), '.00', '') as PBVMT, REPLACE(CONVERT(varchar(20), (CAST(hd.tnuoc+hd.tgtgt+hd.pbvmt AS money)), 1), '.00', '') as 'Tổng cộng', [description].mota as 'Trạng thái',convert(varchar,ngaythanhtoan,103)+' '+right(convert(varchar,ngaythanhtoan,20),8) as N'Ngày thanh toán', hd.MaNH as 'Ngân hàng' from HoaDonNganHang hd join [description] on hd.dathanhtoan = [description].trangthai  where dbo=replace('" + Dbo.Text + "',' ','')";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "HD");

                conn.Close();
                if (ds.Tables["HD"].Rows.Count > 0)
                {
                    grid_HDN.DataSource = ds.Tables["HD"];
                    grid_HDN.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables["HD"].NewRow());
                    grid_HDN.DataSource = ds;
                    grid_HDN.DataBind();
                    int columncount = grid_HDN.Rows[0].Cells.Count;
                    grid_HDN.Rows[0].Cells.Clear();
                    grid_HDN.Rows[0].Cells.Add(new TableCell());
                    grid_HDN.Rows[0].Cells[0].ColumnSpan = columncount;
                    grid_HDN.Rows[0].Cells[0].Text = "Không có hóa đơn tồn";
                }
                grid_HDN.Visible = true;

            }
            else if (e.CommandName == "XuLyDon")
            {
                try
                {
                    conn = connect.connectSQL_Bang_Ke_Dieu_Chinh();
                    conn.Open();

                    string sql_CapNhatXuLy = "update DKN_Table1 set xuly = N'Đã xử lý', NgayXuLy = getdate() where masndon='" + grvData.DataKeys[selectedRow.RowIndex].Value + "'";
                    cmd = new SqlCommand(sql_CapNhatXuLy, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Cập nhật thành công')</script>");
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Cập nhật thất bại')</script>");
                }
               
            }

        }
        private static DataTable GetData(string query)
        {

            using (SqlConnection con = new SqlConnection("Server=192.168.23.66;Database=Giai_Quyet_Don;User Id=admin;Password=Kh0ngBi3t;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            con.Close();
                            return dt;
                        }

                    }
                }
            }
        }
        protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string id = grvData.DataKeys[e.Row.RowIndex].Value.ToString();
                string dbo = e.Row.Cells[1].Text;
                GridView grvChild = e.Row.FindControl("gridHistory") as GridView;
                grvChild.DataSource = GetData(string.Format("select NDKNai,convert(varchar(10),SDon) +' - '+convert(nvarchar,NgayNhanDon,103)  as NgayNhanDon,TTin_KiemTra,MaNVKTra,KQGQuyet,CONVERT(NVARCHAR,NTHso,103) as NTHso from Thong_Tin_GQDon_Table where dbo=replace('{0}',' ','') order by NCNhat_TTin desc", dbo));
                grvChild.DataBind();
            }
        }

        protected void btn_In_Click(object sender, EventArgs e)
        {
            grvData.Visible = false;
            ReportToolbar1.Visible = true;
            rpDsDon.Visible = true;
        }

        
    }
}