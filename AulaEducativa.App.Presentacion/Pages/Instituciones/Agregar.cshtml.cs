using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Instituciones
{
    [Authorize]
    public class AgregarModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        [BindProperty]
        public Institucion Institucion { get; set; }

        public AgregarModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _unidadDeTrabajo.RepositorioInstitucion == null)
            {
                return Page();
            }

            _unidadDeTrabajo.RepositorioInstitucion.Insertar(Institucion);
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }
    }
}
