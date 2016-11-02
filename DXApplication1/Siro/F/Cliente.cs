using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Siro.F
{
    public partial class Cliente : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();
        Model.Cliente cl = new Model.Cliente();
        public Cliente()
        {
            InitializeComponent();
            this.clientesBindingSource.AddingNew +=
           new AddingNewEventHandler(ClientesBindingSource_AddingNew);
        }
        void ClientesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //e.NewObject = new Clientes();
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
            //dbContext.Clientes.Load();
            clientesBindingSource.DataSource = dbContext.Clientes.ToList();
            LlenarCombos();
        }
        private void LlenarCombos()
        {
            foreach (TiposCliente current in (IEnumerable<TiposCliente>)this.dbContext.TiposCliente)
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = current.IdTipoCliente,
                    Description = current.TipoCliente
                };
                this.cTipoCliente.Properties.Items.Add(item);
            }
            foreach (ClasesCliente current2 in (IEnumerable<ClasesCliente>)this.dbContext.ClasesCliente)
            {
                this.cClaseCliente.Properties.Items.Add(new ImageComboBoxItem
                {
                    Value = current2.IdClaseCliente,
                    Description = current2.ClaseCliente
                });
            }
            foreach (Clientes current3 in (IEnumerable<Clientes>)this.dbContext.Clientes)
            {
                this.cRepresentanteLegal.Properties.Items.Add(new ImageComboBoxItem
                {
                    Value = current3.idCliente,
                    Description = current3.NombreCompleto
                });
            }
            new Controller.Producto().ListaPrecios().ForEach(f=> {
             ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = f.IdPrecio,
                    Description = f.Precio
                };
             cmbListaPrecios.Properties.Items.Add(item);
            });
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = clientesBindingSource.Current as Clientes;
            if (row.idCliente == 0)
                dbContext.Clientes.Add(row);
            dbContext.SaveChanges();
            lblMsg.Caption = "Los Datos Fueron Guardados Correctamente";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainerControl1.PanelVisibility= DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clientesBindingSource.AddNew();
        }
    }
}