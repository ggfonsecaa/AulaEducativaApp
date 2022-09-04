using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Persistencia.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadBase, IAgregadoRaiz
    {
        public IEnumerable<TEntity> ObtenerTodos();

        public TEntity ObtenerPorId(object id);

        public void Insertar(TEntity entity);

        public void Eliminar(object id);

        public void Eliminar(TEntity entidad);

        public void Actualizar(TEntity entidad);
    }
}