using AulaEducativa.App.Dominio.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Usuario : EntidadBase, IAgregadoRaiz
    {
        [StringLength(255, ErrorMessage = "El campo no debe tener más de 255 caracteres")]
        public string Email { get; set; }
        public int InstitucionId { get; set; } 
        public virtual Institucion? Institucion { get; set; }
    }
}