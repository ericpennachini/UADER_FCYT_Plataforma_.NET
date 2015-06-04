using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class ProyectoD
    {
        public ProyectoD()
        {
            this.Caracterizacion = new HashSet<CaracterizacionD>();
        }

        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

        public virtual GerenteD Gerente { get; set; }
        public virtual ICollection<CaracterizacionD> Caracterizacion { get; set; }
    }
}
