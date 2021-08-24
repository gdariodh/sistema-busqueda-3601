﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using sistema_busqueda.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_busqueda.Pages
{
    public class IndexModel : PageModel
    {

       [BindProperty]
       [Required(ErrorMessage ="El campo usuario es requerido")]
        public string Usuario { get; set; }


        [Display(Name="Contraseña")]
        [BindProperty]
        [Required(ErrorMessage ="El campo password es requerido")]

        public string Password { get; set; } 

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                var nombreUsuario = this.Usuario;
                var passwordUsuario = this.Password;
                var repo = new IndexRepository();
                

                if (repo.ValidarUsuario(nombreUsuario, passwordUsuario))
                {
                    return RedirectToPage("./Privacy");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El usuario o la password no son validos");
                    return Page();

                }
            }
            else
            {
                return Page();
            }

            
        }
    }
}
