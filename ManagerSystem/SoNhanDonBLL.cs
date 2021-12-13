using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ManagerSystem.Prop;
using DevExpress.XtraReports.UI;
using System.Web.UI.WebControls;
namespace ManagerSystem
{
    public class SoNhanDonBLL
    {
        //ThamSo thamso = new ThamSo();
        SqlCommand cmd = new SqlCommand();
        ConnectDB connectDB = new ConnectDB();
        SqlConnection conn;
        SqlDataReader dr;
        SqlDataAdapter da;
        dsSoNhanDon ds;
        public DataSet LoadDataReport()
        {
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("sp_SelectSoNhanDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNhanDon", HttpContext.Current.Session["MaNhanDon"]);
                da = new SqlDataAdapter(cmd);
                ds = new dsSoNhanDon();
                da.Fill(ds, "v_DataNhanDon");
                //rpDonThuKH rpnhandon = new rpDonThuKH();
                //rprvNhanDon.Report = rpnhandon;
                //rpnhandon.DataSource = ds.Tables["v_DataNhanDon"];
                //rpnhandon.Parameters["param"].Value = "KN";
                //rpnhandon.Parameters["param"].Visible = true;
            }
            conn.Close();
            return ds;
        }
        public void LoadDataToDropDown(string namestore, string textfield, DropDownList dropdown)
        {
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
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
        public void UpdateData(int id, string dba, string loaidon, string ngaynhandon, string noidung, string hieuluc, string pbd, string sovanban, string ngaylapcongvan, string nhomthongtin, string quan, string phuong, string khachhang, string diachi, string ghichu, Boolean hoadon, Boolean hopdongthuenha, Boolean GDKKD, Boolean HKKT3, Boolean STTru, Boolean giaycapsonha, Boolean xacnhansonha, Boolean giayungthuan, Boolean masothue, string manhanvien, string dienthoai1, string manhanvienktra, Boolean ganmoi, Boolean khongkiemtra, Boolean sms, string xacnhanno)
        {
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[Proc_Ins_Upt_Del]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@LoaiCapNhat", "UPT");
                cmd.Parameters.AddWithValue("@DBo", dba);
                //cmd.Parameters.AddWithValue("@SDon", sodon);
                cmd.Parameters.AddWithValue("@LDon", loaidon);
                cmd.Parameters.AddWithValue("@NNDon", ngaynhandon);
                cmd.Parameters.AddWithValue("@NDDon", noidung);
                cmd.Parameters.AddWithValue("@HieuLuc", hieuluc);
                cmd.Parameters.AddWithValue("@BPYeuCau", pbd);
                cmd.Parameters.AddWithValue("@SoCVBP", sovanban);
                cmd.Parameters.AddWithValue("@NgayLapCVBP", ngaylapcongvan);
                cmd.Parameters.AddWithValue("@NhomKN", nhomthongtin);
                cmd.Parameters.AddWithValue("@Qtt", quan);
                cmd.Parameters.AddWithValue("@Ptt", phuong);
                cmd.Parameters.AddWithValue("@KHang", khachhang);
                cmd.Parameters.AddWithValue("@DChi", diachi);
                cmd.Parameters.AddWithValue("@GChu", ghichu);
                cmd.Parameters.AddWithValue("@HDon", hoadon);
                cmd.Parameters.AddWithValue("@HDThueNha_CQNha", hopdongthuenha);
                cmd.Parameters.AddWithValue("@GiayDangKyKD", GDKKD);
                cmd.Parameters.AddWithValue("@HKhau_KT3", HKKT3);
                cmd.Parameters.AddWithValue("@SoTamTru_XNTTru", STTru);
                cmd.Parameters.AddWithValue("@GiayCap_DoiSoNha", giaycapsonha);
                cmd.Parameters.AddWithValue("@GiayXNSoNha", xacnhansonha);
                cmd.Parameters.AddWithValue("@GiayUngThuan", giayungthuan);
                cmd.Parameters.AddWithValue("@GiayDangKyMST", masothue);
                cmd.Parameters.AddWithValue("@MaNV", manhanvien);
                cmd.Parameters.AddWithValue("@DThoaiKH", dienthoai1);
                cmd.Parameters.AddWithValue("@MaNVKTra", manhanvienktra);
                cmd.Parameters.AddWithValue("@GM", ganmoi);
                cmd.Parameters.AddWithValue("@KhongKiemTra", khongkiemtra);
                cmd.Parameters.AddWithValue("@SMS", sms);
                cmd.Parameters.AddWithValue("@XacNhanNo", xacnhanno);
                cmd.ExecuteNonQuery();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi kết nối')</script>");
            }
        }
    }

}