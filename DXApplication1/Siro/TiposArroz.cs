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
    
    public partial class TiposArroz
    {
        public TiposArroz()
        {
            this.RA = new HashSet<RA>();
        }
    
        public int IdTipoArroz { get; set; }
        public string TipoArroz { get; set; }
    
        public virtual ICollection<RA> RA { get; set; }
    }
}