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
    
    public partial class ClasesCliente
    {
        public ClasesCliente()
        {
            this.Clientes = new HashSet<Clientes>();
        }
    
        public int IdClaseCliente { get; set; }
        public string ClaseCliente { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public string descr { get; set; }
    
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}