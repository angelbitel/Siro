namespace Siro.Model
{
    public class FPago
    {
        public decimal Monto { get; set; }
        public int IdFormaPago { get; set; }
        public int IdCertificadoEmitido { get; set; }
        public string FormaPago { get; set; }
        public int SecuenciaTransaccion { get; set; }
        public decimal Restante { get; set; }
    }
}
