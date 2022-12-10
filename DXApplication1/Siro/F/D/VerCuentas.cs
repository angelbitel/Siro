using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Siro.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class VerCuentas : XtraForm
    {
        public VerCuentas() => InitializeComponent();
        public int? IdAsiento { get; set; }
        private void VerCuentas_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = Asientos;
            Asientos = new BindingList<AsientoContable>();
            var lst = new Controller.Lst();
            lst.Origenes.ForEach(f => cmbOrigen.Items.Add(new ImageComboBoxItem { Description = f.OrigenTransaccion, Value = f.IdOrigen }));
            Refrescar();
            maestroContableBindingSource.DataSource =
            lst.Cuentas();
        }

        private void Refrescar()
        {
            var lst = new Controller.Lst();
            Asientos.Clear();
            lst.LstAsientosResumen(Principal.Bariables.PeridoContable.Year, Principal.Bariables.PeridoContable.Month, Principal.Bariables.IdEmpresa.Id).ToList().ForEach(f =>
            {
                Asientos.Add(new AsientoContable
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = f.CuentaContable,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detlle = f.Detalle,
                    IdOrigen = f.IdOrigen
                });
            });
            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {Asientos.ToList().GroupBy(g => g.IdAsiento).Select(s => s.Key).Count()}";
            var asientosDesba = Asientos.GroupBy(g => new { g.IdAsiento }).Select(s => new { s.Key.IdAsiento, Debito = s.Sum(su => su.Debito), Credito = s.Sum(su => su.Credito) }).ToList();
            asientosDesba.ToList().Where(w => w.Debito - w.Credito != 0).ToList().ForEach(f =>
            {
                Asientos.Where(w => w.IdAsiento == f.IdAsiento).ToList().ForEach(g =>
                {
                    g.Desbalanceado = true;
                });
            });

            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {asientosDesba.Count()};";
            btnDesba.Caption = $"ASIENTOS DESBALANCEADOS:{Asientos.Where(w => w.Desbalanceado == true).GroupBy(g => IdAsiento = g.IdAsiento).Select(s => s.Key).Count()}";
            gridControl1.DataSource = Asientos;
        }

        private VAsientos Asiento { get; set; }
        public BindingList<AsientoContable> Asientos { get; set; }
        public bool Modificar { get; private set; }
        public int UltimoAsiento { get; internal set; }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) => Asiento = gridView1.GetFocusedRow() as VAsientos;
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("ESTA SEGURO QUE DESEA MODIFICAR ESTE ASIENTO", "MENSAJE DE ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Modificar = true;
                var row = gridView1.GetFocusedRow() as Siro.Model.AsientoContable;
                if (row == null) {
                    lblMsg.Caption = "SELECCIONE EL ASIENTO A MODIFICAR";
                    return;
                }
                IdAsiento = row.IdAsiento;
                var d = new Controller.Diario().Asiento(row.IdAsiento);
                if(d != null)
                {
                    F.Diario.Asiento.Clear();
                    if (F.Diario.Asiento.Count == 0)
                        F.Diario.Asiento.Add(new AsientoContable { });

                    F.Diario.Asiento[0].Fecha = d.Fecha;
                    F.Diario.Asiento[0].IdAsiento = d.IdAsiento;
                    F.Diario.Asiento[0].Comentario = d.Comentario;
                    F.Diario.Asiento[0].IdUsuario = d.IdUser;
                    F.Diario.Asiento[0].IdOrigen = d.IdOrigen;
                    F.Diario.Asiento[0].id = d.IdUser;

                    d.DetalleAsientos.ToList().ForEach(f =>
                    {
                        F.Diario.Asiento.Add(new AsientoContable
                        {
                            Credito = f.Credito ?? 0,
                            CuentaContable = f.MaestroCuentas != null ? f.MaestroCuentas.Text : null,
                            CuentasCombinadas = f.MaestroCuentas != null ? f.MaestroCuentas.CuentaContable : null,
                            Debito = f.Debito ?? 0,
                            IdAsiento = f.IdAsiento ?? 0,
                            IdCuentaContable = f.IdMaestroCuenta ?? 0,
                            IdCliente = f.IdCliente,
                            IdBanco = f.IdBanco,
                            IdColaborador = f.IdColaborador,
                            IdDetalleAsiento = f.IdDetalleAsiento,
                            IdOrigen = row.IdOrigen,
                            Comentario = row.Comentario
                        });
                    });

                }
                //this.Close();
            }
        }

        private void btnQuitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var eje = new Controller.Diario();
            if (XtraMessageBox.Show("Seguro Que Deseas Eliminar Asiento", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var row = gridView1.GetFocusedRow() as AsientoContable;
                if (row == null)
                {
                    XtraMessageBox.Show("Seleccione un asiento");
                    return;
                }
                   
                eje.EliminarAsiento(row.IdAsiento);
                var lst = new Controller.Lst();
                gridControl1.DataSource = lst.LstAsientos(Principal.Bariables.PeridoContable.Year, Principal.Bariables.PeridoContable.Month, Principal.Bariables.IdEmpresa.Id);
            }

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => gridControl1.ShowPrintPreview();
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => gridView1.ActiveFilterString = string.Format("IdAsiento = {0}", UltimoAsiento);
        private void btnDesba_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gridView1.ActiveFilterString = $"[Desbalanceado] = True";            
            lblMsg.Caption = $"EL DESBALANCE ES DE: {Asientos.Where(w=> w.Desbalanceado == true).Sum(s=> s.Debito-s.Credito)}";

        }

        private void barButtonItemClonar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (XtraMessageBox.Show("ESTA SEGURO QUE DESEA CLONAR ESTE ASIENTO", "MENSAJE DE ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Modificar = true;
                var row = gridView1.GetFocusedRow() as AsientoContable;
                if (row == null)
                {
                    lblMsg.Caption = "SELECCIONE EL ASIENTO A MODIFICAR";
                    return;
                }
                IdAsiento = row.IdAsiento;
                var d = new Controller.Diario().Asiento(row.IdAsiento);
                if (d != null)
                {
                    F.Diario.Asiento.Clear();
                    if (F.Diario.Asiento.Count == 0)
                        F.Diario.Asiento.Add(new AsientoContable { });

                    F.Diario.Asiento[0].Fecha = d.Fecha;
                    F.Diario.Asiento[0].IdAsiento = 0;
                    F.Diario.Asiento[0].Comentario = d.Comentario;
                    F.Diario.Asiento[0].IdUsuario = d.IdUser;
                    F.Diario.Asiento[0].IdOrigen = d.IdOrigen;
                    F.Diario.Asiento[0].IdTransaccion = d.IdTransaccion;

                    d.DetalleAsientos.ToList().ForEach(f =>
                    {
                        F.Diario.Asiento.Add(new AsientoContable
                        {
                            Credito = f.Credito ?? 0,
                            CuentaContable = f.MaestroCuentas != null ? f.MaestroCuentas.Text : null,
                            CuentasCombinadas = f.MaestroCuentas != null ? f.MaestroCuentas.CuentaContable : null,
                            Debito = f.Debito ?? 0,
                            IdAsiento = f.IdAsiento ?? 0,
                            IdCuentaContable = f.IdMaestroCuenta ?? 0,
                            IdCliente = f.IdCliente,
                            IdBanco = f.IdBanco,
                            IdColaborador = f.IdColaborador,
                            IdDetalleAsiento = 0,
                            IdOrigen = row.IdOrigen,
                            Comentario = row.Comentario
                        });
                        F.Diario.Asiento.ToList().ForEach(g =>
                        {
                            if (g.Debito + g.Credito == 0)
                                F.Diario.Asiento.Remove(g);
                        });
                    });

                }
                //this.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Refrescar();
        }

        private void repositoryItemHyperLinkEditComentario_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("ESTA SEGURO QUE DESEA MODIFICAR ESTE ASIENTO", "MENSAJE DE ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Modificar = true;
                var row = gridView1.GetFocusedRow() as AsientoContable;
                if (row == null)
                {
                    lblMsg.Caption = "SELECCIONE EL ASIENTO A MODIFICAR";
                    return;
                }
                IdAsiento = row.IdAsiento;
                var d = new Controller.Diario().Asiento(row.IdAsiento);
                if (d != null)
                {
                    F.Diario.Asiento.Clear();
                    if (F.Diario.Asiento.Count == 0)
                        F.Diario.Asiento.Add(new AsientoContable { });

                    F.Diario.Asiento[0].Fecha = d.Fecha;
                    F.Diario.Asiento[0].IdAsiento = d.IdAsiento;
                    F.Diario.Asiento[0].Comentario = d.Comentario;
                    F.Diario.Asiento[0].IdUsuario = d.IdUser;

                    d.DetalleAsientos.ToList().ForEach(f =>
                    {
                        F.Diario.Asiento.Add(new AsientoContable
                        {
                            Credito = f.Credito ?? 0,
                            CuentaContable = f.MaestroCuentas != null ? f.MaestroCuentas.Text : null,
                            CuentasCombinadas = f.MaestroCuentas != null ? f.MaestroCuentas.CuentaContable : null,
                            Debito = f.Debito ?? 0,
                            IdAsiento = f.IdAsiento ?? 0,
                            IdCuentaContable = f.IdMaestroCuenta ?? 0,
                            IdCliente = f.IdCliente,
                            IdBanco = f.IdBanco,
                            IdColaborador = f.IdColaborador,
                            IdDetalleAsiento = f.IdDetalleAsiento,
                            IdOrigen = row.IdOrigen,
                            Comentario = row.Comentario
                        });
                    });

                }
                //this.Close();
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

            var lst = new Controller.Lst();
            Asientos.Clear();
            var row = repositoryItemSearchLookUpEdit1View.GetFocusedRow() as Model.MaestroContable;
            lst.LstAsientosResumen(row.IdMaestroCuenta, Principal.Bariables.IdEmpresa.Id).ToList().ForEach(f =>
            {
                Asientos.Add(new AsientoContable
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = f.CuentaContable,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detlle = f.Detalle,
                    IdOrigen = f.IdOrigen
                });
            });
            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {Asientos.ToList().GroupBy(g => g.IdAsiento).Select(s => s.Key).Count()}";
            var asientosDesba = Asientos.GroupBy(g => new { g.IdAsiento }).Select(s => new { s.Key.IdAsiento, Debito = s.Sum(su => su.Debito), Credito = s.Sum(su => su.Credito) }).ToList();
            asientosDesba.ToList().Where(w => w.Debito - w.Credito != 0).ToList().ForEach(f =>
            {
                Asientos.Where(w => w.IdAsiento == f.IdAsiento).ToList().ForEach(g =>
                {
                    g.Desbalanceado = true;
                });
            });

            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {asientosDesba.Count()};";
            btnDesba.Caption = $"ASIENTOS DESBALANCEADOS:{Asientos.Where(w => w.Desbalanceado == true).GroupBy(g => IdAsiento = g.IdAsiento).Select(s => s.Key).Count()}";
            gridControl1.DataSource = Asientos;
        }

        private void repositoryItemSearchLookUpEdit1View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var gridLookUpEdit = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var lst = new Controller.Lst();
            Asientos.Clear();
            var row = gridLookUpEdit.GetFocusedRow() as Model.MaestroContable;
            lst.LstAsientosResumen(row.IdMaestroCuenta, Principal.Bariables.IdEmpresa.Id).ToList().ForEach(f =>
            {
                Asientos.Add(new AsientoContable
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = f.CuentaContable,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detlle = f.Detalle,
                    IdOrigen = f.IdOrigen
                });
            });
            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {Asientos.ToList().GroupBy(g => g.IdAsiento).Select(s => s.Key).Count()}";
            var asientosDesba = Asientos.GroupBy(g => new { g.IdAsiento }).Select(s => new { s.Key.IdAsiento, Debito = s.Sum(su => su.Debito), Credito = s.Sum(su => su.Credito) }).ToList();
            asientosDesba.ToList().Where(w => w.Debito - w.Credito != 0).ToList().ForEach(f =>
            {
                Asientos.Where(w => w.IdAsiento == f.IdAsiento).ToList().ForEach(g =>
                {
                    g.Desbalanceado = true;
                });
            });

            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {asientosDesba.Count()};";
            btnDesba.Caption = $"ASIENTOS DESBALANCEADOS:{Asientos.Where(w => w.Desbalanceado == true).GroupBy(g => IdAsiento = g.IdAsiento).Select(s => s.Key).Count()}";
            gridControl1.DataSource = Asientos;

        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void repositoryItemTextEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
            }
        }

        private void barButtonItemBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = new Controller.Lst();
            Asientos.Clear();
            int idAsiento = 0;
            if (int.TryParse(barEditItem1.EditValue.ToString(), out idAsiento))
            {
                lst.LstAsientosResumen(idAsiento).ToList().ForEach(f =>
                {
                    Asientos.Add(new AsientoContable
                    {
                        Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                        IdAsiento = f.IdAsiento,
                        Credito = Math.Abs(f.Credito ?? 0m),
                        CuentaContable = f.CuentaContable,
                        Debito = Math.Abs(f.Debito ?? 0m),
                        Fecha = f.Fecha,
                        IdCuentaContable = f.IdCuentaContable,
                        Mayor = f.Mayor,
                        Detlle = f.Detalle,
                        IdOrigen = f.IdOrigen
                    });
                });
                lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {Asientos.ToList().GroupBy(g => g.IdAsiento).Select(s => s.Key).Count()}";
                var asientosDesba = Asientos.GroupBy(g => new { g.IdAsiento }).Select(s => new { s.Key.IdAsiento, Debito = s.Sum(su => su.Debito), Credito = s.Sum(su => su.Credito) }).ToList();
                asientosDesba.ToList().Where(w => w.Debito - w.Credito != 0).ToList().ForEach(f =>
                {
                    Asientos.Where(w => w.IdAsiento == f.IdAsiento).ToList().ForEach(g =>
                    {
                        g.Desbalanceado = true;
                    });
                });
                lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {asientosDesba.Count()};";
            }

            btnDesba.Caption = $"ASIENTOS DESBALANCEADOS:{Asientos.Where(w => w.Desbalanceado == true).GroupBy(g => IdAsiento = g.IdAsiento).Select(s => s.Key).Count()}";
            gridControl1.DataSource = Asientos;

        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmLogAsientos();
            frm.Show();
        }
    }
}