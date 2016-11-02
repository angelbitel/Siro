using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Siro.F.I
{
    public partial class EntradasSalidas : DevExpress.XtraEditors.XtraForm
    {
        List<Model.EntradasSalidas> lstRegistroArroz = new List<Model.EntradasSalidas>();
        List<TiposMovimiento> lstTMovimiento = new List<TiposMovimiento>();
        List<Productos> lstProduct = new List<Productos>();
        List<Almacenes> lstAlmacenes = new List<Almacenes>();
        public EntradasSalidas()
        {
            InitializeComponent();
        }
        private void crearLst()
        {
             var ra = new Controller.RA();
             int idAlmacen = ra.MaxSilo();
             var val = new InicioEA();
             val.ShowDialog();
            lstProduct.ForEach(f => lstRegistroArroz.Add(new Model.EntradasSalidas{ Fecha=val.Fecha, PorcentajeDesCuentoSilo=val.Porcentaje, IdProducto=f.IdProducto, IdUser= Principal.Bariables.IdUsuario, IdTipoMovimiento = val.IdTipoMovimiento, IdAlmacen=idAlmacen}));
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var row = entradasSalidasBindingSource.Current as Model.EntradasSalidas;
            if (row != null)
                if (row.Fecha == null)
                {
                    row.Fecha = Principal.Bariables.PeridoContable;
                    row.IdUser = Principal.Bariables.IdUsuario;
                    row.PorcentajeDesCuentoSilo = 1.45M;
                }
        }
        bool tipoMovimiento { get; set; }
        private void lstTipoMovimiento_EditValueChanged(object sender, EventArgs e)
        {
            var tm = (sender as SearchLookUpEdit).Properties.View.GetFocusedRow();
            tipoMovimiento=(tm as TiposMovimiento).Resta??false;
            //Recalcular();
        }

        private void LLenarListas()
        {
            var lst = new Controller.Lst();
            lstProduct = lst.LstProducto(Principal.Bariables.IdEmpresa.Id);
            lstTMovimiento = lst.TiposMovimientos;
            lstAlmacenes = lst.Almacenes;
        }
        private void txtPorcentaje_KeyUp(object sender, KeyEventArgs e)
        {
            var control = (sender as TextEdit);
            //Recalcular();
        }

        private void Recalcular()
        {
            var row = gridView1.GetFocusedRow() as Model.EntradasSalidas;
            int mult = 1;
            if (tipoMovimiento)
                mult = -1;
            if (row != null)
            {
                var total = (row.Cantidad * row.PorcentajeDesCuentoSilo) / 100 + row.Cantidad;
                var cnt = row.Cantidad;
                total= total <0 ? total * -1:total;
                total = total * mult;

                cnt = cnt < 0 ? cnt * -1 : cnt;
                cnt = cnt * mult;

                gridView1.SetFocusedRowCellValue(colTotal, total);
                gridView1.SetFocusedRowCellValue(colCantidad, cnt);
                gridView1.SetFocusedRowCellValue(colModificado, true);
                row.Modificado = true;
            }
        }

        private void EntradasSalidas_Load(object sender, EventArgs e)
        {
            LLenarListas();
            entradasSalidasBindingSource.DataSource = lstRegistroArroz;
            productosBindingSource.DataSource = lstProduct;
            tiposMovimientoBindingSource.DataSource = lstTMovimiento;
            tiposAlmacenBindingSource.DataSource = lstAlmacenes;
            crearLst();
            barEditItem1.EditValue = Principal.Bariables.PeridoContable;
            barEditItem2.EditValue = Principal.Bariables.PeridoContable;
            Desde = Principal.Bariables.PeridoContable;
            Hasta = Principal.Bariables.PeridoContable;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if ((new string[] { "colCantidad", "colPrecioVenta" }).Contains(e.Column.Name))
            //{
            //}
               var row = gridView1.GetFocusedRow() as Model.EntradasSalidas;
            int mult = 1;
            if (tipoMovimiento)
                mult = -1;
            if (row != null)
            {
                var total = (row.Cantidad * row.PorcentajeDesCuentoSilo) / 100 + row.Cantidad;
                var cnt = row.Cantidad;
                total = total < 0 ? total * -1 : total;
                total = total * mult;

                cnt = cnt < 0 ? cnt * -1 : cnt;
                cnt = cnt * mult;
                row.Total = total;
                row.Cantidad = cnt;
                //gridView1.SetFocusedRowCellValue(colTotal, total);
                //gridView1.SetFocusedRowCellValue(colCantidad, cnt);
                //gridView1.SetFocusedRowCellValue(colModificado, true);
                row.Modificado = true;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = new Controller.RA().LstInventario(Desde, Hasta);
            lstRegistroArroz = lst;
            gridControl1.DataSource = lstRegistroArroz;
        }
        private DateTime Desde { get; set; }
        private DateTime Hasta { get; set; }
        private void DtDesde_EditValueChanged(object sender, EventArgs e)
        {
            Desde =(sender as DevExpress.XtraEditors.DateEdit).DateTime;
        }

        private void DtHasta_EditValueChanged(object sender, EventArgs e)
        {
            Hasta = (sender as DevExpress.XtraEditors.DateEdit).DateTime;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int cnt = 0;
            gridView1.UpdateCurrentRow();
            lstRegistroArroz.ForEach(f => { 
                if(f.Modificado && f.Cantidad != 0)
                {
                    var ra = new Controller.RA();
                    ra.Agregarkardex(new Siro.Kardex
                    {
                        Cantidad = f.Cantidad,
                        Comentario = f.Comentario,
                        IdInventario = f.IdInventario,
                        IdProducto = f.IdProducto,
                        IdTipoMovimiento = f.IdTipoMovimiento,
                        PorcentajeDescuentoSilo = f.PorcentajeDesCuentoSilo,
                        Precio = f.Precio,
                        Total = f.Total,
                        Fecha = f.Fecha,
                        IdUser = Principal.Bariables.IdUsuario,
                        IdAlmacen = f.IdAlmacen,
                        PorcentajeEntero = f.PorcentajeEntero,
                        PorcentajeQuebrado = f.PorcentajeQuebrado
                    });
                    f.IdInventario = ra.NuevoId;
                    if (ra.Ejecuto)
                        cnt++;
                }
            });
            lblMsg.Caption = string.Format("{0} {1}", "Cantidad De Registros Guardados:", cnt);
        }
    }
}