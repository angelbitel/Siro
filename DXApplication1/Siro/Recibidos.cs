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
    
    public partial class Recibidos
    {
        public Recibidos()
        {
            this.RA = new HashSet<RA>();
        }
    
        public int IdRecibido { get; set; }
        public string Recibido { get; set; }
    
        public virtual ICollection<RA> RA { get; set; }
    }
}
