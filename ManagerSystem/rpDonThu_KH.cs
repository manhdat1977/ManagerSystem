using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ManagerSystem
{
    public partial class rpDonThu_KH : DevExpress.XtraReports.UI.XtraReport
    {
        ThamSo thamso = new ThamSo();
        public rpDonThu_KH()
        {
            InitializeComponent();
        }
        private void rpDonThuKH_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            //string ma = ThamSo.Masonhandon.Substring(ThamSo.Masonhandon.Length - 2, 2);
            if (lblLDon.ToString() == "KN")
            {
                chkSMS.Visible = false;
                lblFullName.Visible = true;
                lblHieuLuc.Visible = false;
            }
            else
            {
                chkSMS.Visible = true;
                lblFullName.Visible = false;
                lblHieuLuc.Visible = true;
            }
            lblDate.Text = "Tp.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + "";
        }

    }
}
