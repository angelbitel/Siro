using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Siro.F.I
{
    public partial class Vendedores : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiroCon dbContext = new Siro.slSiroCon();
        public Vendedores()
        {
            InitializeComponent();
            dbContext.Vendedores.Load();
            gridControl1.DataSource = dbContext.Vendedores.Local.ToBindingList();
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }  
    }
}