using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Institucion : EntidadBase, IAgregadoRaiz
    {
        public string Nombre { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }


        public string GenerarCodigo() {
            return null;
        }

        public bool ValidarCodigoUsuario(string codigo) {
            return true;
        }
    }
}