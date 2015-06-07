using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio.Modelo;
using System.Data.Entity;
using PNet.AccesoDatos;

namespace PNet.Repositorio
{
    public class RepositorioCaracterizacion : Repositorio<Caracterizacion>
    {
        public RepositorioCaracterizacion(DbContext contexto)
            : base(contexto)
        {
            
        }
    }
}
