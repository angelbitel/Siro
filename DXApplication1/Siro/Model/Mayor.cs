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
        public string PagadoA { get; set; }
        public string NumeroCheque { get; set; }
        public string Importante { get; set; }
    }
    public class ObtenerMayor
    {
        public int IdAsiento { get; set; }
        public DateTime? Fecha { get; set; }
        public Decimal? Debito { get; set; }
        public Decimal? Credito { get; set; }
        public Decimal? Total { get; set; }
        public Decimal? Balance { get; set; }
        public Decimal? BalanceMes { get; set; }
        public string Comentario { get; set; }
        public string NumeroCheque { get; set; }
        public string PagadoA { get; set; }
        public string Importante { get; set; }
    }
}
