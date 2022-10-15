using System;

namespace Siro.Model
{
    public class Resumen
    {
        public DateTime? PrimeraTransaccion { get; set; }
        public DateTime? UltimaTransaccion { get; set; }
        public int CantidadAsientos { get; set; }
        public decimal? Debitos { get; set; }
        public decimal? Creditos { get; set; }
        public decimal? Balance { get; set; }
    }
}
