using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AulaEducativa.App.Presentacion.Pages.Inscripcion
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private string _email;

        [BindProperty]
        public IEnumerable<Materia> Materias { get; set; }
        public Materia Materia { get; set; }
        public Estudiante Estudiante { get; set; }
        public Profesor Profesor { get; set; }

        public IndexModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet()
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico", tracking: true).FirstOrDefault();
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();
            Materias = _unidadDeTrabajo.RepositorioMateria.ObtenerPorCondicion(filter: x => x.GradoAcademicoId == Estudiante.GradoAcademicoId,includeProperties: "GradoAcademico,GradoAcademico.Profesores,Estudiantes");

            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;
            ViewData["Perfil"] = Profesor == null ? "Estudiante" : "Profesor";
        }

        public async Task<IActionResult> OnPostAsync(int id, string action = "add")
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico", tracking: true).FirstOrDefault();
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();
            Materia = _unidadDeTrabajo.RepositorioMateria.ObtenerPorId(id);

            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;


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