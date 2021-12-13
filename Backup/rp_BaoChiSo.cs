using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ManagerSystem
{
    public partial class rp_BaoChiSo : DevExpress.XtraReports.UI.XtraReport
    {
        public static string topic = null;
        public rp_BaoChiSo()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTopic.Text = topic;
        }

    }
}
