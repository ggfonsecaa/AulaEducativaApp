using AulaEducativa.App.Dominio.Entidades;

namespace AulaEducativa.App.Dominio.Interfaces
{
    public interface IPersona
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdUsuario { get; set; }

        public IPersona ActualizarInformacion(IPersona persona);
        public IPersona ConsultarInformacion(IPersona persona);
        public void AsignarGrado(GradoAcademico gradoAcademico);
    }
}
