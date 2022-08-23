using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Horario : EntidadBase, IAgregadoRaiz
    {
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
    }
}
