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
        void Habilitar();
        void Deshabilitar();
        T Obtener(int id);
        IList<T> Listar();
        void Modificar(T entidad);
        void Eliminar(T entidad);
    }
}
