using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Dominio.Interfaces;
using AulaEducativa.App.Persistencia.Datos;
using AulaEducativa.App.Persistencia.Repositorios;

namespace AulaEducativa.App.Persistencia
{
    internal class UnidadDeTrabajo : IDisposable
    {
        private AulaEducativaContext context = new AulaEducativaContext();
        private Repositorio<Actividad> repositorioActividad;
        private Repositorio<ActividadAdjunto> repositorioActividadAdjunto;
        private Repositorio<Calificacion> repositorioCalificacion;
        private Repositorio<Curso> repositorioCurso;
        private Repositorio<Estudiante> repositorioEstudiante;
        private Repositorio<GradoAcademico> repositorioGradoAcademico;
        private Repositorio<Horario> repositorioHorario;
        private Repositorio<Institucion> repositorioInstitucion;
        private Repositorio<InstitucionTipo> repositorioInstitucionTipo;
        private Repositorio<Materia> repositorioMateria;
        private Repositorio<Menu> repositorioMenu;
        private Repositorio<Profesor> repositorioProfesor;
        private Repositorio<Grupo> repositorioGrupo;
        private Repositorio<Rol> repositorioRol;
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

        public Repositorio<ActividadAdjunto> RepositorioActividadAdjunto
        {
            get
            {
                if (repositorioActividadAdjunto == null)
                {
                    repositorioActividadAdjunto = new Repositorio<ActividadAdjunto>(context);
                }

                return repositorioActividadAdjunto;
            }
        }

        public Repositorio<Calificacion> RepositorioCalificacion
        {
            get
            {
                if (repositorioCalificacion == null)
                {
                    repositorioCalificacion = new Repositorio<Calificacion>(context);
                }

                return repositorioCalificacion;
            }
        }

        public Repositorio<Curso> RepositorioCurso
        {
            get
            {
                if (repositorioCurso == null)
                {
                    repositorioCurso = new Repositorio<Curso>(context);
                }

                return repositorioCurso;
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

        public Repositorio<Horario> RepositorioHorario
        {
            get
            {
                if (repositorioHorario == null)
                {
                    repositorioHorario = new Repositorio<Horario>(context);
                }

                return repositorioHorario;
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

        public Repositorio<InstitucionTipo> RepositorioInstitucionTipo
        {
            get
            {
                if (repositorioInstitucionTipo == null)
                {
                    repositorioInstitucionTipo = new Repositorio<InstitucionTipo>(context);
                }

                return repositorioInstitucionTipo;
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

        public Repositorio<Menu> RepositorioMenu
        {
            get
            {
                if (repositorioMenu == null)
                {
                    repositorioMenu = new Repositorio<Menu>(context);
                }

                return repositorioMenu;
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

        public Repositorio<Grupo> RepositorioGrupo
        {
            get
            {
                if (repositorioGrupo == null)
                {
                    repositorioGrupo = new Repositorio<Grupo>(context);
                }

                return repositorioGrupo;
            }
        }

        public Repositorio<Rol> RepositorioRol
        {
            get
            {
                if (repositorioRol == null)
                {
                    repositorioRol = new Repositorio<Rol>(context);
                }

                return repositorioRol;
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
