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
    public class EditEmpleadosModel : PageModel
    {
         private readonly IRepositorioEmpleados repositorioEmpleados;
        [BindProperty]
        public Empleado Empleado { get; set; }

        public EditEmpleadosModel(IRepositorioEmpleados repositorioEmpleados)
        {
            this.repositorioEmpleados = repositorioEmpleados;
        }
        public IActionResult OnGet(int EmpleadoId)
        {
            Empleado = repositorioEmpleados.GetEmpleadoPorId(EmpleadoId);
            
            if (Empleado == null)
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

            Empleado = repositorioEmpleados.Update(Empleado);
            return Page();
        }
    }
}
