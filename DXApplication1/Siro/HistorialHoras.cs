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
    
    public partial class HistorialHoras
    {
        public int IdHorario { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<System.DateTime> Mes { get; set; }
        public Nullable<System.TimeSpan> Entrada { get; set; }
        public Nullable<System.TimeSpan> Salida { get; set; }
    
        public virtual Colaboradores Colaboradores { get; set; }
    }
}
