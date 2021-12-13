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
    public partial class cattam : System.Web.UI.Page
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
            ac.CapNhatTruycap(5, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        public GridView search(string querySearch, GridView gridData)
        {
            if (txtSearch.Text == "" || dropSearch.Text == "Tìm theo...")
            {
                Response.Write("<script>alert('Bạn chưa nhập dữ liệu cần tìm hoặc chưa chọn loại dữ liệu')</script>");
            }
            else
            {
                conn = conDB.connect_DQLDHN();
                conn.Open();
                cmd = new SqlCommand(querySearch, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("" + value + "", data);
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
                search("select * from lapcattam a join LapCatTam_lydo b on a.lydo = b.malydo where danhba ='" + txtSearch.Text+"'order by ngaycapnhat desc", grid_Cattam);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,hoten as N'Họ tên',diachi as N'Địa chỉ',convert(varchar,NgayLBK,105) as N'Ngày lập BK',SoBK as N'Số BK',LDDNCatTam as N'Lí do cắt',SoLHD as N'Số lượng HĐ',TongTien as N'Tổng tiền',CViec as N'Công việc' from dbo.dbo_BangKeDNCatTam_Table where dbo='" + txtSearch.Text + "' order by NgayLBK desc", grid_Cattam);
            }
            else if (dropSearch.Text == "Địa chỉ")
            {
                search("select * from lapcattam a join LapCatTam_lydo b on a.lydo = b.malydo where diachi like '%" + txtSearch.Text+ "%' order by ngaycapnhat desc", grid_Cattam);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,hoten as N'Họ tên',diachi as N'Địa chỉ',convert(varchar,NgayLBK,105) as N'Ngày lập BK',SoBK as N'Số BK',LDDNCatTam as N'Lí do cắt',SoLHD as N'Số lượng HĐ',TongTien as N'Tổng tiền',CViec as N'Công việc' from dbo.dbo_BangKeDNCatTam_Table where diachi like '%" + txtSearch.Text + "%' order by NgayLBK desc", grid_Cattam);
            }
            else if (dropSearch.Text == "Mã lộ trình")
            {
                search("select * from lapcattam a join LapCatTam_lydo b on a.lydo = b.malydo where mlt like '" + txtSearch.Text + "%' ngaycapnhat desc", grid_Cattam);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,hoten as N'Họ tên',diachi as N'Địa chỉ',convert(varchar,NgayLBK,105) as N'Ngày lập BK',SoBK as N'Số BK',LDDNCatTam as N'Lí do cắt',SoLHD as N'Số lượng HĐ',TongTien as N'Tổng tiền',CViec as N'Công việc' from dbo.dbo_BangKeDNCatTam_Table where LT like '" + txtSearch.Text + "%' order by NgayLBK desc", grid_Cattam);
            }
            else if (dropSearch.Text == "Tên khách hàng")
            {
                search("select * from lapcattam a join LapCatTam_lydo b on a.lydo = b.malydo where tenkh like '%" + txtSearch.Text + "%' ngaycapnhat desc", grid_Cattam);
                //search("select left(DBo,4)+' '+substring(dbo,5,3)+' '+right(dbo,4) as N'Danh bạ',left(LT,2)+' '+substring(lt,3,2)+' '+right(lt,3) as MLT,hoten as N'Họ tên',diachi as N'Địa chỉ',convert(varchar,NgayLBK,105) as N'Ngày lập BK',SoBK as N'Số BK',LDDNCatTam as N'Lí do cắt',SoLHD as N'Số lượng HĐ',TongTien as N'Tổng tiền',CViec as N'Công việc' from dbo.dbo_BangKeDNCatTam_Table where hoten like '%" + txtSearch.Text + "%' order by NgayLBK desc", grid_Cattam);
            }          
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            checkInputText();
            ct.Visible = true;
        }
    }
}