using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Design;
using PNet.Dominio.Modelo;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace PNet.Repositorio
{
    public class Repositorio<T>:IRepositorio<T> where T: class
    {
        protected DbSet<T> dbSet;
        protected DbContext _contexto;

        public Repositorio(DbContext contexto)
        {
            try
            {
                _contexto = contexto;
                dbSet = contexto.Set<T>();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public void Guardar(T entidad, int id)
        {
            if (id == 0)
            {
                dbSet.Add(entidad);
            }
            _contexto.SaveChanges();
        }

        public T GetPorId(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> DevolverTodos()
        {
            return dbSet;
        }

        public virtual void Eliminar(T entidad)
        {   
            //ahora permite sobreescritura (virtual)
            dbSet.Remove(entidad);
            _contexto.SaveChanges();
        }
    }
}
