using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Institucion : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
