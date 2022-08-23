using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Calificacion : EntidadBase, IAgregadoRaiz
    {
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }

    }
}
