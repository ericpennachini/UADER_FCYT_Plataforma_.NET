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

        /// <summary>
        ///     Sobreescritura del metodo Equals() de Object, para 
        ///     definir cu�ndo son iguales dos gerentes.
        /// </summary>
        /// <param name="obj">se castea a un Gerente</param>
        /// <returns>true si son dos gerentes iguales, nombre y apellido</returns>
        public override bool Equals(object obj)
        {
            Gerente ger = (Gerente)obj;
            return (this.nombre == ger.nombre)&&(this.apellido == ger.apellido);
        }

        public override string ToString()
        {
            return nombre + " " + apellido;
        }
    }
}
