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
    public class EditClientesModel : PageModel
    {
        private readonly IRepositorioClientes repositorioClientes;
        [BindProperty]
        public Cliente Cliente { get; set; }

        public EditClientesModel(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public IActionResult OnGet(int? clienteId)
        {
            if (clienteId.HasValue)
            {
                Cliente = repositorioClientes.GetClientePorId(clienteId.Value);
            }
            else
            {
                Cliente = new Cliente();
            }
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
            if(Cliente.Id>0)
            {
            Cliente = repositorioClientes.Update(Cliente);
            }
            else
            {
             repositorioClientes.Add(Cliente);
            }
            return Page();
        }
    }
}
