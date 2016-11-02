using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Siro.F.D;
using Siro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Siro.F
{
    public partial class Diario : DevExpress.XtraEditors.XtraForm
    {
        /*VARIABLES DE LA FORMA DIARIO*/
        //Siro.slEntities dbContext = new Siro.slEntities();
        private BindingList<AsientoContable> Asiento = new BindingList<AsientoContable>();

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
            //if(Principal.Bariables.PeridoContable != DateTime.Now)
            //{
            //    Principal.Bariables.PeridoContable = DateTime.Now;
            //}
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
            gridControl1.DataSource = Asiento;
            var control = new Controller.Contabilidad().CuentasMaestras(Principal.Bariables.IdEmpresa.Id);
            Cuentas = control;
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
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                //EsDesdeTxt = true;
                var txt = sender as DevExpress.XtraEditors.TextEdit;
                int prsN = 0;
                if (!int.TryParse(txt.Text, out prsN))
                    return;
                if (txt.Text.Trim() == string.Empty)
                    return;
                var row = Cuentas.SingleOrDefault(s => s.Id == int.Parse(txt.Text));
                if (row == null)
                {
                    XtraMessageBox.Show("No existe Esta Cuenta!");
                    return;
                }
                gridView1.SetFocusedRowCellValue(colCuentaContable, row.Text);
                gridView1.SetFocusedRowCellValue(colIdCuentaContable, row.Id);
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
                if(Principal.Bariables.IdCuentaProveedor == row.ID)
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
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detalleDiario = new List<DetalleAsientos>();
            Asiento.ToList().ForEach(f =>
            {
                detalleDiario.Add(new DetalleAsientos
                {
                    Credito = f.Credito,
                    Debito = f.Debito,
                    IdAsiento = f.IdAsiento,
                    IdMaestroCuenta = f.IdCuentaContable,
                    IdCliente = f.IdCliente,
                    idProvedor = f.IdProveedor,
                    IdBanco = f.IdBanco,
                    IdColaborador = f.IdColaborador,
                    IdDetalleAsiento = f.IdDetalleAsiento
                });
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
                IdTransaccion = IdTransaccion
            };
            /****** Enviar Asiento Contable ******/
            var diario = new Controller.Diario();
            bool respuesta = diario.AgregarAsiento(asiento);
            lblMsg.Caption = diario.MSG + " " + diario.NuevoId.ToString();
            if (respuesta)
            {
                Asiento.Clear();
                IdCliente = null;
                IdRegistroBanco = null;
                IdTransaccion = null;
            }
            tComentario.ResetText();
        }

        private void btnQuitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        Model.Cuentas idC { get; set; }
        private void btnEditColumn_Click(object sender, EventArgs e)
        {
            if (!EsDesdeTxt)
            {
                var frmSelectCuenta = new F.D.SelectorCuentas();
                frmSelectCuenta.ShowDialog(this);
                if (frmSelectCuenta.Id != 0)
                {
                    idC = Cuentas.SingleOrDefault(s => s.Id == frmSelectCuenta.Id);
                    (sender as TextEdit).Text = frmSelectCuenta.Cuenta;
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
                    //idC = Cuentas.SingleOrDefault(s => s.Id == frmSelectCuenta.Id);
                    //Asiento.Add(new AsientoContable { CuentasCombinadas = idC.Id, CuentaContable =frmSelectCuenta.Cuenta });

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
            vc.ShowDialog(this);
            if (vc.Asientos != null)
            {
                Asiento = vc.Asientos;
                gridControl1.DataSource = Asiento;
                tComentario.Text = Asiento[0].Comentario;
            }
        }
    }
}