using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;

namespace Siro.F.D
{
    public partial class DetalleFactura : DevExpress.XtraEditors.XtraForm
    {
        public BindingList<DetallesFacturaItem> Asiento = new BindingList<DetallesFacturaItem>();
        private bool RequiereItbm { get; set; }
        public DetalleFactura(BindingList<DetallesFacturaItem> asiento, bool rItbm)
        {
            if(asiento != null)
                Asiento = asiento;
            InitializeComponent();
            detallesFacturaItemBindingSource.DataSource = Asiento;
            RequiereItbm = rItbm;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue(e.RowHandle, colCantidad, 1);
            lblMsg.Caption = "";
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            //AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //using (var db = new Siro.slContabilidad())
            //{
            //    collection.Add("Yes");
            //    collection.Add("No");
            //    collection.Add("Maybe");
            //}
            //txtProducto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
            //txtProducto.Mask.AutoComplete.
            //txtProducto.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //textEdit1.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //textEdit1.MaskBox.AutoCompleteCustomSource = collection;
            var lst = new Controller.Lst();
            almacenesBindingSource.DataSource = lst.AlmacenesP(Principal.Bariables.IdEmpresa.Id);
            marcasBindingSource.DataSource = lst.Marcas(Principal.Bariables.IdEmpresa.Id);
            categoriasBindingSource.DataSource = lst.Categorias;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            var pre = gridView1.GetFocusedRowCellValue(colMonto).ToString();
            var cnt = gridView1.GetFocusedRowCellValue(colCantidad).ToString();
            decimal pc = 0, itbm = 0;
            decimal.TryParse(pre, out pc);
            if (RequiereItbm)
            {
                view.SetRowCellValue(e.RowHandle, colITBMS, ((pc*int.Parse(cnt)) * 0.07M));
            }
                view.SetRowCellValue(e.RowHandle, colTotal, itbm+pc);

        }
    }
}