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

namespace Siro.F
{
    public partial class Perfiles : DevExpress.XtraEditors.XtraForm
    {
        public Perfiles()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            slEntities context = new slEntities();
            var o = (usuariosBindingSource.Current as Siro.Usuarios);
            var usr = new Siro.Usuarios
            {
                contraseña = o.contraseña,
                direccion = o.direccion,
                email = o.email,
                fechaCumpleaño = o.fechaCumpleaño,
                img = o.img,
                nombreCompleto = o.nombreCompleto,
                usuario = o.usuario,
                telefono = o.telefono,
                IdUser = o.IdUser,
                IdPerfil = o.IdPerfil
            };
            if (usr.IdUser == 0)
                context.Usuarios.Add(usr);
            else
                context.Entry(usr).State = EntityState.Modified;

            context.SaveChanges();
            LblMsg.Caption = "Datos Guardados Correctamente!!";
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            slEntities context = new slEntities();
            var c = context.Usuarios.SingleOrDefault(w => w.IdUser == Principal.Bariables.IdUsuario); ;
            usuariosBindingSource.DataSource = c;
        }
    }
}