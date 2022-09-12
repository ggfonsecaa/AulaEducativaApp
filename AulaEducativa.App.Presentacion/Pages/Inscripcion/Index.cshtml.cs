using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Inscripcion
{
    public class IndexModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        [BindProperty]
        public IEnumerable<Materia> Materias { get; set; }
        public Materia Materia { get; set; }
        public Estudiante Estudiante { get; set; }

        public IndexModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet()
        {
            Materias = _unidadDeTrabajo.RepositorioMateria.ObtenerPorCondicion(includeProperties: "GradoAcademico,GradoAcademico.Profesores,Estudiantes");
        }

        public async Task<IActionResult> OnPostAsync(int id, string action = "add")
        {

            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: e => e.Id == 1, includeProperties: "Materias", tracking: true).FirstOrDefault();
            Materia = _unidadDeTrabajo.RepositorioMateria.ObtenerPorId(id);

            if (action == "add")
            {
                Estudiante.Materias.Add(Materia);
            }
            else 
            {
                Estudiante.Materias.Remove(Materia);
            }
            
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }
    }
}