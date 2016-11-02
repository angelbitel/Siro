using System;

namespace Siro.Model
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string Servicios1 { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> ITBMS { get; set; }
        public Nullable<decimal> IS { get; set; }
    }
}
