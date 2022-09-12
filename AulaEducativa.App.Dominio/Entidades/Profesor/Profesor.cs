using AulaEducativa.App.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Profesor: EntidadBase, IAgregadoRaiz, IPersona
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Apellidos { get; set; }

        [MaxLength(100, ErrorMessage = "El valor no debe ser mayor a 100")]
        public int? Edad { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(50, ErrorMessage = "El campo no debe tener más de 50 caracteres")]
        public string? Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(10, ErrorMessage = "El campo no debe tener más de 10 caracteres")]
        public string? Telefono { get; set; }
        public int UsuarioId { get; set; }
        public int GradoAcademicoId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual GradoAcademico? GradoAcademico { get; set; }

        public IPersona ActualizarInformacion(IPersona estudiante) {
            return null;
        }

        public IPersona ConsultarInformacion(IPersona estudiante) {
            return null;
        }

        public void AsignarGrado(GradoAcademico gradoAcademico) {

        }
    }
}