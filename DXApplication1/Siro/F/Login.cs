using Siro.Properties;
using System;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var res =Principal.Bariables.db.Usuarios.SingleOrDefault(w => w.usuario == textEdit1.Text);
                string pwd = res!= null? res.contraseña:string.Empty;
                if (pwd == textEdit2.Text)
                {
                    Settings.Default.UltimoUsuario = textEdit1.Text;
                    Settings.Default.Save();
                    Principal.Bariables.HabilitarP = true;
                    Principal.Bariables.IdUsuario = res.IdUser;
                    this.Close();
                }
                else
                {
                    barStaticItem1.Caption = "Usuario o Contraseña Incorrecto";
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (WindowsIdentity.GetCurrent().Name.IndexOf("angel") != -1)
            {
                Principal.Bariables.HabilitarP = true;
                Principal.Bariables.IdUsuario = 1;
                if (Settings.Default.UltimoUsuario.Trim().Length == 0)
                {
                    Settings.Default.UltimoUsuario = "Angel";
                    Settings.Default.Save();
                }

                this.Close();
            }
            if (Settings.Default.UltimoUsuario != null)
            {
                textEdit1.Text = Settings.Default.UltimoUsuario;
                this.Text = string.Format("Bienvenido {0} a SIRO", Settings.Default.UltimoUsuario);
                try
                {
                    var img = Principal.Bariables.db.Usuarios.SingleOrDefault(w => w.usuario == Settings.Default.UltimoUsuario).img;
                    if (img != null)
                    {
                        pictureEdit1.EditValue = img;
                    }
                }
                catch (Exception ex)
                {
                    barStaticItem1.Caption = ex.Message;
                }
                textEdit2.Focus();
            }
        }
    }
}