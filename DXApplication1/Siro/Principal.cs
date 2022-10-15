using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraReports.UI;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro
{
    public partial class Principal : DevExpress.XtraEditors.XtraForm
    {
        public static Model.V Bariables = new Model.V();
        public static Principal This { get; set; }
        public static List<Model.MaestroContable> LstCuentas = new List<Model.MaestroContable>();
        public Principal()
        {
            Bariables.IdEmpresa = new Model.Empresa();
            Bariables.db = new slEntities();

            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            This = this;
            AddDocumentManager();
            //new F.Login().ShowDialog();
            //if (!Bariables.HabilitarP)
            //    this.Close();
            PrepararUi();
            if(Settings.Default.DIdEmpresa != 0)
            {
                Bariables.IdEmpresa.Id = Settings.Default.DIdEmpresa;
                Bariables.IdEmpresa.Nombre = Settings.Default.DEmpresa;
                Bariables.PeridoContable = Settings.Default.DFecha;

                var prm = new Model.Prmts(Bariables.IdEmpresa.Id);
                Bariables.IdCuentaCliente = prm.IdCuentaCliente;
                Bariables.IdCuentaEmpleado = prm.IdCuentaEmpleado;
                Bariables.IdCuentaItbm = prm.IdCuentaItbm;
                Bariables.IdCuentaProveedor = prm.IdCuentaProveedor;
                Bariables.IdCuentaBanco = prm.IdCuentaBanco;
                Bariables.IdCaja = prm.IdCaja;
                Bariables.IdBancoCXC = prm.IdBancoCXC;
            }
            var q = string.Empty;
            if (Principal.Bariables.PeridoContable.Day <= 15)
                q = "Primera ";
            else
                q = "Segunda ";
            this.Text = string.Format("Periodo {1}, {2} Quincena [{0}]", Settings.Default.DEmpresa, Settings.Default.DFecha.ToString(" yyyy MMMM"), q);
            Bariables.Desde =  new DateTime(DateTime.Now.Year, 1, 1);
            Bariables.Hasta = DateTime.Now;
            dockPanel1.Text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Bariables.Usuario);
            Task.Run(async () =>
            {
                var cont = new Controller.VMContabilidad();
                var resCuentas = await cont.CuentasContables();
                resCuentas.ForEach(f => LstCuentas.Add(new Model.MaestroContable { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.CuentaContable, Text = f.Text }));
            });
        }
        private void OpenForm(DevExpress.XtraEditors.XtraForm frm)
        {
            if (!IsFormAlreadyOpen(frm.Name))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.ItemName)
            {
                case "navBarItem1":
                    new F.Dashboards("Ventas").Show();
                    break;
                case "navBarItem2":
                    OpenForm(new F.D.Factura());
                    break;
                case "navBarItem3":
                    new F.Dashboards("Proveedores").Show();
                    break;
                case "navBarItem4":
                    OpenForm(new F.Inventario());
                    break;
                case "navBarItem5":
                    OpenForm(new F.D.MaestrosCuentas());
                    break;
                case "navBarItem6":
                    OpenForm(new F.Cliente());
                    break;
                case "navBarItem7":
                    OpenForm(new F.Producto());
                    break;
                case "navBarItem8":
                    OpenForm(new F.Usuario());
                    break;
                case "navBarItem9":
                    OpenForm(new F.Perfil());
                    break;
                case "navBarItem10":
                    OpenForm(new F.Empresa());
                    break;
                case "navBarItem12":
                    new F.Dashboards("Contabilidad").Show();
                    break;
                case "navBarItem13":
                    var f7 = new F.CrearModificarReporte();
                        f7.Show();
                    break;
                case "navBarItem14":
                    OpenForm(new F.Servicio());
                    break;
                case "navBarItem15":
                    OpenForm(new F.Facturacion.Categoria());
                    break;
                case "navBarItem16":
                    new F.Dashboards("EstadoResultados").Show();
                    break;
                case "navBarItem17":
                    OpenForm(new F.Planilla());
                    break;
                case "navBarItem18":
                    OpenForm(new F.Cotizacion());
                    break;
                case "navBarItem19":
                    new F.D.Periodo().ShowDialog();                    
                    var q = string.Empty;
                    if (Principal.Bariables.PeridoContable.Day <= 15)
                        q = "Primera ";
                    else
                        q = "Segunda ";
                    this.Text = string.Format("Periodo {1}, {2} Quincena [{0}]", Settings.Default.DEmpresa, Settings.Default.DFecha.ToString(" yyyy MMMM"), q);
                    break;
                case "navBarItem20":
                    OpenForm(new F.Contabilidad());
                    break;
                case "navBarItem21":
                    new F.DashboardDesigner().ShowDialog();
                    break;
                case "navBarItem22":
                    OpenForm(new F.D.Proveedores());
                    break;
                case "navBarItem23":
                    new F.Dashboards("Bancos").Show();
                    break;
                case "navBarItem25":
                    GenerarReporteD("BalancePrueba", null);
                    break;
                case "navBarItem26":
                    GenerarReporteDFecha("EstadosSituacionFechas", null);
                    break;
                case "navBarItem27":
                    GenerarReporteDFecha("EstadoResultadosFechas", null);
                    break;
                case "navBarItem28":
                    GenerarReporteDFecha("Reporte Gastos Fechas", null);
                    break;
                case "navBarItem29":
                    OpenForm(new F.D.ShowBanco(true));
                    break;
                case "navBarItem32":
                    GenerarReporteDFecha("DiarioDetalladoFecha", null);
                    break;
                case "navBarItem33":
                    new F.Dashboards("Gastos").Show();
                    break;
                case "navBarItem34":
                    new F.Dashboards("CuentasXPagar").Show();
                    break;
                case "navBarItem30":
                    OpenForm(new F.Facturacion.Almacen());
                    break;
                case "navBarItem24":
                    OpenForm(new F.Facturacion.Marca());
                    break;
                case "navBarItem31":
                    OpenForm(new F.I.SilosInfo());
                    break;
                case "navBarItem35":
                    OpenForm(new F.I.Vendedores());
                    break;
                case "navBarItem36":
                    var frm = new F.D.MantenimientoCuentas();
                    OpenForm(frm);
                    break;
                case "navBarItem37":
                    OpenForm(new F.VMaestroCuentas());
                    break;
                case "navBarItem38":
                    new F.Dashboards("Balance Prueba").Show();
                    break;
                case "navBarItem39":
                    new F.PeriodosFiscales().ShowDialog();
                    break;
            }
        }
        private void GenerarReporteD(string reporte, int[] tip)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", reporte));
            report.Parameters["PrmAño"].Value = Principal.Bariables.PeridoContable.Year;
            report.Parameters["PrmMes"].Value = Principal.Bariables.PeridoContable.Month;
            if (tip != null)
                report.Parameters["prmTipo"].Value = tip;

            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this;
            printTool3.PreviewForm.Text = "R. " + reporte;
            printTool3.ShowPreview();
        }
        private void GenerarReporteDFecha(string reporte, int[] tip)
        {
            var f = new Siro.F.D.FiltroFecha();
            f.ShowDialog(this);
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", reporte));
            report.Parameters["prmDesde"].Value = f.Desde;
            report.Parameters["prmHasta"].Value = f.Hasta;
            if (tip != null)
                report.Parameters["prmTipo"].Value = tip;

            report.Parameters["prmIdEmpresa"].Value = Principal.Bariables.IdEmpresa.Id;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this;
            printTool3.PreviewForm.Text = "R. " + reporte;
            printTool3.ShowPreview();
        }
        public void GenerarMayor()
        {
            var f7 = new F.D.Mayor();
            if (!IsFormAlreadyOpen(f7.Name))
            {
                f7.MdiParent = this;
                f7.Show();
            }
        }
        void AddDocumentManager()
        {
            var manager = new DocumentManager();
            manager.MdiParent = this;
            manager.View = new TabbedView();
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
        public void PrepararUi()
        {
            var perfil = Bariables.db.DetallesPerfil.Where(s => s.IdPerfil == Bariables.IdPerfil).ToList();
            if (perfil.Count > 1)
            {
                perfil.ForEach(f =>
                {
                    for (int i = 0; i < navBarControl1.Items.Count; i++)
                    {
                        if (f.MenuName == navBarControl1.Items[i].Name)
                        {
                            navBarControl1.Items[i].Enabled = true;
                            break;
                        }
                    }
                });
            }
        }
        private void dockPanel1_CustomButtonChecked(object sender, ButtonEventArgs e)
        {
            if (e.Button == dockPanel1.CustomHeaderButtons[0])
            {
                new F.Perfiles().ShowDialog();
            }
        }
    }
}