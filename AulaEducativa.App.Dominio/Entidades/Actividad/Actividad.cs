using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Actividad : EntidadBase, IAgregadoRaiz
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha límite")]
        public DateTime FechaLimite { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }

        [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
        [Display(Name = "Calificación")]
        public string Calificacion { get; set; }
        public string Adjunto { get; set;}
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Materia Materia { get; set; }


        public void AgregarAdjunto(object adjunto) {

        }

        public object ConsultarAdjunto() {
            return null;
        }

        public void CrearActividad() {

        }

        public Actividad ConsultarActividad() {
            return null;
        }

        public void EntregarActividad() {

        }

        public void CalificarActividad(string calificacion) {

        }
    }
}