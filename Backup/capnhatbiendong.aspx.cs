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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNgayNhapDC.Text = DateTime.Now.ToString("dd/MM/yyyy");
                try
                {
                    txtNhanVienDC.Text = Info()["USER_ID"].ToString();
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
                divSHK.Visible = false;
                divSHK.Visible = false;
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
            if(chkCatDMTrung.Checked==false)
            {
                try
                {
                    if (txtNgayCapBN.Text.Length == 10)
                    {
                        FindMaSoNDon();
                        lblMessage.Visible = false;
                        FindSHKhau();
                        divSHK.Visible = true;
                        divSHK.Visible = true;
                    }
                }
                catch
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "* Sai thông tin nhận đơn. Vui lòng nhập lại!!!";
                    ClearText();
                    gridSHK.Visible = false;
                    gridCMND.Visible = false;
                }
            }
            else
            {
                FindDanhBa();
                lblMessage.Visible = false;
                FindSHKhau();
                divSHK.Visible = true;
                divSHK.Visible = true;
            }
            
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
        public void FindSHKhau()
        {
            objSHKhau.Dbo = txtDba.Text;
            gridSHK.DataSource = objSHKhau.LoadSHK(objSHKhau);
            gridSHK.DataBind();
            gridSHK.Visible = true;
            object objnkdcap = objSHKhau.LoadSHK(objSHKhau).Compute("Sum(NKDCap)", string.Empty);
            txtTongNKDCap.Text = "Tổng nhân khẩu được cấp: " + objnkdcap.ToString();
            txtTongNKDCap.Visible = true;
        }

        protected void gridSHK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = gridSHK.Rows[index];
                //objCMND.SoCTDKDM = row.Cells[4].Text;
                //lblSoCT.Text = row.Cells[4].Text;
                //Label l1 = gridSHK.SelectedRow.FindControl("lblMaCTDKDM") as Label;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                HiddenField lbl = (HiddenField)row.FindControl("lblMaCTDKDM");
                objCMND.MaCTDKDM = lbl.Value;
                lblSoCT.Text = lbl.Value;
                //SoCTDKDM = lbl.Value;
                //int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                //string key = Convert.ToString(gridSHK.DataKeys[rowIndex].Values[0]);
                //string MaCT = key.Substring(16);
                //lblSoCT.Text = MaCT;
                //objCMND.SoCTDKDM = MaCT;
                if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
                {
                    gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                    gridCMND.DataBind();
                    gridCMND.Visible = true;
                    divCMND.Visible = true;
                }
                else
                {
                    objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
                    gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                    gridCMND.DataBind();
                    int columncount = gridCMND.Rows[0].Cells.Count;
                    gridCMND.Rows[0].Cells.Clear();
                    // GridView1.FooterRow.Cells.Clear();
                    gridCMND.Rows[0].Cells.Add(new TableCell());
                    gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
                    gridCMND.Rows[0].Cells[0].Text = "No Records Found";
                    gridCMND.Visible = true;
                    divCMND.Visible = true;
                }
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + lbl.Text + "')", true);
            }
            else if (e.CommandName == "AddNew")
            {
                
                GridViewRow frow = gridSHK.FooterRow;
                objSHKhau.Dbo = txtDba.Text;
                objSHKhau.DThoai = txtSDT.Text;
                objSHKhau.MaLoaiSo = ((DropDownList)frow.FindControl("dropLoaiChungtu")).Text;
                objSHKhau.QP = ((TextBox)frow.FindControl("txtQP")).Text;
                objSHKhau.SoCTDKDM = ((TextBox)frow.FindControl("txtSoCTDKDM")).Text;
                objSHKhau.TSNKhau = Convert.ToInt16(((TextBox)frow.FindControl("txtTSNKhau")).Text);
                objSHKhau.NKDCap = Convert.ToInt16(((TextBox)frow.FindControl("txtNKDCap")).Text);
                objSHKhau.SoPhong = ((TextBox)frow.FindControl("txtSoPhong")).Text;
                objSHKhau.GhiChu = ((TextBox)frow.FindControl("txtGChu")).Text;
                //objSHKhau.MaNV = Session["MaNhanVien"].ToString();
                objSHKhau.MaNV = Info()["USER_ID"].ToString();
                if (((TextBox)frow.FindControl("txtNgayHetHan")).Text == "")
                {
                    objSHKhau.NgayHetHan = null;
                }
                else
                {
                    objSHKhau.NgayHetHan = ((TextBox)frow.FindControl("txtNgayHetHan")).Text;
                }
                if (Convert.ToInt16(((TextBox)frow.FindControl("txtTSNKhau")).Text) < Convert.ToInt16(((TextBox)frow.FindControl("txtNKDCap")).Text))
                {
                    lblStatus.Text = "Nhân khẩu được cấp không lớn hơn tổng số nhân khẩu";
                    lblStatus.Visible = true;
                    lblLink.Visible = false;
                    linkSHK.Visible = false;
                }
                else
                {
                    int inserted = objSHKhau.InsertSHK(objSHKhau);
                    if (inserted > 0)
                    {
                        this.FindSHKhau();
                    }
                    else
                    {
                        linkSHK.HRef = "~/thongkeSHK.aspx?Id=" + ((TextBox)frow.FindControl("txtSoCTDKDM")).Text + "";
                        lblLink.Text = "Sổ hộ khẩu đã cấp tại danh bạ khác. Click vào đây để kiểm tra";
                        lblLink.Visible = true;
                        linkSHK.Visible = true;
                        lblStatus.Visible = false;
                    }
                }
            }
            //else if (e.CommandName == "Delete")
            //{ 
            //GetID

            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Get the value of column from the DataKeys using the RowIndex.
            //int id = Convert.ToInt32(gridSHK.DataKeys[rowIndex].Values[0]);
            //objSHKhau.ID = id;
            //objSHKhau.DelelteSHK(objSHKhau);

            //Control ctl = e.CommandSource as Control;
            //GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;
            //object objTemp = gridSHK.DataKeys[CurrentRow.RowIndex].Value as object;
            //if (objTemp != null)
            //{
            //    string id = objTemp.ToString();
            //    objSHKhau.ID = Convert.ToInt32(id);
            //    objSHKhau.DelelteSHK(objSHKhau);
            //    //Do your operations
            //    FindSHKhau();
            //}
            //}
        }

        protected void gridSHK_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSHK.PageIndex = e.NewPageIndex;
            this.FindSHKhau();
        }

        protected void gridCMND_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCMND.PageIndex = e.NewPageIndex;
            objCMND.MaCTDKDM = lblSoCT.Text;
            gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
            gridCMND.DataBind();
        }
        public class ChungTu
        {
            public string LoaiSo { get; set; }
            public string ChuThich { get; set; }
        }
        protected void dropLoaiChungtu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            //TextBox chuthich = new TextBox();  
            //DataTable dt = new DataTable();
            //ChungTu ct = new ChungTu();
            Control ctrl = gridSHK.FooterRow.FindControl("dropLoaiChungtu") as DropDownList;
            if (ctrl != null)
            {
                DropDownList dropchungtu = (DropDownList)ctrl;
                if (ddl.ClientID == dropchungtu.ClientID)
                {
                    TextBox chuthich = gridSHK.FooterRow.FindControl("txtChuThich") as TextBox;
                    objChungTu._LoaiChungTu = dropchungtu.SelectedValue;
                    dt = objChungTu.LoadChuThich(objChungTu);
                    chuthich.Text = dt.Rows[0][0].ToString();
                }
            }

        }

        protected void gridSHK_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Control ctrl = e.Row.FindControl("dropLoaiChungtu");
                Control text = e.Row.FindControl("txtChuThich");
                if (ctrl != null)
                {
                    DropDownList dd = ctrl as DropDownList;
                    //SqlConnection conn = new SqlConnection(connStr);
                    dt = new DataTable();
                    dt = objChungTu.LoadLoaiChungTu();
                    dd.DataTextField = "LoaiChungTu";
                    dd.DataValueField = "LoaiChungTu";
                    dd.DataSource = dt;
                    dd.DataBind();
                    //dd.Items.Insert(0,"--Chọn loại sổ--");
                    if (text != null)
                    {
                        TextBox chuthich = text as TextBox;
                        objChungTu._LoaiChungTu = dd.SelectedValue;
                        dt = objChungTu.LoadChuThich(objChungTu);
                        chuthich.Text = dt.Rows[0][0].ToString();
                    }
                }

            }
        }

        protected void gridSHK_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gridSHK.DataKeys[e.RowIndex].Value;
            objSHKhau.ID = Convert.ToInt32(id);
            objSHKhau.DelelteSHK(objSHKhau);
            FindSHKhau();
        }

        protected void gridCMND_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNewCMND")
            {
                HttpCookie reqCookies = Request.Cookies["userinfo"];
                GridViewRow frow = gridCMND.FooterRow;
                objCMND.MaCTDKDM = lblSoCT.Text;
                objCMND.LoaiCMND = ((DropDownList)frow.FindControl("dropLoaiCMND")).Text;
                objCMND.SoCMND = ((TextBox)frow.FindControl("txtCMND")).Text;
                objCMND.KhongCMND = ((CheckBox)frow.FindControl("chkKhongCMND")).Checked;
                objCMND.SoPhong = ((TextBox)frow.FindControl("txtSoPhong")).Text;
                objCMND.GhiChu = ((TextBox)frow.FindControl("txtGhiChu")).Text;
                objCMND.MaNV = reqCookies["USER_ID"].ToString();
                int inserted = objCMND.InsertCMND(objCMND);
                if (inserted > 0)
                {
                    objCMND.MaCTDKDM = lblSoCT.Text;

                    //int rowIndex = Convert.ToInt32(e.CommandArgument);
                    //Get the value of column from the DataKeys using the RowIndex.
                    //string key = Convert.ToString(gridSHK.DataKeys[rowIndex].Values[0]);
                    //string MaCT = key.Substring(16);
                    //lblSoCT.Text = MaCT;
                    //objCMND.SoCTDKDM = MaCT;
                    if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
                    {
                        gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                        gridCMND.DataBind();
                        gridCMND.Visible = true;
                    }
                    else
                    {
                        objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
                        gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                        gridCMND.DataBind();
                        int columncount = gridCMND.Rows[0].Cells.Count;
                        gridCMND.Rows[0].Cells.Clear();
                        //gridview1.footerrow.cells.clear();
                        gridCMND.Rows[0].Cells.Add(new TableCell());
                        gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridCMND.Rows[0].Cells[0].Text = "no records found";
                        gridCMND.Visible = true;
                    }
                }
                else
                {

                }
            }
        }

        protected void gridCMND_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objCMND.SoCMND = (string)gridCMND.DataKeys[e.RowIndex].Value;
            objCMND.DeleteCMND(objCMND);
            objCMND.MaCTDKDM = lblSoCT.Text;
            if (objCMND.LoadListCMND(objCMND).Rows.Count > 0)
            {
                gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                gridCMND.DataBind();
                gridCMND.Visible = true;
            }
            else
            {
                objCMND.LoadListCMND(objCMND).Rows.Add(objCMND.LoadListCMND(objCMND).NewRow());
                gridCMND.DataSource = objCMND.LoadListCMND(objCMND);
                gridCMND.DataBind();
                int columncount = gridCMND.Rows[0].Cells.Count;
                gridCMND.Rows[0].Cells.Clear();
                // GridView1.FooterRow.Cells.Clear();
                gridCMND.Rows[0].Cells.Add(new TableCell());
                gridCMND.Rows[0].Cells[0].ColumnSpan = columncount;
                gridCMND.Rows[0].Cells[0].Text = "No Records Found";
                gridCMND.Visible = true;
            }
        }

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
            objbkdc.Dot = int.Parse(txtMLT.Text.Substring(0,2));
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
            objbkdc.TLSHoatDC = int.Parse(txtSH_DC.Text);
            objbkdc.TLCQuanDC = int.Parse(txtHCSN_DC.Text);
            objbkdc.TLSXuatDC = int.Parse(txtSX_DC.Text);
            objbkdc.TLKDoanhDC = int.Parse(txtKD_DC.Text);
            objbkdc.DMucDC = int.Parse(txtDM_DC.Text);
            objbkdc.MNNghe = txtMNN.Text;
            objbkdc.MNNgheDC = txtMNNDC.Text;
            objbkdc.GChu = txtDienGiai.Text;
            objbkdc.InBD = chkInbienDong.Checked;
            objbkdc.MaNV= Info()["USER_ID"].ToString();
            objbkdc.CatDMTrung = chkCatDMTrung.Checked;
            objbkdc.DMuc_HoNgheo = int.Parse(txtDMHN.Text);
            objbkdc.DMuc_HoNgheoDC = int.Parse(txtDMHN_DC.Text);
            objbkdc.NVNhanHS = lblNVNhanHS.Text;
            int i = objbkdc.InsertBKDC(objbkdc);
            if(i == 1)
            {
                ClearText();
                lblMessage.Text = "Thêm dữ liệu thành công";
            }
            else
            {
                lblMessage.Text = "Thêm dữ liệu thất bại";
            }
        }
    }
}