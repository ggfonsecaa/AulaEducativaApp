using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class InstitucionTipo : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public ICollection<Institucion> Instituciones { get; set; }
    }
}
