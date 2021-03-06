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
    public class CreateEmpleadosModel : PageModel
    {
private readonly IRepositorioEmpleados repositorioEmpleados;
        [BindProperty]
        public Empleado Empleado { get; set; }

        public CreateEmpleadosModel(IRepositorioEmpleados repositorioEmpleados)
        {
            this.repositorioEmpleados = repositorioEmpleados;
        }
        public IActionResult OnGet(int? EmpleadoId)
        {
            Empleado = new Empleado();
            return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }    
            repositorioEmpleados.Add(Empleado);
            return Page();
        }
    }
}


