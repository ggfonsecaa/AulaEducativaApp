using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class GradoAcademico : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
