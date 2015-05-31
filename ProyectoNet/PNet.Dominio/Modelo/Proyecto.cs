using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class Proyecto
    {
        public Proyecto()
        {
            this.Caracterizacion = new HashSet<Caracterizacion>();
        }

        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

        public virtual Gerente Gerente { get; set; }
        public virtual ICollection<Caracterizacion> Caracterizacion { get; set; }
    }
}
