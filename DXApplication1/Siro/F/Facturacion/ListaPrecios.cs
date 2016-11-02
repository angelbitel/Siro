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
using DevExpress.XtraEditors.Controls;

namespace Siro.F.Facturacion
{
    public partial class ListaPrecios : DevExpress.XtraEditors.XtraForm
    {
        private int IdProducto { get; set; }
        public ListaPrecios(int idProducto)
        {
            IdProducto = idProducto;
            InitializeComponent();
        }

        private void ListaPrecios_Load(object sender, EventArgs e)
        {
            var produ = new Controller.Producto();
            
            produ.ListaPrecios().ForEach(f =>
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = f.IdPrecio,
                    Description = f.Precio
                };
                repositoryItemImageComboBox1.Items.Add(item);
                repositoryItemImageComboBox1.Items.Add(item);
            });
            var lstP = new List<PrecioProducto>();
            lstP.Add(new PrecioProducto { IdPrecio = 1 });
            lstP.Add(new PrecioProducto { IdPrecio = 2 });
            lstP.Add(new PrecioProducto { IdPrecio = 3 });

            produ.ListaPreciosProductos(IdProducto).ForEach(f=>{
                lstP.ForEach(g =>
                {
                    if (g.IdPrecio == f.IdPrecio)
                    {
                        g.IdPrecioProducto = f.IdPrecioProducto;
                        g.IdProducto = f.IdProducto;
                        g.IdServicio = f.IdServicio;
                        g.Precio = f.Precio;
                    }
                });
            });
            precioProductoBindingSource.DataSource = lstP;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var row = precioProductoBindingSource.Current as PrecioProducto;
            if (row.IdProducto == 0 || row.IdProducto == null)
                row.IdProducto = IdProducto;

            var produ = new Controller.Producto();
            produ.Guardar(row);
            lblMsg.Caption = produ.MSG;
        }
    }
}