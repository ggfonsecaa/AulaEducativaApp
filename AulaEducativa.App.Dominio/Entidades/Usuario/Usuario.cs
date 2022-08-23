using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Usuario : EntidadBase, IAgregadoRaiz
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public Grupo IdGrupo { get; set; }
        public Institucion IdInstitucion { get; set; }
    }
}
