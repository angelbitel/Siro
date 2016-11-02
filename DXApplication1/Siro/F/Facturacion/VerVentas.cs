using System;

namespace Siro.F.Facturacion
{
    public partial class VerVentas : DevExpress.XtraEditors.XtraForm
    {
        public VerVentas()
        {
            InitializeComponent();
        }

        private void VerVentas_Load(object sender, EventArgs e)
        {
            SetDashBoardPanel(@"Dashboards\Ventas.xml");
        }
        private void SetDashBoardPanel(string rept)
        {
            dashboardViewer1.LoadDashboard(rept);
        }
    }
}