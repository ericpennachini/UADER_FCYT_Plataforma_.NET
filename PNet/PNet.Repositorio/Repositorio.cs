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
            catch (Exception) 
            {
                throw;
            }
        }

        public void Guardar(T entidad, int id)
        {
            try
            {
                if (id == 0)
                {
                    dbSet.Add(entidad);
                }
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetPorId(int id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> DevolverTodos()
        {
            try
            {
                return dbSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Eliminar(T entidad)
        {   
            //ahora permite sobreescritura (virtual)
            try
            {
                dbSet.Remove(entidad);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
