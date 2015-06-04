using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Dominio
{
    public class FactorD
    {
        public FactorD()
        {
            this.Caracteristica = new HashSet<CaracteristicaD>();
            this.Caracterizacion = new HashSet<CaracterizacionD>();
        }

        public int idFactor { get; set; }
        public string nombreFactor { get; set; }

        public virtual ICollection<CaracteristicaD> Caracteristica { get; set; }
        public virtual ICollection<CaracterizacionD> Caracterizacion { get; set; }
    }
}
