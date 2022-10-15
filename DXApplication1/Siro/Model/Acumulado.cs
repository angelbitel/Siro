namespace Siro.Model
{
    public class Acumulado
    {
        public int IdAcumuladoCuentas { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int IdMaestroCuentas { get; set; }
        public decimal? Debito { get; set; }
        public decimal? Credito { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? SaldoAnterior { get; set; }
        public decimal? Total { get; set; }
        public int? IdPeriodoFiscal { get; set; }
    }
}
