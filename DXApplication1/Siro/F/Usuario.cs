using DevExpress.XtraEditors.Controls;
using System;
using System.Data.Entity;
using System.Linq;

namespace Siro.F
{
    public partial class Usuario : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        public Usuario()
        {
            InitializeComponent();
            dbContext.Usuarios.Load();
            gridControl1.DataSource = dbContext.Usuarios.Local.ToBindingList();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //(e.Row as Usuarios).nombreCompleto = "El ver ";
            dbContext.SaveChanges();
            lblMsg.Caption = "Datos Guardados!!";
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var usuario = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colusuario);
            var pwd = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colcontraseña);
            if(string.IsNullOrEmpty(usuario.ToString()))
            {
                gridView1.SetColumnError(colusuario, "Falta el usuario");
            }
            if (string.IsNullOrEmpty(pwd.ToString()))
            {
                gridView1.SetColumnError(colcontraseña, "Falta contraseña");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            lblMsg.Caption = "Por favor complete los campos;";
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            dbContext.Perfil.ToList().ForEach(f =>
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = f.IdPerfil,
                    Description = f.Perfil1
                };
                repositoryItemImageComboBox1.Items.Add(item);
            });
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var per = new Perfil();
            per.ShowDialog();
            Siro.Perfil perfil = per.NuevoPerfil;
            if (per.NuevoPerfil != null)
            {
                var item = new ImageComboBoxItem
                {
                    Value = perfil.IdPerfil,
                    Description = perfil.Perfil1
                };
                repositoryItemImageComboBox1.Items.Add(item);
            }
        }
    }
}