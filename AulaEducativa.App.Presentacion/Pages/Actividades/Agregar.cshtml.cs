using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AulaEducativa.App.Presentacion.Pages.Actividades
{
    public class AgregarModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private string _email;

        [BindProperty]
        public Actividad Actividad { get; set; }
        public Estudiante Estudiante { get; set; }
        public Profesor Profesor { get; set; }
        public SelectList Materias { get; set; }
        public SelectList Estudiantes { get; set; }

        public AgregarModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public void OnGet(int id)
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico", tracking: true).FirstOrDefault();
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();
            Actividad = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id, includeProperties: "Materia,Estudiante").FirstOrDefault();
            

            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;

            PopulateDropDownList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico", tracking: true).FirstOrDefault();
            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;

            if (!ModelState.IsValid || _unidadDeTrabajo.RepositorioActividad == null)
            {
                PopulateDropDownList();
                return Page();
            }

            _unidadDeTrabajo.RepositorioActividad.Insertar(Actividad);
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }

        public void PopulateDropDownList(object selectedOption = null)
        {
            var grado = from d in _unidadDeTrabajo.RepositorioMateria.ObtenerPorCondicion(filter: x => x.GradoAcademicoId == Profesor.GradoAcademicoId)
                        orderby d.Id // Sort by name.
                        select d;

            Materias = new SelectList(grado, "Id", "Nombre", selectedOption);

            var estudiantes = from d in _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.GradoAcademicoId == Profesor.GradoAcademicoId)
                        orderby d.Id // Sort by name.
                        select new { d.Id, NombreCompleto = d.Nombres+" "+d.Apellidos };

            Estudiantes = new SelectList(estudiantes, "Id", "NombreCompleto", selectedOption);
        }
    }
}
