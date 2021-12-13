using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManagerSystem.Prop;
namespace ManagerSystem
{
    public partial class lichsukiemtra : System.Web.UI.Page
    {
        GiaiQuyetDon obj = new GiaiQuyetDon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                obj.dbo = Request.QueryString["ID"];
                gridLichSuKtra.DataSource = obj.LichSuKiemTra(obj);
                gridLichSuKtra.DataBind();
            }
        }
    }
}