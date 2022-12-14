using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Materia : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una opción válida")]
        public int GradoAcademicoId { get; set; }

        [Display(Name = "Grado académico")]
        public virtual GradoAcademico? GradoAcademico { get; set; }
        public virtual ICollection<Actividad>? Actividades { get; set; }
        public virtual ICollection<Estudiante>? Estudiantes { get; set; } 

    }
}