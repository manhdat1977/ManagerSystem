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
    public partial class ketquadonthu : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB connectDB = new ConnectDB();
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlDataReader dr;
        //string maHS = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        //public DropDownList data(string query, string text, string value, DropDownList dropname)
        //{
        //    conn = connnectDB.connectSQL();
        //    conn.Open();
        //    dt = new DataTable();
        //    da = new SqlDataAdapter(query, conn);
        //    da.Fill(dt);
        //    dropname.DataSource = dt;
        //    dropname.DataTextField = text;
        //    dropname.DataValueField = value;
        //    dropname.DataBind();
        //    conn.Close();
        //    return dropname;
        //}
        private void LoadDataToDropDownListItem()
        {
            //data("select * from dbo.LDon_CapNhatDonThu", "LDon", "LDon", txtLdon);
        }

        //private void loadChuyenPBD()
        //{
        //    cmd = new SqlCommand("select chuyenbandoi as N'Chuyển PBĐ',chuthich as N'Chú thích',ngaychuyen as N'Ngày chuyển',ngayphanhoi as N'Phản hồi' from chuyenbandoi_table where masndon='"+maHS+"'",conn);
        //    cmd.ExecuteNonQuery();
        //    da = new SqlDataAdapter(cmd);
        //    ds = new DataSet();
        //    da.Fill(ds, "DS_DKN_KTV");
        //    //gridPBD.DataSource = ds.Tables[0];
        //    //gridPBD.DataBind();
        //}
        private void getThongTinDBa()
        {
            conn = connectDB.connectBK();
            conn.Open();
            cmd = new SqlCommand("select MaLT as mlt,KH as kh,DC as dc from SoDBo_Table where db='" + txtDba.Text + "'", conn);
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                txtDC.Text = dr["dc"].ToString();
                txtMLT.Text = dr["mlt"].ToString();
                txtKH.Text = dr["kh"].ToString();             
            }
            conn.Close();
        }
        public void getKetQuaHS()
        {
            conn = connectDB.connectSQL_Giai_Quyet_Don();
            conn.Open();
            cmd = new SqlCommand("select NCNhat_TTin as 'Ngày cập nhật',NDKNai as 'Nội dung khiếu nại',TTin_KiemTra as 'Thông tin kiểm tra',KQGQuyet as 'Kết quả giải quyết',MaNVKTra as 'Nhân viên kiểm tra' from dbo.Thong_Tin_GQDon_Table where dbo = '" + txtDba.Text + "' order by NCNhat_TTin", conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Thong_Tin_GQDon_Table");
            gridKetQua.DataSource = ds.Tables[0];
            gridKetQua.DataBind();
            conn.Close();
        }

        protected void btn_Tim_Click(object sender, EventArgs e)
        {
            getThongTinDBa();
            getKetQuaHS();
        }
    }
}