using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class BKDC
    {
        SqlConnection conn = new SqlConnection();
        ConnectDB condb = new ConnectDB();
        SqlCommand cmd = new SqlCommand();

        public string MaSNDon { get; set; }
        public string TTin { get; set; }
        public string Dbo { get; set; }
        public string SDon { get; set; }
        public string LDon { get; set; }
        public string NNDon { get; set; }
        public int SBKeBD { get; set; }
        public string HLucBD { get; set; }
        public string NgayInBK { get; set; }
        public string NhomKN { get; set; }
        public string NgayNhapDC { get; set; }
        public string DThoai { get; set; }
        public int Dot { get; set; }
        public string MLTrinh { get; set; }
        public string HDong { get; set; }
        public string KHang { get; set; }
        public string DChi { get; set; }
        public string DChi_TruSo { get; set; }
        public string MSThue { get; set; }
        public string GBieu { get; set; }
        public int TLSHoat { get; set; }
        public int TLCQuan { get; set; }
        public int TLSXuat { get; set; }
        public int TLKdoanh { get; set; }
        public int DMuc { get; set; }
        public int DMuc_HoNgheo { get; set; }
        public string KHangDC { get; set; }
        public string DChiDC { get; set; }
        public string DChi_TruSoDC { get; set; }
        public string MSThueDC { get; set; }
        public string GBieuDC { get; set; }
        public int TLSHoatDC { get; set; }
        public int TLCQuanDC { get; set; }
        public int TLSXuatDC { get; set; }
        public int TLKDoanhDC { get; set; }
        public int DMucDC { get; set; }
        public string MNNghe { get; set; }
        public string MNNgheDC { get; set; }
        public Boolean InBD { get; set; }
        public string MaNV { get; set; }
        public string QTT { get; set; }
        public string PTT { get; set; }
        public string NguoiKy { get; set; }
        public string NVNhanHS { get; set; }
        public Boolean CatDMTrung { get; set; }
        public int DMuc_HoNgheoDC { get; set; }
        public string GChu { get; set; }
        public BKDC() { }

        public int InsertBKDC(BKDC objBKDC)
        {
            int i = 0;
            conn = condb.connectSQL_Bang_Ke_Dieu_Chinh();
            if(conn.State!=ConnectionState.Open)
            {
                conn.Open();
                cmd = new SqlCommand("proc_Ins_BKDC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSNDon",objBKDC.MaSNDon);
                cmd.Parameters.AddWithValue("@DBo", objBKDC.Dbo);
                cmd.Parameters.AddWithValue("@SDon", objBKDC.SDon);
                cmd.Parameters.AddWithValue("@LDon", objBKDC.LDon);
                cmd.Parameters.AddWithValue("@NNDon", objBKDC.NNDon);
                cmd.Parameters.AddWithValue("@NhomKN", objBKDC.NhomKN);
                cmd.Parameters.AddWithValue("@DThoai", objBKDC.DThoai);
                cmd.Parameters.AddWithValue("@Dot", objBKDC.Dot);
                cmd.Parameters.AddWithValue("@MLTrinh", objBKDC.MLTrinh);
                cmd.Parameters.AddWithValue("@HDong", objBKDC.HDong);
                cmd.Parameters.AddWithValue("@KHang", objBKDC.KHang);
                cmd.Parameters.AddWithValue("@DChi", objBKDC.DChi);
                cmd.Parameters.AddWithValue("@DChi_TruSo", objBKDC.DChi_TruSo);
                cmd.Parameters.AddWithValue("@MSThue", objBKDC.MSThue);
                cmd.Parameters.AddWithValue("@GBieu", objBKDC.GBieu);
                cmd.Parameters.AddWithValue("@TLSHoat", objBKDC.TLSHoat);
                cmd.Parameters.AddWithValue("@TLCQuan", objBKDC.TLCQuan);
                cmd.Parameters.AddWithValue("@TLSXuat", objBKDC.TLSXuat);
                cmd.Parameters.AddWithValue("@TLKDoanh", objBKDC.TLKdoanh);
                cmd.Parameters.AddWithValue("@DMuc", objBKDC.DMuc);
                cmd.Parameters.AddWithValue("@KHangDC", objBKDC.KHangDC);
                cmd.Parameters.AddWithValue("@DChiDC", objBKDC.DChiDC);
                cmd.Parameters.AddWithValue("@DChi_TruSoDC", objBKDC.DChi_TruSoDC);
                cmd.Parameters.AddWithValue("@MSThueDC", objBKDC.MSThueDC);
                cmd.Parameters.AddWithValue("@GBieuDC", objBKDC.GBieuDC);
                cmd.Parameters.AddWithValue("@TLSHoatDC", objBKDC.TLSHoatDC);
                cmd.Parameters.AddWithValue("@TLCQuanDC", objBKDC.TLCQuanDC);
                cmd.Parameters.AddWithValue("@TLSXuatDC", objBKDC.TLSXuatDC);
                cmd.Parameters.AddWithValue("@TLKDoanhDC", objBKDC.TLKDoanhDC);
                cmd.Parameters.AddWithValue("@DMucDC", objBKDC.DMucDC);
                cmd.Parameters.AddWithValue("@MNNghe", objBKDC.MNNghe);
                cmd.Parameters.AddWithValue("@MNNgheDC", objBKDC.MNNgheDC);
                cmd.Parameters.AddWithValue("@GChu", objBKDC.GChu);
                cmd.Parameters.AddWithValue("@InBD", objBKDC.InBD);
                cmd.Parameters.AddWithValue("@MaNV", objBKDC.MaNV);
                cmd.Parameters.AddWithValue("@QTT", objBKDC.QTT);
                cmd.Parameters.AddWithValue("@PTT", objBKDC.PTT);
                cmd.Parameters.AddWithValue("@NVNhanHS", objBKDC.NVNhanHS);
                cmd.Parameters.AddWithValue("@CatDMTrung", objBKDC.CatDMTrung);
                cmd.Parameters.AddWithValue("@DMuc_HoNgheo", objBKDC.DMuc_HoNgheo);
                cmd.Parameters.AddWithValue("@DMuc_HoNgheoDC", objBKDC.DMuc_HoNgheoDC);
                i = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return i;
        }
    }  
}