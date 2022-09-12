using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Dominio.Interfaces;
using AulaEducativa.App.Persistencia.Datos;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections;
using System.Linq.Expressions;

namespace AulaEducativa.App.Persistencia.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadBase, IAgregadoRaiz
    {
        private AulaEducativaContext context;
        private DbSet<TEntity> dbSet;

        public Repositorio(AulaEducativaContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> ObtenerTodos() 
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual IEnumerable<TEntity> ObtenerPorCondicion(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool tracking = false)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (tracking)
            {
                query = query.AsTracking();
            }
            else {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity ObtenerPorId(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insertar(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Eliminar(object id)
        {
            TEntity entidad = dbSet.Find(id);
            Eliminar(entidad);
        }

        public virtual void Eliminar(TEntity entidad)
        {
            if (context.Entry(entidad).State == EntityState.Detached)
            {
                dbSet.Attach(entidad);
            }
            dbSet.Remove(entidad);
        }

        public virtual void Actualizar(TEntity entidad)
        {
            dbSet.Attach(entidad);
            context.Entry(entidad).State = EntityState.Modified;
        }
    }
}