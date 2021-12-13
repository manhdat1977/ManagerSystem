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
    public partial class capnhatbiendong : System.Web.UI.Page
    {
        SoDBo objSDbo = new SoDBo();
        DKN objdkn = new DKN();
        SHKhau objSHKhau = new SHKhau();
        CMND objCMND = new CMND();
        LoaiChungTu objChungTu = new LoaiChungTu();
        DataTable dt;
        BKDC objbkdc = new BKDC();
        //string SoCTDKDM = null;
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string stDBo, stSoCTDK, stDC_ThuongTru, stHoTen, stCCCD, stCMND, stNgheo_CanNgheo, stLoai_CDM, stThoiHanTamTru, stDBo_CatDinhMuc, stPhong, stGhiChu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    TimDonKN_ID(id);
                    //UnBlockTextbox();
                    btnUpdate.Visible = true;
                    btnLuu.Visible = false;
                }
                txtNgayNhapDC.Text = DateTime.Now.ToString("dd/MM/yyyy");
                try
                {
                    txtNhanVienDC.Text = Info()["USER_ID"].ToString();
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
                //divSHK.Visible = false;
                //divSHK.Visible = false;
                //LoadDataToDropDown("proc_LoadLoaiDon", "LDon", dropLDon);
            }
        }
        private HttpCookie Info()
        {
            HttpCookie reqCookie = Request.Cookies["userinfo"];
            return reqCookie;
        }
        protected void txtNgayCapBN_TextChanged(object sender, EventArgs e)
        {
            //

        }
        public void LoadDataToDropDown(string namestore, string textfield, DropDownList dropdown)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            conn.Open();
            cmd = new SqlCommand(namestore, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            dropdown.DataTextField = textfield;
            dropdown.DataSource = dr;
            dropdown.DataBind();
            dropdown.SelectedIndex = 0;
            conn.Dispose();
            conn.Close();

        }
        public void ClearText()
        {
            txtDba.Text = "";
            txtSDon.Text = "";
            dropLDon.Text = "";
            txtNgayCapBN.Text = "";
            txtSoBK.Text = "";
            txtHieuLuc.Text = "";
            txtNgayInBK.Text = "";
            txtNhomTT.Text = "";
            txtMLT.Text = "";
            txtMNN.Text = "";
            txtMNNDC.Text = "";
            txtSDT.Text = "";
            txtKH.Text = "";
            txtKH_DC.Text = "";
            txtDCDatDH.Text = "";
            txtDCDatDH_DC.Text = "";
            txtDCTSo.Text = "";
            txtDCTSo_DC.Text = "";
            //txtDCTSo.Text = "";
            txtMST.Text = "";
            txtMST_DC.Text = "";
            txtGB.Text = "";
            txtGB_DC.Text = "";
            txtDM.Text = "";
            txtDM_DC.Text = "";
            txtSH.Text = "";
            txtSH_DC.Text = "";
            txtHCSN.Text = "";
            txtHCSN_DC.Text = "";
            txtSX.Text = "";
            txtSX_DC.Text = "";
            txtKD.Text = "";
            txtKD_DC.Text = "";
            txtDienGiai.Text = "";
            txtDMHN_DC.Text = "";
            grd_CanCuocCongDan.Visible = false;
        }
        public void FindDanhBa()
        {
            objSDbo.DB = txtDba.Text;
            dt = new DataTable();
            dt = objSDbo.dtDbo(objSDbo);
            txtMLT.Text = dt.Rows[0]["MaLT"].ToString();
            txtMNN.Text = dt.Rows[0]["MaNN"].ToString();
            txtSDT.Text = dt.Rows[0]["DThoai_SMS"].ToString();
            txtKH.Text = dt.Rows[0]["KH"].ToString();
            txtDCDatDH.Text = dt.Rows[0]["DC"].ToString();
            //txtDCTSo.Text = dt.Rows[0][""].ToString();
            txtMST.Text = dt.Rows[0]["MST"].ToString();
            txtGB.Text = dt.Rows[0]["GB"].ToString();
            txtDM.Text = dt.Rows[0]["DM"].ToString();
            txtSH.Text = dt.Rows[0]["SH"].ToString();
            txtHCSN.Text = dt.Rows[0]["CQ"].ToString();
            txtSX.Text = dt.Rows[0]["SX"].ToString();
            txtKD.Text = dt.Rows[0]["DV"].ToString();
        }
        public void FindMaSoNDon()
        {
            objdkn.danhba = txtDba.Text;
            objdkn.ngaynhandon = txtNgayCapBN.Text;
            objdkn.sodon = Convert.ToInt32(txtSDon.Text);
            objdkn.loaidon = dropLDon.Text;
            dt = new DataTable();
            dt = objdkn.FindMaSNDon(objdkn);
            txtNhomTT.Text = dt.Rows[0]["NhomKN"].ToString();
            txtMLT.Text = dt.Rows[0]["MLTrinh"].ToString();
            txtMNN.Text = dt.Rows[0]["MNNghe"].ToString();
            txtSDT.Text = dt.Rows[0]["DThoaiKH"].ToString();
            txtKH.Text = dt.Rows[0]["KHang"].ToString();
            txtDCDatDH.Text = dt.Rows[0]["DChi"].ToString();
            //txtDCTSo.Text = dt.Rows[0][""].ToString();
            lblNVNhanHS.Text = dt.Rows[0]["MaNV"].ToString();
            txtMST.Text = dt.Rows[0]["MSThue"].ToString();
            txtGB.Text = dt.Rows[0]["GBieu"].ToString();
            txtDM.Text = dt.Rows[0]["DMuc"].ToString();
            txtSH.Text = dt.Rows[0]["TLSHoat"].ToString();
            txtHCSN.Text = dt.Rows[0]["TLCQuan"].ToString();
            txtSX.Text = dt.Rows[0]["TLSXuat"].ToString();
            txtKD.Text = dt.Rows[0]["TLKDoanh"].ToString();

            lblMessage.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objbkdc.id = Convert.ToInt32(Request.QueryString["id"]);
            objbkdc.KHangDC = txtKH_DC.Text;
            objbkdc.DChiDC = txtKH_DC.Text;
            objbkdc.DChi_TruSoDC = txtDCTSo_DC.Text;
            objbkdc.MSThueDC = txtMST_DC.Text;
            objbkdc.GBieuDC = txtGB_DC.Text;
            objbkdc.TLSHoatDC = txtSH_DC.Text;
            objbkdc.TLCQuanDC = txtHCSN_DC.Text;
            objbkdc.TLSXuatDC = txtSX_DC.Text;
            objbkdc.TLKDoanhDC = txtKD_DC.Text;
            objbkdc.DMucDC = txtDM_DC.Text;
            objbkdc.MNNgheDC = txtMNNDC.Text;
            objbkdc.GChu = txtDienGiai.Text;
            objbkdc.InBD = chkInbienDong.Checked;
            objbkdc.MaNV = txtNhanVienDC.Text;
            objbkdc.DMuc_HoNgheoDC = txtDMHN_DC.Text;
            int i = objbkdc.UpdateBKDC(objbkdc);
            if(i > 0 )
            {
                MyFunction.MessageBox(this, "Cập nhật thành công");
                Response.Redirect("capnhatbiendong.aspx");
            }    
            else
            {
                MyFunction.MessageBox(this, "Cập nhật thất bại. Vui lòng kiểm tra lại");
            }    
        }

        //public void FindSHKhau()
        //{
        //    objSHKhau.Dbo = txtDba.Text;
        //    gridSHK.DataSource = objSHKhau.LoadSHK(objSHKhau);
        //    gridSHK.DataBind();
        //    gridSHK.Visible = true;
        //    object objnkdcap = objSHKhau.LoadSHK(objSHKhau).Compute("Sum(NKDCap)", string.Empty);
        //    txtTongNKDCap.Text = "Tổng nhân khẩu được cấp: " + objnkdcap.ToString();
        //    txtTongNKDCap.Visible = true;
        //}

        //protected void gridSHK_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {
        //        //int index = Convert.ToInt32(e.CommandArgument);
        //        //GridViewRow row = gridSHK.Rows[index];
        //        //objCMND.SoCTDKDM = row.Cells[4].Text;
        //        //lblSoCT.Text = row.Cells[4].Text;
        //        //Label l1 = gridSHK.SelectedRow.FindControl("lblMaCTDKDM") as Label;
        //        GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        //        HiddenField lbl = (HiddenField)row.FindControl("lblMaCTDKDM");
        //        objCMND.MaCTDKDM = lbl.Value;
        //        lblSoCT.Text = lbl.Value;
        //        //SoCTDKDM = lbl.Value;
        //        //int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        //Get the value of column from the DataKeys using the RowIndex.
        //        //string key = Convert.ToString(gridSHK.DataKeys[rowIndex].Values[0]);
        //        //string MaCT = key.Substring(16);
        //        //lblSoCT.Text = MaCT;
        //        //objCMND.SoCTDKDM = MaCT;
        //        if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
        //        {
        //            gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //            gridCMND.DataBind();
        //            gridCMND.Visible = true;
        //            divCMND.Visible = true;
        //        }
        //        else
        //        {
        //            objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
        //            gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //            gridCMND.DataBind();
        //            int columncount = gridCMND.Rows[0].Cells.Count;
        //            gridCMND.Rows[0].Cells.Clear();
        //            // GridView1.FooterRow.Cells.Clear();
        //            gridCMND.Rows[0].Cells.Add(new TableCell());
        //            gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
        //            gridCMND.Rows[0].Cells[0].Text = "No Records Found";
        //            gridCMND.Visible = true;
        //            divCMND.Visible = true;
        //        }
        //        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + lbl.Text + "')", true);
        //    }
        //    else if (e.CommandName == "AddNew")
        //    {

        //        GridViewRow frow = gridSHK.FooterRow;
        //        objSHKhau.Dbo = txtDba.Text;
        //        objSHKhau.DThoai = txtSDT.Text;
        //        objSHKhau.MaLoaiSo = ((DropDownList)frow.FindControl("dropLoaiChungtu")).Text;
        //        objSHKhau.QP = ((TextBox)frow.FindControl("txtQP")).Text;
        //        objSHKhau.SoCTDKDM = ((TextBox)frow.FindControl("txtSoCTDKDM")).Text;
        //        objSHKhau.TSNKhau = Convert.ToInt16(((TextBox)frow.FindControl("txtTSNKhau")).Text);
        //        objSHKhau.NKDCap = Convert.ToInt16(((TextBox)frow.FindControl("txtNKDCap")).Text);
        //        objSHKhau.SoPhong = ((TextBox)frow.FindControl("txtSoPhong")).Text;
        //        objSHKhau.GhiChu = ((TextBox)frow.FindControl("txtGChu")).Text;
        //        //objSHKhau.MaNV = Session["MaNhanVien"].ToString();
        //        objSHKhau.MaNV = Info()["USER_ID"].ToString();
        //        if (((TextBox)frow.FindControl("txtNgayHetHan")).Text == "")
        //        {
        //            objSHKhau.NgayHetHan = null;
        //        }
        //        else
        //        {
        //            objSHKhau.NgayHetHan = ((TextBox)frow.FindControl("txtNgayHetHan")).Text;
        //        }
        //        if (Convert.ToInt16(((TextBox)frow.FindControl("txtTSNKhau")).Text) < Convert.ToInt16(((TextBox)frow.FindControl("txtNKDCap")).Text))
        //        {
        //            lblStatus.Text = "Nhân khẩu được cấp không lớn hơn tổng số nhân khẩu";
        //            lblStatus.Visible = true;
        //            lblLink.Visible = false;
        //            linkSHK.Visible = false;
        //        }
        //        else
        //        {
        //            int inserted = objSHKhau.InsertSHK(objSHKhau);
        //            if (inserted > 0)
        //            {
        //                this.FindSHKhau();
        //            }
        //            else
        //            {
        //                linkSHK.HRef = "~/thongkeSHK.aspx?Id=" + ((TextBox)frow.FindControl("txtSoCTDKDM")).Text + "";
        //                lblLink.Text = "Sổ hộ khẩu đã cấp tại danh bạ khác. Click vào đây để kiểm tra";
        //                lblLink.Visible = true;
        //                linkSHK.Visible = true;
        //                lblStatus.Visible = false;
        //            }
        //        }
        //    }
        //    //else if (e.CommandName == "Delete")
        //    //{ 
        //    //GetID

        //    //int rowIndex = Convert.ToInt32(e.CommandArgument);
        //    //Get the value of column from the DataKeys using the RowIndex.
        //    //int id = Convert.ToInt32(gridSHK.DataKeys[rowIndex].Values[0]);
        //    //objSHKhau.ID = id;
        //    //objSHKhau.DelelteSHK(objSHKhau);

        //    //Control ctl = e.CommandSource as Control;
        //    //GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;
        //    //object objTemp = gridSHK.DataKeys[CurrentRow.RowIndex].Value as object;
        //    //if (objTemp != null)
        //    //{
        //    //    string id = objTemp.ToString();
        //    //    objSHKhau.ID = Convert.ToInt32(id);
        //    //    objSHKhau.DelelteSHK(objSHKhau);
        //    //    //Do your operations
        //    //    FindSHKhau();
        //    //}
        //    //}
        //}

        //protected void gridSHK_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gridSHK.PageIndex = e.NewPageIndex;
        //    this.FindSHKhau();
        //}

        //protected void gridCMND_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gridCMND.PageIndex = e.NewPageIndex;
        //    objCMND.MaCTDKDM = lblSoCT.Text;
        //    gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //    gridCMND.DataBind();
        //}
        ////public class ChungTu
        ////{
        ////    public string LoaiSo { get; set; }
        ////    public string ChuThich { get; set; }
        ////}
        //protected void dropLoaiChungtu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddl = sender as DropDownList;
        //    //TextBox chuthich = new TextBox();  
        //    //DataTable dt = new DataTable();
        //    //ChungTu ct = new ChungTu();
        //    Control ctrl = gridSHK.FooterRow.FindControl("dropLoaiChungtu") as DropDownList;
        //    if (ctrl != null)
        //    {
        //        DropDownList dropchungtu = (DropDownList)ctrl;
        //        if (ddl.ClientID == dropchungtu.ClientID)
        //        {
        //            TextBox chuthich = gridSHK.FooterRow.FindControl("txtChuThich") as TextBox;
        //            objChungTu._LoaiChungTu = dropchungtu.SelectedValue;
        //            dt = objChungTu.LoadChuThich(objChungTu);
        //            chuthich.Text = dt.Rows[0][0].ToString();
        //        }
        //    }

        //}

        //protected void gridSHK_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        Control ctrl = e.Row.FindControl("dropLoaiChungtu");
        //        Control text = e.Row.FindControl("txtChuThich");
        //        if (ctrl != null)
        //        {
        //            DropDownList dd = ctrl as DropDownList;
        //            //SqlConnection conn = new SqlConnection(connStr);
        //            dt = new DataTable();
        //            dt = objChungTu.LoadLoaiChungTu();
        //            dd.DataTextField = "LoaiChungTu";
        //            dd.DataValueField = "LoaiChungTu";
        //            dd.DataSource = dt;
        //            dd.DataBind();
        //            //dd.Items.Insert(0,"--Chọn loại sổ--");
        //            if (text != null)
        //            {
        //                TextBox chuthich = text as TextBox;
        //                objChungTu._LoaiChungTu = dd.SelectedValue;
        //                dt = objChungTu.LoadChuThich(objChungTu);
        //                chuthich.Text = dt.Rows[0][0].ToString();
        //            }
        //        }

        //    }
        //}

        //protected void gridSHK_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int id = (int)gridSHK.DataKeys[e.RowIndex].Value;
        //    objSHKhau.ID = Convert.ToInt32(id);
        //    objSHKhau.DelelteSHK(objSHKhau);
        //    FindSHKhau();
        //}

        //protected void gridCMND_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "AddNewCMND")
        //    {
        //        HttpCookie reqCookies = Request.Cookies["userinfo"];
        //        GridViewRow frow = gridCMND.FooterRow;
        //        objCMND.MaCTDKDM = lblSoCT.Text;
        //        objCMND.LoaiCMND = ((DropDownList)frow.FindControl("dropLoaiCMND")).Text;
        //        objCMND.SoCMND = ((TextBox)frow.FindControl("txtCMND")).Text;
        //        objCMND.KhongCMND = ((CheckBox)frow.FindControl("chkKhongCMND")).Checked;
        //        objCMND.SoPhong = ((TextBox)frow.FindControl("txtSoPhong")).Text;
        //        objCMND.GhiChu = ((TextBox)frow.FindControl("txtGhiChu")).Text;
        //        objCMND.MaNV = reqCookies["USER_ID"].ToString();
        //        int inserted = objCMND.InsertCMND(objCMND);
        //        if (inserted > 0)
        //        {
        //            objCMND.MaCTDKDM = lblSoCT.Text;

        //            //int rowIndex = Convert.ToInt32(e.CommandArgument);
        //            //Get the value of column from the DataKeys using the RowIndex.
        //            //string key = Convert.ToString(gridSHK.DataKeys[rowIndex].Values[0]);
        //            //string MaCT = key.Substring(16);
        //            //lblSoCT.Text = MaCT;
        //            //objCMND.SoCTDKDM = MaCT;
        //            if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
        //            {
        //                gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //                gridCMND.DataBind();
        //                gridCMND.Visible = true;
        //            }
        //            else
        //            {
        //                objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
        //                gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //                gridCMND.DataBind();
        //                int columncount = gridCMND.Rows[0].Cells.Count;
        //                gridCMND.Rows[0].Cells.Clear();
        //                //gridview1.footerrow.cells.clear();
        //                gridCMND.Rows[0].Cells.Add(new TableCell());
        //                gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
        //                gridCMND.Rows[0].Cells[0].Text = "no records found";
        //                gridCMND.Visible = true;
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //}

        //protected void gridCMND_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    objCMND.SoCMND = (string)gridCMND.DataKeys[e.RowIndex].Value;
        //    objCMND.DeleteCMND(objCMND);
        //    objCMND.MaCTDKDM = lblSoCT.Text;
        //    if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
        //    {
        //        gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //        gridCMND.DataBind();
        //        gridCMND.Visible = true;
        //    }
        //    else
        //    {
        //        objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
        //        gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
        //        gridCMND.DataBind();
        //        int columncount = gridCMND.Rows[0].Cells.Count;
        //        gridCMND.Rows[0].Cells.Clear();
        //        // GridView1.FooterRow.Cells.Clear();
        //        gridCMND.Rows[0].Cells.Add(new TableCell());
        //        gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
        //        gridCMND.Rows[0].Cells[0].Text = "No Records Found";
        //        gridCMND.Visible = true;
        //    }
        //}

        protected void btnThongTinGQD_Click(object sender, EventArgs e)
        {
            Response.Redirect("lichsukiemtra.aspx?id=" + txtDba.Text + "");
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            objbkdc.MaSNDon = txtDba.Text + "" + txtNgayCapBN.Text + "" + txtSDon.Text + "" + dropLDon.Text;
            objbkdc.Dbo = txtDba.Text;
            objbkdc.SDon = txtSDon.Text;
            objbkdc.LDon = dropLDon.Text;
            objbkdc.NNDon = txtNgayCapBN.Text;
            objbkdc.NhomKN = txtNhomTT.Text;
            objbkdc.DThoai = txtSDT.Text;
            objbkdc.Dot = int.Parse(txtMLT.Text.Substring(0, 2));
            objbkdc.MLTrinh = txtMLT.Text;
            objbkdc.KHang = txtKH.Text;
            objbkdc.DChi = txtKH.Text;
            objbkdc.DChi_TruSo = txtDCTSo.Text;
            objbkdc.MSThue = txtMST.Text;
            objbkdc.GBieu = txtGB.Text;
            objbkdc.TLSHoat = int.Parse(txtSH.Text);
            objbkdc.TLCQuan = int.Parse(txtHCSN.Text);
            objbkdc.TLSXuat = int.Parse(txtSX.Text);
            objbkdc.TLKdoanh = int.Parse(txtKD.Text);
            objbkdc.DMuc = int.Parse(txtDM.Text);
            objbkdc.KHangDC = txtKH_DC.Text;
            objbkdc.DChiDC = txtKH_DC.Text;
            objbkdc.DChi_TruSoDC = txtDCTSo_DC.Text;
            objbkdc.MSThueDC = txtMST_DC.Text;

            objbkdc.GBieuDC = txtGB_DC.Text;
            objbkdc.TLSHoatDC = txtSH_DC.Text;
            objbkdc.TLCQuanDC = txtHCSN_DC.Text;
            objbkdc.TLSXuatDC = txtSX_DC.Text;
            objbkdc.TLKDoanhDC = txtKD_DC.Text;
            objbkdc.DMucDC = txtDM_DC.Text;

            objbkdc.MNNghe = txtMNN.Text;
            objbkdc.MNNgheDC = txtMNNDC.Text;
            objbkdc.GChu = txtDienGiai.Text;
            objbkdc.InBD = chkInbienDong.Checked;
            objbkdc.MaNV = Info()["USER_ID"].ToString();
            objbkdc.CatDMTrung = chkCatDMTrung.Checked;
            objbkdc.DMuc_HoNgheo = txtDMHN.Text;
            objbkdc.DMuc_HoNgheoDC = txtDMHN_DC.Text;
            objbkdc.NVNhanHS = lblNVNhanHS.Text;
            try
            {
                int i = objbkdc.InsertBKDC(objbkdc);
                if (i > 1)
                {
                    ClearText();
                    lblMessage.Text = "Thêm dữ liệu thành công";
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Thêm dữ liệu thất bại";
                    lblMessage.Visible = true;
                }
            }
            catch
            {
                MyFunction.MessageBox(this, "Danh bạ và số đơn này đã được nhập. Vui lòng kiểm tra lại");
            }
            
        }
        void Bind_grd_CanCuocCongDan()
        {
            SqlConnection _conn = new SqlConnection("data source=192.168.23.66;Initial catalog=ChamSocKhachHang; User Id=Admin; Password=Kh0ngBi3t");
            _conn.Open();
            SqlCommand _cmd = new SqlCommand("[Proc_SelectCCCD]", _conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dbo", txtDba.Text);
            DataTable _dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_dt);
            if (_dt.Rows.Count > 0)
            {
                grd_CanCuocCongDan.DataSource = _dt;
                grd_CanCuocCongDan.DataBind();
                grd_CanCuocCongDan.Rows[0].Visible = true;
            }
            else
            {
                _dt.Rows.Add(_dt.NewRow());
                grd_CanCuocCongDan.DataSource = _dt;
                grd_CanCuocCongDan.DataBind();
                grd_CanCuocCongDan.Rows[0].Visible = false;
            }

            _conn.Close();
        }

        protected void grd_CanCuocCongDan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            stDBo = txtDba.Text;
            stSoCTDK = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("SoCTDK")).Text;
            stDC_ThuongTru = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("DC_ThuongTru")).Text;
            stHoTen = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("HoTen")).Text;
            stCCCD = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("CCCD")).Text;
            stCMND = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("CMND")).Text;
            stNgheo_CanNgheo = ((DropDownList)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("Ngheo_CanNgheo")).SelectedValue;
            stLoai_CDM = ((DropDownList)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("Loai_CDM")).SelectedValue;
            stThoiHanTamTru = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("ThoiHanTamTru")).Text;
            stDBo_CatDinhMuc = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("DBo_CatDinhMuc")).Text;
            stPhong = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("Phong")).Text;
            stGhiChu = ((TextBox)grd_CanCuocCongDan.Rows[e.RowIndex].FindControl("GhiChu")).Text;
            if ((stCCCD == "" && stCMND == "") || (stDBo == "") || (stNgheo_CanNgheo == "") || (stLoai_CDM == ""))
            {
                MyFunction.MessageBox(this, "Ô <Danh bạ>, <Căn cước>, <Chứng minh>, <Hộ nghèo>, <Loại cấp ĐM> không được trống");
                return;
            }
            if (stLoai_CDM == "2" && stThoiHanTamTru == "")
            {
                MyFunction.MessageBox(this, "Thời hạn tạm trú phải nhập khi loại cấp ĐM là 2");
                return;
            }
            if (stLoai_CDM == "3" && stDBo_CatDinhMuc == "")
            {
                MyFunction.MessageBox(this, "Danh bạ cắt ĐM phải nhập khi loại cấp ĐM là 3");
                return;
            }
            SqlConnection _conn = new SqlConnection("data source=192.168.23.66;Initial catalog=ChamSocKhachHang; User Id=Admin; Password=Kh0ngBi3t");
            _conn.Open();
            //string query = "EXEC [Proc_UpdateCCCD] " + e.Keys["ID"].ToString() + ",'" + stDBo.ToString() + "','" + stSoCTDK.ToString() + "','" + stThoiHanTamTru.ToString() + "','" + stDBo_CatDinhMuc.ToString() + "','" + stDC_ThuongTru.ToString() + "','" + stHoTen.ToString() + "','" + stCCCD.ToString() + "','" + stCMND.ToString() + "','" + stPhong.ToString() + "','" + stGhiChu.ToString() + "','" + stNgheo_CanNgheo.ToString() + "','" + stLoai_CDM.ToString() + "'";
            SqlCommand _cmd = new SqlCommand("[Proc_UpdateCCCD]", _conn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@ID", e.Keys["ID"].ToString());
            _cmd.Parameters.AddWithValue("@DBo", txtDba.Text);
            _cmd.Parameters.AddWithValue("@SoCTDK", stSoCTDK.ToString());
            _cmd.Parameters.AddWithValue("@ThoiHanTamTru", stThoiHanTamTru.ToString());
            _cmd.Parameters.AddWithValue("@DBo_CatDinhMuc", stDBo_CatDinhMuc.ToString());
            _cmd.Parameters.AddWithValue("@DC_ThuongTru", stDC_ThuongTru.ToString());
            _cmd.Parameters.AddWithValue("@HoTen", stHoTen.ToString());
            _cmd.Parameters.AddWithValue("@CCCD", stCCCD.ToString());
            _cmd.Parameters.AddWithValue("@CMND", stCMND.ToString());
            _cmd.Parameters.AddWithValue("@Phong", stPhong.ToString());
            _cmd.Parameters.AddWithValue("@GhiChu", stGhiChu.ToString());
            _cmd.Parameters.AddWithValue("@Ngheo_CanNgheo", stNgheo_CanNgheo.ToString());
            _cmd.Parameters.AddWithValue("@Loai_CDM", stLoai_CDM.ToString());
            _cmd.Parameters.AddWithValue("@MaNV",txtNhanVienDC.Text );
            DataTable _dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_dt);
            _conn.Close();
            if (_dt.Rows[0]["RecCapNhat"].ToString() == "0")
            {
                string ThongBao = "";
                if (_dt.Rows[0]["ID_CCCD"].ToString() != "0") { ThongBao = "Căn cước công dân đã được cấp cho danh bạ: " + _dt.Rows[0]["DB_CCCD"].ToString() + "\\n"; }
                if (_dt.Rows[0]["ID_CMND"].ToString() != "0") { ThongBao = ThongBao + "Chứng minh nhân dân đã được cấp cho danh bạ: " + _dt.Rows[0]["DB_CMND"].ToString(); }
                MyFunction.MessageBox(this, "Không cập nhật được do trùng dữ liệu:\\n" + ThongBao.ToString());
            }
            else { Bind_grd_CanCuocCongDan(); return; }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            stDBo = txtDba.Text;
            stSoCTDK = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtSoCTDK")).Text;
            stDC_ThuongTru = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtDC_ThuongTru")).Text;
            stHoTen = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtHoTen")).Text;
            stCCCD = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtCCCD")).Text;
            stCMND = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtCMND")).Text;
            stNgheo_CanNgheo = ((DropDownList)grd_CanCuocCongDan.FooterRow.FindControl("txtNgheo_CanNgheo")).SelectedValue;
            stLoai_CDM = ((DropDownList)grd_CanCuocCongDan.FooterRow.FindControl("txtLoai_CDM")).SelectedValue;
            stThoiHanTamTru = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtThoiHanTamTru")).Text;
            stDBo_CatDinhMuc = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtDBo_CatDinhMuc")).Text;
            stPhong = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtPhong")).Text;
            stGhiChu = ((TextBox)grd_CanCuocCongDan.FooterRow.FindControl("txtGhiChu")).Text;
            if ((stCCCD == "" && stCMND == "") || (stDBo == "") || (stNgheo_CanNgheo == "") || (stLoai_CDM == ""))
            {
                MyFunction.MessageBox(this, "Ô <Danh bạ>, <Căn cước>, <Chứng minh>, <Hộ nghèo>, <Loại cấp ĐM> không được trống");
                return;
            }
            if (stLoai_CDM == "2" && stThoiHanTamTru == "")
            {
                MyFunction.MessageBox(this, "Thời hạn tạm trú phải nhập khi loại cấp ĐM là 2");
                return;
            }
            if (stLoai_CDM == "3" && stDBo_CatDinhMuc == "")
            {
                MyFunction.MessageBox(this, "Danh bạ cắt ĐM phải nhập khi loại cấp ĐM là 3");
                return;
            }
            SqlConnection _conn = new SqlConnection("data source=192.168.23.66;Initial catalog=ChamSocKhachHang; User Id=Admin; Password=Kh0ngBi3t");
            _conn.Open();
            string query = "EXEC [Proc_BoSungCCCD] '" + stDBo.ToString() + "','" + stSoCTDK.ToString() + "','" + stThoiHanTamTru.ToString() + "','" + stDBo_CatDinhMuc.ToString() + "','" + stDC_ThuongTru.ToString() + "','" + stHoTen.ToString() + "','" + stCCCD.ToString() + "','" + stCMND.ToString() + "','" + stPhong.ToString() + "','" + stGhiChu.ToString() + "','" + stNgheo_CanNgheo.ToString() + "','" + stLoai_CDM.ToString() + "'";
            SqlCommand _cmd = new SqlCommand(query, _conn);
            DataTable _dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_dt);
            _conn.Close();
            if (_dt.Rows[0]["RecCapNhat"].ToString() == "0")
            {
                string ThongBao = "";
                if (_dt.Rows[0]["ID_CCCD"].ToString() != "0") { ThongBao = "Căn cước công dân đã được cấp cho danh bạ: " + _dt.Rows[0]["DB_CCCD"].ToString() + "\\n"; }
                if (_dt.Rows[0]["ID_CMND"].ToString() != "0") { ThongBao = ThongBao + "Chứng minh nhân dân đã được cấp cho danh bạ: " + _dt.Rows[0]["DB_CMND"].ToString(); }
                MyFunction.MessageBox(this, "Không bổ sung được do trùng dữ liệu:\\n" + ThongBao.ToString());
            }
            else { Bind_grd_CanCuocCongDan(); }
        }

        protected void grd_CanCuocCongDan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection _conn = new SqlConnection("data source=192.168.23.66;Initial catalog=ChamSocKhachHang; User Id=Admin; Password=Kh0ngBi3t");
            _conn.Open();
            string query = "EXEC [Proc_XoaCCCD] '" + e.Keys["ID"].ToString() + "','" + txtNhanVienDC.Text + "'";
            SqlCommand _cmd = new SqlCommand(query, _conn);
            int KetQua = (int)_cmd.ExecuteScalar();
            _conn.Close();
            if (KetQua == 0) { MyFunction.MessageBox(this, "Không cập nhật được dữ liệu"); } else { Bind_grd_CanCuocCongDan(); }
        }

        protected void btnThongTinBD_Click(object sender, EventArgs e)
        {
            Response.Redirect("lichsubiendong.aspx?id=" + txtDba.Text + "");
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            if (chkCatDMTrung.Checked == false)
            {
                try
                {
                    if (CheckMaSoNhanDon() > 0)
                    {
                        MyFunction.MessageBox(this, "Mã nhận đơn này đã được nhập. Vui lòng kiểm tra lại");
                    }

                    if (CheckDanhBaIsTrue() > 0)
                    {
                        MyFunction.MessageBox(this, "Danh bạ đang chờ in biến động. Vui lòng kiểm tra lại");
                    }
                    FindMaSoNDon();
                    lblMessage.Visible = false;
                    Bind_grd_CanCuocCongDan();

                    //FindSHKhau();
                    //divSHK.Visible = true;
                    //divSHK.Visible = true;

                }
                catch
                {
                    //lblMessage.Visible = true;
                    //lblMessage.Text = "* Sai thông tin nhận đơn. Vui lòng nhập lại!!!";
                    //ClearText();
                    //gridSHK.Visible = false;
                    //gridCMND.Visible = false;
                    FindDanhBa();
                    lblMessage.Visible = false;
                    Bind_grd_CanCuocCongDan();
                }
            }
            else
            {
                FindDanhBa();
                lblMessage.Visible = false;
                Bind_grd_CanCuocCongDan();

                //FindSHKhau();
                //divSHK.Visible = true;
                //divSHK.Visible = true;
            }
            Bind_grd_CanCuocCongDan();
        }

        //protected void SoCTDK_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stSoCTDK = ((TextBox)gvRow.FindControl("SoCTDK")).Text;
        //    gvRow.FindControl("DC_ThuongTru").Focus();
        //}

        //protected void DC_ThuongTru_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stDC_ThuongTru = ((TextBox)gvRow.FindControl("DC_ThuongTru")).Text;
        //    gvRow.FindControl("HoTen").Focus();
        //}

        //protected void HoTen_TextChanged(object sender, EventArgs e)
        //{
        //    //TextBox txt = (TextBox)sender;
        //    //GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    //stHoTen = ((TextBox)gvRow.FindControl("HoTen")).Text;
        //    //gvRow.FindControl("CCCD").Focus();
        //}

        //protected void CCCD_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stCCCD = ((TextBox)gvRow.FindControl("CCCD")).Text;
        //    gvRow.FindControl("CMND").Focus();
        //}

        //protected void CMND_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stCMND = ((TextBox)gvRow.FindControl("CMND")).Text;
        //    gvRow.FindControl("Ngheo_CanNgheo").Focus();
        //}

        //protected void Ngheo_CanNgheo_TextChanged(object sender, EventArgs e)
        //{
        //    DropDownList txt = (DropDownList)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stNgheo_CanNgheo = ((DropDownList)gvRow.FindControl("Ngheo_CanNgheo")).Text;
        //    gvRow.FindControl("Loai_CDM").Focus();
        //}

        //protected void Loai_CDM_TextChanged(object sender, EventArgs e)
        //{
        //    DropDownList txt = (DropDownList)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stLoai_CDM = ((DropDownList)gvRow.FindControl("Loai_CDM")).Text;
        //    gvRow.FindControl("ThoiHanTamTru").Focus();
        //}

        //protected void ThoiHanTamTru_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stThoiHanTamTru = ((TextBox)gvRow.FindControl("ThoiHanTamTru")).Text;
        //    gvRow.FindControl("DBo_CatDinhMuc").Focus();
        //}

        //protected void DBo_CatDinhMuc_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stDBo_CatDinhMuc = ((TextBox)gvRow.FindControl("DBo_CatDinhMuc")).Text;
        //    gvRow.FindControl("Phong").Focus();
        //}

        //protected void Phong_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    gvRow.FindControl("GhiChu").Focus();
        //}

        //protected void GhiChu_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    stGhiChu = ((TextBox)gvRow.FindControl("GhiChu")).Text;
        //}

        //protected void btnLuu_Click(object sender, EventArgs e)
        //
        //Bind_grd_CanCuocCongDan();
        //}

        public int CheckMaSoNhanDon()
        {
            string madon = txtDba.Text + "" + DateTime.Parse(txtNgayCapBN.Text).ToString("dd/MM/yyyy") + "" + txtSDon.Text + "" + dropLDon.Text;
            objbkdc.MaSNDon = madon;
            int i = objbkdc.CheckMaDon(objbkdc);
            return i;
        }

        public int CheckDanhBaIsTrue()
        {
            objbkdc.Dbo = txtDba.Text;
            int i = objbkdc.CheckDanhBaIsTrue(objbkdc);
            return i;
        }

        protected void TimDonKN_ID(int id)
        {
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_TimBKDC_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtNhomTT.Text = dr["NhomKN"].ToString();
                    txtMLT.Text = dr["MLTrinh"].ToString();
                    txtMNN.Text = dr["MNNghe"].ToString();
                    txtSDT.Text = dr["DThoai"].ToString();
                    txtKH.Text = dr["KHang"].ToString();
                    txtDCDatDH.Text = dr["DChi"].ToString();
                    //txtDCTSo.Text = dt.Rows[0][""].ToString();
                    lblNVNhanHS.Text = dr["MaNV"].ToString();
                    txtMST.Text = dr["MSThue"].ToString();
                    txtGB.Text = dr["GBieu"].ToString();
                    txtDM.Text = dr["DMuc"].ToString();
                    txtSH.Text = dr["TLSHoat"].ToString();
                    txtHCSN.Text = dr["TLCQuan"].ToString();
                    txtSX.Text = dr["TLSXuat"].ToString();
                    txtKD.Text = dr["TLKDoanh"].ToString();
                    txtDba.Text = dr["dbo"].ToString();
                    txtSDon.Text = dr["sdon"].ToString();
                    dropLDon.Text = dr["ldon"].ToString();
                    txtNgayCapBN.Text = DateTime.Parse(dr["NNDon"].ToString()).ToString("dd/MM/yyyy");
                    txtNhomTT.Text = dr["NhomKN"].ToString();
                    txtSoBK.Text = dr["SBKeBD"].ToString();
                    txtHieuLuc.Text = dr["HLucBD"].ToString();
                    txtNgayInBK.Text = dr["NgayInBK"].ToString();
                    txtMNNDC.Text = dr["MNNgheDC"].ToString();
                    txtDCTSo.Text = dr["DChi_TruSo"].ToString();
                    txtMST.Text = dr["MSThue"].ToString();
                    txtDMHN.Text = dr["DMuc_HoNgheo"].ToString();
                    txtSH.Text = dr["TLSHoat"].ToString();
                    txtKD.Text = dr["TLKDoanh"].ToString();
                    txtSX.Text = dr["TLSXuat"].ToString();
                    txtHCSN.Text = dr["TLCQuan"].ToString();
                    txtKH_DC.Text = dr["KHangDC"].ToString();
                    txtDCDatDH_DC.Text = dr["DChiDC"].ToString();
                    txtDCTSo_DC.Text = dr["DChi_TruSoDC"].ToString();
                    txtMST_DC.Text = dr["MSThueDC"].ToString();
                    txtGB_DC.Text = dr["GBieuDC"].ToString();
                    txtDMHN_DC.Text = dr["DMuc_HoNgheoDC"].ToString();
                    txtDM_DC.Text = dr["DMucDC"].ToString();
                    txtSH_DC.Text = dr["TLSHoatDC"].ToString();
                    txtSX_DC.Text = dr["TLSXuatDC"].ToString();
                    txtHCSN_DC.Text = dr["TLCQuanDC"].ToString();
                    txtKD_DC.Text = dr["TLKDoanhDC"].ToString();
                }
            }
            conn.Close();
        }
    }
}