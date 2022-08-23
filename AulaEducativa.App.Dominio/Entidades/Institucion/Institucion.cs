using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Institucion : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public InstitucionTipo IdInstitucionTipo { get; set; }
    }
}
