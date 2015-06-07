using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio.Modelo;
using System.Data.Entity;

namespace PNet.Repositorio
{
    public class RepositorioGerente: Repositorio<Gerente>
    {
        public RepositorioGerente(DbContext contexto)
            : base(contexto)
        {

        }
    }
}
