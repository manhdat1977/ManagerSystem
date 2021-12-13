using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ManagerSystem.Prop
{
    public class SMS
    {
        SqlCommand cmd = new SqlCommand();
        public string KHang { get; set; }
        public string DThoai_SMS { get; set; }
        public string QTT { get; set; }
        public string PTT { get; set; }
        public string VungDMa { get; set; }

        public SMS() { }

    }
}