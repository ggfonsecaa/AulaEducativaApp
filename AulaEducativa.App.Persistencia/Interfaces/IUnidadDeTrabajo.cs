using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Repositorios;

namespace AulaEducativa.App.Persistencia.Interfaces
{
    public interface IUnidadDeTrabajo
    {
        public Repositorio<Actividad> RepositorioActividad { get; }

        public Repositorio<Estudiante> RepositorioEstudiante { get; }

        public Repositorio<GradoAcademico> RepositorioGradoAcademico { get; }

        public Repositorio<Institucion> RepositorioInstitucion { get; }

        public Repositorio<Materia> RepositorioMateria { get; }

        public Repositorio<Profesor> RepositorioProfesor { get; }

        public Repositorio<Usuario> RepositorioUsuario { get; }

        public void Guardar();
        public Task<int> GuardarAsincrono();
    }
}