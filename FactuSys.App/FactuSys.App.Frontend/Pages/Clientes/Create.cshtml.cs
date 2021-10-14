using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FactuSys.App.Dominio;
using FactuSys.App.Persistencia;

namespace FactuSys.App.Frontend.Pages
{
    public class CreateClientesModel : PageModel
    {
        //private readonly IRepositorioClientes repositorioClientes;
        public readonly IRepositorioClientes repositorioClientes = new RepositorioClientesMemoria(new Persistencia.AppContext());
        [BindProperty]
        public Cliente Cliente { get; set; }

        public CreateClientesModel(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public IActionResult OnGet()
        {
            Cliente = new Cliente();
            return Page();

        }

        public IActionResult OnPost()
        {
            Cliente = new Cliente();
            Cliente.Nombre = Request.Form["Cliente.Nombre"];
            Cliente.Apellidos = Request.Form["Cliente.Apellidos"];
            Cliente.Telefono = Request.Form["Cliente.Telefono"];
            Cliente.Email = Request.Form["Cliente.Email"];
            Cliente.FechaNacimiento =Convert.ToDateTime(Request.Form["Cliente.FechaNacimiento"]);
            if(!ModelState.IsValid)
            {
                return Page();
            }
            repositorioClientes.Add(Cliente);
            return Page();
        }
    }
}

