using System.Data.Entity;

namespace Siro.F.I
{
    public partial class SilosInfo : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiroCon dbContext = new Siro.slSiroCon();
        public SilosInfo()
        {
            InitializeComponent();
            dbContext.Almacenaje.Load();
            gridControl1.DataSource = dbContext.Almacenaje.Local.ToBindingList();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
    }
}