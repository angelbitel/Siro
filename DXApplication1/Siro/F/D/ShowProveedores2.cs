using DevExpress.XtraReports.UI;
using System;
using System.Linq;

namespace Siro.F.D
{
    public partial class ShowProveedores2 : DevExpress.XtraEditors.XtraForm
    {
        public ShowProveedores2()
        {
            InitializeComponent();
        }

        private void ShowProveedores2_Load(object sender, EventArgs e)
        {
            var contenedor = new Controller.CuentasXPagar().Proveedores().OrderBy(o=> o.Proveedor).ToList();
            provedoresBindingSource.DataSource = contenedor;
        }
        private void GenerarReporte(int prmt)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", "HistorialPagosProveedor"));
            report.Parameters["PrmProveedor"].Value = prmt;
            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "Historial Pagos";
            printTool3.ShowPreview();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenerarReporte(int.Parse(gluBanco1.EditValue.ToString()));
        }
    }
}