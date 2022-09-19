using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Perfil
{
    [Authorize]
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private string _email;

        public Estudiante Estudiante { get; set; }
        public Profesor Profesor { get; set; }

        public IndexModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet()
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();

            ViewData["Perfil"] = Profesor == null ? "Estudiante" : "Profesor";
            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;
        }

        public async Task<IActionResult> OnPostAsync(string type)
        {

            if (type == "Estudiante")
            {
                _unidadDeTrabajo.RepositorioEstudiante.Actualizar(Estudiante);
                await _unidadDeTrabajo.GuardarAsincrono();
            }
            else
            {
                _unidadDeTrabajo.RepositorioProfesor.Actualizar(Profesor);
                await _unidadDeTrabajo.GuardarAsincrono();
            }


            return RedirectToPage("./Index");
        }
    }
}