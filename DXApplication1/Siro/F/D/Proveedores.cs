using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Siro.F.D
{
    public partial class Proveedores : DevExpress.XtraEditors.XtraForm
    {
        Siro.slContabilidad db = new Siro.slContabilidad();
        public Proveedores()
        {
            InitializeComponent();
            db.provedores.Load();
            gridControl1.DataSource = db.provedores.Local.ToBindingList();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            db.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
        //public void Dispose()
        //{
        //    db.Dispose();
        //}
    }
}