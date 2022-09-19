// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

using AulaEducativa.App.Dominio.Entidades;
using AulaEducativa.App.Persistencia.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace AulaEducativa.App.Presentacion.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private Usuario Usuario { get; set; }
        private Estudiante Estudiante { get; set; }
        private Profesor Profesor { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public SelectList GradosAcademicos { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string Type { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage = "Este campo es requerido")]
            [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
            public string Nombres { get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            [StringLength(30, ErrorMessage = "El campo no debe tener más de 30 caracteres")]
            public string Apellidos { get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            [Display(Name = "Grado académico")]
            public int GradoAcademico { get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Confirmación de contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas ingresadas no coinciden")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null, string type = null)
        {
            ReturnUrl = returnUrl;
            PopulateDropDownList();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (type == null)
            {
                Type = "Estudiante";
            }
            else
            {
                Type = type;
            }
        }

        public async Task<IActionResult> OnPostAsync(string tipoUsuario = null)
        {
            //returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{

                    Usuario = new Usuario();
                    Usuario.InstitucionId = 1;
                    Usuario.Email = Input.Email;

                    _unidadDeTrabajo.RepositorioUsuario.Insertar(Usuario);
                    await _unidadDeTrabajo.GuardarAsincrono();

                    if (tipoUsuario == "Estudiante")
                    {
                        Estudiante = new Estudiante();
                        Estudiante.Nombres = Input.Nombres;
                        Estudiante.Apellidos = Input.Apellidos;
                        Estudiante.UsuarioId = _unidadDeTrabajo.RepositorioUsuario.ObtenerPorCondicion(filter: x => x.Email == Input.Email).FirstOrDefault().Id;
                        Estudiante.GradoAcademicoId = Input.GradoAcademico;

                        _unidadDeTrabajo.RepositorioEstudiante.Insertar(Estudiante);
                        await _unidadDeTrabajo.GuardarAsincrono();
                    }
                    else
                    {
                        Profesor = new Profesor();
                        Profesor.Nombres = Input.Nombres;
                        Profesor.Apellidos = Input.Apellidos;
                        Profesor.UsuarioId = _unidadDeTrabajo.RepositorioUsuario.ObtenerPorCondicion(filter: x => x.Email == Input.Email).FirstOrDefault().Id;
                        Profesor.GradoAcademicoId = Input.GradoAcademico;

                        _unidadDeTrabajo.RepositorioProfesor.Insertar(Profesor);
                        await _unidadDeTrabajo.GuardarAsincrono();
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("~/");
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            PopulateDropDownList();
            // If we got this far, something failed, redisplay form
            return Page();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        public void PopulateDropDownList(object selectedOption = null)
        {
            var grado = from d in _unidadDeTrabajo.RepositorioGradoAcademico.ObtenerTodos()
                                   orderby d.Id // Sort by name.
                                   select d;

            GradosAcademicos = new SelectList(grado, "Id", "Nombre", selectedOption);
        }
    }
}
