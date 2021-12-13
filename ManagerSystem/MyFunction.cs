using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ManagerSystem
{
    
    public class MyFunction
    {
        public static void MessageBox(Page page, string strMsg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "PopupScript", "alert('" + strMsg.ToString() + "')", true);
        }
    }
}