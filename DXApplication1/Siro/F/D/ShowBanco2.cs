using System;

namespace Siro.F.D
{
    public partial class ShowBanco2 : DevExpress.XtraEditors.XtraForm
    {
        public ShowBanco2()
        {
            InitializeComponent();
        }

        public int IdBanco { get; set; }
        public string Banco { get; set; }
        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdBanco = int.Parse(gluProveedor.EditValue.ToString());
            Banco = gluProveedor.Text;
        }
        bool fromLoad { get; set; }
        private void gluProveedor_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (!fromLoad)
                    this.Close();
            }
            else
                fromLoad = false;
        }

        private void ShowBanco2_Load(object sender, EventArgs e)
        {
            var contenedorBanco = new Controller.CuentasXPagar().LstBancos();
            bancosBindingSource.DataSource = contenedorBanco;
            this.gluProveedor.Focus();
            fromLoad = true;
        }
    }
}