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
    
    public partial class Cobradores
    {
        public Cobradores()
        {
            this.AgendaCobros = new HashSet<AgendaCobros>();
        }
    
        public int IdCobrador { get; set; }
        public string Cobrador { get; set; }
        public Nullable<int> IdTipoCobrador { get; set; }
    
        public virtual ICollection<AgendaCobros> AgendaCobros { get; set; }
    }
}
