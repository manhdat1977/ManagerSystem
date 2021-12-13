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
    public partial class capnhatSOT : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectDB condb = new ConnectDB();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Timkiem();
        }
        void Timkiem()
        {
            conn = condb.ConntectToSUAONGTRONG();
            conn.Open();
            //cmd = new SqlCommand("proc_select_thongtinsuachua", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@dbo", txt_Dbo.Text);
            if (dropTimKiem.Text == "Số phiếu")
            {
                cmd = new SqlCommand("select * from ThongTinSuaChua where SoPhieu = '" + txtTimKiem.Text + "'", conn);
            }
            else if (dropTimKiem.Text == "Danh bạ")
            {
                cmd = new SqlCommand("select * from ThongTinSuaChua where Dbo = '" + txtTimKiem.Text + "'", conn);
            }
            else if (dropTimKiem.Text == "Địa chỉ")
            {
                cmd = new SqlCommand("select * from ThongTinSuaChua where DChi like  '%" + txtTimKiem.Text + "%'", conn);
            }
            else
            {
                Response.Write("<script>alert('Vui lòng chọn loại tìm kiếm')</script>");
            }
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gridCapNhatHoanCong.DataSource = dt;
            gridCapNhatHoanCong.DataBind();
            conn.Close();
        }

        protected void gridCapNhatHoanCong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gridCapNhatHoanCong.DataKeys[index].Values[0]);
                lblID.Text = id.ToString();
                conn = condb.ConntectToSUAONGTRONG();
                conn.Open();
                cmd = new SqlCommand("proc_select_thongtinsuachua_id", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtKH.Text = dr["KHang"].ToString();
                    txtDC.Text = dr["DChi"].ToString();
                    txtMLT.Text = dr["MLT"].ToString();
                    txtDba.Text = dr["dbo"].ToString();
                    txtGhiChu.Text = dr["GhiChu"].ToString();
                    txtNoiDung.Text = dr["NoiDungkHBao"].ToString();
                    txtSDT.Text = dr["SDT"].ToString();
                    dropTieuChi.Text = dr["TieuChi"].ToString();
                    txtNDSuaChua.Text = dr["NoiDungSuaChua"].ToString();
                    txtNguoiBao.Text = dr["NguoiLienLac"].ToString();
                    string[] arrList = dr["SoPhieu"].ToString().Split('/');
                    //drop.Text = arrList[1];
                    txtSoPhieu.Text = arrList[0];
                    txtNVThucHien.Text = dr["NhanVienThucHien"].ToString();
                }
                conn.Close();
            }
        }

        protected void btnCapNhatHoanCong_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
            {
                if (dropTieuChi.Text != "" && txtNVThucHien.Text != "" && txtNDSuaChua.Text != "")
                {
                    conn = condb.ConntectToSUAONGTRONG();
                    conn.Open();
                    cmd = new SqlCommand("[proc_capnhat_hoancong]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ThoiGianHoanThanh", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@NoiDungSuaChua", txtNDSuaChua.Text);
                    cmd.Parameters.AddWithValue("@TieuChi", dropTieuChi.Text);
                    cmd.Parameters.AddWithValue("@NhanVienThucHien", txtNVThucHien.Text);
                    cmd.Parameters.AddWithValue("@DanhGia", dropDanhGia.Text);
                    cmd.Parameters.AddWithValue("@HoanCong", chkHoanCong.Checked);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Tiêu chí, tên nhân viên thực hiện, nội dung sửa chữa không được để trống')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Vui lòng click vào nút Chọn trên danh sách để chọn hồ sơ cập nhật hoàn công')</script>");
            }
        }

        private void Clear()
        {
            txtDba.Text = "";
            txtDC.Text = "";
            txtGhiChu.Text = "";
            txtKH.Text = "";
            txtMLT.Text = "";
            txtNDSuaChua.Text = "";
            txtNguoiBao.Text = "";
            txtNoiDung.Text = "";
            txtNVThucHien.Text = "";
            txtSDT.Text = "";
            txtSoPhieu.Text = "";
            txtTimKiem.Text = "";
        }
    }
}