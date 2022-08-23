using AulaEducativa.App.Dominio.Entidades;

namespace AulaEducativa.App.Dominio.Interfaces
{
    public interface IPersona
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public ICollection<Contacto> Contactos { get; set; }
        public Usuario IdUsuario { get; set; }
        public int Edad { get; set; }
    }
}
