using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Repositorio
{
    interface IRepositorio<T>
    {
        void Guardar(T entidad, int id);
        void Eliminar(T entidad);
        T GetPorId(int id);
        IQueryable<T> DevolverTodos();
    }
}
