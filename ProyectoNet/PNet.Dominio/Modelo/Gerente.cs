using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class Gerente
    {
        public Gerente()
        {
            this.Proyecto = new HashSet<Proyecto>();
        }

        public int idGerente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
