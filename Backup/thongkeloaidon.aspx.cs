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
    public partial class thongkeloaidon : System.Web.UI.Page
    {
        SqlConnection con;
        ConnectDB connect = new ConnectDB();
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public SqlDataReader loadData(string sql)
        {
            con = connect.connectSQL_Bang_Ke_Dieu_Chinh();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            return dr;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((loadData("select count(*) from dbo.DKN_Table1 where LDon = 'KN' and BPYeuCau = '01- Khách hàng' and NNDon between convert(varchar(10),'" + txtTuNgay.Text + "',105) and convert(varchar(10),'" + txtDenNgay.Text + "',105)")).Read())
            {
                lblDKN.Text = dr[0].ToString();
                con.Close();
            }

            if (loadData("select count(a.DBo) from [Bang_Ke_Dieu_Chinh].[dbo].[DKN_Table1] a join [Giai_Quyet_Don].[dbo].[ChuyenBanDoi_Table] b on a.MaSNDon = b.MaSNDon where LDon = 'KN' and BPYeuCau = '01- Khách hàng' and NNDon between convert(varchar(10),'" + txtTuNgay.Text + "',105) and convert(varchar(10),'" + txtDenNgay.Text + "',105) ").Read())
            {
                int a;
                a = int.Parse(lblDKN.Text) - int.Parse(dr[0].ToString());
                lblDonChuyenPBD.Text = a.ToString();
                con.Close();
            }

            if (loadData("select count(*) from dbo.DKN_Table1 where LDon = 'DC' and NhomKN like '04%' and NNDon between convert(varchar(10),'" + txtTuNgay.Text + "',105) and convert(varchar(10),'" + txtDenNgay.Text + "',105)or LDon = 'DC' and NhomKN like '05%' and NNDon between convert(varchar(10),'" + txtTuNgay.Text + "',105) and convert(varchar(10),'" + txtDenNgay.Text + "',105)").Read())
            {
                lblSTDM.Text = dr[0].ToString();
                con.Close();
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}