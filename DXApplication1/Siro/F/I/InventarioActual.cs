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
using Siro.Properties;
using DevExpress.DataAccess.ConnectionParameters;

namespace Siro.F.I
{
    public partial class InventarioActual : DevExpress.XtraEditors.XtraForm
    {
        public string Dashboar { get; set; }
        public InventarioActual()
        {
            InitializeComponent();
            Dashboar = "InventarioProduccionEnProceso";
            dashboardViewer1.LoadDashboard(String.Format(@"Dashboards\{0}.xml", Dashboar));
        }
        private void dashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
        {
            var cnn = Settings.Default.slConnectionString.Split(';');
            var pcp = e.ConnectionParameters as MsSqlConnectionParameters;
            pcp.ServerName = cnn[0].Split('=')[1];
            pcp.Password = cnn[3].Split('=')[1];
            pcp.UserName = cnn[2].Split('=')[1];
            pcp.AuthorizationType = MsSqlAuthorizationType.SqlServer;
        }
    }
}