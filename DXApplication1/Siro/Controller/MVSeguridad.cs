using Siro.Properties;
using System;
using System.Linq;
using System.Data.SqlClient;

namespace Siro.Controller
{
    internal class MVSeguridad
    {
        slEntities context;
        public MVSeguridad() => context = new slEntities();

        public string Mensaje { get; private set; }

        public byte[] UserImg(string userName)
        {
            var len = context.Database.SqlQuery<Int64>("SELECT TOP 1 DATALENGTH(Img) FROM Usuarios WHERE usuario = @Usuario", new SqlParameter("@Usuario", userName)).Single();
            var len2 = System.Convert.FromBase64String(Settings.Default.Img).Length;
            if (len != len2)
            {
                var img = context.Usuarios.Where(s => s.usuario == userName && s.Activar == true).Select(s => s.img).ToList()[0];
                Settings.Default.Img = Convert.ToBase64String(img);
                Settings.Default.Save();
                return img;
            }
            else
                return Convert.FromBase64String(Settings.Default.Img);
        }
        public Model.Login UserLogin(string userName)
        {
            var user = new Model.Login { };
            try
            {
                var dbUs = context.Database.SqlQuery<Model.Login>("SELECT IdUsuario, usuario AS NombreUsuario, IdPerfil, Contraseña, Usuario FROM Usuarios WHERE Usuario = @Usuario", new SqlParameter("Usuario", userName)).ToList();
                if (dbUs.Count > 0)
                    user = dbUs[0];

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
            return user;
        }
    }
}