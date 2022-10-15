using Siro.Properties;
using DevExpress.DataAccess.ConnectionParameters;

namespace Siro.F
{
    public partial class DashboardDesigner : DevExpress.XtraEditors.XtraForm
    {
        public DashboardDesigner() => InitializeComponent();

        private void dashboardDesigner1_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
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