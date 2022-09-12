using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Dominio.Interfaces;

using System.Linq.Expressions;

namespace AulaEducativa.App.Persistencia.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadBase, IAgregadoRaiz
    {
        public IEnumerable<TEntity> ObtenerTodos();

        public IEnumerable<TEntity> ObtenerPorCondicion(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool tracking = false);

        public TEntity ObtenerPorId(object id);

        public void Insertar(TEntity entity);

        public void Eliminar(object id);

        public void Eliminar(TEntity entidad);

        public void Actualizar(TEntity entidad);
    }
}