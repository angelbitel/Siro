using System;

namespace Siro.Model
{
    public class Planilla
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUser { get; set; }
        public System.DateTime FechaProceso { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Quincena { get; set; }
        public Nullable<decimal> RataPorHora { get; set; }
        public Nullable<decimal> SalarioQuincenal { get; set; }
        public Nullable<decimal> TotalHoras { get; set; }
        public Nullable<decimal> SalarioBruto { get; set; }
        public Nullable<decimal> OtrasDeducciones { get; set; }
        public Nullable<decimal> CXCRecurrentes { get; set; }
        public Nullable<decimal> CXC { get; set; }
        public Nullable<decimal> SeguroSocial { get; set; }
        public Nullable<decimal> SeguroEducativo { get; set; }
        public Nullable<decimal> ISR { get; set; }
        public Nullable<decimal> SeguroSocialPatronal { get; set; }
        public Nullable<decimal> SeguroEducativoPatronal { get; set; }
        public Nullable<decimal> Decimo { get; set; }
        public Nullable<decimal> Vacacciones { get; set; }
        public Nullable<decimal> SalarioNeto { get; set; }
        public Nullable<decimal> indemnizacion { get; set; }
        public Nullable<decimal> Antiguedad { get; set; }
        public Nullable<decimal> Recerva { get; set; }
        public Nullable<decimal> Riesgo { get; set; }
        public Nullable<int> PeriodDecimo { get; set; }
        public Nullable<decimal> SeguroSocialDecimo { get; set; }
        public Nullable<decimal> SeguroSocialDecimoPatrono { get; set; }
        public Nullable<decimal> Bonificaciones { get; set; }
        public Nullable<decimal> SalarioNetoBonificaciones {
            get 
            {
                return SalarioNeto + Bonificaciones??0m;
            }
        }
        public string TipoContrato { get; set; }
        public string Estado { get; set; }
    }
}
