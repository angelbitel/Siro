using System;

namespace Siro.Model
{
    public class VerAsientos
    {
        public string Comentario { get; set; }
        public int IdAsiento { get; set; }
        public decimal? Credito { get; set; }
        public string CuentaContable { get; set; }
        public decimal? Debito { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaOperacion { get; set; }
        //IdAsiento = f.IdAsiento,
        public int? IdBanco  { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCuentaContable { get; set; }
        public int? IdProveedor  { get; set; }
        public string Mayor { get; set; }
        public string Detalle { get; set; }
        public int? IdOrigen { get; internal set; }
        public int IdMaestroCuenta { get; set; }
    }
}
