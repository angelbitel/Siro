using System;

namespace Siro.Model
{
    public class RegistroArroz
    {
        public int IdEntradaArroz { get; set; }
        public Nullable<int> IdRecibido { get; set; }
        public string EntradaDeArroz { get; set; }
        public Nullable<decimal> PesoBruto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Neto { get; set; }
        public string Matricula { get; set; }
        public Nullable<decimal> PorcentajeHumedad { get; set; }
        public Nullable<decimal> PorcentajeImpurezas { get; set; }
        public Nullable<int> IdConductor { get; set; }
        public string Conductor { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdTipoFlete { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public Nullable<int> IdProductor { get; set; }
        public int IdTipoArroz { get; set; }
        public string TipoArroz { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> IdAlmacen { get; set; }
        public string Almacen { get; set; }
        public Nullable<System.DateTime> FehaProceso { get; set; }
        public string NumeroBoleta { get; set; }
        public string Recibido { get; set; }
        public Nullable<decimal> Apach { get; set; }
        public Nullable<decimal> PorcentajeEntero { get; set; }
        public Nullable<decimal> PorcentajeQuebrado { get; set; }
        public Nullable<decimal> Rendimiento { get; set; }
        public Nullable<decimal> PorcentajeAjusteSeco { get; set; }
        public Nullable<decimal> Seco { get; set; }
        public RegistroArroz()
        {
            this.Rendimiento = PorcentajeEntero + PorcentajeQuebrado;
        }
    }
}
