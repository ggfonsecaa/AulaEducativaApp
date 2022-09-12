using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Materias
{
    public class IndexModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        [BindProperty]
        public IEnumerable<Materia> Materias { get; set; }

        public IndexModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet()
        {
            Materias = _unidadDeTrabajo.RepositorioMateria.ObtenerPorCondicion(filter: e => e.Estudiantes.Any(x => x.UsuarioId == 4), includeProperties: "GradoAcademico,GradoAcademico.Profesores,Estudiantes");
        }
    }
}