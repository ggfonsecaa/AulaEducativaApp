using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AulaEducativa.App.Presentacion.Pages.Calificaciones
{
    [Authorize]
    public class DetalleModel : PageModel
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private string _email;
        public Estudiante Estudiante { get; set; }
        public Profesor Profesor { get; set; }
        public AdjuntoModel Adjunto { get; set; }

        [BindProperty]
        public Actividad Actividad { get; set; }

        public DetalleModel(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public class AdjuntoModel
        {
            public IFormFile AdjuntoActividad { get; set; }
            public string? FileName { get; set; }
            public byte[]? FileContent { get; set; }
        }

        public void OnGet(int id)
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico").FirstOrDefault();
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();

            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;
            ViewData["Perfil"] = Profesor == null ? "Estudiante" : "Profesor";

            Actividad = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id, includeProperties: "Materia,Estudiante").FirstOrDefault();

            if (Actividad.Adjunto != null) 
            {
               Adjunto = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id, includeProperties: "Materia,Estudiante").Select(f => new AdjuntoModel() { FileName = "Ajunto", FileContent = f.Adjunto}).FirstOrDefault();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Materias,Usuario,GradoAcademico").FirstOrDefault();
            Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == _email, includeProperties: "Usuario,GradoAcademico").FirstOrDefault();

            ViewData["NombreUsuario"] = Profesor == null ? Estudiante.Nombres + " " + Estudiante.Apellidos : Profesor.Nombres + " " + Profesor.Apellidos;
            ViewData["Grado"] = Profesor == null ? Estudiante.GradoAcademico.Nombre : Profesor.GradoAcademico.Nombre;
            ViewData["Perfil"] = Profesor == null ? "Estudiante" : "Profesor";
            //Actividad = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id).FirstOrDefault();
            //Actividad.Calificacion = calificacion;

            _unidadDeTrabajo.RepositorioActividad.Actualizar(Actividad);
            await _unidadDeTrabajo.GuardarAsincrono();

            return RedirectToPage("./Index");
        }

        public FileResult OnGetDescargarArchivo(int id)
        {
            var bytes = _unidadDeTrabajo.RepositorioActividad.ObtenerPorCondicion(filter: a => a.Id == id, includeProperties: "Materia,Estudiante").FirstOrDefault().Adjunto;

            //Send the File to Download.
            return File(bytes, "application/pdf", "Adjunto.pdf");
        }
    }
}
