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

namespace Siro.F.Facturacion
{
    public partial class Marca : DevExpress.XtraEditors.XtraForm
    {
        Siro.slContabilidad dbContext = new Siro.slContabilidad();
        public Marca()
        {
            InitializeComponent();
            dbContext.Marcas.Load();
            gridControl1.DataSource = dbContext.Marcas.Local.ToBindingList();
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, colIdEmpresa, Principal.Bariables.IdEmpresa.Id);
        }
    }
}