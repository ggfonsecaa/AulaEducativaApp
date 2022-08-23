using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Rol : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

    }
}
