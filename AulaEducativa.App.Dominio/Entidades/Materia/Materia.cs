using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Materia : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public int IdGradoAcademico { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; } 
    }
}
