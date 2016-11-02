using DevExpress.XtraReports.UI;
using Siro.Model;
using Siro.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siro.F.D
{
    public partial class Banco : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        List<ClienteMini> lstClientes = new List<ClienteMini>();
        List<Bancos> lstBancos = new List<Bancos>();
        List<Model.Cuentas> Cuentas { get; set; }
        List<Model.Cuentas> Personas { get; set; }
        public Banco()
        {
            InitializeComponent();
        }

        private void Banco_Load(object sender, EventArgs e)
        {
            Task task = Task.Run(() => CargarDatos());
            clientesBindingSource.DataSource = lstClientes;
            bancosBindingSource.DataSource = lstBancos;
            dateEditFecha.EditValue = DateTime.Now;
            int?[] debito = { 1, 5, 6, 7, 9 };
            int?[] credito = { 2, 3, 4 };
            //var control = new Controller.Contabilidad().Cuentas(Principal.Bariables.IdEmpresa.Id, debito);
            //var control2 = new Controller.Contabilidad().Cuentas(Principal.Bariables.IdEmpresa.Id, credito);

            //TreeListCuentasCredito.Properties.DataSource = control2;
            TreeListCuentasCredito.Properties.DisplayMember = "Text";
            TreeListCuentasCredito.Properties.ValueMember = "ID";
            TreeListCuentasCredito.Properties.AutoExpandAllNodes = false;

            //TreeListCuentasDebito.Properties.DataSource = control;
            TreeListCuentasDebito.Properties.DisplayMember = "Text";
            TreeListCuentasDebito.Properties.ValueMember = "ID";
            TreeListCuentasDebito.Properties.AutoExpandAllNodes = false;

            Personas = new Controller.Contabilidad().Personas(Principal.Bariables.IdEmpresa.Id);
            TreeListPersona.Properties.DataSource = Personas;
            TreeListPersona.Properties.DisplayMember = "Text";
            TreeListPersona.Properties.ValueMember = "ID";
            TreeListPersona.Properties.AutoExpandAllNodes = false;
            
        }
        public void CargarDatos()
        {
            dbContext.Clientes.Select(s => new { s.idCliente, s.NombreCompleto, s.CedulaRuc }).ToList().ForEach(f =>
            {
                lstClientes.Add(new ClienteMini
                {
                    CedulaRuc = f.CedulaRuc,
                    idCliente = f.idCliente,
                    NombreCompleto = f.NombreCompleto
                });
            });
            dbContext.Bancos.ToList().ForEach(f =>
            {
                lstBancos.Add(new Bancos
                {
                    Banco = f.Banco,
                    IdBanco = f.IdBanco,
                    NumeroCuenta = f.NumeroCuenta
                });
            });
        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            Controller.Banco bc = new Controller.Banco();
            var per = new Model.Cuentas();
            if (!Utility.EsNum(tMonto.Text))
            {
                lblMsg.Caption = "Coloque el Monto Del Cheque";
                return;
            }
            if (!Utility.EsNum(TreeListPersona.EditValue.ToString()))
            {
                lblMsg.Caption = "Seleccione un Cliente, Proveedor O Colaborador";
                return;
            }
            var sndBanco = new RegistrosBanco
            {
                NumeroCuenta = tNumeroCuenta.Text,
                FechaCheque = dateEditFecha.DateTime,
                IdBanco = IdBanco,
                IdUser = Principal.Bariables.IdUsuario,
                Monto = decimal.Parse(tMonto.Text),
                NumeroCheque = tNumCheque.Text,
                IdEmpresa = Principal.Bariables.IdEmpresa.Id
            };
            if (Convert.ToInt32(TreeListPersona.EditValue.ToString()) > 0)
            {
                var t = int.Parse(TreeListPersona.EditValue.ToString());
                var row = Personas.SingleOrDefault(s => s.ID == t);
                if (row != null)
                {
                    per = row;
                    //switch (row.Tipo)
                    //{
                    //    case 1:
                    //        sndBanco.idProvedor = per.ID - 10;
                    //        break;
                    //    case 2:
                    //        sndBanco.IdColaborador = per.ID - 100;
                    //        break;
                    //    case 3:
                    //        sndBanco.IdCliente = per.ID - 300;
                    //        break;
                    //}
                }
            }
            if (Convert.ToInt32(TreeListCuentasCredito.EditValue.ToString()) > 0)
            {
                var t = int.Parse(TreeListCuentasCredito.EditValue.ToString());
                sndBanco.IdCredito = t;
            }
            else {
                lblMsg.Caption = "Seleccione Cuenta CRedito!!...";
                return;
            }
            if (Convert.ToInt32(TreeListCuentasDebito.EditValue.ToString()) > 0)
            {
                var t = int.Parse(TreeListCuentasDebito.EditValue.ToString());
                sndBanco.IdDebito = t;
            }
            else
            {
                lblMsg.Caption = "Seleccione Cuenta CRedito!!...";
                return;
            }
            var res= bc.Agregar(sndBanco);
            lblMsg.Caption = bc.MSG;
            if(res)
            {
                /*Agragar Valores a las propiedades de forma que hizo el llamado*/
                Diario.IdCliente = IdCliente;
                Diario.NombreCliente = Cliente;
                Diario.MontoFactura = sndBanco.Monto ?? 0;
                Diario.IdRegistroBanco = bc.NuevoId;
                simpleButton2.PerformClick();
            }
            simpleButton1.PerformClick();
        }
        private int IdCliente { get; set; }
        private string Cliente { get; set; }
        private int IdBanco { get; set; }
        private void gridLookUpEditBanco_EditValueChanged(object sender, EventArgs e)
        {
            if (Utility.EsNum(gridLookUpEditBanco.EditValue.ToString()))
            {
                IdBanco = int.Parse(gridLookUpEditBanco.EditValue.ToString());
                lblMsg.Caption = "Banco Seleccionado: " + gridLookUpEditBanco.Text;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tNumCheque.ResetText();
            tNumeroCuenta.ResetText();
            tMonto.Text="00.00";
            tConcepto.ResetText();
        }
        int docBanc = 0;
        private int NumDoc()
        {
            int idPer = 0;
            var t = int.Parse(TreeListPersona.EditValue.ToString());
            var row = Personas.SingleOrDefault(s => s.ID == t);
            if (row == null)
                return 0;
            //switch (row.Tipo)
            //{
            //    case 1:
            //        idPer = t - 10;
            //        break;
            //    case 2:
            //        idPer = t - 100;
            //        break;
            //    case 3:
            //        idPer = t - 300;
            //        break;
            //}
            var res = dbContext.RegistrosBanco.Where(s => s.IdCliente == idPer || s.IdColaborador == idPer || s.idProvedor == idPer).Max(m => m.IdRegistroBanco);
            docBanc = res;
            return docBanc;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            docBanc = NumDoc();
            XtraReport1 report = new XtraReport1();
            report.Parameters["prmRegistroBanco"].Value = docBanc;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(docBanc >0)
                docBanc--;
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            XtraReport1 report = new XtraReport1();
            docBanc = NumDoc();
            report.Parameters["prmRegistroBanco"].Value = docBanc;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            docBanc++;
            GenerarReporte();
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();
            docBanc = NumDoc();
            report.Parameters["prmRegistroBanco"].Value = docBanc;
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowPreviewDialog();
            }
        }
    }
}