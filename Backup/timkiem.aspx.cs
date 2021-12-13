using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem
{
    public partial class timkiem : System.Web.UI.Page
    {
        ConnectDB connect = new ConnectDB();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        int stt = 1;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getYear();
                box_HDN.Visible = false;   
            }
            ac.CapNhatTruycap(8, Info()["USER_ID"].ToString());
        }
        public void getYear()
        {
            //int y = DateTime.Now.Year;
            for (int i = DateTime.Now.Year; i >= 2007; i--)
            {
                dropNam.Items.Add(i.ToString());
            }
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public int LengthSeach(string chuoi)
        {
            chuoi = txtSearch.Text;
            chuoi = chuoi.Trim();
            int sokytu = 1;
            for (int i = 1; i < chuoi.Length; i++)
            {
                sokytu++;
            }
            return sokytu;
        }
        public GridView search(string querySearch, GridView gridData)
        {
            if (txtSearch.Text == "" || dropSearch.Text=="Tìm theo...")
            {
                Response.Write("<script>alert('Bạn chưa nhập dữ liệu cần tìm hoặc chưa chọn loại dữ liệu')</script>");
            }
            else
            {
                conn = connect.connectBK();
                conn.Open();
                cmd = new SqlCommand(querySearch, conn);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "SoDBo_Table");
                gridData.DataSource = ds.Tables[0];
                gridData.DataBind();
                conn.Close();
                grid_HDN.SelectedIndex = -1;
                if (gridData.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Không tìm thấy kết quả. Vui lòng kiểm tra lại thông tin')</script>");
                }
            }
            return gridData;
        }
       
        public void checkInputText()
        {
            //if (IsNumber(txtSearch.Text) == true && LengthSeach(txtSearch.Text) == 11)
            //{
            //    search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,DThoai,KH,DC,sothan,hieu,co,dma from SoDBo_Table where db='" + txtSearch.Text + "'", gridSearch);
            //}
            //else if (IsNumber(txtSearch.Text) == true && LengthSeach(txtSearch.Text) == 7)
            //{
            //    search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,DThoai,KH,DC,sothan,hieu,co,dma from SoDBo_Table where MaLT='" + txtSearch.Text + "' order by malt asc", gridSearch);
   
            //}
            //else
            //{
            //    search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,DThoai,KH,DC,sothan,hieu,co,dma from SoDBo_Table where DC like '%" + txtSearch.Text + "%' order by DC asc", gridSearch);
            //}
            if (dropSearch.Text == "Danh bạ")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where db='" + txtSearch.Text + "'", gridSearch);
            }
            else if(dropSearch.Text=="Địa chỉ")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where dc like '%" + txtSearch.Text + "%' order by DC asc", gridSearch);
            }
            else if (dropSearch.Text == "Mã lộ trình")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where MaLT like '" + txtSearch.Text + "%' order by malt asc", gridSearch);
            }
            else if (dropSearch.Text == "Tên khách hàng")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where KH like '%" + txtSearch.Text + "%' order by KH asc", gridSearch);
            }
            else if (dropSearch.Text == "Hợp đồng")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where HD = '" + txtSearch.Text + "' order by HD asc", gridSearch);
            }
            else if (dropSearch.Text == "Số điện thoại")
            {
                search("select left(db,4)+' '+SUBSTRING(db,5,3)+' '+RIGHT(db,4) as DB,HD,left(MaLT,2)+' '+SUBSTRING(malt,3,2)+' '+RIGHT(MaLT,3) as MaLT,GB,DM,DThoai_SMS,KH,DC,sothan,co,dma from SoDBo_Table where DThoai_SMS = '" + txtSearch.Text + "'", gridSearch);
            }
        }
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            checkInputText();
            gridChiSo.Visible = false;
            box_HDN.Visible = false;
            Image1.Visible = false; 
            int a = gridSearch.Rows.Count;

            toolsearch.Visible = false;
            Image1.Visible = false;
            gridSearch.Visible = true;
            printImg.Visible = false;   
        }
        public void countResult()
        {

        }
        protected void gridSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSearch.PageIndex = e.NewPageIndex;
            //int trang_thu = e.NewPageIndex;
            //int sodong = gridSearch.PageSize;
            //stt = trang_thu * sodong + 1;
            checkInputText();
        }

        protected void gridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = gridSearch.Rows[index];
            TableCell Dbo = selectedRow.Cells[1];
            TableCell MLT = selectedRow.Cells[3];
            TableCell DT = selectedRow.Cells[6];
            TableCell KH = selectedRow.Cells[7];
            TableCell DC = selectedRow.Cells[8];
            //TableCell GB = selectedRow.Cells[5];
            //TableCell DM = selectedRow.Cells[6];
            TableCell SoThan = selectedRow.Cells[9];
            //TableCell Hieu = selectedRow.Cells[7];
            TableCell Co = selectedRow.Cells[10];
            TableCell VungDMA = selectedRow.Cells[11];
            string dba_ = Dbo.Text;
            string mlt_ = MLT.Text;
            string kh_ = KH.Text;
            string dc_ = DC.Text;
            //string gb_ = GB.Text;
            //string dm_ = DM.Text;
            string dt_ = DT.Text;
            string st_ = SoThan.Text;
            //string hieu_ = Hieu.Text;
            string co_ = Co.Text;
            string dma_ = VungDMA.Text;
            if (e.CommandName == "Select")
            {
                Image1.Visible = true;
                box_HDN.Visible = false;
                gridChiSo.Visible = false;
                //Response.Write("<script>alert('" + contact + "')</script>");
                Image1.ImageUrl = "~/banve.ashx?id=" + dba_;              
                Image1.Visible = true;
                toolsearch.Visible = false;
                printImg.Visible = true;
            }
            //else if (e.CommandName == "Click")
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('giadinhGIS.htm','_newtab');", true);
            //}
            else if (e.CommandName == "HDN")
            {
                box_HDN.Visible = true;
                gridChiSo.Visible = false;
                Image1.Visible = false;
                printImg.Visible = false;
                conn = connect.connectHD();
                conn.Open();
                //string query = "Select hd.kyHD as Kỳ, hd.namHD as Năm, hd.tnuoc as 'Tiền nước', hd.TGTGT, hd.PBVMT, hd.tnuoc+hd.tgtgt+hd.pbvmt as 'Tổng cộng', [description].mota as 'Trạng thái',convert(varchar,ngaythanhtoan,103)+' '+right(convert(varchar,ngaythanhtoan,20),8) as N'Ngày thanh toán', hd.MaNH as 'Ngân hàng' from HD join [description] on hd.dathanhtoan = [description].trangthai  where dbo=replace('" + Dbo.Text + "',' ','')";
                string query = "Select hd.kyHD as Kỳ, hd.namHD as Năm, REPLACE(CONVERT(varchar(20), (CAST(hd.tnuoc AS money)), 1), '.00', '') as 'Tiền nước', REPLACE(CONVERT(varchar(20), (CAST(hd.TGTGT AS money)), 1), '.00', '') as TGTGT, REPLACE(CONVERT(varchar(20), (CAST(hd.PBVMT AS money)), 1), '.00', '') as PBVMT, REPLACE(CONVERT(varchar(20), (CAST(hd.tnuoc+hd.tgtgt+hd.pbvmt AS money)), 1), '.00', '') as 'Tổng cộng', [description].mota as 'Trạng thái',convert(varchar,ngaythanhtoan,103)+' '+right(convert(varchar,ngaythanhtoan,20),8) as N'Ngày thanh toán', hd.MaNH as 'Ngân hàng' from HoaDonNganHang hd join [description] on hd.dathanhtoan = [description].trangthai  where dbo=replace('" + Dbo.Text + "',' ','') order by hd.namhd desc,hd.kyHD desc ";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "HD");
                grid_HDN.DataSource = ds.Tables["HD"];
                grid_HDN.DataBind();
                //if (grid_HDN.Rows.Count.ToString() == "0")
                //{
                //    grid_HDN.DataSource = null;
                //    ds.Tables[0].Rows.Add(ds.Tables["HD"].NewRow());
                //    grid_HDN.DataSource = ds;
                //    grid_HDN.DataBind();
                //    int columncount = grid_HDN.Rows[0].Cells.Count;
                //    grid_HDN.Rows[0].Cells.Clear();
                //    grid_HDN.Rows[0].Cells.Add(new TableCell());
                //    grid_HDN.Rows[0].Cells[0].ColumnSpan = columncount;
                //    grid_HDN.Rows[0].Cells[0].Text = "Không có hóa đơn tồn";                  
                //}
                //else
                //{                 
                //    grid_HDN.DataSource = ds.Tables["HD"];
                //    grid_HDN.DataBind();
                //}
                conn.Close();
                grid_HDN.Visible = true;
            }
            else if (e.CommandName == "View")
            {
                gridChiSo.Visible = false;
                Image1.Visible = false;
                printImg.Visible = false;
                box_HDN.Visible = false;
                if (DT.Text.Length > 8)
                {

                    txtSDT.Text = dt_;
                    txtSDT.Visible = true;
                    lblSDT.Visible = true;
                }
                else
                {
                    txtSDT.Visible = false;
                    lblSDT.Visible = false;
                }
                if (SoThan.Text.Length > 1)
                {
                    txtSoThan.Text = st_;
                    lblSoThan.Visible = true;
                    txtSoThan.Visible = true;
                }
                else
                {
                    lblSoThan.Visible = false;
                    txtSoThan.Visible = false;
                }
                txtDba.Text = dba_;
                txtMLT.Text = mlt_;
                txtKH.Text = kh_;
                txtDChi.Text = dc_;
                //txtGBieu.Text = gb_;
                //txtDmuc.Text = dm_;
                txtSDT.Text = dt_;
                //txtHieu.Text = hieu_;
                txtCo.Text = co_;
                txtDMA.Text = dma_;
                Image1.Visible = false;
                toolsearch.Visible = true;
                gridSearch.Visible = false;
            }
 
        }
        protected void btnChiso_Click(object sender, EventArgs e)
        {
            box_HDN.Visible = false;
            Image1.Visible = false;
            gridChiSo.Visible = true;
            printImg.Visible = false;
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
                cmd = new SqlCommand("select nam as 'Năm',ky as 'Kỳ',code as 'Code', cso_cu as 'Chỉ số cũ', cso_moi as 'Chỉ số mới', TThu as 'Tiêu thụ',CONVERT(VARCHAR(10),ndso_kn,105) as 'Ngày đọc số', GBieu as 'GB', DMuc as 'ĐM'  from temp_hd order by ndso_kn,ky desc", conn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Temp_HD");
                gridChiSo.Visible = true;
                gridChiSo.DataSource = ds.Tables["Temp_HD"];
                gridChiSo.DataBind();
                conn.Close();
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
        protected void gridSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string id = grvData.DataKeys[e.Row.RowIndex].Value.ToString();
                string dbo = e.Row.Cells[1].Text;
                GridView grvChild = e.Row.FindControl("gridHistory") as GridView;
                grvChild.DataSource = GetData(string.Format("select NDKNai,CONVERT(VARCHAR(10),NgayNhanDon,105) as NgayNhanDon,TTin_KiemTra,MaNVKTra,KQGQuyet,CONVERT(VARCHAR(10),NTHso,105) as NTHso from Thong_Tin_GQDon_Table where dbo=replace('{0}',' ','') order by year(NgayNhanDon) desc,MONTH(ngaynhandon) desc,DAY(ngaynhandon) desc", dbo));
                grvChild.DataBind();
            }
        }
    }
}