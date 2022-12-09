using System;

namespace Siro.Model
{
    public class AsientoContable
    {
        public int IdAsiento { get; set; }
        public int IdDetalleAsiento { get; set; }
        public int? IdOrigen { get; set; }
        public Nullable<int> IdCuentaContable { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public string CuentasCombinadas { get; set; }
        public string CuentaContable { get; set; }
        public string Comentario { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string FechaCorta => Fecha.Value.ToString("yyyy MMM");
        public Nullable<int> Dia => Fecha.Value.Day;
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Mayor { get; set; }
        public string Detlle { get; set; }
        public bool Desbalanceado { get; set; }
        public DateTime? FechaOperacion { get; set; }
    }
}
