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
    public partial class SoNhanDon : System.Web.UI.Page
    {
        SqlConnection conn = null;
        ConnectDB connectDB = new ConnectDB();
        SqlCommand cmd;
        SqlDataReader dr;
        
        SoNhanDonBLL sonhandon = new SoNhanDonBLL();
        DKN dkn = new DKN();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                sonhandon.LoadDataToDropDown("proc_LoadLoaiDon", "LDon", dropLoaidon);
                sonhandon.LoadDataToDropDown("proc_LoadNhomThongTin", "NhomThongTin", dropNhomThongTin);
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    TimDonKN_ID(id);
                    UnBlockTextbox();
                    btnCapNhat.Visible = true;
                }
                else
                {
                    dropLoaidon.Text = "DC";
                    txtSoDon.Text = "";
                    txtNgay.Text = "";
                    dropPBD.Text = "";
                    txtSoVanBan.Text = "";
                    txtNgayLap.Text = "";
                    txtNoiDung.Text = "";
                    dropNhomThongTin.SelectedIndex = 1;
                    txtDanhBa.Text = "";
                    txtSDT1.Text = "";
                    txtHopDong.Text = "";
                    txtLoTrinh.Text = "";
                    txtKH.Text = "";
                    txtDiaChi.Text = "";
                    txtGB.Text = "";
                    txtDMuc.Text = "";
                    txtQuan.Text = "";
                    txtPhuong.Text = "";
                    lblMaNVKTra.Text = "";
                    chkChuaCoDBa.Checked = false;
                    chkKhongKTra.Checked = false;
                    chkSMS.Checked = false;
                    chkHoaDon.Checked = false;
                    chkHKKT3.Checked = false; ;
                    chkSTTru.Checked = false;
                    chkGiayCapSoNha.Checked = false;
                    chkHDThueNha.Checked = false;
                    chkXacNhanSoNha.Checked = false;
                    chkGDKKD.Checked = false;
                    chkMST.Checked = false;
                    chkGiayUngThuan.Checked = false;
                    txtXacNhanNo.Text = "";
                    btnCapNhat.Visible = false;
                    BlockTextbox();
                }

            }
        }
        protected void TimDonKN_ID(int id)
        {
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_TimDKN_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dropLoaidon.Text = dr["LDon"].ToString();
                    txtSoDon.Text = dr["SDon"].ToString();
                    txtNgay.Text = Convert.ToDateTime(dr["NNDon"].ToString()).ToString("dd/MM/yyyy");
                    dropPBD.Text = dr["BPYeuCau"].ToString();
                    txtSoVanBan.Text = dr["SoCVBP"].ToString();
                    try
                    {
                        txtNgayLap.Text = Convert.ToDateTime(dr["NgayLapCVBP"].ToString()).ToString("dd/MM/yyyy");
                    }
                    catch
                    {
                        txtNgayLap.Text = dr["NgayLapCVBP"].ToString();
                    }
                    txtNoiDung.Text = dr["NDDon"].ToString();
                    dropNhomThongTin.Text = dr["NhomKN"].ToString();
                    txtDanhBa.Text = dr["Dbo"].ToString();
                    txtSDT1.Text = dr["DThoaiKH"].ToString();
                    txtHopDong.Text = dr["HDong"].ToString();
                    txtLoTrinh.Text = dr["MLTrinh"].ToString();
                    txtKH.Text = dr["KHang"].ToString();
                    txtDiaChi.Text = dr["DChi"].ToString();
                    txtGB.Text = dr["GBieu"].ToString();
                    txtDMuc.Text = dr["Dmuc"].ToString();
                    txtQuan.Text = dr["QTT"].ToString();
                    txtPhuong.Text = dr["PTT"].ToString();
                    lblMaNVKTra.Text = dr["NVKTra"].ToString();
                    chkChuaCoDBa.Checked = Convert.ToBoolean(dr["GM"].ToString());
                    chkKhongKTra.Checked = Convert.ToBoolean(dr["KhongKiemTra"].ToString());
                    chkSMS.Checked = Convert.ToBoolean(dr["SMS"].ToString());
                    chkHoaDon.Checked = Convert.ToBoolean(dr["HDon"].ToString());
                    chkHKKT3.Checked = Convert.ToBoolean(dr["HKhau_KT3"].ToString()); ;
                    chkSTTru.Checked = Convert.ToBoolean(dr["SoTamTru_XNTTru"].ToString());
                    chkGiayCapSoNha.Checked = Convert.ToBoolean(dr["GiayCap_DoiSoNha"].ToString());
                    chkHDThueNha.Checked = Convert.ToBoolean(dr["HDThueNha_CQNha"].ToString());
                    chkXacNhanSoNha.Checked = Convert.ToBoolean(dr["GiayXNSoNha"].ToString());
                    chkGDKKD.Checked = Convert.ToBoolean(dr["GiayDangKyKD"].ToString());
                    chkMST.Checked = Convert.ToBoolean(dr["GiayDangKyMST"].ToString());
                    chkGiayUngThuan.Checked = Convert.ToBoolean(dr["GiayUngThuan"].ToString());
                    txtXacNhanNo.Text = dr["XacNhanNo"].ToString();
                    lblID.Text = dr["Id"].ToString();
                }
            }
            conn.Close();
        }
        public void LoadInFoSoDbo(string dbo)
        {
            conn = connectDB.connectBK();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("sp_GetDataSoDbo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dbo", dbo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtHopDong.Text = dr["HD"].ToString();
                    txtLoTrinh.Text = dr["MaLT"].ToString();
                    txtKH.Text = dr["KH"].ToString();
                    txtDiaChi.Text = dr["DC"].ToString();
                    txtGB.Text = dr["GB"].ToString();
                    txtDMuc.Text = dr["DM"].ToString();
                    txtQuan.Text = dr["QTT"].ToString();
                    txtPhuong.Text = dr["PTT"].ToString();
                    lblMaNVKTra.Text = dr["MaNVKTra"].ToString();
                }
            }
            dr.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void btnTimDBa_Click(object sender, EventArgs e)
        {
            if (txtDanhBa.Text != null || txtDanhBa.Text != "")
            {
                LoadInFoSoDbo(txtDanhBa.Text);
            }
            else
            {
                Response.Write("<script>alert('Bạn chưa nhập danh bạ!')</script>");
            }
        }
        //public string Username()
        //{
        //    HttpCookie reqCookies = Request.Cookies["userinfo"];
        //    string nguoiduyet = reqCookies["USER_ID"].ToString();
        //    return nguoiduyet;
        //}
        public void TaoDon()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["userinfo"];
                dkn.danhba = txtDanhBa.Text;
                dkn.diachi = txtDiaChi.Text;
                dkn.dienthoai1 = txtSDT1.Text;
                dkn.ganmoi = chkChuaCoDBa.Checked;
                dkn.GDKKD = chkGDKKD.Checked;
                dkn.ghichu = txtGhiChu.Text;
                dkn.giaycapsonha = chkGiayCapSoNha.Checked;
                dkn.giayungthuan = chkGiayUngThuan.Checked;
                dkn.HDThueNha = chkHDThueNha.Checked;
                dkn.hieuluc = txtHieuLuc.Text;
                dkn.HKKT3 = chkHKKT3.Checked;
                dkn.hoadon = chkHoaDon.Checked;
                dkn.khachhang = txtKH.Text;
                dkn.khongkiemtra = chkKhongKTra.Checked;
                dkn.loaidon = dropLoaidon.Text;
                //dkn.manhanvien = Session["MaNhanVien"].ToString();
                dkn.manhanvien = reqCookies["Fullname"].ToString();
                dkn.manhanvienkiemtra = lblMaNVKTra.Text;
                dkn.masothue = chkMST.Checked;
                dkn.noidung = txtNoiDung.Text;
                dkn.ngaylapcv = txtNgayLap.Text;
                dkn.ngaynhandon = DateTime.Now.ToString("dd/MM/yyyy");
                dkn.nhomthongtin = dropNhomThongTin.Text;
                dkn.phongbandoi = dropPBD.Text;
                dkn.phuong = txtPhuong.Text;
                dkn.quan = txtQuan.Text;
                dkn.sms = chkSMS.Checked;
                dkn.sovanban = txtSoVanBan.Text;
                dkn.STTru = chkSTTru.Checked;
                dkn.xacnhanno = txtXacNhanNo.Text;
                dkn.xacnhansonha = chkXacNhanSoNha.Checked;
                sonhandon.InsertData(dkn.danhba, dkn.loaidon, dkn.ngaynhandon, dkn.noidung, dkn.hieuluc, dkn.phongbandoi, dkn.sovanban, dkn.ngaylapcv, dkn.nhomthongtin, dkn.quan, dkn.phuong, dkn.khachhang, dkn.diachi, dkn.ghichu, dkn.hoadon, dkn.HDThueNha, dkn.GDKKD, dkn.HKKT3, dkn.STTru, dkn.giaycapsonha, dkn.xacnhansonha, dkn.giayungthuan, dkn.masothue, dkn.manhanvien, dkn.dienthoai1, dkn.manhanvienkiemtra, dkn.ganmoi, dkn.khongkiemtra, dkn.sms, dkn.xacnhanno);
                Response.Redirect("rpNhanDon.aspx");
            }
            catch
            {
                Response.Write("<script>alert('Tạo đơn thất bại'!)</script>");
            }
        }
        protected void btnIn_Click(object sender, EventArgs e)
        {
            //Response.Write("window.open('rpNhanDon.aspx?id=" + "0322404001019/02/2019991KN" + "','_blank')");
            if (txtDanhBa.Text == "")
            {

                lblMessage.Text = "* Lỗi: Bạn chưa nhập danh bạ";
                lblMessage.Visible = true;
            }
            else
            {
                TaoDon();
                lblMessage.Visible = false;
            }
        }

        protected void btnLichSu_Click(object sender, EventArgs e)
        {
            Response.Redirect("lichsunhandon.aspx?id=" + txtDanhBa.Text + "");
        }
        public void CapNhatDon()
        {
            try
            {
                dkn.danhba = txtDanhBa.Text;
                dkn.diachi = txtDiaChi.Text;
                dkn.dienthoai1 = txtSDT1.Text;
                dkn.ganmoi = chkChuaCoDBa.Checked;
                dkn.GDKKD = chkGDKKD.Checked;
                dkn.ghichu = txtGhiChu.Text;
                dkn.giaycapsonha = chkGiayCapSoNha.Checked;
                dkn.giayungthuan = chkGiayUngThuan.Checked;
                dkn.HDThueNha = chkHDThueNha.Checked;
                dkn.hieuluc = txtHieuLuc.Text;
                dkn.HKKT3 = chkHKKT3.Checked;
                dkn.hoadon = chkHoaDon.Checked;
                dkn.khachhang = txtKH.Text;
                dkn.khongkiemtra = chkKhongKTra.Checked;
                dkn.loaidon = dropLoaidon.Text;
                dkn.manhanvien = Session["MaNhanVien"].ToString();
                dkn.manhanvienkiemtra = lblMaNVKTra.Text;
                dkn.masothue = chkMST.Checked;
                dkn.noidung = txtNoiDung.Text;
                dkn.ngaylapcv = txtNgayLap.Text;
                dkn.ngaynhandon = DateTime.Now.ToString("yyyy-MM-dd");
                dkn.nhomthongtin = dropNhomThongTin.Text;
                dkn.phongbandoi = dropPBD.Text;
                dkn.phuong = txtPhuong.Text;
                dkn.quan = txtQuan.Text;
                dkn.sms = chkSMS.Checked;
                dkn.sovanban = txtSoVanBan.Text;
                dkn.STTru = chkSTTru.Checked;
                dkn.xacnhanno = txtXacNhanNo.Text;
                dkn.xacnhansonha = chkXacNhanSoNha.Checked;
                dkn.ID = Convert.ToInt32(Request.QueryString["id"]);
                //dkn.sodon = Convert.ToInt32(txtSoDon.Text);
                sonhandon.UpdateData(dkn.ID, dkn.danhba, dkn.loaidon, dkn.ngaynhandon, dkn.noidung, dkn.hieuluc, dkn.phongbandoi, dkn.sovanban, dkn.ngaylapcv, dkn.nhomthongtin, dkn.quan, dkn.phuong, dkn.khachhang, dkn.diachi, dkn.ghichu, dkn.hoadon, dkn.HDThueNha, dkn.GDKKD, dkn.HKKT3, dkn.STTru, dkn.giaycapsonha, dkn.xacnhansonha, dkn.giayungthuan, dkn.masothue, dkn.manhanvien, dkn.dienthoai1, dkn.manhanvienkiemtra, dkn.ganmoi, dkn.khongkiemtra, dkn.sms, dkn.xacnhanno);
                Response.Write("<script>alert('Cập nhật thành công'!)</script>");
                Response.Redirect("sonhandon.aspx");
            }
            catch
            {
                Response.Write("<script>alert('Cập nhật thất bại'!)</script>");
            }
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtDanhBa.Text != "")
            {
                if (txtNoiDung.Text != "")
                {
                    if (txtQuan.Text != "" && txtPhuong.Text != "")
                    {
                        CapNhatDon();
                    }
                    else Response.Write("<script>alert('Quận phường không được để trống'!)</script>");
                }
                else Response.Write("<script>alert('Nội dung không được để trống'!)</script>");
            }
            else Response.Write("<script>alert('Danh bạ không được để trống'!)</script>");
        }
        public void BlockTextbox()
        {
            txtSoDon.Enabled = false;
            txtNgay.Enabled = false;
            txtHopDong.Enabled = false;
            txtLoTrinh.Enabled = false;
            txtKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtQuan.Enabled = false;
            txtPhuong.Enabled = false;
            txtDMuc.Enabled = false;
            txtGB.Enabled = false;

        }
        public void UnBlockTextbox()
        {
            //txtSoDon.Enabled = true;
            //txtNgay.Enabled = true;
            txtHopDong.Enabled = true;
            txtLoTrinh.Enabled = true;
            txtKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtQuan.Enabled = true;
            txtPhuong.Enabled = true;
            txtDMuc.Enabled = true;
            txtGB.Enabled = true;
        }

        protected void chkChuaCoDBa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuaCoDBa.Checked == true)
            {
                UnBlockTextbox();
            }
            else
            {
                BlockTextbox();
            }
        }

        protected void btnLSBienDong_Click(object sender, EventArgs e)
        {
            Response.Redirect("lichsubiendong.aspx?id=" + txtDanhBa.Text + "");
        }
    }
}