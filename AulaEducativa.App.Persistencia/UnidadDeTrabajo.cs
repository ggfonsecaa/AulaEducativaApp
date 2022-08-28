using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;
using AulaEducativa.App.Persistencia.Datos;
using AulaEducativa.App.Persistencia.Repositorios;

namespace AulaEducativa.App.Persistencia
{
    public class UnidadDeTrabajo : IDisposable, IUnidadDeTrabajo
    {
        private AulaEducativaContext context = new AulaEducativaContext();
        private Repositorio<Actividad> repositorioActividad;
        private Repositorio<Estudiante> repositorioEstudiante;
        private Repositorio<GradoAcademico> repositorioGradoAcademico;
        private Repositorio<Institucion> repositorioInstitucion;
        private Repositorio<Materia> repositorioMateria;
        private Repositorio<Profesor> repositorioProfesor;
        private Repositorio<Usuario> repositorioUsuario;

        public Repositorio<Actividad> RepositorioActividad
        {
            get
            {
                if (repositorioActividad == null)
                {
                    repositorioActividad = new Repositorio<Actividad>(context);
                }

                return repositorioActividad;
            }
        }

        public Repositorio<Estudiante> RepositorioEstudiante
        {
            get
            {
                if (repositorioEstudiante == null)
                {
                    repositorioEstudiante = new Repositorio<Estudiante>(context);
                }

                return repositorioEstudiante;
            }
        }

        public Repositorio<GradoAcademico> RepositorioGradoAcademico
        {
            get
            {
                if (repositorioGradoAcademico == null)
                {
                    repositorioGradoAcademico = new Repositorio<GradoAcademico>(context);
                }

                return repositorioGradoAcademico;
            }
        }

        public Repositorio<Institucion> RepositorioInstitucion
        {
            get
            {
                if (repositorioInstitucion == null)
                {
                    repositorioInstitucion = new Repositorio<Institucion>(context);
                }

                return repositorioInstitucion;
            }
        }

        public Repositorio<Materia> RepositorioMateria
        {
            get
            {
                if (repositorioMateria == null)
                {
                    repositorioMateria = new Repositorio<Materia>(context);
                }

                return repositorioMateria;
            }
        }

        public Repositorio<Profesor> RepositorioProfesor
        {
            get
            {
                if (repositorioProfesor == null)
                {
                    repositorioProfesor = new Repositorio<Profesor>(context);
                }

                return repositorioProfesor;
            }
        }

        public Repositorio<Usuario> RepositorioUsuario
        {
            get
            {
                if (repositorioUsuario == null)
                {
                    repositorioUsuario = new Repositorio<Usuario>(context);
                }

                return repositorioUsuario;
            }
        }

        public void Guardar()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}