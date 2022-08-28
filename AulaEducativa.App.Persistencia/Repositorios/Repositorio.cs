using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Dominio.Interfaces;
using AulaEducativa.App.Persistencia.Datos;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<TEntity> ObtenerTodos() 
        { 
            return null;
        }

        public TEntity ObtenerPorId(object id)
        {
            return null;
        }

        public void Insertar(TEntity entity)
        {

        }

        public void Eliminar(object id)
        {

        }

        public void Eliminar(TEntity entidad)
        {

        }

        public void Actualizar(TEntity entidad)
        {

        }
    }
}
