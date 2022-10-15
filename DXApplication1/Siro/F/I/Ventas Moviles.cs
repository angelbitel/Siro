using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Siro.Controller;
using Siro.Properties;

namespace Siro.F.I
{
    public partial class VentasMovilesAgre : DevExpress.XtraEditors.XtraForm
    {
        Siro.slSiroCon dbContext = new Siro.slSiroCon();
        public BindingList<DetalleVentasMovil> detalle = new BindingList<DetalleVentasMovil>();
        public VentasMovilesAgre()
        {
            InitializeComponent();
            var l = new Lst();
            vendedoresBindingSource.DataSource = l.Vendedores;
            clientesBindingSource.DataSource = l.Clientes;
            productosBindingSource.DataSource = l.LstProducto(Principal.Bariables.IdEmpresa.Id);
            almacenajeBindingSource.DataSource = l.AlmacenesProduccion;
            gridControl1.DataSource = detalle;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            lblMsg.Caption = "Nuevo renglon..";
        }

        private void VentasMovilesAgre_Load(object sender, EventArgs e)
        {
            sluSilo.EditValue = 1;
            dtFecha.DateTime = Principal.Bariables.PeridoContable;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int idAlmacen = 0, idVendedor=0, idCliente;
            int.TryParse(sluSilo.EditValue.ToString(), out idAlmacen);
            int.TryParse(sluCliente.EditValue.ToString(), out idCliente);
            int.TryParse(sluVendor.EditValue.ToString(), out idVendedor);
            if (idAlmacen == 0)
            {
                lblMsg.Caption = "Seleccione Un SILO";
                return;
            } 
            if (idCliente == 0)
            {
                lblMsg.Caption = "Seleccione Un CLIENTE";
                return;
            } 
            if (idVendedor == 0)
            {
                lblMsg.Caption = "Seleccione Un VENDEDOR";
                return;
            }

            var fHeader = new VentasMoviles
            {
                Cantidad = detalle.Sum(s => s.Cantidad),
                FechaProceso = DateTime.Now,
                FechaVenta = dtFecha.DateTime,
                IdAlmacen = idAlmacen,
                IdCliente = idCliente,
                IdUsuario = Principal.Bariables.IdUsuario,
                IdVendedor = idVendedor,
                DetalleVentasMovil = detalle.ToList(),
                NumeroRecibo = txtRecibo.Text,
                Total = detalle.Sum(s => s.Monto)
            };
            dbContext.VentasMoviles.Add(fHeader);
            try
            {
                dbContext.SaveChanges();
                lblMsg.Caption = string.Format("Muy bien {0}, agregaste una nueva factura!!!", Settings.Default.UltimoUsuario);
            }
            catch (Exception ex)
            {
                lblMsg.Caption = ex.Message;
            }
        }
    }
}