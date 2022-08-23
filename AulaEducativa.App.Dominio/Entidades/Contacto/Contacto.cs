using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Contacto
    {
        public IPersona Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool ContactoPrincipal { get; set; }

        public Contacto(IPersona id, string direccion, string telefono, bool contactoPrincipal)
        {
            Id = id;
            Direccion = direccion;
            Telefono = telefono;
            ContactoPrincipal = contactoPrincipal;
        }
    }
}
