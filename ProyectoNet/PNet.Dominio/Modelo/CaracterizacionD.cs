using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class CaracterizacionD
    {
        public int idCaracterizacion { get; set; }
        public short Valor { get; set; }
        public short Ponderacion { get; set; }

        public virtual FactorD Factor { get; set; }
        public virtual ProyectoD Proyecto { get; set; }
    }
}
