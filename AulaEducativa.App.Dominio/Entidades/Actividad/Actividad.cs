using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Actividad : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Estudiante IdEstudiante { get; set; }
        public Curso IdCurso { get; set; }
        public ICollection<ActividadAdjunto> ActividadAdjuntos { get; set; }
        public Calificacion IdCalificacion { get; set; }

    }
}
