//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Caracterizacion
    {
        public int idCaracterizacion { get; set; }
        public short Valor { get; set; }
        public short Ponderacion { get; set; }
    
        public virtual Factor Factor { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}