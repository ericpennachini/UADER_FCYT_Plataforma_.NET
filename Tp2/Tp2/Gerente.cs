//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gerente
    {
        public Gerente()
        {
            this.Proyecto = new HashSet<Proyecto>();
        }
    
        public int idGerente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    
        public virtual ICollection<Proyecto> Proyecto { get; set; }

        public override string ToString()
        {
            return nombre + " " + apellido;
        }
    }
}
