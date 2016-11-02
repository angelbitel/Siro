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
using DevExpress.XtraEditors.Controls;

namespace Siro.F
{
    public partial class Servicio : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        public Servicio()
        {
            InitializeComponent();
            dbContext.Servicios.Where(w => w.IdEmpresa == Principal.Bariables.IdEmpresa.Id).Load();
            gridControl1.DataSource = dbContext.Servicios.Local.ToBindingList();
        }
        private void LLenarCategorias()
        {
            using (var db = new Siro.slEntities())
            {
                db.Categorias.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdCategoria,
                        Description = f.Categoria
                    };
                    repositoryItemImageComboBoxCategoria.Items.Add(item);
                });
            }
        }
        private void LLenarEmpresas()
        {
            using (var db = new Siro.slEntities())
            {
                db.Empresas.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdEmpresa,
                        Description = f.Empresa
                    };
                    repositoryItemImageComboBoxEmpresa.Items.Add(item);
                });
            }
        }

        private void Servicio_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(() => LLenarEmpresas(), () => LLenarCategorias());
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
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue(e.RowHandle, colIdEmpresa, Principal.Bariables.IdEmpresa.Id);
            lblMsg.Caption = "";
        }
    }
}