using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Estudiante : EntidadBase, IAgregadoRaiz, IPersona
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public ICollection<Contacto> Contactos { get; set; }
        public Usuario IdUsuario { get; set; }
        public int Edad { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
    }
}
