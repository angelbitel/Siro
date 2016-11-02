using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Siro.Model;
using Siro.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Siro.F.D
{
    public partial class CuentasPorCobrar : DevExpress.XtraEditors.XtraForm
    {
        public CuentasPorCobrar()
        {
            InitializeComponent();
        }
        BindingList<DetallesFactura> Cuentas = new BindingList<DetallesFactura>();
        private int IdCliente { get; set; }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                lblMsg.Caption = "Seleccione un Cliente..";
                return;
            }
            var ejec = new Controller.CuentasXPagar();
            var row = new Siro.Factura
            {
                Fecha = dtFecha.DateTime,
                IdCliente = IdCliente,
                NumeroFactura = txtNumFactura.Text,
                DetallesFactura = new List<DetallesFactura>(),
                ModoPago = cmbTerminoPago.Text,
                Glosa = txtGlosa.Text,
                FechaVencimiento = dtFVencimiento.DateTime,
                Tipo = 2,
                MontoPagado =0,
                IdEmpresa = Principal.Bariables.IdEmpresa.Id
            };
            row.DetallesFactura = Cuentas;
            if (cmbTerminoPago.SelectedIndex == 0)
                row.MontoPagado = Cuentas.Sum(s => s.Total);
            else
                row.MontoPagado = 0;
            var eje=ejec.Guardar(row,false);
            if (eje)
            {
                lblMsg.Caption = ejec.MSG;
                var ejecA = new Controller.Diario();
                var asiento = new Asientos
                {
                    IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                    Fecha = row.Fecha,
                    FechaCreacion = DateTime.Now,
                    Comentario = row.Glosa,
                    IdUser = Principal.Bariables.IdUsuario,
                    DetalleAsientos = new List<DetalleAsientos>()
                };
                var dtAsiento = new List<DetalleAsientos>();

                row.DetallesFactura.ToList().ForEach(f =>
                {
                    int idCuenta = Principal.Bariables.IdCaja;
                    if (row.ModoPago == "Contado")
                        idCuenta = Principal.Bariables.IdCaja;
                    else if (row.ModoPago == "Cheque")
                        idCuenta = Principal.Bariables.IdBancoCXC;
                    else
                        idCuenta = Principal.Bariables.IdCuentaCliente;

                    dtAsiento.Add(new DetalleAsientos
                    {
                        Debito = f.Monto * f.Cantidad,
                        IdMaestroCuenta = idCuenta,
                        IdCliente = IdCliente
                    });
                    if (f.ITBMS > 0)
                    {
                        dtAsiento.Add(new DetalleAsientos
                        {
                            Credito = f.ITBMS,
                            IdMaestroCuenta = Principal.Bariables.IdCuentaItbm
                        });
                    }
                    dtAsiento.Add(new DetalleAsientos
                    {
                        Credito = f.Total,
                        IdMaestroCuenta = f.IdCuentaContable
                    });
                });

                asiento.DetalleAsientos = dtAsiento;

                if (ejecA.AgregarAsiento(asiento))
                    lblMsg.Caption = ejecA.MSG;
                Cuentas.Clear();
            }
            else
            {
                lblMsg.Caption = ejec.MSG;
            }
        }
        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdCliente = int.Parse(gluProveedor.EditValue.ToString());
        }
        private void cmbTerminoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dias = 0;
            switch (cmbTerminoPago.SelectedIndex)
            {
                case 0:
                    dias = 0;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = true;
                    break;
                case 1:
                    dias = 0;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = true;
                    break;
                case 2:
                    dias = 7;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 3:
                    dias = 15;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 4:
                    dias = 30;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 5:
                    dias = 45;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 6:
                    dias = 60;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 7:
                    dias = 90;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 8:
                    dtFVencimiento.Enabled = true;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 9:
                    dtFVencimiento.Enabled = true;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 10:
                    dtFVencimiento.Enabled = true;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 11:
                    dtFVencimiento.Enabled = true;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 12:
                    dtFVencimiento.Enabled = true;
                    layoutControlGroup6.Enabled = false;
                    break;
                default:
                    break;
            }
            dtFVencimiento.DateTime = DateTime.Now.AddDays(dias);
        }
        private void gridView7_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            bool rItbm = bool.Parse((gridView7.GetFocusedRowCellValue(colRItbms) ?? "false").ToString());
            var cnt = int.Parse((gridView7.GetFocusedRowCellValue(colCantidad) ?? "0").ToString());
            var mnt = decimal.Parse((gridView7.GetFocusedRowCellValue(colMonto) ?? "0").ToString());
            var itbm = (cnt * mnt) * (rItbm ? 0.07M : 0);
            var total = (cnt * mnt) + itbm;

            view.SetRowCellValue(e.RowHandle, colITBMS, itbm);
            view.SetRowCellValue(e.RowHandle, colTotal, total);
        }
        List<ClienteMini> lstClientes = new List<ClienteMini>();
        private void CargarDatosClientes()
        {
            lstClientes.Clear();
            new Controller.Cliente().lstClientes.ToList().ForEach(f =>
            {
                lstClientes.Add(new ClienteMini
                {
                    CedulaRuc = f.CedulaRuc,
                    idCliente = f.idCliente,
                    NombreCompleto = f.NombreCompleto,
                    IdPrecio = f.IdPrecio
                });
            });
        }
        private void gridView7_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, colRItbms, false);
            view.SetRowCellValue(e.RowHandle, colCantidad, 1);
        }
        private void CuentasPorCobrar_Load(object sender, EventArgs e)
        {
            var control = new Controller.Contabilidad().LstCuentasFiltradas(Principal.Bariables.IdEmpresa.Id, new int[] { 4 }); ;
            MaestroCuentasBindingSource.DataSource = control;
            gridControl3.DataSource = Cuentas;
            CargarDatosClientes();
            clientesBindingSource.DataSource = lstClientes;
            dtFecha.DateTime = Principal.Bariables.PeridoContable;
            cmbFormaPagoAplicar.SelectedIndex = 0;
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            var frmP = new F.D.ShortClientes();
            frmP.ShowDialog(this);
            var contenedor = new Controller.CuentasXPagar().Proveedores();
            CargarDatosClientes();
        }
        private void btnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView7.DeleteRow(gridView7.FocusedRowHandle);
        }
        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if(e.Page.Name == "tab2")
            {
                simpleButton4.Enabled = false;
                gridControl4.DataSource = new Controller.CuentasXPagar().CXC();
            }
            else
            {
                simpleButton4.Enabled = true;
            }
        }
        private void txtMontoPagoAplicar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
        }
        private void btnAplicarPago_Click(object sender, EventArgs e)
        {
            if (cmbFormaPagoAplicar.Text == string.Empty)
            {
                lblMsg.Caption = "Seleccione Forma Pago..";
                return;
            }
            var rowPago = gridView8.GetFocusedRow() as VPagosProveedor;
            if (rowPago == null)
            {
                lblMsg.Caption = "Seleccione un Cliente";
                return;
            }
            var ejec = new Controller.CuentasXPagar();
            decimal mnt = 0;
            if (decimal.TryParse(txtMontoPagoAplicar.Text, out mnt) && mnt == 0)
            {
                lblMsg.Caption = " Monto A Aplicar Incorrecto";
                return;
            }
            bool eje = ejec.PagarFactura(rowPago.IdFactura, (mnt + rowPago.MontoPagado ?? 0));
            if (eje)
            {
                lblMsg.Caption = ejec.MSG;
                var ejecA = new Controller.Diario();
                var asiento = new Asientos
                {
                    IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                    Fecha = Principal.Bariables.PeridoContable,
                    FechaCreacion = DateTime.Now,
                    Comentario = txtGlosaPgar.Text,
                    IdUser = Principal.Bariables.IdUsuario,
                    DetalleAsientos = new List<DetalleAsientos>()
                };
                var dtAsiento = new List<DetalleAsientos>();

                int idCuenta = Principal.Bariables.IdCaja;
                if (cmbFormaPagoAplicar.Text == "Contado")
                    idCuenta = Principal.Bariables.IdCaja;
                else if (cmbFormaPagoAplicar.Text == "Cheque")
                    idCuenta = Principal.Bariables.IdBancoCXC;
                else
                    idCuenta = Principal.Bariables.IdCuentaCliente;

                dtAsiento.Add(new DetalleAsientos
                {
                    Debito = mnt,
                    IdMaestroCuenta = idCuenta
                });
                dtAsiento.Add(new DetalleAsientos
                {
                    Credito = mnt,
                    IdCliente = rowPago.IdProvedor,
                    IdMaestroCuenta = Principal.Bariables.IdCuentaCliente
                });

                asiento.DetalleAsientos = dtAsiento;

                if (ejecA.AgregarAsiento(asiento))
                {
                    gridControl4.DataSource = new Controller.CuentasXPagar().CXC();
                }
                lblMsg.Caption = ejecA.MSG;
            }
            else
            {
                lblMsg.Caption = ejec.MSG;
            }
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var row = gridView8.GetFocusedRow() as VPagosProveedor;
            if(row != null)
            {
                GenerarReporte(row.IdCliente??0);
            }
        }
        private void GenerarReporte(int prmt)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(@"Reportes\\Diario\\EstadoCuenta.repx");
            report.Parameters["prmCliente"].Value = prmt;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "Estado De Cuenta";
            printTool3.ShowPreview();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            gridView8.ShowPrintPreview();
        }
    }
}
