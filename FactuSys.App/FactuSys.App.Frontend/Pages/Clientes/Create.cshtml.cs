using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FactuSys.App.Dominio;
using FactuSys.App.Persistencia.AppRepositorios;

namespace FactuSys.App.Frontend.Pages
{
    public class CreateClientesModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;
        [BindProperty]
        public Cliente Cliente { get; set; }

        public CreateClientesModel(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public IActionResult OnGet(int? clienteId)
        {
            Cliente = new Cliente();
            return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }    
            repositorioClientes.Add(Cliente);
            return Page();
        }
    }
}

