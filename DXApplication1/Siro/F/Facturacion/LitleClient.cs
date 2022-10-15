using DevExpress.XtraEditors.Controls;
using Siro.Model;
using System;
using System.Linq;

namespace Siro.F.Facturacion
{
    public partial class LitleClient : DevExpress.XtraEditors.XtraForm
    {
        public LitleClient()
        {
            InitializeComponent();
            clientesBindingSource.AddNew();
        }
        public bool Nuevo { get; set; }
        public ClienteMini NuevoCliente { get; set; }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cli = clientesBindingSource.Current as Siro.Clientes;
            if(string.IsNullOrEmpty(cli.CedulaRuc.Trim()))
            {
                lblMsg.Caption = "Introduzca La Identificacion";
                return;
            }
            if (string.IsNullOrEmpty(cli.NombreCompleto.Trim()))
            {
                lblMsg.Caption = "Introduzca El Nombre Del Cliente";
                return;
            }
            var db = new slEntities();
            db.Clientes.Add(cli);
            db.SaveChanges();
            Nuevo = true;
            NuevoCliente = new ClienteMini { CedulaRuc = cli.CedulaRuc, idCliente = cli.idCliente, NombreCompleto = cli.NombreCompleto };
            this.Close();
        }

        private void LitleClient_Load(object sender, EventArgs e)
        {
            new slEntities().TiposCliente.ToList().ForEach(f =>
            {
                ImageComboBoxItem itm = new ImageComboBoxItem
                {
                    Value = f.IdTipoCliente,
                    Description = f.TipoCliente
                };
                IdTipoClienteCmb.Properties.Items.Add(itm);
            });
        }
    }
}