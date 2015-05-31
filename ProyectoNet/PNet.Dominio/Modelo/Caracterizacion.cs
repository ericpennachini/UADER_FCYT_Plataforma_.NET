using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class Caracterizacion
    {
        public int idCaracterizacion { get; set; }
        public short Valor { get; set; }
        public short Ponderacion { get; set; }

        public virtual Factor Factor { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
