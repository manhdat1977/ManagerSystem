using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace ManagerSystem
{
    public partial class QuanLyCuocGoi : System.Web.UI.Page
    {
        ConnectDB connDB = new ConnectDB();
        OleDbConnection connOLE;
        SqlConnection conn;
        SqlCommand cmd;
        OleDbCommand cmdOLE;
        SqlDataReader dr;
        OleDbDataReader drOLE;
        DataSet ds;
        SqlDataAdapter da;
        OleDbDataAdapter daOLE;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txtDba.Text = "";
            txtDC.Text = "";
            txtKH.Text = "";
            txtNgGoi.Text = "";
            txtPhuong.Text = "";
            txtQuan.Text = "";
            txtSDT.Text = "";
            txtNoiDung.Text = "";
            txtPhanHoi.Text="";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            connDB = new ConnectDB();
            conn = connDB.connectBK();
            conn.Open();
            cmd = new SqlCommand("select KH as kh, DC as dc from SoDBo_Table where DB='"+txtDba.Text+"'", conn);
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                txtKH.Text = dr["kh"].ToString();
                txtDC.Text = dr["dc"].ToString();
            }
            conn.Close();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string fullname = grvCuocGoi.SelectedRow.Cells[3].Text.Substring(0, (grvCuocGoi.SelectedRow.Cells[3].Text.Length) - 5);

            conn = connDB.connectGhiAm();
            conn.Open();
            //cmd = new SqlCommand("insert into thongtin_cuocgoi (ten_nguoi_goi,sdt,thoi_gian_goi_toi,noi_dung_cuoc_goi,dbo,so_nha,quan,phuong,khach_hang,nhom_noi_dung,noi_dung_phan_hoi,fullkey) values (N'" + txtNgGoi.Text + "','" + txtSDT.Text + "','" + grvCuocGoi.SelectedRow.Cells[0].Text + "',N'" + txtNoiDung.Text + "','" + txtDba.Text + "','" + txtDC.Text + "','" + txtQuan.Text + "','" + txtPhuong.Text + "','" + txtKH.Text + "',N'" + dropNhomTT.Text + "',N'" + txtPhanHoi.Text + "','" + DateTime.Now.Year + "" + DateTime.Now.Month.ToString("00") + "" + DateTime.Now.Day.ToString("00") + "" + txtSDT.Text + "')", conn);
            cmd = new SqlCommand("insert into thongtin_cuocgoi (ten_nguoi_goi,sdt,thoi_gian_goi_toi,noi_dung_cuoc_goi,dbo,so_nha,quan,phuong,khach_hang,nhom_noi_dung,noi_dung_phan_hoi,fullkey) values (N'" + txtNgGoi.Text + "','" + txtSDT.Text + "',convert(date,'" + grvCuocGoi.SelectedRow.Cells[0].Text + "',103),N'" + txtNoiDung.Text + "','" + txtDba.Text + "','" + txtDC.Text + "','" + txtQuan.Text + "','" + txtPhuong.Text + "','" + txtKH.Text + "',N'" + dropNhomTT.Text + "',N'" + txtPhanHoi.Text + "','" + fullname + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            clear();
            //Response.Write("<script>alert('"+fullname+"')</script>");
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnThongke_Click(object sender, EventArgs e)
        {
            conn = connDB.connectGhiAm();
            conn.Open();
            cmd = new SqlCommand("select ten_nguoi_goi as 'Người gọi',sdt,noi_dung_cuoc_goi as 'Nội dung',noi_dung_phan_hoi as 'Phản hồi' from thongtin_cuocgoi where Thoi_Gian_Goi_Toi between CONVERT(date,'"+txtTuNgay.Value+"',103) and CONVERT(date,'"+txtDenNgay.Value+"',103)", conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "thongtin_cuocgoi");
            grvTimKiem.DataSource = ds.Tables["thongtin_cuocgoi"];
            grvTimKiem.DataBind();
            conn.Close();

        }

        protected void grvCuocGoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSDT.Text = grvCuocGoi.SelectedRow.Cells[1].Text;
            Nhaplieu.Visible = true;
        }

        protected void btnSort1_Click(object sender, EventArgs e)
        {
           
                connOLE = connDB.connectIndex();
                connOLE.Open();
                cmdOLE = new OleDbCommand("select top 10 [time],dtmf,type,fullname from Record where chnl = '05' order by time desc", connOLE);
                cmdOLE.ExecuteNonQuery();
                daOLE = new OleDbDataAdapter(cmdOLE);
                ds = new DataSet();
                daOLE.Fill(ds, "Record");
                grvCuocGoi.DataSource = ds.Tables[0];
                grvCuocGoi.DataBind();
                connOLE.Close();
           
        }
    }
}