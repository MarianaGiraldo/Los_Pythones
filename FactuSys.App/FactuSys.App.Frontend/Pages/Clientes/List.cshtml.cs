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
    public class ListClientesModel : PageModel
    {
       //private readonly IRepositorioClientes repositorioClientes;
        public readonly IRepositorioClientes repositorioClientes = new RepositorioClientesMemoria(new Persistencia.AppContext());
        public IEnumerable<Cliente> Clientes {get;set;}

       [BindProperty(SupportsGet =true)]
       public string FiltroBusqueda { get; set; }


       public ListClientesModel(IRepositorioClientes repositorioClientes)
       {
            this.repositorioClientes=repositorioClientes;
       }
       
        public void OnGet(string filtroBusqueda)
        {
           // ListaClientes = new List<string>();
           // ListaClientes.AddRange(Clientes);
          FiltroBusqueda=filtroBusqueda;
          Clientes=repositorioClientes.GetClientesPorFiltro(filtroBusqueda);

        }
    }
}
