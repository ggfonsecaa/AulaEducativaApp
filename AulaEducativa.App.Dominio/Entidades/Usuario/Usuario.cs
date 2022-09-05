using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Usuario : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public int InstitucionId { get; set; } 
        public virtual Institucion? Institucion { get; set; }

        public bool IniciarSesion(){
            return false;
        }

        public bool RegistrarUsuario() {
            return false;
        }

        public void CerrarSesion() {
            
        }
    }
}