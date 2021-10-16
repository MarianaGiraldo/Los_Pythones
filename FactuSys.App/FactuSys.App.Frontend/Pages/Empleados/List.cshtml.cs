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
    public class ListEmpleadosModel : PageModel
    {
       private readonly IRepositorioEmpleados repositorioEmpleados;
       public IEnumerable<Empleado> Empleados {get;set;}

       [BindProperty(SupportsGet =true)]
       public string FiltroBusqueda { get; set; }


       public ListEmpleadosModel(IRepositorioEmpleados repositorioEmpleados)
       {
            this.repositorioEmpleados=repositorioEmpleados;
       }
       
        public void OnGet(string filtroBusqueda)
        {
          //ListaEmpleados = new List<string>();
          //ListaEmpleados.AddRange(Empleados);
          FiltroBusqueda=filtroBusqueda;
          Empleados=repositorioEmpleados.GetEmpleadosPorFiltro(filtroBusqueda);

        }
    }
}
