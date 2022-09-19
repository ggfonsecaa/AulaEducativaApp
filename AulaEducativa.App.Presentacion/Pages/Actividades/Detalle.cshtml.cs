using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Actividades
{
    [Authorize]
    public class DetalleModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        [BindProperty]
        public Actividad Actividad { get; set; }

        public DetalleModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet(int id)
        {
            Actividad = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id, includeProperties: "Materia,Estudiante").FirstOrDefault();
        }
    }
}
