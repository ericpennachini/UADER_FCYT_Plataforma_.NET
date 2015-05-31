using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class Caracteristica
    {
        public int idCaracteristica { get; set; }
        public string denominacion { get; set; }
        public Nullable<int> valor { get; set; }

        public virtual Factor Factor { get; set; }
    }
}
