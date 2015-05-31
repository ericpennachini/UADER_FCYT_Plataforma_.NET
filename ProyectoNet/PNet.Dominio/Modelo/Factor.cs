using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class Factor
    {
        public Factor()
        {
            this.Caracteristica = new HashSet<Caracteristica>();
            this.Caracterizacion = new HashSet<Caracterizacion>();
        }

        public int idFactor { get; set; }
        public string nombreFactor { get; set; }

        public virtual ICollection<Caracteristica> Caracteristica { get; set; }
        public virtual ICollection<Caracterizacion> Caracterizacion { get; set; }
    }
}
