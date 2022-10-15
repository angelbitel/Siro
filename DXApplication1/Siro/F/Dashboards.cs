using DevExpress.DataAccess.ConnectionParameters;
using Siro.Properties;
using System;

namespace Siro.F
{
    public partial class Dashboards : DevExpress.XtraEditors.XtraForm
    {
        private string Dashboard { get; set; }
        public Dashboards(string dashboard)
        {
            Dashboard = dashboard;
            InitializeComponent();
            dashboardViewer1.LoadDashboard(String.Format(@"Dashboards\{0}.xml",Dashboard));
        }
        private void dashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
        {
            var cnn = Settings.Default.CnnReport.Split(';');
            var pcp = e.ConnectionParameters as MsSqlConnectionParameters;
            pcp.ServerName = cnn[0].Split('=')[1];
            pcp.DatabaseName = cnn[1].Split('=')[1];
            pcp.UserName = cnn[3].Split('=')[1];
            pcp.Password = cnn[4].Split('=')[1];
            pcp.AuthorizationType = MsSqlAuthorizationType.SqlServer;
        }
    }
}