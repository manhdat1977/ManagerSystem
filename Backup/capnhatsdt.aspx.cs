using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManagerSystem.Prop;
using System.Data;
namespace ManagerSystem
{
    public partial class capnhatsdt : System.Web.UI.Page
    {
        SoDBo objSoDbo = new SoDBo();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblStatus.Visible = false;
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            objSoDbo.DB = txtDba.Text;
            dt = new DataTable();
            dt = objSoDbo.dtDbo(objSoDbo);
            txtSDT.Text = dt.Rows[0]["DThoai_SMS"].ToString();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            objSoDbo.DB = txtDba.Text;
            objSoDbo.DThoai_SMS = txtSDT_Moi.Text;
            int i = objSoDbo.Update_SDT(objSoDbo);
            if(i==1)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Cập nhật thành công";
                txtDba.Text = "";
                txtSDT.Text = "";
                txtSDT_Moi.Text = "";
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Cập nhật thất bại";
            }
        }
    }
}