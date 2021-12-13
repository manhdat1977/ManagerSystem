using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ManagerSystem.Prop;
using System.Globalization;
namespace ManagerSystem
{
    public partial class giaiquyetdon : System.Web.UI.Page
    {
        DuyetHoSo objDuyetHS = new DuyetHoSo();
        GiaiQuyetDon objdkn = new GiaiQuyetDon();
        HoSoKiemTra objhskt = new HoSoKiemTra();
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        CultureInfo provider = CultureInfo.InvariantCulture;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToDropLDon();
                LoadDataToTTDocso();
                LoadDataToKQGQuyet();
                dropNhomKQ.Text = "";
                dropTTDS.Text = "";
                LoadDonChuaGQ();
            }
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            conn = condb.connect_KhoHoSo();
            conn.Open();
            DateTime ncbiennhan = DateTime.Parse(txtNgayCapBN.Text);
            string maHS = txtDba.Text + "" + ncbiennhan.ToString("dd/MM/yyyy") + "" + txtSoDon.Text + "" + dropLoaiDon.Text;
            //objdkn.dbo = txtDba.Text;
            //objdkn.NNDon = txtNgayCapBN.Text;
            //objdkn.SDon = int.Parse(txtSoDon.Text);
            //objdkn.LDon = dropLoaiDon.Text;
            objdkn.MaSNDon = maHS;
            objdkn.FindMaSoDon(objdkn);
            dt = objdkn.FindMaSoDon(objdkn);
            txtKH.Text = dt.Rows[0]["Khang"].ToString();
            txtDC.Text = dt.Rows[0]["DChi"].ToString();
            txtNoidungDon.Text = dt.Rows[0]["NDKNai"].ToString(); ;
            conn.Close();
            GetImageToGrid();
        }
        public DropDownList data(SqlConnection constring, string query, string text, string value, DropDownList dropname)
        {
            //conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            //----Mở----//
            constring.Open();
            dt = new DataTable();
            da = new SqlDataAdapter(query, constring);
            da.Fill(dt);
            dropname.DataSource = dt;
            dropname.DataTextField = text;
            dropname.DataValueField = value;
            dropname.DataBind();
            //---Đóng---//
            conn.Close();
            return dropname;
        }
        private void LoadDataToDropLDon()
        {
            data(condb.connectSQL_Bang_Ke_Dieu_Chinh(), "select * from dbo.[Loai_Don_Table]", "LDon", "LDon", dropLoaiDon);
        }
        private void LoadDataToTTDocso()
        {
            data(condb.connectSQL_Giai_Quyet_Don(), "select * from dbo.[TTin_DSo_Table]", "ChuThich", "TTin_Dso", dropTTDS);
        }
        private void LoadDataToKQGQuyet()
        {
            data(condb.connectSQL_Giai_Quyet_Don(), "select * from dbo.[KetQuaGiaiQuyet_Table]", "KQGQuyet", "MaKQ", dropNhomKQ);
        }
        private int ChuyenDonDuyet()
        {
            objDuyetHS.MaSNDon = MaSNDon();
            objDuyetHS.NguoiDuyet = dropNguoiDuyet.SelectedValue;
            objDuyetHS.NguoiChuyenHS = Session["USER_ID"].ToString();
            int i = objDuyetHS.InsertContentFile(objDuyetHS);
            return i;
        }
        public string MaSNDon()
        {
            DateTime ncbiennhan = DateTime.Parse(txtNgayCapBN.Text);
            string maHS = txtDba.Text + "" + ncbiennhan.ToString("dd/MM/yyyy") + "" + txtSoDon.Text + "" + dropLoaiDon.Text;
            return maHS;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            //DateTime ncbiennhan = DateTime.Parse(txtNgayCapBN.Text);
            //string maHS = txtDba.Text + "" + ncbiennhan.ToString("dd/MM/yyyy") + "" + txtSoDon.Text + "" + dropLoaiDon.Text;
            objdkn.MaSNDon = MaSNDon();
            objdkn.TTin_Dso = dropTTDS.SelectedValue;
            objdkn.KQGQuyet = txtKQGiaiQuyet.Text;
            objdkn.MaKQ = dropNhomKQ.SelectedValue;
            objdkn.ThaiDoPhucVu = dropThaiDo.Text;
            objdkn.GQDHan = chkXepDon.Checked;
            objdkn.PhoiHopCacDVi = chkPhoiHopCacDVi.Checked;
            int updated = objdkn.UpdateKQGuyet(objdkn);
            if (chkChuyenLD.Checked == true)
            {
                if (updated > 0)
                {
                    if (ChuyenDonDuyet() > 0)
                    {
                        ClearText();
                        LoadDonChuaGQ();
                    }
                }
            }
            else
            {
                if (updated > 0)
                {
                    ClearText();
                    LoadDonChuaGQ();
                }
            }

        }
        public void GetImageToGrid()
        {
            conn = condb.connect_KhoHoSo();
            conn.Open();
            DateTime ncbiennhan = DateTime.Parse(txtNgayCapBN.Text);
            string maHS = txtDba.Text + "" + ncbiennhan.ToString("dd/MM/yyyy") + "" + txtSoDon.Text + "" + dropLoaiDon.Text;
            objhskt.MaSNDon = maHS;
            dt = objhskt.GetAllTable(objhskt);
            gridImage.DataSource = dt;
            gridImage.DataBind();
            conn.Close();
        }
        private void ClearText()
        {
            txtDba.Text = "";
            txtDC.Text = "";
            txtKH.Text = "";
            txtKQGiaiQuyet.Text = "";
            txtNDBienBan.Text = "";
            txtNgayCapBN.Text = "";
            txtNoidungDon.Text = "";
            txtSoDon.Text = "";
            chkXepDon.Checked = false;
            chkPhoiHopCacDVi.Checked = false;
        }
        public void LoadDonChuaGQ()
        {
            conn = condb.connectSQL_Giai_Quyet_Don();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    cmd = new SqlCommand("proc_TimKiem_Don", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (dropSearch.Text == "Danh bạ")
                    {
                        cmd.Parameters.AddWithValue("@Dbo", txtSearch.Text);
                        cmd.Parameters.AddWithValue("@SDon", "");
                        cmd.Parameters.AddWithValue("@LDon", "");
                        cmd.Parameters.AddWithValue("@NgayNhanDon", "");
                        cmd.Parameters.AddWithValue("@MaNVKTra", "");
                    }
                    else if (dropSearch.Text == "Số đơn")
                    {
                        cmd.Parameters.AddWithValue("@Dbo", "");
                        cmd.Parameters.AddWithValue("@SDon", txtSearch.Text);
                        cmd.Parameters.AddWithValue("@LDon", "");
                        cmd.Parameters.AddWithValue("@NgayNhanDon", "");
                        cmd.Parameters.AddWithValue("@MaNVKTra", "");
                    }
                    else if (dropSearch.Text == "Loại đơn")
                    {
                        cmd.Parameters.AddWithValue("@Dbo", "");
                        cmd.Parameters.AddWithValue("@SDon", "");
                        cmd.Parameters.AddWithValue("@LDon", txtSearch.Text);
                        cmd.Parameters.AddWithValue("@NgayNhanDon", "");
                        cmd.Parameters.AddWithValue("@MaNVKTra", "");
                    }
                    else if (dropSearch.Text == "Ngày nhận đơn")
                    {
                        cmd.Parameters.AddWithValue("@Dbo", "");
                        cmd.Parameters.AddWithValue("@SDon", "");
                        cmd.Parameters.AddWithValue("@LDon", "");
                        cmd.Parameters.AddWithValue("@NgayNhanDon", txtSearch.Text);
                        cmd.Parameters.AddWithValue("@MaNVKTra", "");
                    }
                    else if (dropSearch.Text == "Kiểm tra viên")
                    {
                        cmd.Parameters.AddWithValue("@Dbo", "");
                        cmd.Parameters.AddWithValue("@SDon", "");
                        cmd.Parameters.AddWithValue("@LDon", "");
                        cmd.Parameters.AddWithValue("@NgayNhanDon", "");
                        cmd.Parameters.AddWithValue("@MaNVKTra", txtSearch.Text);
                    }
                }
                else
                {
                    //gridDSDonChuaGQ.DataSource = objdkn.DonChuaGiaiQuyet();
                    //gridDSDonChuaGQ.DataBind();
                    cmd = new SqlCommand("proc_TimKiem_Don", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dbo", "");
                    cmd.Parameters.AddWithValue("@SDon", "");
                    cmd.Parameters.AddWithValue("@LDon", "");
                    cmd.Parameters.AddWithValue("@NgayNhanDon", "");
                    cmd.Parameters.AddWithValue("@MaNVKTra", "");
                }
                da = new SqlDataAdapter(cmd);
                dt.Clear();
                dt = new DataTable();
                da.Fill(dt);
                gridDSDonChuaGQ.DataSource = dt;
                gridDSDonChuaGQ.DataBind();
                conn.Close();
                dt.Dispose();
                da.Dispose();
                //////////////////////////////////////////////////////////////////////
                //conn.Open();
                //if(dropSearch.Text=="Danh bạ")
                //{
                //    cmd = new SqlCommand("proc_TimKiem_Don", conn);
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    da = new SqlDataAdapter(cmd);
                //    dt = new DataTable();
                //    da.Fill(dt);
                //    gridDSDonChuaGQ.DataSource = dt;
                //    gridDSDonChuaGQ.DataBind();
                //}
                //conn.Close();
            }

        }

        protected void gridDSDonChuaGQ_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                objdkn.MaSNDon = Convert.ToString(gridDSDonChuaGQ.DataKeys[rowIndex].Values[0]);
                dt = new DataTable();
                dt = objdkn.FindMaSoDon(objdkn);
                txtDba.Text = dt.Rows[0]["Dbo"].ToString();
                txtSoDon.Text = dt.Rows[0]["SDon"].ToString();
                dropLoaiDon.Text = dt.Rows[0]["LDon"].ToString().ToUpper();
                txtNgayCapBN.Text = dt.Rows[0]["NgayNhanDon"].ToString().Substring(0, 10);
                txtKH.Text = dt.Rows[0]["KHang"].ToString();
                txtDC.Text = dt.Rows[0]["DChi"].ToString();
                txtNoidungDon.Text = dt.Rows[0]["NDKNai"].ToString();
                txtNDBienBan.Text = dt.Rows[0]["TTin_KiemTra"].ToString();
                GetImageToGrid();
            }
        }

        protected void gridDSDonChuaGQ_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDSDonChuaGQ.PageIndex = e.NewPageIndex;
            this.LoadDonChuaGQ();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadDonChuaGQ();
        }
    }
}