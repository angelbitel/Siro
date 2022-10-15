using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Siro.Properties;

namespace Siro.F
{
    public partial class Inventario : DevExpress.XtraEditors.XtraForm
    {
        public Inventario()
        {
            InitializeComponent();
            //dockPanel1.FloatLocation = new Point(dockPanel1.FloatLocation.X, this.Location.Y);
        }
        public bool IsFormAlreadyOpen(string name)
        {
            foreach (Form item in this.MdiChildren) // check all opened forms
            {
                if (item.Name == name) // check by form name if it's opened
                {
                    item.BringToFront(); // bring it front
                    return true; //exit
                }
            }
            return false;
        }
        private void GenerarReporte(string reporte)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Inventario\\{0}.repx", reporte));
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = reporte;
            printTool3.ShowPreview();
        }
        private void OpenForm(DevExpress.XtraEditors.XtraForm frm)
        {
            if (!IsFormAlreadyOpen(frm.Name))
            {
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistroArroz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new I.IngresosRA());
        }

        private void btnAjusteInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new I.EntradasSalidas());
        }

        private void btnCerrarCicloArroz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new I.CerrarCiclo().ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new F.Dashboards("Inventario Silos").Show();
        }

        private void btnMovil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new I.VentasMovilesAgre());
        }
    }
}