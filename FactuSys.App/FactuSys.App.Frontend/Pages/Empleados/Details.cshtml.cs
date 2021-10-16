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
    public class DetailsEmpleadosModel : PageModel
    {
        private readonly IRepositorioEmpleados repositorioEmpleados;
        public Empleado Empleado {get;set;}

        public DetailsEmpleadosModel(IRepositorioEmpleados repositorioEmpleados)
        {
            this.repositorioEmpleados=repositorioEmpleados;
        }
        
        public IActionResult OnGet(int empleadoId)
        {
            Empleado = repositorioEmpleados.GetEmpleadoPorId(empleadoId);
            if(Empleado==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
    
}
