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
    public class EditClientesModel : PageModel
    {
        //private readonly IRepositorioClientes repositorioClientes;
        public readonly IRepositorioClientes repositorioClientes = new RepositorioClientesMemoria(new Persistencia.AppContext());
        [BindProperty]
        public Cliente Cliente { get; set; }

        public EditClientesModel(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public IActionResult OnGet(int clienteId)
        {
            Cliente = repositorioClientes.GetClientePorId(clienteId);
            
            if (Cliente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            Cliente = repositorioClientes.Update(Cliente);
            return Page();
        }
    }
}
