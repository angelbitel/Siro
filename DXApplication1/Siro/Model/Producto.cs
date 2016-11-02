using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Model
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public string Productos1 { get; set; }
        public string CodigoBarras { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> PrecioCompra { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> ITBM { get; set; }
        public Nullable<decimal> IS { get; set; }
        public Nullable<int> PuntoReorden { get; set; }
        public Nullable<int> IdPrecioProducto { get; set; }
        public Nullable<int> IdPrecio { get; set; }

    }
}
