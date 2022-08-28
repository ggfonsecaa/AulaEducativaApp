using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class GradoAcademico : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesor> Profesores { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
    }
}