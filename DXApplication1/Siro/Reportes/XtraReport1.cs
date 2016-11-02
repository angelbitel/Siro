using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Siro.Reportes
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var cnv = new Conversion();
            XRLabel label = (XRLabel)sender;
            double FieldValue = Convert.ToDouble(GetCurrentColumnValue("Monto"));
            string txt = cnv.enletras(FieldValue.ToString());
            (sender as XRLabel).Text = txt;
        }
        
    }
}
