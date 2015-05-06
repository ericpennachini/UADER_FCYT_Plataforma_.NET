using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2
{
    class Repositorio<T>: IRepositorio<T> where T:class
    {
        private DbSet<T> dbSet;

        private DbContext _contexto;

        public Repositorio(DbContext contexto)
        {
            _contexto = contexto;
            dbSet = contexto.Set<T>();
        }

        public void Guardar(T entidad)
        {
            dbSet.Add(entidad);
        }

        public void Actualizar(T entidad)
        {
            dbSet.Attach(entidad);
        }

        public T GetPorId(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> DevolverTodos()
        {
            return dbSet;
        }
    }
}
