using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Materia : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombre { get; set; }
        public int GradoAcademicoId { get; set; }
        public virtual GradoAcademico? GradoAcademico { get; set; }
        public virtual ICollection<Actividad>? Actividades { get; set; }
        public virtual ICollection<Estudiante>? Estudiantes { get; set; } 


        public void InscribirMateria() {

        }

        public void RemoverMateria() {

        }

        public List<Estudiante> ConsultarEstudiantes() {
            return null;
        }

        public Profesor ConsultarProfesor() {
            return null;
        }
    }
}