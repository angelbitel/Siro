//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Siro
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngresosDeduccionesHoras
    {
        public int IdIngresoDeducionHora { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaProceso { get; set; }
        public Nullable<int> Quincena { get; set; }
        public Nullable<int> IdFactor { get; set; }
    
        public virtual Colaboradores Colaboradores { get; set; }
        public virtual Factores Factores { get; set; }
    }
}