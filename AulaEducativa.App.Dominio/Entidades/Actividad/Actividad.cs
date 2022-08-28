using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Actividad : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Calificacion { get; set; }
        public string Adjunto { get; set;}
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
