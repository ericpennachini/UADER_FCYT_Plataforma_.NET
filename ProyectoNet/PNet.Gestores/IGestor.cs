using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNet.Gestores
{
    public interface IGestor<T> where T: class
    {
        void Guardar(T entidad);
        T Obtener(int id);
        IList<T> Listar();
    }
}
