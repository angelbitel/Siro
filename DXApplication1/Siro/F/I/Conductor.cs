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
using System.Data.Entity;

namespace Siro.F.I
{
    public partial class Conductor : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiro dbContext = new Siro.slSiro();
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