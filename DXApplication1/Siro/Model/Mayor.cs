using System;

namespace Siro.Model
{
    public class Mayor
    {
        public int IdAsiento { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Comentario { get; set; }
        public int IdDetalleAsiento { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public int IdCuentaContable { get; set; }
        public string Cuenta { get; set; }
    }
}
