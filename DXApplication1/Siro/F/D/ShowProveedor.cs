using System;

namespace Siro.F.D
{
    public partial class ShowProveedor : DevExpress.XtraEditors.XtraForm
    {
        public ShowProveedor()
        {
            InitializeComponent();
        }
        bool fromLoad { get; set; }
        private void ShowProveedor_Load(object sender, EventArgs e)
        {
            var contenedor = new Controller.CuentasXPagar().Proveedores();
            provedoresBindingSource.DataSource = contenedor;
            this.gluProveedor.Focus();
            fromLoad = true;
        }

        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdProveedor = int.Parse(gluProveedor.EditValue.ToString());
            Proveedor = gluProveedor.Text;
        }
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }

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
    }
}