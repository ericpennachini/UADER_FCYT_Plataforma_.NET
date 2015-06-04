using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio;
using System.Data.Entity;

namespace PNet.Repositorio
{
    public class RepositorioProyecto: Repositorio<ProyectoD>
    {
        public RepositorioProyecto(DbContext contexto) 
            : base(contexto)
        {

        }

        public ProyectoD GetUltimoProyecto()
        {
            var _proyecto = from p in _contexto.Set<ProyectoD>() orderby p.idProyecto select p;
            return _proyecto.Last<ProyectoD>();
        }
    }
}
