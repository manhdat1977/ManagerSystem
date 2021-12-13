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
    public partial class vungdma : System.Web.UI.Page
    {
        SqlConnection connect;
        ConnectDB dbconnect = new ConnectDB();
        DataRow dr;
        SqlCommand cmd;
        ds_KTV_DMA ds;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadKy();
                loadNam();
                ReportToolbar1.Visible = false;
                ReportViewer1.Visible = false;
                if (Info()["p"].ToString() == "Admin" || Info()["p"].ToString() == "TP" || Info()["p"].ToString() == "TT")
                {
                    divListKTV.Visible = true;
                }
                else if (Info()["p"].ToString() == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    divListKTV.Visible = false;
                }
                loaddata_todropdown();
            }
            ac.CapNhatTruycap(4, Info()["USER_ID"].ToString());
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        public void loadKy()
        {
            for (int i = 1; i <= 12; i++)
            {
                dropKy.Items.Add(i.ToString());
            }
        }
        public void loadNam()
        {
            for (int y = DateTime.Now.Year-1; y <= DateTime.Now.Year; y++)
            {
                dropNam.Items.Add(y.ToString());
            }
        }
        public DropDownList data(string query, string text, string value, DropDownList dropname)
        {
            connect = dbconnect.connectSQL();
            //----Mở----//
            connect.Open();
            dt = new DataTable();
            da = new SqlDataAdapter(query, connect);
            da.Fill(dt);
            dropname.DataSource = dt;
            dropname.DataTextField = text;
            dropname.DataValueField = value;
            dropname.DataBind();
            //---Đóng---//
            connect.Close();
            return dropname;
        }
        protected void loaddata_todropdown()
        {

            connect = dbconnect.connectSQL();
            connect.Open();
            cmd = new SqlCommand("select [username] as a,[fullname] as b from quanlynguoidung where permission = 'KTV'", connect);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dropKTV.DataSource = dt;
            dropKTV.DataBind();
            dropKTV.DataTextField = "b";
            dropKTV.DataValueField = "a";
            dropKTV.DataBind();
            dropKTV.Items.Insert(0, new ListItem("Chọn kiểm tra viên..."));
            connect.Close();
        }
        public void showData()
        {
            string namestore;
            if (Info()["p"].ToString() == "Admin" || Info()["p"].ToString() == "TP" || Info()["p"].ToString() == "TT")
            {
                namestore = "proc_KTV_" + dropKTV.Text;
            }
            else
            {
                namestore = "proc_KTV_" + Info()["USER_ID"].ToString();
            }
            string chuoi1 = "HD_" + dropKy.Text + dropNam.Text;
            int kytruoc;
            string chuoi2;
            int namtruoc;
            if (dropKy.Text == "1")
            {
                namtruoc = int.Parse(dropNam.Text)-1;
                kytruoc = 12;
                chuoi2 = "HD_" + kytruoc.ToString() +namtruoc.ToString();
            }
            else
            {
                namtruoc = int.Parse(dropNam.Text);
                kytruoc = int.Parse(dropKy.Text) - 1;
                chuoi2 = "HD_" + kytruoc.ToString() + namtruoc.ToString();
            }
            //kyhoadon khd = new kyhoadon();
            //string hd = null;
            //string hd_2 = null;
            //int kysau = int.Parse(dropMonth.Text) - 1;
            //hd = khd.hoadon = "HD_" + dropMonth.Text + dropYear.Text;
            //hd_2 = khd.hoadon = "HD_" + kysau.ToString() + dropYear.Text;
            connect = dbconnect.connectDMA();
            if (connect.State != ConnectionState.Open)
            {
                connect.Open();
            }
            cmd = new SqlCommand(namestore.ToString(), connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tablename", chuoi1.ToString());
            cmd.Parameters.AddWithValue("@tablename_2", chuoi2.ToString());
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("update tonghopKTV set ID=N'I/ Kết quả thực hiện kỳ " + dropKy.Text + " năm " + dropNam.Text + "' where ID ='1'", connect);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("update tonghopKTV set ID=N'II/ So sánh kỳ " + dropKy.Text + " năm " + dropNam.Text + " với kỳ " + kytruoc.ToString() + " năm " + namtruoc.ToString() + "'  where ID ='2'", connect);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter("select vungDMA,SLDHN,DM,tieuthu,tiennuoc,GBBQ,round(TyleTTN_KT,2) as TyleTTN_KT,ID,SH,KD,SX,HCSN from tonghopKTV order by VungDMA", connect);
            ds = new ds_KTV_DMA();
            da.Fill(ds, "tonghopKTV");
            rp_KTV_DMA rpt = new rp_KTV_DMA();
            ReportViewer1.Report = rpt;
            rpt.DataSource = ds.Tables["tonghopKTV"];
            //da.Fill(ds, "dt_TongHopDMA");
            //datalist.DataSource = ds.Tables["dt_TongHopDMA"];
            //datalist.DataBind();
            ReportToolbar1.Visible = true;
            ReportViewer1.Visible = true;
            connect.Close();
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {         
            showData();
        }
    }
}