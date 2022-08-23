using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Menu : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }

    }
}
