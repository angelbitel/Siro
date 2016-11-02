using DevExpress.XtraEditors.Controls;
using Siro.F.Facturacion;
using System;
using System.Data.Entity;
using System.Linq;

namespace Siro.F
{
    public partial class Producto : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        public Producto()
        {
            InitializeComponent();
            dbContext.Productos.Where(w=> w.IdEmpresa==Principal.Bariables.IdEmpresa.Id).Load();
            gridControl1.DataSource = dbContext.Productos.Local.ToBindingList();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
        private void LLenarEmpresas()
        {
            using (var db = new Siro.slEntities())
            {
                db.Empresas.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdEmpresa,
                        Description = f.Empresa
                    };
                    repositoryItemImageComboBoxEmpresa.Items.Add(item);
                });
            }
        }
        private void LLenarCategorias()
        {
            using (var db = new Siro.slEntities())
            {
                db.Categorias.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdCategoria,
                        Description = f.Categoria
                    };
                    repositoryItemImageComboBoxCategoria.Items.Add(item);
                });
            }
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            //Parallel.Invoke(() => LLenarEmpresas(), () => LLenarCategorias());
            LLenarEmpresas();
            LLenarCategorias();
            //productosBindingSource.DataSource = lstProductos;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            gridView1.UpdateCurrentRow();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PrintDialog();
        }

        private void btnLstPrecio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new ListaPrecios(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colIdProducto).ToString())).ShowDialog(this);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue(e.RowHandle, colIdEmpresa, Principal.Bariables.IdEmpresa.Id);
            view.SetRowCellValue(e.RowHandle, colCantidad, 1);
            lblMsg.Caption = "";
        }
    }
}