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
    public partial class taoyeucausot : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectDB condb = new ConnectDB();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SoPhieuHeThong();
            }
        }
        public bool CheckID(string ID)
        {
            conn = condb.ConntectToSUAONGTRONG();
            conn.Open();
            cmd = new SqlCommand("[proc_select_thongtinsuachua_sophieu]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sophieu", ID);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return false;
            conn.Close();
            return true;
        }
        void SoPhieuHeThong()
        {
            conn = condb.ConntectToSUAONGTRONG();
            conn.Open();
            //cmd = new SqlCommand("select max(LEFT(SoPhieu,len(SoPhieu)-5)) as SoPhieu from dbo.ThongTinSuaChua where year(ThoiGianNhanHS) = 2019", conn);
            cmd = new SqlCommand("proc_getmax", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblSoPhieu.Text = "Số phiếu hiện tại là: " + dr[0].ToString();
            }
            conn.Close();
            lblSoPhieu.Visible = true;
            lblSoPhieu.Font.Bold = true;
        }
        protected void btnDba_Click(object sender, EventArgs e)
        {
            conn = condb.connectBK();
            conn.Open();
            cmd = new SqlCommand("proc_getall_Dbo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dbo", txtDba.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtKH.Text = dr["KH"].ToString();
                txtDC.Text = dr["DC"].ToString();
                txtMLT.Text = dr["MaLT"].ToString();
            }
            conn.Close();
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtDba.Text == "" && txtNguoiBao.Text == "")
            {
                Response.Write("<script>alert('Danh bạ hoặc tên người liên lạc không được để trống')</script>");
            }
            else
            {
                if (txtSoPhieu.Text != "")
                {
                    if (CheckID(txtSoPhieu.Text + "/" + DateTime.Now.Year) == true)
                    {
                        conn = new SqlConnection("Server=192.168.23.66;Database=SUAONGTRONG;User Id=admin;Password=Kh0ngBi3t;");
                        conn.Open();
                        //cmd = new SqlCommand("insert into ThongTinSuaChua (dbo,Khang,Dchi,MLT,NoiDungKHBao,ThoiGianNhanHS,sdt,ghichu) values( '" + txtDba.Text + "','" + lbTenKhachHang.Text + "','" + lbDiaChi.Text + "','"+lbLoTrinh.Text+"',N'" + txtNDKHBao.Text + "',convert(varchar(10), getdate(), 103),'" + txtSDT.Text + "','" + txtGhichu.Text + "')", conn);
                        cmd = new SqlCommand("proc_insert_YCKH", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@dbo", txtDba.Text);
                        cmd.Parameters.AddWithValue("@KH", txtKH.Text);
                        cmd.Parameters.AddWithValue("@DC", txtDC.Text);
                        cmd.Parameters.AddWithValue("@MLT", txtMLT.Text);
                        cmd.Parameters.AddWithValue("@NoiDungKHBao", txtNoiDung.Text);
                        cmd.Parameters.AddWithValue("@ThoiGianNhanHS", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                        cmd.Parameters.AddWithValue("@SoPhieu", txtSoPhieu.Text + "/" + DateTime.Now.Year);
                        cmd.Parameters.AddWithValue("@NguoiLienLac", txtNguoiBao.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Clear();
                    }
                    else
                    {
                        Response.Write("<script>alert('Số phiếu này đã được tạo')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Số phiếu không được để trống')</script>");
                }
            }
            SoPhieuHeThong();
        }

        private void Clear()
        {
            txtDba.Text = "";
            txtDC.Text = "";
            txtGhiChu.Text = "";
            txtKH.Text = "";
            txtMLT.Text = "";
            txtNguoiBao.Text = "";
            txtNoiDung.Text = "";
            txtSDT.Text = "";
            txtSoPhieu.Text = "";
        }
    }
}