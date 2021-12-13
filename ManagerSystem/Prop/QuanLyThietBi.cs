using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace ManagerSystem.Prop
{
    public class QuanLyThietBi
    {
        public int id { get; set; }
        public string MaSo { get; set; }
        public string MaHieu { get; set; }
        public string Loai { get; set; }
        public string SoSeri { get; set; }
        public string CauHinh { get; set; }
        public string ThoiGianSuDung { get; set; }
        public string BoPhanSuDung { get; set; }
        public string NhanVienSuDung { get; set; }
        public string TinhTrangThietBi { get; set; }
        public string ViTri { get; set; }

        public QuanLyThietBi(){ }

        public DataTable FindDevice(QuanLyThietBi objQLTB)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.ConntectToQLTB();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_find_device", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasoTB", objQLTB.MaSo);
                cmd.Parameters.AddWithValue("@LoaiTB", objQLTB.Loai);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public void DeleteDevice(QuanLyThietBi objQLTB)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.ConntectToQLTB();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_delete_device", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objQLTB.id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        DataTable dt = new DataTable();
        public int InsertDevice(QuanLyThietBi objQLTB)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();

            int insert = 0;
            conn = connectDB.ConntectToQLTB();
            if (conn.State != ConnectionState.Open)
            {  
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_insert_device", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSoTB", objQLTB.MaSo);
                cmd.Parameters.AddWithValue("@HieuTB", objQLTB.MaHieu);
                cmd.Parameters.AddWithValue("@LoaiTB", objQLTB.Loai);
                cmd.Parameters.AddWithValue("@SoSeri", objQLTB.SoSeri);
                cmd.Parameters.AddWithValue("@CauHinh", objQLTB.CauHinh);
                cmd.Parameters.AddWithValue("@ThoiGianSudung", objQLTB.ThoiGianSuDung);
                cmd.Parameters.AddWithValue("@BoPhanSuDung", objQLTB.BoPhanSuDung);
                cmd.Parameters.AddWithValue("@NhanVienSudung", objQLTB.NhanVienSuDung);
                cmd.Parameters.AddWithValue("@TinhTrangThietBi", objQLTB.TinhTrangThietBi);
                cmd.Parameters.AddWithValue("@ViTri", objQLTB.ViTri);
                insert = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return insert;
        }
        public DataTable AllDevice()
        { 
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.ConntectToQLTB();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from ThongTinThietbi order by LoaiTB, HieuTB, BoPhanSuDung ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        public void UpdateDevice(QuanLyThietBi objQLTB)
        {
            SqlConnection conn = new SqlConnection();
            ConnectDB connectDB = new ConnectDB();
            conn = connectDB.ConntectToQLTB();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[proc_update_device]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objQLTB.id);
                cmd.Parameters.AddWithValue("@MaSoTB",objQLTB.MaSo);
                cmd.Parameters.AddWithValue("@HieuTB",objQLTB.MaHieu);
                cmd.Parameters.AddWithValue("@LoaiTB",objQLTB.Loai);
                cmd.Parameters.AddWithValue("@SoSeri",objQLTB.SoSeri);
                cmd.Parameters.AddWithValue("@CauHinh",objQLTB.CauHinh);
                cmd.Parameters.AddWithValue("@ThoiGianSudung",objQLTB.ThoiGianSuDung);
                cmd.Parameters.AddWithValue("@BoPhanSuDung",objQLTB.BoPhanSuDung);
                cmd.Parameters.AddWithValue("@NhanVienSudung",objQLTB.NhanVienSuDung);
                cmd.Parameters.AddWithValue("@TinhTrangThietBi",objQLTB.TinhTrangThietBi);
                cmd.Parameters.AddWithValue("@ViTri", objQLTB.ViTri);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}