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
    public partial class AddC : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiroCon db = new Siro.slSiroCon();
        public AddC()
        {
            InitializeComponent();
            db.Conductores.Load();
            gridControl1.DataSource = db.Conductores.Local.ToBindingList();
        }
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            db.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }
        public int IdConductor { get; set; }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.IdConductor = int.Parse(gridView1.GetFocusedRowCellValue(colIdConductor).ToString());
            this.Close();
        }
    }
}