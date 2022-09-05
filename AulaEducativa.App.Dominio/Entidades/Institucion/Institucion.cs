using AulaEducativa.App.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Institucion : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombre { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }


        public string GenerarCodigo() {
            return null;
        }

        public bool ValidarCodigoUsuario(string codigo) {
            return true;
        }
    }
}