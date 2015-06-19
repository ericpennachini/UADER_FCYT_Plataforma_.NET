using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio.Modelo;
using System.Data.Entity;

namespace PNet.Repositorio
{
    public class RepositorioProyecto: Repositorio<Proyecto>
    {
        public RepositorioProyecto(DbContext contexto) 
            : base(contexto)
        { }

        public Proyecto GetUltimoProyecto()
        {
            try
            {
                var _proyecto = from p in _contexto.Set<Proyecto>() orderby p.idProyecto select p;
                return _proyecto.ToArray<Proyecto>().Last<Proyecto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public override void Eliminar(Proyecto entidad)
        //{
        // No hace falta esto, el repositorio se encarga de hacerlo
        //}
    }
}
