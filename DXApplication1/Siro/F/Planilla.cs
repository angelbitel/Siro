using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Planilla : DevExpress.XtraEditors.XtraForm
    {
        public Planilla()
        {
            InitializeComponent();
            Entorno();
        }
        private void Entorno()
        {
            if (Controller.DescuentosGobierno.decimo)
            {
                navBarItem19.Enabled = true;
                navBarItem19.Appearance.ForeColor = System.Drawing.Color.Green;
                this.navBarItem19.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                lblMsg.Caption = "Este Mes Corresponde El Pago Del Decimo Tercer Mes";
            }
            else
            {
                navBarItem19.Enabled = false;
            }
            var controller = new Controller.Lst();
            navBarItem35.Caption = string.Format("Cumpleañeros Del Mes({0})", controller.Cumpleaños);
        }
        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraForm fr;
            switch (e.Link.ItemName)
            {
                case "navBarItem19":
                    if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        lblMsg.Caption = "";
                        Parallel.Invoke(() => CalculosDecimo());
                    }
                    break;
                case "navBarItem20":
                    GenerarReporte("ReporteFirmaDecimo", Principal.Bariables.PeridoContable);
                    break;
                case "navBarItem21":
                    GenerarReporte("TalonariosDecimo", Principal.Bariables.PeridoContable);
                    break;
                case "navBarItem27":
                    fr = new F.P.VerFactores();
                    if (!IsFormAlreadyOpen(fr.Name))
                    {
                        fr.MdiParent = this.MdiParent;
                        fr.Show();
                    }
                    break;
                case "navBarItem28":
                    GenerarReporte("Talonarios", Principal.Bariables.PeridoContable);
                    break;
                case "navBarItem29":
                    GenerarReporte("Planilla03", null);
                    break;
                case "navBarItem30":
                    GenerarReporte("ReporteFirma", Principal.Bariables.PeridoContable);
                    break;
                case "navBarItem31":
                    var f = new P.ColaboradorEm();
                    if (!IsFormAlreadyOpen(f.Name))
                    {
                        f.MdiParent = this.MdiParent;
                        f.Show();
                    }
                    break;
                case "navBarItem32":
                    new F.P.PruebaPlanilla().Show();
                    break;
                case "navBarItem33":
                    if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        lblMsg.Caption = "";
                        CalculosDeduccionesAcredores();
                        CalculosHoras();
                    }
                    break;
                case "navBarItem34":
                    if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        lblMsg.Caption = "";
                        GenerarAsientos();
                    }
                    break;
                case "navBarItem35":
                    OpenForm(new F.P.Cumpleaños());
                    break;
                case "navBarItem22":
                    var f1 = new P.PlanillaGenerada();
                    if (!IsFormAlreadyOpen(f1.Name))
                    {
                        f1.MdiParent = this.MdiParent;
                        f1.Show();
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
        private void ImprimirReportes(string rptName)
        {
            var printTool3 = new ReportPrintTool(XtraReport.FromFile(string.Format(@"Reportes\\Planilla\\{0}.repx",rptName), true));
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = rptName;
            printTool3.ShowPreview();
        }
        private void CalculosDecimo()
        {
            var proces = new Controller.Colaborador();
            lblMsg.Caption = "Ejecutando Procedo De Calculo Decimo Tercer Mes!!";
            if (proces.CalcularDecimo())
            {
                lblMsg.Caption = string.Format("Se Procesaron {0} Colaboradores ", proces.Procesados);
            }
        }
        private void CalculosDeduccionesAcredores()
        {
            var proces = new Controller.Colaborador();
            lblMsg.Caption = "Ejecutando Procedo De Deducciones Acredores!!";
            if (proces.ProcesarDeduccionesAcredores())
            {
                lblMsg.Caption = string.Format("Se Procesaron Deducciones Correctamente!!");
            }
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
        private void BuscarRegistrosHoras()
        {
            lblMsg.Caption = System.IO.File.Exists(Settings.Default.ArchivoPlanilla).ToString();
            if (!System.IO.File.Exists(Settings.Default.ArchivoPlanilla))
                return;
            var lines = System.IO.File.ReadAllLines(Settings.Default.ArchivoPlanilla);
            var lstHoras = new List<HorasTrabajadas>();
            foreach (var line in lines)
            {
                var str = Utility.SplitFixedWidth(line, false, new int[]{2,3,2,6,2,4});
                lstHoras.Add(new HorasTrabajadas
                {
                     Año = int.Parse(str[5]),
                     HoraTrabajada = decimal.Parse(str[3]),
                     IdColaborador = int.Parse(str[1]),
                     IdEmpresa = int.Parse(str[0]),
                     IdFactor = int.Parse(str[2]),
                     Mes = int.Parse(str[4])
                });
            }
            using (var db =new slPlanilla())
            {
                lstHoras.ForEach(f=> {
                    var row = db.HorasTrabajadas.Count(s => s.Año == f.Año && s.Mes == f.Mes && s.IdColaborador == f.IdColaborador && s.HoraTrabajada ==f.HoraTrabajada);
                    if(row == 0)
                    {                        
                        new Controller.HoraTrabjada().Guardar(f);
                    }
                    this.lblMsg.Caption = string.Format("Procesando La Hora {0} del codigo colaborador {1}:", f.IdColaborador, f.HoraTrabajada);
                });
                this.lblMsg.Caption = "Proceso Terminado";
            }
        }
        private void Planilla_Load(object sender, EventArgs e)
        {
            var q=string.Empty;
            if(Principal.Bariables.PeridoContable.Day <= 15)
                q="Primera ";
            else
                q="Segunda ";
            this.labelControl2.Text = string.Format("Procesando Planilla de la {0} Quincena de {1} ", q, Principal.Bariables.PeridoContable.ToString("MMMM")).ToUpper();
        }
        public void CalculosHoras()
        {
            BuscarRegistrosHoras();
            var proces = new Controller.Colaborador();
            proces.CalculosHoras();

            lblMsg.Caption = proces.MSG;
        }
        public void GenerarAsientos()
        {
            BuscarRegistrosHoras();
            var proces = new Controller.Colaborador();
            proces.GenerarAsientos();

            lblMsg.Caption = proces.MSG;
        }
        private void GenerarReporte(string reporte, DateTime? perido )
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Planilla\\{0}.repx", reporte));
            report.Parameters["prmIdEmpresa"].Value = Settings.Default.DIdEmpresa;
            if(perido != null)
                report.Parameters["prmFecha"].Value = perido;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = reporte;
            printTool3.ShowPreview();
        }
    }
}