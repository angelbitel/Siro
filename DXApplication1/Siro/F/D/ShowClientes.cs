using Siro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Siro.F.D
{
    public partial class ShowClientes : DevExpress.XtraEditors.XtraForm
    {
        public ShowClientes()
        {
            InitializeComponent();
        }

        private void ShowClientes_Load(object sender, EventArgs e)
        {
            CargarDatosClientes();
            clientesBindingSource.DataSource = lstClientes;
            this.gluProveedor.Focus();
            fromLoad = true;
        }
        List<ClienteMini> lstClientes = new List<ClienteMini>();
        private void CargarDatosClientes()
        {
            lstClientes.Clear();
            new Controller.Cliente().lstClientes.ToList().ForEach(f =>
            {
                lstClientes.Add(new ClienteMini
                {
                    CedulaRuc = f.CedulaRuc,
                    idCliente = f.idCliente,
                    NombreCompleto = f.NombreCompleto,
                    IdPrecio = f.IdPrecio
                });
            });
        }

        public int IdCliente { get; set; }
        public string Cliente { get; set; }

        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdCliente = int.Parse(gluProveedor.EditValue.ToString());
            Cliente = gluProveedor.Text;
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
    }
}