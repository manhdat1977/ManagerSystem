using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ManagerSystem.Prop;
namespace ManagerSystem
{
    public partial class duyethoso : System.Web.UI.Page
    {
        GiaiQuyetDon objdkn = new GiaiQuyetDon();
        DuyetHoSo objDuyetHS = new DuyetHoSo();
        DataTable dt = new DataTable();
        HoSoKiemTra objhskt = new HoSoKiemTra();
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                divcontent.Visible = false;
            }
        }

        public string NguoiDuyet()
        {
            HttpCookie reqCookies = Request.Cookies["userinfo"];
            string nguoiduyet = reqCookies["USER_ID"].ToString();
            return nguoiduyet;
        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            txtSearchDbo.Text = "";
            LoadDuyet();
        }
        public void LoadDuyet()
        {
            gridChuaDuyet.Visible = false;
            gridDuyet.Visible = true;
            divcontent.Visible = false;
            //objDuyetHS.NguoiDuyet = Session["USER_ID"].ToString();
            objDuyetHS.NguoiDuyet = NguoiDuyet();
            dt = objDuyetHS.GetAll_CheckFile(objDuyetHS);
            gridDuyet.DataSource = dt;
            gridDuyet.DataBind();
            btnSearch.Visible = true;
            txtSearchDbo.Visible = true;
            btnSearchChuaDuyet.Visible = false;
        }
        public void LoadChuaDuyet()
        {
            gridChuaDuyet.Visible = true;
            gridDuyet.Visible = false;
            divcontent.Visible = true;
            //objDuyetHS.NguoiDuyet = Session["USER_ID"].ToString();
            objDuyetHS.NguoiDuyet = NguoiDuyet();
            dt = objDuyetHS.GetAll_UnCheckFile(objDuyetHS);
            gridChuaDuyet.DataSource = dt;
            gridChuaDuyet.DataBind();
            divcontent.Visible = true;
            btnSearchChuaDuyet.Visible = true;
            txtSearchDbo.Visible = true;
            btnSearch.Visible = false;
            divcontent.Visible = true;
        }
        protected void btnChuaDuyet_Click(object sender, EventArgs e)
        {
            txtSearchDbo.Text = "";
            LoadChuaDuyet();
        }
        public void GetImageToGrid()
        {
            conn = condb.connect_KhoHoSo();
            conn.Open();
            DateTime ncbiennhan = DateTime.Parse(txtNgayCapBN.Text);
            string maHS = txtDba.Text + "" + ncbiennhan.ToString("dd/MM/yyyy") + "" + txtSoDon.Text + "" + txtLDon.Text;
            objhskt.MaSNDon = maHS;
            dt = objhskt.GetAllTable(objhskt);
            gridImage.DataSource = dt;
            gridImage.DataBind();
            conn.Close();
        }
        protected void gridChuaDuyet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                objdkn.MaSNDon = Convert.ToString(gridChuaDuyet.DataKeys[rowIndex].Values[0]);
                txtID.Text = objdkn.MaSNDon;
                dt = new DataTable();
                dt = objdkn.FindMaSoDon(objdkn);
                txtDba.Text = dt.Rows[0]["Dbo"].ToString();
                txtSoDon.Text = dt.Rows[0]["SDon"].ToString();
                txtLDon.Text = dt.Rows[0]["LDon"].ToString().ToUpper();
                txtNgayCapBN.Text = dt.Rows[0]["NgayNhanDon"].ToString().Substring(0, 10);
                txtKH.Text = dt.Rows[0]["KHang"].ToString();
                txtDC.Text = dt.Rows[0]["DChi"].ToString();
                txtNoidungDon.Text = dt.Rows[0]["NDKNai"].ToString();
                txtNDBienBan.Text = dt.Rows[0]["TTin_KiemTra"].ToString();
                txtDeXuat.Text = dt.Rows[0]["YeuCauDeXuat"].ToString();
                GetImageToGrid();
            }
        }
        public void ClearText()
        {
            txtDba.Text = "";
            txtDC.Text = "";
            txtID.Text = "";
            txtKH.Text = "";
            txtDeXuat.Text = "";
            txtLDon.Text = "";
            txtNDBienBan.Text = "";
            txtNDXuLy.Text = "";
            txtNgayCapBN.Text = "";
            txtNoidungDon.Text = "";
            txtSoDon.Text = "";
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            objDuyetHS.MaSNDon = txtID.Text;
            objDuyetHS.NoiDung = txtNDXuLy.Text;
            int i = objDuyetHS.UpdateContentFile(objDuyetHS);
            if(i>0)
            {
                LoadChuaDuyet();
                ClearText();
            }
            else
            {

            }
        }

        protected void gridChuaDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridChuaDuyet.PageIndex = e.NewPageIndex;
            this.LoadChuaDuyet();
        }

        protected void gridDuyet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDuyet.PageIndex = e.NewPageIndex;
            this.LoadDuyet();
        }
         
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchDbo.Text!="")
            {
                gridChuaDuyet.Visible = false;
                gridDuyet.Visible = true;
                divcontent.Visible = false;
                //objDuyetHS.NguoiDuyet = Session["USER_ID"].ToString();
                objDuyetHS.NguoiDuyet = NguoiDuyet();
                objDuyetHS.MaSNDon = txtSearchDbo.Text;
                dt = objDuyetHS.Filter_Dbo_CheckFile(objDuyetHS);
                gridDuyet.DataSource = dt;
                gridDuyet.DataBind();
                btnSearch.Visible = true;
                txtSearchDbo.Visible = true;
                btnSearchChuaDuyet.Visible = false;
            }
            else
            {
                LoadDuyet();
            }
        }

        protected void btnSearchChuaDuyet_Click(object sender, EventArgs e)
        {
            if(txtSearchDbo.Text!="")
            {
                gridChuaDuyet.Visible = true;
                gridDuyet.Visible = false;
                divcontent.Visible = true;
                //objDuyetHS.NguoiDuyet = Session["USER_ID"].ToString();
                objDuyetHS.NguoiDuyet = NguoiDuyet();
                objDuyetHS.MaSNDon = txtSearchDbo.Text;
                dt = objDuyetHS.Filter_Dbo_UnCheckFile(objDuyetHS);
                gridChuaDuyet.DataSource = dt;
                gridChuaDuyet.DataBind();
                divcontent.Visible = true;
                btnSearchChuaDuyet.Visible = true;
                txtSearchDbo.Visible = true;
                btnSearch.Visible = false;
                divcontent.Visible = true;
            }
           else
            {
                LoadChuaDuyet();
            }
        }
    }
}