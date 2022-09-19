// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AulaEducativa.App.Persistencia.Interfaces;
using AulaEducativa.App.Dominio.Entidades;

namespace AulaEducativa.App.Presentacion.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _signInManager = signInManager;
            _logger = logger;
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public string Type { get; set; }
        public Estudiante Estudiante { get; set; }
        public Profesor Profesor { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Este campo es requerido")]
            [EmailAddress]
            [Display(Name = "Correo electr�nico")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            [DataType(DataType.Password)]
            [Display(Name = "Contrase�a")]
            public string Password { get; set; }

            [Display(Name = "Recordar mis datos?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null, string type = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            if (type == null)
            {
                Type = "Estudiante";
            }
            else 
            {
                Type = type;
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string type = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (type == "Estudiante")
                    {
                        Estudiante = _unidadDeTrabajo.RepositorioEstudiante.ObtenerPorCondicion(filter: x => x.Usuario.Email == Input.Email, includeProperties: "Usuario").FirstOrDefault();

                        if (Estudiante == null)
                        {
                            ModelState.AddModelError(string.Empty, "Los datos proporcionados no son v�lidos");
                            Type = "Estudiante";
                            return Page();
                        }
                    }
                    else 
                    {
                        Profesor = _unidadDeTrabajo.RepositorioProfesor.ObtenerPorCondicion(filter: x => x.Usuario.Email == Input.Email, includeProperties: "Usuario").FirstOrDefault();

                        if (Profesor == null)
                        {
                            ModelState.AddModelError(string.Empty, "Los datos proporcionados no son v�lidos");
                            Type = "Profesor";
                            return Page();
                        }
                    }

                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Los datos proporcionados no son v�lidos");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
