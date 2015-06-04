using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class GerenteD
    {
        public GerenteD()
        {
            this.Proyecto = new HashSet<ProyectoD>();
        }

        public int idGerente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public virtual ICollection<ProyectoD> Proyecto { get; set; }
    }
}
