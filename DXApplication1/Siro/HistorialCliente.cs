//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Siro
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistorialCliente
    {
        public int IdHistorial { get; set; }
        public Nullable<int> IdResultadoGestion { get; set; }
        public Nullable<int> IdCliente { get; set; }
    
        public virtual ResultadosGestion ResultadosGestion { get; set; }
    }
}