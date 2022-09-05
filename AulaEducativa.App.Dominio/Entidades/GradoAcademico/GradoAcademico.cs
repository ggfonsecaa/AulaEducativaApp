using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class GradoAcademico : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombre { get; set; }
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }
        public virtual ICollection<Profesor>? Profesores { get; set; }
        public virtual ICollection<Materia>? Materias { get; set; }
    }
}