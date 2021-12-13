using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class DKN
    {
        public string danhba { get; set; }
        public string loaidon { get; set; }
        public string ngaynhandon { get; set; }
        public string noidung { get; set; }
        public string hieuluc { get; set; }
        public string phongbandoi { get; set; }
        public string sovanban { get; set; }
        public string ngaylapcv { get; set; }
        public string nhomthongtin { get; set; }
        public string quan { get; set; }
        public string phuong { get; set; }
        public string khachhang { get; set; }
        public string diachi { get; set; }
        public string ghichu { get; set; }
        public Boolean hoadon { get; set; }
        public Boolean HDThueNha { get; set; }
        public Boolean GDKKD { get; set; }
        public Boolean HKKT3 { get; set; }
        public Boolean STTru { get; set; }
        public Boolean giaycapsonha { get; set; }
        public Boolean xacnhansonha { get; set; }
        public Boolean giayungthuan { get; set; }
        public Boolean masothue { get; set; }
        public string manhanvien { get; set; }
        public string dienthoai1 { get; set; }
        public string manhanvienkiemtra { get; set; }
        public Boolean ganmoi { get; set; }
        public Boolean khongkiemtra { get; set; }
        public Boolean sms { get; set; }
        public string xacnhanno { get; set; }
        public int sodon { get; set; }
        public int ID { get; set; }

        public DKN()
        { }
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection();
        ConnectDB connectDB = new ConnectDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public void InsertDKN(DKN objDKN)
        {
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[Proc_Ins_Upt_Del]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", "0");
                cmd.Parameters.AddWithValue("@LoaiCapNhat", "INS");
                cmd.Parameters.AddWithValue("@DBo", objDKN.danhba);
                cmd.Parameters.AddWithValue("@SDon", "0");
                cmd.Parameters.AddWithValue("@LDon", objDKN.loaidon);
                cmd.Parameters.AddWithValue("@NNDon", objDKN.ngaynhandon);
                cmd.Parameters.AddWithValue("@NDDon", objDKN.noidung);
                cmd.Parameters.AddWithValue("@HieuLuc", objDKN.hieuluc);
                cmd.Parameters.AddWithValue("@BPYeuCau", objDKN.phongbandoi);
                cmd.Parameters.AddWithValue("@SoCVBP", objDKN.sovanban);
                cmd.Parameters.AddWithValue("@NgayLapCVBP", objDKN.ngaylapcv);
                cmd.Parameters.AddWithValue("@NhomKN", objDKN.nhomthongtin);
                cmd.Parameters.AddWithValue("@Qtt", objDKN.quan);
                cmd.Parameters.AddWithValue("@Ptt", objDKN.phuong);
                cmd.Parameters.AddWithValue("@KHang", objDKN.khachhang);
                cmd.Parameters.AddWithValue("@DChi", objDKN.diachi);
                cmd.Parameters.AddWithValue("@GChu", objDKN.ghichu);
                cmd.Parameters.AddWithValue("@HDon", objDKN.hoadon);
                cmd.Parameters.AddWithValue("@HDThueNha_CQNha", objDKN.HDThueNha);
                cmd.Parameters.AddWithValue("@GiayDangKyKD", objDKN.GDKKD);
                cmd.Parameters.AddWithValue("@HKhau_KT3", objDKN.HKKT3);
                cmd.Parameters.AddWithValue("@SoTamTru_XNTTru", objDKN.STTru);
                cmd.Parameters.AddWithValue("@GiayCap_DoiSoNha", objDKN.giaycapsonha);
                cmd.Parameters.AddWithValue("@GiayXNSoNha", objDKN.xacnhansonha);
                cmd.Parameters.AddWithValue("@GiayUngThuan", objDKN.giayungthuan);
                cmd.Parameters.AddWithValue("@GiayDangKyMST", objDKN.masothue);
                cmd.Parameters.AddWithValue("@MaNV", objDKN.manhanvien);
                cmd.Parameters.AddWithValue("@DThoaiKH", objDKN.dienthoai1);
                cmd.Parameters.AddWithValue("@MaNVKTra", objDKN.manhanvienkiemtra);
                cmd.Parameters.AddWithValue("@GM", objDKN.ganmoi);
                cmd.Parameters.AddWithValue("@KhongKiemTra", objDKN.khongkiemtra);
                cmd.Parameters.AddWithValue("@SMS", objDKN.sms);
                cmd.Parameters.AddWithValue("@XacNhanNo", objDKN.xacnhanno);
                //cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    HttpContext.Current.Session["MaNhanDon"] = dr["MaSNDon"].ToString();
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi kết nối')</script>");
            }
            conn.Close();
        }
        public DataTable FindMaSNDon(DKN objDKN)
        {

            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_TimDKN_MSNDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dbo", objDKN.danhba);
                cmd.Parameters.AddWithValue("@NNDon", objDKN.ngaynhandon);
                cmd.Parameters.AddWithValue("@SDon", objDKN.sodon);
                cmd.Parameters.AddWithValue("@LDon", objDKN.loaidon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public void UpdateDKN(DKN objDKN)
        {
            int i = 0;
            conn = connectDB.connectSQL_Bang_Ke_Dieu_Chinh();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("[Proc_Ins_Upt_Del]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objDKN.ID);
                cmd.Parameters.AddWithValue("@LoaiCapNhat", "UPT");
                cmd.Parameters.AddWithValue("@DBo", objDKN.danhba);
                //cmd.Parameters.AddWithValue("@SDon", "0");
                cmd.Parameters.AddWithValue("@LDon", objDKN.loaidon);
                cmd.Parameters.AddWithValue("@NNDon", objDKN.ngaynhandon);
                cmd.Parameters.AddWithValue("@NDDon", objDKN.noidung);
                cmd.Parameters.AddWithValue("@HieuLuc", objDKN.hieuluc);
                cmd.Parameters.AddWithValue("@BPYeuCau", objDKN.phongbandoi);
                cmd.Parameters.AddWithValue("@SoCVBP", objDKN.sovanban);
                cmd.Parameters.AddWithValue("@NgayLapCVBP", objDKN.ngaylapcv);
                cmd.Parameters.AddWithValue("@NhomKN", objDKN.nhomthongtin);
                cmd.Parameters.AddWithValue("@Qtt", objDKN.quan);
                cmd.Parameters.AddWithValue("@Ptt", objDKN.phuong);
                cmd.Parameters.AddWithValue("@KHang", objDKN.khachhang);
                cmd.Parameters.AddWithValue("@DChi", objDKN.diachi);
                cmd.Parameters.AddWithValue("@GChu", objDKN.ghichu);
                cmd.Parameters.AddWithValue("@HDon", objDKN.hoadon);
                cmd.Parameters.AddWithValue("@HDThueNha_CQNha", objDKN.HDThueNha);
                cmd.Parameters.AddWithValue("@GiayDangKyKD", objDKN.GDKKD);
                cmd.Parameters.AddWithValue("@HKhau_KT3", objDKN.HKKT3);
                cmd.Parameters.AddWithValue("@SoTamTru_XNTTru", objDKN.STTru);
                cmd.Parameters.AddWithValue("@GiayCap_DoiSoNha", objDKN.giaycapsonha);
                cmd.Parameters.AddWithValue("@GiayXNSoNha", objDKN.xacnhansonha);
                cmd.Parameters.AddWithValue("@GiayUngThuan", objDKN.giayungthuan);
                cmd.Parameters.AddWithValue("@GiayDangKyMST", objDKN.masothue);
                cmd.Parameters.AddWithValue("@MaNV", objDKN.manhanvien);
                cmd.Parameters.AddWithValue("@DThoaiKH", objDKN.dienthoai1);
                cmd.Parameters.AddWithValue("@MaNVKTra", objDKN.manhanvienkiemtra);
                cmd.Parameters.AddWithValue("@GM", objDKN.ganmoi);
                cmd.Parameters.AddWithValue("@KhongKiemTra", objDKN.khongkiemtra);
                cmd.Parameters.AddWithValue("@SMS", objDKN.sms);
                cmd.Parameters.AddWithValue("@XacNhanNo", objDKN.xacnhanno);
                cmd.ExecuteNonQuery();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi kết nối')</script>");
            }
            conn.Close();
        }
    }
}
