using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Siro.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class CuentasPorPagar : DevExpress.XtraEditors.XtraForm
    {
        BindingList<DetallesFactura> Cuentas = new BindingList<DetallesFactura>();
        public CuentasPorPagar()
        {
            InitializeComponent();
            layoutControlGroup6.Enabled = false;
            dtFecha.DateTime = Principal.Bariables.PeridoContable;
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
                    dias = 7;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 2:
                    dias = 15;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 3:
                    dias = 30;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 4:
                    dias = 45;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 5:
                    dias = 60;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 6:
                    dias = 90;
                    dtFVencimiento.Enabled = false;
                    layoutControlGroup6.Enabled = false;
                    break;
                case 7:
                    dias = 120;
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
                default:
                    break;
            }
            dtFVencimiento.DateTime = DateTime.Now.AddDays(dias);
        }
        private void CuentasPorPagar_Load(object sender, EventArgs e)
        {
            var control = new Controller.Contabilidad().LstCuentasFiltradas(Principal.Bariables.IdEmpresa.Id, new int[]{6,9});
            MaestroCuentasBindingSource.DataSource = control;
            gridControl1.DataSource = Cuentas;
            var contenedor= new Controller.CuentasXPagar().Proveedores();
            provedoresBindingSource.DataSource = contenedor;
            var contenedorBanco=  new Controller.CuentasXPagar().LstBancos();
            bancosBindingSource.DataSource = contenedorBanco;
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            bool rItbm = bool.Parse((gridView1.GetFocusedRowCellValue(colRItbms)??"false").ToString());

            var cnt = int.Parse((gridView1.GetFocusedRowCellValue(colCantidad) ?? "0").ToString());
            var mnt = decimal.Parse((gridView1.GetFocusedRowCellValue(colMonto) ?? "0").ToString());
            var itbm = (cnt * mnt) * (rItbm ? 0.07M:0);
            var total = (cnt * mnt) + itbm;

            view.SetRowCellValue(e.RowHandle, colITBMS, itbm);
            view.SetRowCellValue(e.RowHandle, colTotal, total);
            view.SetRowCellValue(e.RowHandle, colDetallesFacturaItem, new List<DetallesFacturaItem>());
        }
        private void btnGuardarCxP_Click(object sender, EventArgs e)
        {
            if (chkNotaCredito.Checked)
            {
                if (XtraMessageBox.Show("Esta Seguro Que Desea La Nota De Credito", "Mensaje", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    lblMsg.Caption = "La Nota De Credito Fue Cancelada";
                }
                else
                {
                    GuardarNotaCredito();
                }
                return;
            }
            if (cmbTerminoPago.Text == "Contado[Cheque]" && IDBanco == 0)
            {
                lblMsg.Caption = "Seleccione un Banco..";
                return;
            }
            var ejec = new Controller.CuentasXPagar();
            var row = new Siro.Factura
            {
                Fecha = dtFecha.DateTime,
                IdProvedor = IdProveedor,
                NumeroFactura = txtNumFactura.Text,
                DetallesFactura = new List<DetallesFactura>(),
                ModoPago = cmbTerminoPago.Text,
                Glosa = txtGlosa.Text,
                FechaVencimiento = dtFVencimiento.DateTime,
                Tipo=1,
                IdEmpresa= Principal.Bariables.IdEmpresa.Id
            };
            row.DetallesFactura = Cuentas;
            if (cmbTerminoPago.SelectedIndex == 0)
                row.MontoPagado = Cuentas.Sum(s => s.Total);
            else
                row.MontoPagado = 0;
            if(ejec.Guardar(row,false))
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
                    dtAsiento.Add(new DetalleAsientos
                    {
                        Debito = (f.Monto*(f.Cantidad??0)),
                        IdMaestroCuenta = f.IdCuentaContable
                    });
                    if (f.ITBMS > 0)
                    {
                        dtAsiento.Add(new DetalleAsientos
                        {
                            Debito = f.ITBMS,
                            IdMaestroCuenta = Principal.Bariables.IdCuentaItbm
                        });
                    }
                    dtAsiento.Add(new DetalleAsientos
                    {
                        Credito = f.Total,
                        idProvedor = row.IdProvedor,
                        IdMaestroCuenta = Principal.Bariables.IdCuentaProveedor
                    });
                });
                asiento.DetalleAsientos = dtAsiento;
                var eje = ejecA.AgregarAsiento(asiento);
                if (row.ModoPago == "Contado[Cheque]" && eje)
                {
                    var asientoBanco = new Asientos
                    {
                        IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                        Fecha = row.Fecha,
                        FechaCreacion = DateTime.Now,
                        Comentario = row.Glosa,
                        IdUser = Principal.Bariables.IdUsuario,
                        DetalleAsientos = new List<DetalleAsientos>()
                    };
                    var dtAsientoBanco = new List<DetalleAsientos>();
                    dtAsientoBanco.Add(new DetalleAsientos
                    {
                        Debito = Cuentas.Sum(s => s.Total),
                        idProvedor = row.IdProvedor,
                        IdMaestroCuenta = Principal.Bariables.IdCuentaProveedor
                    });
                    dtAsientoBanco.Add(new DetalleAsientos
                    {
                        Credito = Cuentas.Sum(s => s.Total),
                        IdMaestroCuenta = Principal.Bariables.IdCuentaBanco,
                        IdBanco = IDBanco
                    });
                    asientoBanco.DetalleAsientos = dtAsientoBanco;
                    if(ejecA.AgregarAsiento(asientoBanco))
                    {
                        GuardarBanco(Cuentas.Sum(s => s.Total) ?? 0, IDBanco, txtNumeroCheque.Text, txtNumeroCuenta.Text, dtFecha.DateTime, row.IdProvedor ?? 0, txtGlosa.Text, ejecA.NuevoId??0);
                    }
                }
                Cuentas.Clear();
            }
            else
            {
                lblMsg.Caption = ejec.MSG;
            }
        }

        private void GuardarNotaCredito()
        {
            var ejec = new Controller.CuentasXPagar();
            var row = new Siro.Factura
            {
                Fecha = dtFecha.DateTime,
                IdProvedor = IdProveedor,
                NumeroFactura = txtNumFactura.Text,
                DetallesFactura = new List<DetallesFactura>(),
                ModoPago = "Nota Credito",
                Glosa = txtGlosa.Text,
                FechaVencimiento = dtFVencimiento.DateTime,
                Tipo=1,
                IdEmpresa= Principal.Bariables.IdEmpresa.Id
            };
            row.DetallesFactura = Cuentas;
            if (cmbTerminoPago.SelectedIndex == 0)
                row.MontoPagado = Cuentas.Sum(s => s.Total);
            else
                row.MontoPagado = 0;
            if (ejec.Guardar(row,true))
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
                    dtAsiento.Add(new DetalleAsientos
                    {
                        Credito = (f.Monto * (f.Cantidad ?? 0)),
                        IdMaestroCuenta = f.IdCuentaContable
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
                        Debito = f.Total,
                        idProvedor = row.IdProvedor,
                        IdMaestroCuenta = Principal.Bariables.IdCuentaProveedor
                    });
                });
                asiento.DetalleAsientos = dtAsiento;
                if (ejecA.AgregarAsiento(asiento))
                {
                    lblMsg.Caption = "Nota De Credito Fue Creada Correctamente!!!";
                }

            }
        }
        private void GuardarBanco(decimal mntPagar, int idbanco, string numCheque, string numCuenta, DateTime fecha, int idProvedor, string glosa, int idAdiento)
        {
            Controller.Banco bc = new Controller.Banco();
            var per = new Model.Cuentas();

            var sndBanco = new RegistrosBanco
            {
                NumeroCuenta = numCuenta,
                FechaCheque = fecha,
                IdBanco = idbanco,
                IdUser = Principal.Bariables.IdUsuario,
                Monto = mntPagar,
                NumeroCheque = numCheque,
                IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                idProvedor = idProvedor,
                Concepto = glosa,
                 IdAsiento = idAdiento
            };

            var res= bc.Agregar(sndBanco);
            lblMsg.Caption = bc.MSG;
            if (XtraMessageBox.Show("Desea Imprimir Comprobante De Cheque", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                GenerarReporte("ComprobanteCheque", bc.NuevoId??0);
            }
        }
        private void GenerarReporte(string reporte, int idComprobante)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Diario\\{0}.repx", reporte));
            report.Parameters["prmRegistroBanco"].Value = idComprobante;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = reporte;
            printTool3.ShowPreview();
        }
        private int IdProveedor { get; set; }
        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdProveedor = int.Parse(gluProveedor.EditValue.ToString());
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, colRItbms, false);
            view.SetRowCellValue(e.RowHandle, colCantidad, 1);
        }
        private void gluProvedorPago_EditValueChanged(object sender, EventArgs e)
        {
            gridControl2.DataSource = new Controller.CuentasXPagar().CXCProveedores(int.Parse(gluProvedorPago.EditValue.ToString()));
        }
        private decimal mntPago { get; set; }
        private void textEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal mnt = 0, mntRestante = 0;
                decimal.TryParse(txtMontoPagoAplicar.Text, out mnt);
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    var row = gridView4.GetRow(i) as VPagosProveedor;
                    mntRestante = ((row.MontoAdeudado - row.MontoPagado) ?? 0) - mnt;
                    if (mntRestante < 0)
                    {
                        gridView4.SetRowCellValue(i, colArregloPago, ((row.MontoAdeudado - row.MontoPagado) ?? 0));
                        mnt = mntRestante * -1;
                    }
                    else
                    {
                        gridView4.SetRowCellValue(i, colArregloPago, mnt);
                        mnt = 0;
                    }
                }
                decimal mnt2 = 0;
                decimal.TryParse(txtMontoPagoAplicar.Text, out mnt2);
                if (mnt2 > mnt && mnt != 0)
                    lblMsg.Caption = string.Format("Monto colocado es mayor que la deuda, sobrante de:{0}", mnt);
            }
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            var frmP = new F.D.ShortProveedores();
            frmP.ShowDialog(this);
            var contenedor = new Controller.CuentasXPagar().Proveedores();
            provedoresBindingSource.DataSource = contenedor;
        }

        private void btnPagarProveedor_Click(object sender, EventArgs e)
        {
            if(IDBanco2 ==  0)
            {
                lblMsg.Caption = "Seleccione banco....";
                return;
            }
            int idprov =0;
            int.TryParse(gluProvedorPago.EditValue.ToString(), out idprov);
            if(idprov == 0)
            {
                lblMsg.Caption = "Seleccione un Proveedor....";
                return;
            }
            var ejec = new Controller.CuentasXPagar();
            decimal mnt = 0;
            if (decimal.TryParse(txtMontoPagoAplicar.Text, out mnt) && mnt == 0)
            {
                lblMsg.Caption = " Monto A Aplicar Incorrecto";
                return;
            }
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                var row = gridView4.GetRow(i) as VPagosProveedor;
                if (row.ArregloPago == 0)
                    break;
                ejec.PagarFactura(row.IdFactura, (row.MontoPagado??0) + (row.ArregloPago??0));
                mntPago += row.ArregloPago??0;
            }
            var asientoBanco = new Asientos
            {
                IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                Fecha = Principal.Bariables.PeridoContable,
                FechaCreacion = DateTime.Now,
                Comentario = txtGloas2.Text==""?"Pago De Deuda a Proveedor ":txtGloas2.Text,
                IdUser = Principal.Bariables.IdUsuario,
                DetalleAsientos = new List<DetalleAsientos>()
            };
            var dtAsientoBanco = new List<DetalleAsientos>();
            dtAsientoBanco.Add(new DetalleAsientos
            {
                Debito = mntPago,
                idProvedor = idprov,
                IdMaestroCuenta = Principal.Bariables.IdCuentaProveedor
            });
            dtAsientoBanco.Add(new DetalleAsientos
            {
                Credito = mntPago,
                IdMaestroCuenta = Principal.Bariables.IdCuentaBanco,
                IdBanco = IDBanco2
            });
            asientoBanco.DetalleAsientos = dtAsientoBanco;
            var ejecA = new Controller.Diario();
            
            if (ejecA.AgregarAsiento(asientoBanco))
            {
                GuardarBanco(mntPago, IDBanco2, txtNumCheque1.Text, txtNumCuenta.Text, DateTime.Now, idprov, txtGloas2.Text == "" ? "Pago De Deuda a Proveedor " : txtGloas2.Text, ejecA.NuevoId??0);
            }
            gridControl2.DataSource = new Controller.CuentasXPagar().CXCProveedores(int.Parse(gluProvedorPago.EditValue.ToString()));
            lblMsg.Caption = "Facturas Pagadas Correctamente";
        }
        private int IDBanco { get; set; }
        private int IDBanco2 { get; set; }
        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            IDBanco = int.Parse(gluBanco1.EditValue.ToString());
        }
        private void glUBanco2_EditValueChanged(object sender, EventArgs e)
        {
            IDBanco2 = int.Parse(glUBanco2.EditValue.ToString());
        }
        private void BtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void btnDetalleFactura_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        BindingList<DetallesFacturaItem> dtF = new BindingList<DetallesFacturaItem>();
        private void btnDetalleFactura_Click(object sender, EventArgs e)
        {
            dtF = gridView1.GetFocusedRowCellValue(colDetallesFacturaItem) as BindingList<DetallesFacturaItem>;

            bool rItbm = false;
            bool.TryParse(gridView1.GetFocusedRowCellValue(colRItbms).ToString(), out rItbm);
            var frm = new D.DetalleFactura(dtF, rItbm);
            frm.ShowDialog(this);
            Cuentas[Cuentas.IndexOf(gridView1.GetFocusedRow() as Siro.DetallesFactura)].DetallesFacturaItem = frm.Asiento;
        }
    }
}