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
using DevExpress.XtraGrid.Views.Grid;

namespace Siro.F.I
{
    public partial class AddP : DevExpress.XtraEditors.XtraForm
    {
        Siro.slContabilidad db = new Siro.slContabilidad();
        public AddP()
        {
            InitializeComponent();
            db.provedores.Where(w => w.EsProductor == true).Load();
            gridControl1.DataSource = db.provedores.Local.ToBindingList();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, colEsProductor, true);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            db.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
        public int IdProv { get; set; }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            this.IdProv = int.Parse(gridView1.GetFocusedRowCellValue(colidProvedor).ToString());
            this.Close();
        }

        private void AddP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IdProv == 0)
            {
                lblMsg.Caption = "Seleccione Un Provedor";
                e.Cancel = true;
            }
        }
    }
}