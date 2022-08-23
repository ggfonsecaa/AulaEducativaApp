using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Curso : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public Materia IdMateria { get; set; }
        public GradoAcademico IdGradoAcademico { get; set; } 
        public Profesor IdProfesor { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
    }
}
