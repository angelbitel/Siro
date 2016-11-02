using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Contabilidad : DevExpress.XtraEditors.XtraForm
    {
        public Contabilidad()
        {
            InitializeComponent();
        }
        private void Contabilidad_Load(object sender, EventArgs e)
        {
            CambiarEmpresa();
        }

        private void CambiarEmpresa()
        {
            var q = string.Empty;
            if (Principal.Bariables.PeridoContable.Day <= 15)
                q = "Primera ";
            else
                q = "Segunda ";
            this.labelControl2.Text = string.Format("Proceso Contable de la {0} Quincena de {1} ", q, Principal.Bariables.PeridoContable.ToString("MMMM")).ToUpper();
            lblEmpresa.Text = Principal.Bariables.IdEmpresa.Nombre;
        }
        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.ItemName)
            {
                case "navBarItem1":
                    OpenForm(new F.D.CuentasPorPagar());
                    break;
                case "navBarItem2":
                    OpenForm(new F.D.CuentasPorCobrar());
                    break;
                case "navBarItem31":
                    OpenForm(new F.Diario());
                    break;
                case "navBarItem3":
                    GenerarReporte("DiarioDetallado", null);
                    break;
                case "navBarItem4":
                    GenerarReporte("Diario",null);
                    break;
                case "navBarItem5":
                    GenerarReporte("EstadosSituacion", null);
                    break;
                case "navBarItem6":
                    GenerarReporte("BalancePruebaMes", null);
                    break;
                case "navBarItem8":
                    GenerarReporte("Reporte Gastos", new int[]{6,9});
                    break;
                case "navBarItem9":
                    OpenForm(new F.D.FiltroCuentas());
                    break;
                case "navBarItem10":
                    OpenForm(new F.D.ShowBanco(false));
                    break;
                case "navBarItem11":
                    GenerarReporte("ChequesGenerados",null);
                    break;
                case "navBarItem12":
                    OpenForm(new F.D.ShowProveedores2());
                    break;
                case "navBarItem13":
                    GenerarReporte("EstadoResultados", null);
                    break;
            }

        }
        private void GenerarReporte(string reporte, int[] tip )
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", reporte));
            report.Parameters["PrmAño"].Value = Principal.Bariables.PeridoContable.Year;
            report.Parameters["PrmMes"].Value = Principal.Bariables.PeridoContable.Month;
            if (tip != null)
                report.Parameters["prmTipo"].Value = tip;

            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "R. " + reporte;
            printTool3.ShowPreview();
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
        private void OpenForm(DevExpress.XtraEditors.XtraForm frm)
        {
            if (!IsFormAlreadyOpen(frm.Name))
            {
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
    }
}