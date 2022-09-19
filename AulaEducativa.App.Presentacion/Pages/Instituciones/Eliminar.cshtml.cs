using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AulaEducativa.App.Presentacion.Pages.Instituciones
{
    [Authorize]
    public class EliminarModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        [BindProperty]
        public Institucion Institucion { get; set; }

        public EliminarModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet(int id)
        {
            Institucion = _unidadDeTrabajo.RepositorioInstitucion.ObtenerPorId(id);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _unidadDeTrabajo.RepositorioInstitucion == null)
            {
                return NotFound();
            }

            _unidadDeTrabajo.RepositorioInstitucion.Eliminar(_unidadDeTrabajo.RepositorioInstitucion.ObtenerPorId(id));
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }
    }
}