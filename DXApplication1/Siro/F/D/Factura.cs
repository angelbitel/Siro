using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Siro.Model;
using Siro.Properties;
using Siro.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class Factura : DevExpress.XtraEditors.XtraForm
    {
        public static Siro.Transacciones FDb = new Transacciones();
        Siro.slEntities dbContext = new Siro.slEntities();
        List<Model.Producto> lstProductos = new List<Model.Producto>();
        List<Model.Servicio> lstServicios = new List<Model.Servicio>();
        List<ClienteMini> lstClientes = new List<ClienteMini>();
        Prmts Prm = new Prmts();

        public BindingList<Model.DetalleTransaccion> detalle = new BindingList<Model.DetalleTransaccion>();
        public Factura()
        {
            InitializeComponent();
            detalle.ListChanged += ListChanged;
        }        
        void ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged)
            {                
                decimal cnt = detalle[e.NewIndex].Cantidad??0;
                if (cnt == 0)
                    cnt = 1;
                detalle[e.NewIndex].ITBM = ((detalle[e.NewIndex].Monto * cnt) * detalle[e.NewIndex].ITBM)??0;
                detalle[e.NewIndex].Total = (detalle[e.NewIndex].Monto * cnt) + detalle[e.NewIndex].ITBM;
                detalle[e.NewIndex].IngresoSubsidio = (detalle[e.NewIndex].Total * detalle[e.NewIndex].IngresoSubsidio);
                detalle[e.NewIndex].Total = detalle[e.NewIndex].Total + detalle[e.NewIndex].IngresoSubsidio;
            }
        }
        private void Factura_Load(object sender, EventArgs e)
        {
            dbContext.Categorias.ToList().ForEach(f =>
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = f.IdCategoria,
                    Description = f.Categoria
                };
                repositoryItemImageComboBoxproducto.Items.Add(item);
                repositoryItemImageComboBoxCatSer.Items.Add(item);
            });
            
            gridControlFActura.DataSource = detalle;
            Parallel.Invoke(() => CargarDatos(), () => CargarDatosClientes());
            if(detalle.Any())
            {
                IdCliente = detalle[0].IdCliente;
            }
            clientesBindingSource.DataSource = lstClientes;
            productosBindingSource.DataSource = lstProductos;
            servicioBindingSource.DataSource = lstServicios;
            if (Settings.Default.UsarFiscal)
            {
                DateTime ultZeta = Settings.Default.UltimoZ;
                if (Settings.Default.UltimoZ.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd") && XtraMessageBox.Show("En el dia de hoy no se a hecho la lectura Z desea hacerlo?", "Lectura Z", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new Siro.Controller.HasardFile(Prm).Z();
                }
                Settings.Default.UltimoZ = DateTime.Now;
                Settings.Default.Save();
            }
            if (Settings.Default.DFecha.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                if (!(XtraMessageBox.Show("Desea Continuar con la fecha del periodo contable distinta a la actual", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK))
                {
                    new D.Periodo().ShowDialog(this);
                }
            }

        }
        private void CargarDatos()
        {
            var lst = new Controller.Producto();
            lstProductos = lst.Productos(Settings.Default.DIdEmpresa);
            lstServicios = lst.Servicios(Settings.Default.DIdEmpresa);
        }
        private void CargarDatosClientes()
        {
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

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var row = GetSelectedRow((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            if(row != null)
            {
                detalle.Add(new Model.DetalleTransaccion
                {
                     Cantidad =1,
                     Descripcion = row.Productos1,
                     Monto = row.PrecioVenta,
                     IdProducto = row.IdProducto,
                     itbm = row.ITBM,
                     IdPrecioProducto = row.IdPrecioProducto,
                     IngresoSubsidio = row.IS
                });
            }
        }
        private Model.Producto GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            return (Model.Producto)view.GetRow(view.FocusedRowHandle);
        }
        private Model.Servicio GetSelectedRow2(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            return (Model.Servicio)view.GetRow(view.FocusedRowHandle);
        }
        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            var frmP=new FormaPago(detalle.Sum(s => s.Total)??0);
            frmP.ShowDialog(this);

            var dtF = new List<DetallesTransaccione>();
            if (frmP.Cancelar)
            {
                lblMsg.Caption = "Transaccion Cancelada";
                return;
            }
            detalle.ToList().ForEach(f =>
            {
                dtF.Add(new DetallesTransaccione
                {
                    Cantidad = f.Cantidad,
                    IdProducto = f.IdProducto,
                    IdServicio = f.IdServicio,
                    Monto = f.Monto,
                    ITBM = f.ITBM,
                    Total = f.Total,
                    IdPrecioProducto = f.IdPrecioProducto,
                    IngresoSubsidio = f.IngresoSubsidio
                });
            });
            if (IdCliente != 0)
            {
                /*Agregar Valores a la Transaccion*/
                FDb.DetallesTransaccione = dtF;
                FDb.FechaTransaccion = Principal.Bariables.PeridoContable;
                FDb.IdCliente = IdCliente;
                FDb.IdUser = Principal.Bariables.IdUsuario;
                FDb.Monto = dtF.Sum(s => s.Monto);
                FDb.MontoImpuestos = dtF.Sum(s => s.Total);
                FDb.IdEmpresa = Principal.Bariables.IdEmpresa.Id;

                var factura = new Controller.Factura();
                var ejecucion = factura.AgregarFactura(FDb, checkNotaCredito.Checked);
                lblMsg.Caption = factura.MSG;
                if(ejecucion)
                {
                    var ejecA = new Controller.Diario();
                    var asiento = new Asientos
                    {
                        IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                        Fecha = Principal.Bariables.PeridoContable,
                        FechaCreacion = DateTime.Now,
                        IdUser = Principal.Bariables.IdUsuario,
                        DetalleAsientos = new List<DetalleAsientos>()
                    };
                    var dtAsiento = new List<DetalleAsientos>();
                    int frmPagoCheque = 1;
                    if (FDb.FPagoUilizada.Where(w => w.IdFormaPago == 8).Count() > 0)
                    {
                        frmPagoCheque = 8;
                        var frmFormaPago = new F.D.ShowFormaPago();
                        frmFormaPago.ShowDialog();
                        var ejec = new Controller.CuentasXPagar();
                        var row = new Siro.Factura
                        {
                            Fecha = Principal.Bariables.PeridoContable,
                            IdCliente = IdCliente,
                            NumeroFactura = factura.NuevoId.ToString(),
                            DetallesFactura = new List<DetallesFactura>(),
                            ModoPago = frmFormaPago.FormaPago,
                            FechaVencimiento = frmFormaPago.FechaVencimiento,
                            Tipo = 2,
                            IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                            ITBM = dtF.Sum(s=> s.ITBM),
                            Monto =dtF.Sum(s=> s.Monto*s.Cantidad),
                            MontoPagado =0
                        };
                        var cxcDetalle = new List<DetallesFactura>();
                        dtF.ForEach(f =>
                        {
                            cxcDetalle.Add(new DetallesFactura
                            {
                                Cantidad = f.Cantidad,
                                IdProducto = f.IdProducto,
                                ITBMS = f.ITBM,
                                Monto = f.Monto,
                                Total = (f.Monto * f.Cantidad) + f.ITBM
                            });
                        });
                        row.DetallesFactura = cxcDetalle;
                        var eje = ejec.Guardar(row,false);
                    }
                    if (FDb.FPagoUilizada.Where(w => w.IdFormaPago == 6).Count()>0)
                        frmPagoCheque = 6;
                    dtF.ForEach(f =>
                    {
                        int idCuenta = Principal.Bariables.IdCaja;
                        switch (frmPagoCheque)
                        {
                            case 8:
                                idCuenta = Principal.Bariables.IdCuentaCliente;
                                break;
                            case 6:
                                idCuenta = Principal.Bariables.IdBancoCXC;
                                break;
                            default:
                                idCuenta = Principal.Bariables.IdCaja;
                                break;
                        }
                        dtAsiento.Add(new DetalleAsientos
                        {
                            Debito = (f.Monto * f.Cantidad) + f.ITBM + f.IngresoSubsidio,
                            IdMaestroCuenta = idCuenta
                        });
                        dtAsiento.Add(new DetalleAsientos
                        {
                            Credito = f.Cantidad * f.Monto + f.IngresoSubsidio,
                            IdCliente = IdCliente,
                            IdMaestroCuenta = Principal.Bariables.IdCuentaCliente,
                            IdProducto = f.IdProducto
                        });
                        if (f.ITBM > 0)
                        {
                            dtAsiento.Add(new DetalleAsientos
                            {
                                Credito = f.ITBM,
                                IdCliente = IdCliente,
                                IdMaestroCuenta = Principal.Bariables.IdCuentaItbm
                            });
                        }
                    });
                    asiento.DetalleAsientos = dtAsiento;
                    ejecA.AgregarAsiento(asiento);

                    if (Prm.UsaFiscal && Settings.Default.UsarFiscal)
                    {
                        if (Prm.ImpresoraFiscal == "hasard")
                        {
                            new Siro.Controller.HasardFile(Prm).DocumentoFiscal(factura.TransaccionRealizada, detalle, factura.Cliente(IdCliente), checkNotaCredito.Checked);
                        }
                    }
                    detalle.Clear();
                }
            }
            else
                lblMsg.Caption = "Seleccione Cliente!!";
            //this.Close();
        }
        int IdCliente { get; set; }
        string Cliente { get; set; }
        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            IdCliente = int.Parse(gridLookUpEdit1.EditValue.ToString());
            Cliente = gridLookUpEdit1.Text.ToString();
            var clts = lstClientes.SingleOrDefault(w => w.idCliente == IdCliente);
            if(clts != null)
            {
                if(clts.IdPrecio !=0)
                    gridView2.ActiveFilterString = string.Format("[IdPrecio]= {0}",clts.IdPrecio);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            detalle.Clear();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            tabPane1.SelectedPageIndex = 2;
            transaccionesBindingSource.DataSource = dbContext.Transacciones.Where(w => w.IdCliente == IdCliente).OrderByDescending(o=> o.IdTransaccion).ToList();
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int idFact = (gridView4.GetFocusedRow() as Transacciones).IdTransaccion;
            if (idFact != 0)
            {
                GenerarReporte(idFact, "Facturacion", Principal.Bariables.IdEmpresa.Id);
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var row = GetSelectedRow2((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            if (row != null)
            {
                detalle.Add(new Model.DetalleTransaccion
                {
                    Cantidad = 1,
                    Descripcion = row.Servicios1,
                    Monto = row.Precio,
                    IdServicio = row.IdServicio,
                    ITBM = row.ITBMS,
                    itbm = row.ITBMS,
                    IngresoSubsidio= row.IS
                });
            }
        }

        private void checkNotaCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (!(XtraMessageBox.Show("Estas Seguro Que Deseas Marcar Como Nota De Credito", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK))
            {
                if (checkNotaCredito.Checked)
                    checkNotaCredito.Checked = false;
            }
        }

        private void btnCierreZ_Click(object sender, EventArgs e)
        {
            new Siro.Controller.HasardFile(Prm).Z();
        }

        private void btnCierreX_Click(object sender, EventArgs e)
        {
            new Siro.Controller.HasardFile(Prm).X();
        }

        private void btnDashBoardVentas_Click(object sender, EventArgs e)
        {
            //var frm = new Siro.F.Facturacion.VerVentas();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            GenerarReporte(Principal.Bariables.IdEmpresa.Id, "Ventas Diarias",null);
        }

        private void GenerarReporte(int prmt, string rpt, int? idfa)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx",rpt));
            if (idfa != null)
                report.Parameters["parameter1"].Value = prmt;
            report.Parameters["prmIdEmpresa"].Value = prmt;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = rpt;
            printTool3.ShowPreview();
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int i = e.RowHandle;
            decimal cnt = detalle[i].Cantidad ?? 0;
            if (cnt == 0)
                cnt = 1;
            detalle[i].ITBM = ((detalle[i].Monto * cnt) * detalle[i].ITBM) ?? 0;
            detalle[i].Total = (detalle[i].Monto * cnt) + detalle[i].ITBM;
        }
    }
}