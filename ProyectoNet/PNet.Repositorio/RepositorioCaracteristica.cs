using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio;
using System.Data.Entity;

namespace PNet.Repositorio
{
    public class RepositorioCaracteristica : Repositorio<CaracteristicaD>
    {
        public RepositorioCaracteristica(DbContext contexto)
            : base(contexto)
        {

        }
    }
}
