using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class ActividadAdjunto : EntidadBase, IAgregadoRaiz
    {
        public Actividad Actividad { get; set; }
        public string Adjunto { get; set; }

    }
}
