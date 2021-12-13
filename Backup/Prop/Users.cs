using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class Users
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MatMa { get; set; }
        public string ChucDanh { get; set; }
        public string Quyen { get; set; }
        public int ID { get; set; }
    }

}