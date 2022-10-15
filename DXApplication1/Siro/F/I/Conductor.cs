using System.Data.Entity;

namespace Siro.F.I
{
    public partial class Conductor : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiroCon dbContext = new Siro.slSiroCon();
        public Conductor()
        {
            InitializeComponent();
            dbContext.Conductores.Load();
            gridControl1.DataSource = dbContext.Conductores.Local.ToBindingList();
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
    }
}