using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using Siro.F.D;
using Siro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Diario : DevExpress.XtraEditors.XtraForm
    {
        /*VARIABLES DE LA FORMA DIARIO*/
        //Siro.slEntities dbContext = new Siro.slEntities();
        public static BindingList<AsientoContable> Asiento = new BindingList<AsientoContable>();
        public List<PeriodoFiscal> LstPeriodosFiscales { get; set; }
        /*VARIABLE QUE SE TRASLADAN DE OTROS FORMS*/
        public static int? IdCliente { get; set; }
        public static string NombreCliente { get; set; }
        public static decimal MontoFactura { get; set; }
        public static int? IdTransaccion{ get; set; }
        public static int? IdRegistroBanco { get; set; }
        List<Model.Cuentas> Cuentas { get; set; }
        public Diario()
        {
            InitializeComponent();
            Asiento.ListChanged += ListChanged;
            Inicializar();
            dtFechaAsiento.DateTime = Principal.Bariables.PeridoContable;
        }

        void ListChanged(object sender, ListChangedEventArgs e)
        {
            /*Mecanismo de debito credito searchLookUpEdit1.*/
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var row = Asiento[e.NewIndex];
                var mnt = Asiento[e.NewIndex].Monto;
                switch (row.CuentasCombinadas)
                {
                    case "1":
                        Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case "2":
                        Asiento[e.NewIndex].Credito = mnt;
                        break;
                    case "3":
                        Asiento[e.NewIndex].Credito = mnt;
                        break;
                    case "4":
                        Asiento[e.NewIndex].Credito = mnt;
                        break;
                    case "5":
                        Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case "6":
                        Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case "7":
                        //Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case "9":
                        Asiento[e.NewIndex].Debito = mnt;
                        break;
                }
                if ((Asiento[0].Comentario != null || Asiento[0].Fecha != null) && tComentario.Text.Length == 0 && Asiento.Count == 2)
                {
                    tComentario.Text = Asiento[0].Comentario;
                    dtFechaAsiento.DateTime = Asiento[0].Fecha ?? DateTime.Now;
                }
            }
            /*Diferencia Debito Credito*/
            var sumD = Asiento.Sum(s => s.Debito);
            var sumC = Asiento.Sum(s => s.Credito);
            var tot = sumD - sumC;

            if (tot != 0)
                lblDiferencia.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            else
            {
                lblDiferencia.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
                lblDiferencia.Caption = "0.00";
            }

            lblDiferencia.Caption = tot.Value.ToString("#,#.00#;(#,#.00#)");
        }
        private void Inicializar()
        {
            this.barStaticItemFecha.Caption = Principal.Bariables.PeridoContable.ToString("yyyy MMMM");
            this.barStaticItemEmpresa.Caption = Principal.Bariables.IdEmpresa.Nombre;
            if(Principal.Bariables.IdEmpresa.Nombre == null)
            {
                btnQuitar.PerformClick(); 
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new F.D.Periodo().ShowDialog();
            //this.barStaticItemFecha.Caption = Principal.Bariables.PeridoContable.ToString("yyyy MMMM");
            //this.barStaticItemEmpresa.Caption = Principal.Bariables.IdEmpresa.Nombre;
        }

        private void Diario_Load(object sender, EventArgs e)
        {
            /*CARGAR CUENTAS CONTABLES*/

            var contol = new Controller.Diario();
            LstPeriodosFiscales = contol.LstPeriodos;
            gridControl1.DataSource = Asiento;
            var control = new Controller.Contabilidad().CuentasMaestras();
            Cuentas = control;
            var db = new Controller.Lst();
            var id = db.UltimOAsiento(Principal.Bariables.IdEmpresa.Id);
            linkLabelAsiento.Text = $"ULTIMO ASIENTO GENERADO: {id}";
            UltimoId = id;
            int cntPen = new Controller.VMSesiones().SesionesAbiertas.Count;
            if (cntPen > 0)
                barButtonItem1.Caption = $"Asientos Pendientes ({cntPen})";
            else
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        private void BuscarPendientes()
        {
            var frm = new F.D.SesionesPendientes();
            frm.ShowDialog();
            if (frm.CantidadPendientes > 0)
                barButtonItem1.Caption = $"Asientos Pendientes ({frm.CantidadPendientes})";
            else
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (frm.Sesion != null)
            {
                Asiento.Clear();
                IdCliente = null;
                IdRegistroBanco = null;
                IdTransaccion = null;
                IdSesion = frm.Sesion.IdSesion;
                dtFechaAsiento.EditValue = frm.Sesion.Fecha;
                tComentario.Text = frm.Sesion.Comentario;
                var lst = JsonConvert.DeserializeObject<List<DetalleAsientoCorto>>(frm.Sesion.Sesion);
                if (lst.Count > 0)
                    lst.ForEach(f => Asiento.Add(new AsientoContable
                    {
                        Comentario = f.Comentario,
                        Credito = f.Credito,
                        CuentaContable = f.CuentaContable,
                        CuentasCombinadas = f.CuentasCombinadas,
                        Debito = f.Debito,
                        Detlle = f.Detlle,
                        Fecha = f.Fecha,
                        IdAsiento = 0,
                        IdBanco = f.IdBanco,
                        IdCliente = f.IdCliente,
                        IdColaborador = f.IdColaborador,
                        IdCuentaContable = f.IdCuentaContable,
                        IdDetalleAsiento = 0,
                        IdProveedor = f.IdProveedor,
                        IdUsuario = f.IdUsuario,
                        Mayor = f.Mayor,
                        Monto = f.Monto
                    }));
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            /*Diferencia Debito Credito*/
            var sumD = Asiento.Sum(s => s.Debito);
            var sumC = Asiento.Sum(s => s.Credito);
            var tot = sumD - sumC;

            if (tot != 0)
                lblDiferencia.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            else
            {
                lblDiferencia.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
                lblDiferencia.Caption = "0.00";
            }

            lblDiferencia.Caption = tot.Value.ToString("#,#.00#;(#,#.00#)");
        }
        bool EsDesdeTxt { get; set; }
        private void txtFindAcountId_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //EsDesdeTxt = true;
                var txt = sender as TextEdit;
                int prsN = 0;
                //if (!int.TryParse(txt.Text, out prsN))
                //    return;
                if (txt.Text.Trim() == string.Empty)
                    return;
                var row = new Model.Cuentas();
                row = BuscarCuentaPorId(txt.Text, row);
                if (row == null)
                {
                    XtraMessageBox.Show("No existe Esta Cuenta!");
                    return;
                }
                gridView1.SetFocusedRowCellValue(colCuentaContable, row.Text);
                gridView1.SetFocusedRowCellValue(colIdCuentaContable, row.ID);
                var r = gridView1.GetFocusedRow() as AsientoContable;
                r.IdCuentaContable = row.ID;
                switch (row.Tipo)
                {
                    case 1:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 2:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 3:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 4:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 5:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 6:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 7:
                        //Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case 9:
                        gridView1.FocusedColumn = colDebito;
                        break;
                }
                if (Principal.Bariables.IdCuentaProveedor.ToString() == row.CuentaContable)
                {
                    var frmP = new ShowProveedor();
                    frmP.ShowDialog(this);
                    if (frmP.IdProveedor != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdProveedor, frmP.IdProveedor);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Proveedor);
                    }
                }
                if (Principal.Bariables.IdCuentaCliente.ToString() == row.CuentaContable)
                {
                    var frmP = new ShowClientes();
                    frmP.ShowDialog(this);
                    if (frmP.IdCliente != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdCliente, frmP.IdCliente);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Cliente);
                    }
                }
                if (Principal.Bariables.IdCuentaEmpleado.ToString() == row.CuentaContable)
                {
                    var frmP = new ShowEmpleados();
                    frmP.ShowDialog(this);
                    if (frmP.IdColaborador != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdColaborador, frmP.IdColaborador);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Colaborador);
                    }
                }
                if (Principal.Bariables.IdCuentaBanco.ToString() == row.CuentaContable)
                {
                    var frmP = new ShowBanco2();
                    frmP.ShowDialog(this);
                    if (frmP.IdBanco != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdBanco, frmP.IdBanco);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Banco);
                    }
                }
            }
        }

        private Cuentas BuscarCuentaPorId(string txt, Cuentas row)
        {
            Cuentas.Where(s => s.CuentaContable == txt.Trim()).ToList().ForEach(f =>
            {
                if (row.ID == 0)
                    row = f;
            });
            return row;
        }

        private int UltimoId { get; set; }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detalleDiario = new List<DetalleAsientos>();
            if (Asiento.Count == 0)
                return;
            Asiento.ToList().ForEach(f =>
            {
                if((f.Debito??0m)+ (f.Credito??0m) >0)
                {
                    var row = new Cuentas();
                    row = BuscarCuentaPorId(f.CuentasCombinadas, row);
                    if (f.IdCuentaContable == 0)
                    {

                    }
                    f.IdCuentaContable = row.ID;
                    detalleDiario.Add(new DetalleAsientos
                    {
                        Credito = f.Credito,
                        Debito = f.Debito,
                        IdAsiento = Asiento[0].IdAsiento > 0 ? Asiento[0].IdAsiento : f.IdAsiento,
                        IdMaestroCuenta = f.IdCuentaContable,
                        IdCliente = f.IdCliente,
                        idProvedor = f.IdProveedor,
                        IdBanco = f.IdBanco,
                        IdColaborador = f.IdColaborador,
                        IdDetalleAsiento = f.IdDetalleAsiento
                    });
                }
            });
            var asiento = new Asientos
            {
                IdAsiento =Asiento[0].IdAsiento,
                Comentario = tComentario.Text,
                Fecha = dtFechaAsiento.DateTime,
                IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                DetalleAsientos = detalleDiario,
                IdUser = Principal.Bariables.IdUsuario,
                IdRegistroBanco = IdRegistroBanco,
                IdTransaccion = Asiento[0].IdTransaccion,
                IdOrigen = = Asiento[0].IdOrigen
            };
            if (LstPeriodosFiscales.Count > 0)
            {
                /**PERIODIOS FISCALES VALIDAR QUE NO INGRESE TRANSACCIONES ANTERIORES*/
                if(asiento.Fecha.Value.CompareTo(LstPeriodosFiscales[0].Hasta) < 0)
                {
                    MessageBox.Show($" ALERTA {asiento.Fecha} ESTA DENTRO DEL ULTIMO CIERRE FISCAL ({LstPeriodosFiscales[0].Hasta})" );
                    return;
                }
            }
            /****** Enviar Asiento Contable ******/
            var diario = new Controller.Diario();
            bool respuesta = diario.AgregarAsiento(asiento);
            UltimoId= diario.NuevoId??0;
            lblMsg.Caption = diario.MSG + " " + diario.NuevoId.ToString();
            if (respuesta)
            {
                Asiento.Clear();
                IdCliente = null;
                IdRegistroBanco = null;
                IdTransaccion = null;
                linkLabelAsiento.Text = $"ULTIMO ASIENTO GENERADO: {UltimoId}";
                if (IdSesion != 0)
                {
                    new Controller.VMSesiones().ActualizarSesion(IdSesion);
                    IdSesion = 0;
                    int cntPen = new Controller.VMSesiones().SesionesAbiertas.Count;
                    if (cntPen > 0)
                        barButtonItem1.Caption = $"Asientos Pendientes ({cntPen})";
                    else
                        barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            tComentario.ResetText();
        }

        private void btnQuitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var row = gridView1.GetFocusedRow() as AsientoContable;
            gridView1.DeleteRow(gridView1.FocusedRowHandle);

            /****** ELIMINAR SI EXISTE EN DB ******/
            if (row != null)
            {
                if (row.IdDetalleAsiento > 0)
                {
                    var diario = new Controller.Diario();
                    if (diario.EliminarDetalleAsiento(row.IdDetalleAsiento))
                        barButtonItem1.Caption = $"SE ELIMINA ASIENTO TAMBIEN DE BASE DE DATOS........";
                }
            }
        }
        Model.Cuentas idC { get; set; }
        private void btnEditColumn_Click(object sender, EventArgs e)
        {
            if (!EsDesdeTxt)
            {
                var frmSelectCuenta = new F.D.SelectorCuentas();
                frmSelectCuenta.ShowDialog(this);
                if (!string.IsNullOrEmpty(frmSelectCuenta.CuentaContable))
                {
                    if (frmSelectCuenta.Cuenta != null)
                    {
                        var f = frmSelectCuenta.MCuenta;
                        if (frmSelectCuenta.MCuenta != null)
                        {
                            //Cuentas.Add(new Cuentas
                            //{
                            //    ParentID = f.ParentID ?? 0,
                            //    Text = f.Text,
                            //    ID = f.IdMaestroCuenta,
                            //    Tipo = f.Tipo ?? 0,
                            //    Id = f.Id ?? 0,
                            //    CuentaContable = f.CuentaContable,
                            //    Nivel = f.Nivel ?? 0,
                            //    Nivel0 = f.Nivel0,
                            //    Nivel1 = f.Nivel1,
                            //    Nivel2 = f.Nivel2,
                            //    Nivel3 = f.Nivel3,
                            //    Habilitar = f.Habilitar,
                            //    SumaResta = f.SumaResta,
                            //    CuentaMadre = Buscar(f.Tipo ?? 0, lstCUentas)
                            //});
                        }
                    }
                    idC = Cuentas.SingleOrDefault(s => s.CuentaContable == frmSelectCuenta.CuentaContable);
                    (sender as TextEdit).Text = frmSelectCuenta.Cuenta;

                    var r = gridView1.GetFocusedRow() as AsientoContable;
                    if (r == null)
                        return;
                    r.IdCuentaContable = idC.ID;
                    gridView1.SetFocusedRowCellValue(colIdCuentaContable, idC.ID);
                    gridView1.SetFocusedRowCellValue(colCuentaContable, idC.Text);
                    gridView1.SetFocusedRowCellValue(colCuentasCombinadas, idC.CuentaContable);


                    if (frmSelectCuenta.Id == 0)
                    {
                        lblMsg.Caption = "Seleccione una cuenta";
                        return;
                    }
                }
            }               
        }

        private void btnEditColumn_EditValueChanged(object sender, EventArgs e)
        {
            if (!EsDesdeTxt)
            {
                if (idC == null)
                    return;
                int idCuenta = idC.Id;
                var r = gridView1.GetFocusedRow() as AsientoContable;
                var row = Cuentas.SingleOrDefault(s => s.Id == idCuenta);
                if (r == null)
                    return;
                r.IdCuentaContable = row.ID;
                gridView1.SetFocusedRowCellValue(colIdCuentaContable, row.ID);
                gridView1.SetFocusedRowCellValue(colCuentaContable, idC.Text);
                gridView1.SetFocusedRowCellValue(colCuentasCombinadas, row.Id);
                switch (row.Tipo)
                {
                    case 1:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 2:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 3:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 4:
                        gridView1.FocusedColumn = colCredito;
                        break;
                    case 5:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 6:
                        gridView1.FocusedColumn = colDebito;
                        break;
                    case 7:
                        //Asiento[e.NewIndex].Debito = mnt;
                        break;
                    case 9:
                        gridView1.FocusedColumn = colDebito;
                        break;
                }
                if (Principal.Bariables.IdCuentaProveedor == row.ID)
                {
                    var frmP = new ShowProveedor();
                    frmP.ShowDialog(this);
                    if (frmP.IdProveedor != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdProveedor, frmP.IdProveedor);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Proveedor);
                    }
                }
                if (Principal.Bariables.IdCuentaCliente == row.ID)
                {
                    var frmP = new ShowClientes();
                    frmP.ShowDialog(this);
                    if (frmP.IdCliente != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdCliente, frmP.IdCliente);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Cliente);
                    }
                }
                if (Principal.Bariables.IdCuentaEmpleado == row.ID)
                {
                    var frmP = new ShowEmpleados();
                    frmP.ShowDialog(this);
                    if (frmP.IdColaborador != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdColaborador, frmP.IdColaborador);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Colaborador);
                    }
                }
                if (Principal.Bariables.IdCuentaBanco == row.ID)
                {
                    var frmP = new ShowBanco2();
                    frmP.ShowDialog(this);
                    if (frmP.IdBanco != 0)
                    {
                        gridView1.SetFocusedRowCellValue(colIdBanco, frmP.IdBanco);
                        gridView1.SetFocusedRowCellValue(colComentario, frmP.Banco);
                    }
                }
            }
            else
                EsDesdeTxt = false;
        }

        private void btnCuentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!EsDesdeTxt)
            {
                var frmSelectCuenta = new F.D.ShowCuentas();
                frmSelectCuenta.ShowDialog(this);
                if (frmSelectCuenta.Id != 0)
                {
                    if ((sender as TextEdit) == null) return;
                    (sender as TextEdit).Text = frmSelectCuenta.Cuenta;
                    if (frmSelectCuenta.Id == 0)
                    {
                        lblMsg.Caption = "Seleccione una cuenta";
                        return;
                    }
                }
            }
        }

        private void btnLstAsientos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vc = new F.D.VerCuentas();
            T.OpenForm(vc);
            if (vc.IdAsiento != null && vc.Modificar)
            {
                //Asiento = vc.Asientos;
                //gridControl1.DataSource = Asiento;
                //tComentario.Text = Asiento[0].Comentario;

                var diario = new Controller.Diario().Asiento(vc.IdAsiento);
                if(diario != null)
                {

                }
            }
        }
        private void linkLabelAsiento_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            var vc = new F.D.VerCuentas();
            if (UltimoId > 0)
                if (XtraMessageBox.Show("DESEA VER EL ULTIMO ASIENTO?", "MENSAJE DE ALERTA", MessageBoxButtons.OKCancel) == DialogResult.Yes)
                    vc.UltimoAsiento = UltimoId;
            T.OpenForm(vc);
            if (vc.Asientos != null && vc.Modificar)
            {
                Asiento = vc.Asientos;
                gridControl1.DataSource = Asiento;
                tComentario.Text = Asiento[0].Comentario;
            }
        }
        int IdSesion { get; set; }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var db = new Controller.VMSesiones();
            if(db.GuardarSesion(dtFechaAsiento.DateTime, tComentario.Text, Asiento.ToList(), "Diario", IdSesion) && Asiento.Count >0)
                if (IdSesion == 0) IdSesion = db.Id;
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BuscarPendientes();
        }

        private void Diario_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (Asiento.Count > 0)
            {
                if (XtraMessageBox.Show("EXISTEN SESIONES ABIERTAS DESEA GUARDARLAS?", "MENSAJES", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var db = new Controller.VMSesiones();
                    if (db.GuardarSesion(dtFechaAsiento.DateTime, tComentario.Text, Asiento.ToList(), "Diario", IdSesion))
                        if (IdSesion == 0) IdSesion = db.Id;
                }
            }
        }
    }
}