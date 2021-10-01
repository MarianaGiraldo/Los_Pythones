using System.Collections.Generic;
using FactuSys.App.Dominio;

namespace FactuSys.App.Persistencia.AppRepositorios
{
    public interface IRepositorioClientes
    {
        IEnumerable<Cliente> GetAll();
        IEnumerable<Cliente> GetClientesPorFiltro(string filtro);
        Cliente GetClientePorId(int clienteID);
        Cliente Update(Cliente clienteActualizado);
        Cliente Add(Cliente nuevoCliente);
      
    }
}