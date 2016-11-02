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
using System.Collections;

namespace Siro.F.D
{
    public partial class ShowBanco : DevExpress.XtraEditors.XtraForm
    {
        private bool fcha { get; set; }
        public ShowBanco(bool f)
        {
            InitializeComponent();
            fcha = f;
        }

        private void ShowBanco_Load(object sender, EventArgs e)
        {
            var contenedorBanco = new Controller.CuentasXPagar().LstBancos();
            bancosBindingSource.DataSource = contenedorBanco;
        }

        private void gluBanco1_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void GenerarReporte(int prmt)
        {
            if (fcha)
            {
                var f = new Siro.F.D.FiltroFecha();
                f.ShowDialog(this);
            }
            var lst = new List<int>();
            for (int i = 0; i < gridView5.SelectedRowsCount; i++)
            {
                lst.Add((gridView5.GetRow(gridView5.GetSelectedRows()[i]) as Bancos).IdBanco);
            }

            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", "Movimento Banco Fechas"));
            report.Parameters["prmDesde"].Value = Principal.Bariables.Desde;
            report.Parameters["prmHasta"].Value = Principal.Bariables.Hasta;
            report.Parameters["PrmIdBanco"].Value = lst;
            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent =  this.MdiParent;
            printTool3.PreviewForm.Text = "Movimento Banco";
            printTool3.ShowPreview();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenerarReporte(1);
        }
    }
}