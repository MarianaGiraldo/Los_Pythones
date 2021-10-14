using System;
using System.Collections.Generic;
using System.Linq;
using FactuSys.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;

namespace FactuSys.App.Persistencia
{
    public class RepositorioClientesMemoria : IRepositorioClientes
    {
        List<Cliente> clientes;

        /// <summary>
        ///Referencia al contexto del Cliente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        ///Modelo constructor utiliza
        /// Inyección de dependencia para indicar el contexto a utilizat
        /// </summary>
        ///<param name="appContext"></param>//

        public RepositorioClientesMemoria(AppContext appContext)
        {
            _appContext = appContext;
            // clientes = new List<Cliente>()
            // {
            //     new Cliente{Id=1,Nombre="Juan",Apellidos="Díaz",Telefono="3123889874", Email="JuanD@gmail.com", ClienteID=1, FechaNacimiento= new DateTime(2000, 12, 24), Puntos=0},
            //     new Cliente{Id=2,Nombre="Mariana",Apellidos="Giraldo Luna",Telefono="3123888316", Email="marianaG@gmail.com", ClienteID=2, FechaNacimiento= new DateTime(2000, 12, 24), Puntos=0},
            //     new Cliente{Id=3,Nombre="Felipe",Apellidos="Castro",Telefono="3008917847", Email="felipeC@gmail.com", ClienteID=3, FechaNacimiento=new DateTime(2000, 12, 24), Puntos=0}
            // };
            // foreach (Cliente cliente in clientes)
            // {
            //     var clienteAdicionado = _appContext.Clientes.Add(cliente);
            // }
            // _appContext.Database.OpenConnection();
            // try
            // {
            //     _appContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Personas ON;");
            //     _appContext.SaveChanges();
            //     _appContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Personas OFF;");
            // }
            // finally
            // {
            //     _appContext.Database.CloseConnection();
            // }
        }

        Cliente IRepositorioClientes.Add(Cliente nuevoCliente)
        {
           nuevoCliente.Id=_appContext.Clientes.Max(r => r.Id) + 1; 
           nuevoCliente.ClienteID=_appContext.Clientes.Max(r => r.ClienteID) + 1; 
           clientes.Add(nuevoCliente);
           var clienteAdicionado = _appContext.Clientes.Add(nuevoCliente);
            _appContext.Database.OpenConnection();
            try
            {
                _appContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Personas ON;");
                _appContext.SaveChanges();
                _appContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Personas OFF;");
            }
            finally
            {
                _appContext.Database.CloseConnection();
            }

            return clienteAdicionado.Entity;
        }

        IEnumerable<Cliente> IRepositorioClientes.GetAll()
        {
            return _appContext.Clientes;
        }

        Cliente IRepositorioClientes.GetClientePorId(int ClienteID)
        {
            return _appContext.Clientes.FirstOrDefault(p => p.ClienteID == ClienteID);
        }

        IEnumerable<Cliente> IRepositorioClientes.GetClientesPorFiltro(string filtro=null) // el parámetro es opcional 
        {
            IEnumerable<Cliente> clientes = _appContext.Clientes; // Obtiene todos los clientes
            if (clientes != null)  //Si se tienen clientes
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    clientes = clientes.Where(s => s.Email.Contains(filtro)).ToList(); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return clientes;
        }

        Cliente IRepositorioClientes.Update(Cliente clienteActualizado)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.ClienteID == clienteActualizado.ClienteID);
            if (clienteEncontrado!=null)
            {
                clienteEncontrado.Nombre=clienteActualizado.Nombre;
                clienteEncontrado.Apellidos=clienteActualizado.Apellidos;
                clienteEncontrado.Telefono=clienteActualizado.Telefono;
                clienteEncontrado.Email=clienteActualizado.Email;
                clienteEncontrado.ClienteID=clienteActualizado.ClienteID;
                clienteEncontrado.FechaNacimiento=clienteActualizado.FechaNacimiento;
                clienteEncontrado.Puntos=clienteActualizado.Puntos;
                _appContext.SaveChanges();
            }
            return clienteEncontrado;
        }

        void IRepositorioClientes.Delete(int idCliente)
        {
            var ClienteEncontrado = _appContext.Clientes.FirstOrDefault(p => p.ClienteID == idCliente);
            if(ClienteEncontrado == null)
                return;
            clientes.Remove(ClienteEncontrado);
            _appContext.Clientes.Remove(ClienteEncontrado);
            _appContext.SaveChanges();
        }
          
        IEnumerable<Cliente> IRepositorioClientes.GetClientesporNombre(string nombre)
        {
            IEnumerable<Cliente> clientes = _appContext.Clientes; // Obtiene todos los clientes
            if (clientes != null)  //Si se tienen clientes
            {
                if (!String.IsNullOrEmpty(nombre)) // Si el nombre tiene algun valor
                {
                    clientes = clientes.Where(s => s.Nombre.Contains(nombre)).ToList(); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el nombre
                    /// </summary>
                }
            }
            return clientes;
        }

        IEnumerable<Cliente> IRepositorioClientes.GetClientesporApellido(string apellido)
        {
            IEnumerable<Cliente> clientes = _appContext.Clientes; // Obtiene todos los clientes
            if (clientes != null)  //Si se tienen clientes
            {
                if (!String.IsNullOrEmpty(apellido)) // Si el Apellido tiene algun valor
                {
                    clientes = clientes.Where(s => s.Apellidos.Contains(apellido)).ToList(); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el Apellido
                    /// </summary>
                }
            }
            return clientes;
        }
 
    }
}