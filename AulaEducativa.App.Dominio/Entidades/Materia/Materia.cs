using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Materia : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
