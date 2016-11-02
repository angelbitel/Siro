using System;
namespace Siro.Model
{
    public class Talonario
    {
        public string Empresa { get; set; }
        public int IdColaborador { get; set; }
        public string Colaborador { get; set; }
        public string Sexo { get; set; }
        public Nullable<decimal> SalarioDevengado { get; set; }
        public Nullable<decimal> SeguroEducativo { get; set; }
        public Nullable<decimal> SeguroSocial { get; set; }
        public decimal Renta { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public decimal OtrasDeducciones { get; set; }
        public string Mes { get; set; }
        public decimal Extras { get; set; }
        public decimal Amonestacion { get; set; }
        public decimal CXC { get; set; }
    }
}
