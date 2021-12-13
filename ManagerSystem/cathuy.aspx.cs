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
    public partial class cathuy : System.Web.UI.Page
    {
        ConnectDB conDB = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds;
        access ac = new access();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ac.CapNhatTruycap(6, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        public GridView search(string querySearch,string value,string data, GridView gridData)
        {
            if (txtSearch.Text == "" || dropSearch.Text == "Tìm theo...")
            {
                Response.Write("<script>alert('Bạn chưa nhập dữ liệu cần tìm hoặc chưa chọn loại dữ liệu')</script>");
            }
            else
            {
                conn = conDB.connect_CallCenter();
                conn.Open();
                cmd = new SqlCommand(querySearch, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(""+value+"", data);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                //ds = new DataSet();
                //da.Fill(ds, "dbo_LapPhieuHuy_Table");
                dt = new DataTable();
                da.Fill(dt);
                gridData.DataSource = dt;
                gridData.DataBind();
                conn.Close();
                if (gridData.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Không tìm thấy kết quả. Vui lòng kiểm tra lại thông tin')</script>");
                }
            }
            return gridData;

        }
        public void checkInputText()
        {
            if (dropSearch.Text == "Danh bạ")
            {
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,convert(varchar,NgayLapPhieu,105) as N'Ngày lập',HoTen as N'Họ tên',DiaChi as N'Địa chỉ',CSoGo as N'Chỉ số gỡ',LyDoLLenhCat as N'Lí do cắt',HThucCat as N'Hình thức cắt',SoLHD N'SLHĐ',TongTien as N'Tổng tiền' from dbo.dbo_LapPhieuHuy_Table where dbo='" + txtSearch.Text + "' order by NgayLapPhieu desc", grid_Cathuy);
                search("[proSel_TraCuuCatHuy_DB]", "@DanhBa", txtSearch.Text, grid_Cathuy);
            }
            else if (dropSearch.Text == "Địa chỉ")
            {
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,convert(varchar,NgayLapPhieu,105) as N'Ngày lập',HoTen as N'Họ tên',DiaChi as N'Địa chỉ',CSoGo as N'Chỉ số gỡ',LyDoLLenhCat as N'Lí do cắt',HThucCat as N'Hình thức cắt',SoLHD N'SLHĐ',TongTien as N'Tổng tiền' from dbo.dbo_LapPhieuHuy_Table where diachi like '%" + txtSearch.Text + "%' order by NgayLapPhieu desc", grid_Cathuy);
                search("[proSel_TraCuuCatHuy_DC]", "@DiaChi", txtSearch.Text, grid_Cathuy);
            }
            else if (dropSearch.Text == "Mã lộ trình")
            {
                search("[proSel_TraCuuCatHuy_LT]", "@LT", txtSearch.Text, grid_Cathuy);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,convert(varchar,NgayLapPhieu,105) as N'Ngày lập',HoTen as N'Họ tên',DiaChi as N'Địa chỉ',CSoGo as N'Chỉ số gỡ',LyDoLLenhCat as N'Lí do cắt',HThucCat as N'Hình thức cắt',SoLHD N'SLHĐ',TongTien as N'Tổng tiền' from dbo.dbo_LapPhieuHuy_Table where LT like '" + txtSearch.Text + "%' order by NgayLapPhieu desc", grid_Cathuy);
            }
            else if (dropSearch.Text == "Tên khách hàng")
            {
                search("[proSel_TraCuuCatHuy_KH]", "@KhachHang", txtSearch.Text, grid_Cathuy);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,convert(varchar,NgayLapPhieu,105) as N'Ngày lập',HoTen as N'Họ tên',DiaChi as N'Địa chỉ',CSoGo as N'Chỉ số gỡ',LyDoLLenhCat as N'Lí do cắt',HThucCat as N'Hình thức cắt',SoLHD N'SLHĐ',TongTien as N'Tổng tiền' from dbo.dbo_LapPhieuHuy_Table where HoTen like '%" + txtSearch.Text + "%' order by NgayLapPhieu desc", grid_Cathuy);
            }
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            checkInputText();
            ch.Visible = true;
        }
    }
}