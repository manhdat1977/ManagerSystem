using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ManagerSystem
{
    public partial class reportNangSuat : DevExpress.XtraReports.UI.XtraReport
    {
        public static string topic = null;
        public reportNangSuat()
        {
            InitializeComponent();
        }

        private void reportNangSuat_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTopic.Text = topic;
        }

    }
}
