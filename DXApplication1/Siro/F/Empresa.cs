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

namespace Siro.F
{
    public partial class Empresa : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        public Empresa()
        {
            InitializeComponent();
            gridControl1.DataSource = dbContext.Empresas.ToList();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!";
        }
    }
}