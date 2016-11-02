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
using DevExpress.XtraTreeList.Nodes;

namespace Siro.F.D
{
    public partial class FiltroCuentas : DevExpress.XtraEditors.XtraForm
    {
        public FiltroCuentas()
        {
            InitializeComponent();
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            var lstIds= new List<int>();
            treeList1.NodesIterator.DoOperation((n) => {
                if(n.Checked)
                {
                    lstIds.Add(int.Parse(n.GetValue("Id").ToString()));
                }
            });
            GenerarReporte(lstIds);
        }
        private void FiltroCuentas_Load(object sender, EventArgs e)
        {
            var control = new Controller.Contabilidad().CuentasMaestras(Principal.Bariables.IdEmpresa.Id);
            cuentasBindingSource.DataSource = control;
        }
        private void GenerarReporte(List<int> prmt)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(@"Reportes\\Diario\\DiarioCuentas.repx");
            report.Parameters["PrmAño"].Value = Principal.Bariables.PeridoContable.Year;
            report.Parameters["PrmMes"].Value = Principal.Bariables.PeridoContable.Month;
            report.Parameters["PrmCuentas"].Value = prmt;
            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "Reportes Por Cuentas";
            printTool3.ShowPreview();
        }
    }
}