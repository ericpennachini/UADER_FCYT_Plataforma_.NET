using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2
{
    interface IRepositorio<T>
    {
        void Guardar(T entidad);
        void Actualizar(T entidad);
        T GetPorId(int id);
        T GetUltimo();
        IQueryable<T> DevolverTodos();
    }
}
