using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Actividades
{
    public class EditarModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        [BindProperty]
        public Institucion Institucion { get; set; }

        public EditarModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet(int id)
        {
            Institucion = _unidadDeTrabajo.RepositorioInstitucion.ObtenerPorId(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _unidadDeTrabajo.RepositorioInstitucion == null)
            {
                return Page();
            }

            _unidadDeTrabajo.RepositorioInstitucion.Actualizar(Institucion);
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }
    }
}