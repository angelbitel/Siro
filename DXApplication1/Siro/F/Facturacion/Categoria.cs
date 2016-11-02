using System.Data.Entity;

namespace Siro.F.Facturacion
{
    public partial class Categoria : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        public Categoria()
        {
            InitializeComponent();
            dbContext.Categorias.Load();
            gridControl1.DataSource = dbContext.Categorias.Local.ToBindingList();
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
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
    }
}