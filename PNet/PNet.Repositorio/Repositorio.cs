using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Design;
using PNet.Dominio.Modelo;

namespace PNet.Repositorio
{
    public class Repositorio<T>:IRepositorio<T> where T: class
    {
        protected DbSet<T> dbSet;
        protected DbContext _contexto;

        public Repositorio(DbContext contexto)
        {
            _contexto = contexto;
            dbSet = contexto.Set<T>();
        }

        public void Guardar(T entidad, int id)
        {
            if (id == 0)
            {
                dbSet.Add(entidad);
            }
            _contexto.SaveChanges();
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

        public T GetUltimo()
        {
            return dbSet.Last();
        }
    }
}
