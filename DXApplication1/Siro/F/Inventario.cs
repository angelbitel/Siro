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
        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.ItemName)
            {
                case "navBarItem1":
                   new I.CerrarCiclo().ShowDialog();
                   break;
                case "navBarItem2":
                   GenerarReporte("Iventario Fecha");
                   break;
                case "navBarItem3":
                   GenerarReporte("Inventario Silos");
                   break;
                case "navBarItem31":
                    OpenForm(new I.IngresosRA());
                    break;
                case "navBarItem20":
                    GenerarReporte("ReporteFirmaDecimo");
                    break;
                case "navBarItem21":
                    GenerarReporte("TalonariosDecimo");
                    break;
                case "navBarItem27":
                    OpenForm(new F.P.VerFactores());
                    break;
                case "navBarItem28":
                    OpenForm(new F.I.InventarioActual());
                    break;
                case "navBarItem29":
                    GenerarReporte("Planilla03");
                    break;
                case "navBarItem30":
                    GenerarReporte("ReporteFirma");
                    break;
                case "navBarItem32":
                    new F.P.PruebaPlanilla().Show();
                    break;
                case "navBarItem33":
                    OpenForm(new I.EntradasSalidas());
                    break;
                case "navBarItem34":
                    if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        lblMsg.Caption = "";
                    }
                    break;
            }
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
    }
}