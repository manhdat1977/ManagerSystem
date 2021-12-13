using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data.Linq;
namespace ManagerSystem
{
    public partial class capnhatdonthu : System.Web.UI.Page
    {
        ConnectDB connnectDB = new ConnectDB();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        access ac = new access();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddata_todropdown();
                LoadDataToDropDownListItem();

            }
            //ac.CapNhatTruycap(2, Session["USER_ID"].ToString());
        }
        private string Username()
        {
            HttpCookie reqCookies = Request.Cookies["userinfo"];
            string username = reqCookies["USER_ID"].ToString();
            return username;
        }
        public void getMaHS()
        {
            string maHS = txtDbo.Text + "" + Convert.ToDateTime(txtNgayCapBN.Text).ToString("dd/MM/yyy") + "" + txtSdon.Text + "" + txtLdon.Text;
            conn = connnectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            //Mở kết nối
            conn.Open();
            //------------//
            cmd = new SqlCommand("SELECT BPYeuCau as PBD,SoCVBP as SoCV,NgayLapCVBP as NgaylapCV,HDong as HD,MLTrinh as MLT,DThoaiKH as DT,KHang as Kh,DChi as dc,NDDon as NDDon,dot as dot,qtt as qtt,ptt as ptt, mnnghe as mnn, codhn as co,gbieu as gb,dmuc as dm,nhomkn as nhomkn, manvktra as nvktra FROM DKN_Table1 WHERE MaSNDon = '" + maHS + "'", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "DKN_Table1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    txtPBD.Text = dr["PBD"].ToString();
                    txtVB.Text = dr["SoCV"].ToString();
                    txtNgayLap.Text = dr["NgaylapCV"].ToString();
                    txtHD.Text = dr["hd"].ToString();
                    txtMLT.Text = dr["MLT"].ToString();
                    txtKH.Text = dr["Kh"].ToString();
                    txtDC.Text = dr["dc"].ToString();
                    txtNDDon.Text = dr["NDDon"].ToString();
                    txtDot.Text = dr["dot"].ToString();
                    txtQTT.Text = dr["qtt"].ToString();
                    txtPTT.Text = dr["ptt"].ToString();
                    txtMNN.Text = dr["mnn"].ToString();
                    //txtCo.Text = dr["co"].ToString();
                    txtGB.Text = dr["gb"].ToString();
                    txtDM.Text = dr["dm"].ToString();
                    txtNhomKN.Text = dr["nhomkn"].ToString();
                    //dropNVKtraChinh.SelectedIndex = dropNVKtraChinh.Items.IndexOf(dropNVKtraChinh.Items.FindByValue(dr["nvktra"].ToString()));           
                    loaddata_todropdown();
                    dropNVKtraChinh.Items.Insert(0, dr["nvktra"].ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('Không có số đơn này trong hệ thống')</script>");
                txtDbo.Text = "";
                txtNgayCapBN.Text = "";
                txtSdon.Text = "";
            }

            //--Đóng--//
            conn.Close();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            getMaHS();
        }
        public DropDownList data(string query, string text, string value, DropDownList dropname)
        {
            conn = connnectDB.connectSQL();
            //----Mở----//
            conn.Open();
            dt = new DataTable();
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            dropname.DataSource = dt;
            dropname.DataTextField = text;
            dropname.DataValueField = value;
            dropname.DataBind();
            //---Đóng---//
            conn.Close();
            return dropname;
        }
        private void LoadDataToDropDownListItem()
        {
            data("select * from dbo.LDon_CapNhatDonThu", "LDon", "LDon", txtLdon);
        }
        protected void loaddata_todropdown()
        {
            conn = connnectDB.connectSQL();
            conn.Open();
            cmd = new SqlCommand("select [username] as a,[fullname] as b from quanlynguoidung where permission = 'KTV'", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dropNVKtraPH.DataSource = dt;
            dropNVKtraPH.DataBind();
            dropNVKtraPH.DataTextField = "a";
            dropNVKtraPH.DataValueField = "b";
            dropNVKtraPH.DataBind();
            dropNVKtraPH.Items.Insert(0, new ListItem("", ""));
            dropNVKtraChinh.DataSource = dt;
            dropNVKtraChinh.DataBind();
            dropNVKtraChinh.DataTextField = "a";
            dropNVKtraChinh.DataValueField = "b";
            dropNVKtraChinh.DataBind();
            dropNVKtraChinh.Items.Insert(0, new ListItem("", "-1"));
            conn.Close();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            insertData();
            clear();
        }
        public void clear()
        {
            txtDbo.Text = "";
            txtCo.Text = "";
            txtDC.Text = "";
            txtDM.Text = "";
            txtDot.Text = "";
            txtGB.Text = "";
            txtHD.Text = "";
            txtKH.Text = "";
            txtMLT.Text = "";
            txtMNN.Text = "";
            txtMnnDC.Text = "";
            txtNDBienBan.Value = "";
            txtNDDon.Text = "";
            txtNgayCapBN.Text = "";
            txtNgayLap.Text = "";
            txtNgaynhanHS.Value = "";
            txtNgaytraHS.Value = "";
            txtNhomKN.Text = "";
            txtPBD.Text = "";
            txtPTT.Text = "";
            txtQTT.Text = "";
            txtSdon.Text = "";
            txtSDT.Text = "";
            txtVB.Text = "";
            chkChayNguoc.Checked = false;
            chkChungCu.Checked = false;
            chkCoBamChi.Checked = false;
            chkCoMaVach.Checked = false;
            chkDeXuatTruyThu.Checked = false;
            chkDHNHoatDongBT.Checked = false;
            chkDuChi.Checked = false;
            chkDungMucDich.Checked = false;
            chkGiengCoVan.Checked = false;
            chkGiengKoVan.Checked = false;
            chkHoDanToc.Checked = false;
            chkNhaDongCua.Checked = false;
            chkTonGiao.Checked = false;
            chkTruongHoc.Checked = false;
            chkViTriDHN.Checked = false;
            chkYTe.Checked = false;
            chkLapGieng.Checked = false;
        }
        public void insertData()
        {
            string maHS = txtDbo.Text + "" + Convert.ToDateTime(txtNgayCapBN.Text).ToString("dd/MM/yyy") + "" + txtSdon.Text + "" + txtLdon.Text;
            if (txtNgaynhanHS.Value == "")
            {
                Response.Write("<script>alert('Bạn chưa nhập ngày nhận hồ sơ')</script>");
            }
            else if (txtNgaytraHS.Value == "")
            {
                Response.Write("<script>alert('Bạn chưa nhập ngày trả hồ sơ')</script>");
            }
            else
            {
                try
                {
                    string queryInsert = "INSERT INTO [Thong_Tin_GQDon_Table]([MaSNDon],[NDKNai] ,[SDon],[LDon],[NgayNhanDon],[NhomKN],[NCNhat_TTin],[Dot],[MLTrinh],[DBo]"
          + " ,[Qtt],[Ptt],[HDong],[Co],[KHang],[DChi],[GBieu],[DMuc],[MaBPYeuCau] ,[SBKe],[NLap],[MaNVKTra],[NVKTPhoiHop],[SoDT]"
          + " ,[NNHSo],[NTHSo],[TTin_KiemTra],[BamChi],[DuChi],[CoMaVach]"
          + " ,[MDichSDung],[DHNHoatDongBT],[ViTriDHN],[ChayNguocHoacGanNguoc],[CoGiengGVan],[CoGiengKVan],[TonGiao]"
          + " ,[DanToc],[TruongHoc],[YTe],[ChungCu],[MNNghe],[MNNgheDC],[MaNV]"
          + " ,[XLTromCapTruyThu] ,[NhaDCua],[DongYLapGieng],[TrangThai])"
          + " VALUES"
          + " ('" + maHS + "',N'" + txtNDDon.Text + "','" + txtSdon.Text + "','" + txtLdon.Text + "','" + txtNgayCapBN.Text + "',N'" + txtNhomKN.Text + "',getdate(),'" + txtDot.Text + "','" + txtMLT.Text + "','" + txtDbo.Text + "' ,'" + txtQTT.Text + "','" + txtPTT.Text + "','" + txtHD.Text + "','" + txtCo.Text + "',N'" + txtKH.Text + "',N'" + txtDC.Text + "',"
          + " '" + txtGB.Text + "','" + txtDM.Text + "',N'" + txtPBD.Text + "','" + txtVB.Text + "','" + txtNgayLap.Text + "','" + Username().ToString() + "',N'" + dropNVKtraPH.SelectedItem.Text + "','" + txtSDT.Text + "', CONVERT(date, '" + txtNgaynhanHS.Value + "', 105) ,CONVERT(date,'" + txtNgaytraHS.Value + "', 103),N'" + txtNDBienBan.Value + "',"
          + " '" + chkCoBamChi.Checked + "','" + chkDuChi.Checked + "' ,'" + chkCoMaVach.Checked + "' ,'" + chkDungMucDich.Checked + "','" + chkDHNHoatDongBT.Checked + "','" + chkViTriDHN.Checked + "','" + chkChayNguoc.Checked + "','" + chkGiengCoVan.Checked + "','" + chkGiengKoVan.Checked + "','" + chkTonGiao.Checked + "','" + chkHoDanToc.Checked + "','" + chkTruongHoc.Checked + "','" + chkYTe.Checked + "',"
          + " '" + chkChungCu.Checked + "','" + txtMNN.Text + "','" + txtMnnDC.Text + "' ,'" + Username().ToString() + "','" + chkDeXuatTruyThu.Checked + "',"
          + " '" + chkNhaDongCua.Checked + "','" + chkLapGieng.Checked + "','ONL')";
                    conn = connnectDB.connectSQL_Giai_Quyet_Don();
                    conn.Open();
                    cmd = new SqlCommand(queryInsert, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Cập nhật thành công')</script>");
                }
                catch
                {
                    Response.Write("<script>alert('Số đơn này đã được nhập')</script>");
                }
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void LoadDataToEdit(string id)
        {
            if (id != null || id != "")
            {
                conn = connnectDB.connectSQL_Giai_Quyet_Don();
                conn.Open();
                cmd = new SqlCommand("select * from dbo_Thong_Tin_GQDon_Table where id = '" + id + "'", conn);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "dbo_Thong_Tin_GQDon_Table");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.Read())
                    {
                        txtPBD.Text = dr["PBD"].ToString();
                        txtVB.Text = dr["SoCV"].ToString();
                        txtNgayLap.Text = dr["NgaylapCV"].ToString();
                        txtHD.Text = dr["hd"].ToString();
                        txtMLT.Text = dr["MLT"].ToString();
                        txtKH.Text = dr["Kh"].ToString();
                        txtDC.Text = dr["dc"].ToString();
                        txtNDDon.Text = dr["NDDon"].ToString();
                        txtDot.Text = dr["dot"].ToString();
                        txtQTT.Text = dr["qtt"].ToString();
                        txtPTT.Text = dr["ptt"].ToString();
                        txtMNN.Text = dr["mnn"].ToString();
                        //txtCo.Text = dr["co"].ToString();
                        txtGB.Text = dr["gb"].ToString();
                        txtDM.Text = dr["dm"].ToString();
                        txtNhomKN.Text = dr["nhomkn"].ToString();
                        //dropNVKtraChinh.SelectedIndex = dropNVKtraChinh.Items.IndexOf(dropNVKtraChinh.Items.FindByValue(dr["nvktra"].ToString()));           
                        loaddata_todropdown();
                        dropNVKtraChinh.Items.Insert(0, dr["nvktra"].ToString());
                        conn.Close();
                    }
                }
                else
                {

                }

            }
        }
    }
}