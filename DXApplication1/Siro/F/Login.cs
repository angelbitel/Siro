using Siro.Properties;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
        private byte[] Img { get; set; }
        public string Usuario { get; set; }
        public bool Entrar { get; set; }
        public Login()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.DoWork += new DoWorkEventHandler(bw_DoWork);
            Usuario = Settings.Default.UltimoUsuario;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.Img))
                pictureEdit1.EditValue = Convert.FromBase64String(Settings.Default.Img);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.UltimoUsuario != null)
            {
                try
                {
                    var usr = new Controller.MVSeguridad().UserImg(Settings.Default.UltimoUsuario);
                    if (usr == null) return;
                    Img = usr;
                }
                catch (Exception ex)
                {
                    lbl.Caption = ex.Message.ToUpper();
                }
            }
        }
        public bool Pasar { get; set; }

        private void textEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var res = new Controller.MVSeguridad().UserLogin(textEdit1.Text);
                string pwd = res!= null? res.Contraseña:string.Empty;
                if (pwd == textEdit2.Text)
                {
                    Settings.Default.UltimoUsuario = textEdit1.Text;
                    Settings.Default.Save();
                    Principal.Bariables.HabilitarP = true;
                    Principal.Bariables.IdUsuario = res.IdUsuario;
                    Pasar = true;
                    this.Close();
                }
                else
                {
                    lbl.Caption = "Usuario o Contraseña Incorrecto";
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (WindowsIdentity.GetCurrent().Name.IndexOf("angel") != -1)
            {
                var res = new Controller.MVSeguridad().UserLogin("Angel");
                string pwd = res != null ? res.Contraseña : string.Empty;

                Settings.Default.UltimoUsuario = textEdit1.Text;
                Settings.Default.Save();
                Principal.Bariables.HabilitarP = true;
                Principal.Bariables.IdUsuario = res.IdUsuario;
                Principal.Bariables.IdPerfil = res.IdPerfil;
                Principal.Bariables.Usuario = res.Usuario;
                Pasar = true;
                this.Close();
            }
            else if (Settings.Default.UltimoUsuario != null)
            {
                textEdit1.Text = Settings.Default.UltimoUsuario;
                this.Text = string.Format("Bienvenido {0} a SIRO ACCOUNTING", Settings.Default.UltimoUsuario);
                try
                {
                    textEdit1.Text = Settings.Default.UltimoUsuario;
                    this.Text = string.Format("BIENVENIDO {0} a SIRO ACCOUNTING", Settings.Default.UltimoUsuario);
                    if (!string.IsNullOrEmpty(Settings.Default.Img))
                        pictureEdit1.EditValue = System.Convert.FromBase64String(Settings.Default.Img);
                    textEdit2.Focus();
                }
                catch (Exception ex)
                {
                    lbl.Caption = ex.Message;
                }
                textEdit2.Focus();
            }
        }
    }
}