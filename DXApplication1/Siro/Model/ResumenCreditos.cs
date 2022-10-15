using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Siro.Model
{
    public class ResumenCreditos : INotifyPropertyChanged
    {
        public DateTime? Fecha { get; set; }
        public Nullable<int> IdFactura { get; set; }
        public Nullable<int> IdEntrada { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string Cliente { get; set; }
        public Nullable<decimal> Corriente { get; set; }
        public Nullable<decimal> Morosidad30 { get; set; }
        public Nullable<decimal> Morosidad60 { get; set; }
        public Nullable<decimal> Morosidad90 { get; set; }
        public Nullable<decimal> Morosidad120 { get; set; }
        public Nullable<decimal> MorosidadMas120 { get; set; }
        public Nullable<int> DiasMorosidad { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public bool EstaMoroso
        {
            get
            {
                if (MontoMoroso > 0)
                    return true;
                else
                    return false;
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (new string[] { "Morosidad60", "Morosidad90", "Morosidad120", "MorosidadMas120" }.Contains(propertyName))
            {
                //MontoMoroso = Morosidad60 + Morosidad90 + Morosidad120 + MorosidadMas120;
                //TotalMoroso = Corriente + Morosidad60 + Morosidad90 + Morosidad120 + MorosidadMas120;
            }
        }
        public Nullable<decimal> MontoMoroso { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal? SaldoAnterior { get; set; }
        public Nullable<decimal> TotalMoroso { get; set; }
        decimal deuda = 0;
        decimal pago = 0;
        public decimal Deuda
        {
            get
            {
                if (new int[] { 1, 4 }.Contains(IdTipoMovimiento) && Monto > 0)
                    deuda = Monto;
                else
                    deuda = 0;
                return deuda;
            }
            set
            {
                Monto = value;
            }
        }
        public decimal Pago
        {
            get
            {
                if (new int[] { 2, 3 }.Contains(IdTipoMovimiento) || Monto < 0)
                    pago = Monto;
                else
                    pago = 0;
                return pago;
            }
            set
            {
                Monto = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int IdCredito { get; set; }
        public string Factura { get; set; }
        public Nullable<int> IdProveedor { get { return IdCliente; } }
        public bool? Deshabilitar { get; internal set; }
        public string Comentario { get; internal set; }
        public string Referencia { get; internal set; }
        public string Cuenta { get; internal set; }
        public bool? Procesado { get; internal set; }
        public Nullable<bool> Pagar { get; set; }
        public decimal? BalanceMes { get; internal set; }
        public string Beneficiario { get; internal set; }
    }
}
