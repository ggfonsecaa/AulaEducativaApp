using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Grupo : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public Rol IdRol { get; set; }
    }
}
