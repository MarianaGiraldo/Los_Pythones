using System;
using System.Collections.Generic;
using System.Linq;
using FactuSys.App.Dominio;

namespace FactuSys.App.Persistencia.AppRepositorios
{
    public class RepositorioClientesMemoria : IRepositorioClientes
    {
        List<Cliente> clientes;

        public RepositorioClientesMemoria()
        {
            clientes = new List<Cliente>()
            {
                new Cliente{Id=1,Nombre="Juan",Apellidos="Díaz",Telefono="3123889874", Email="JuanD@gmail.com", ClienteID=1, FechaNacimiento= new DateTime(2000, 12, 24), Puntos=0},
                new Cliente{Id=2,Nombre="Mariana",Apellidos="Giraldo Luna",Telefono="3123888316", Email="marianaG@gmail.com", ClienteID=1, FechaNacimiento= new DateTime(2000, 12, 24), Puntos=0},
                new Cliente{Id=3,Nombre="Felipe",Apellidos="Castro",Telefono="3008917847", Email="felipeC@gmail.com", ClienteID=1, FechaNacimiento=new DateTime(2000, 12, 24), Puntos=0}

            };
        }

        public Cliente Add(Cliente nuevoCliente)
        {
           nuevoCliente.Id=clientes.Max(r => r.Id) +1; 
           clientes.Add(nuevoCliente);
           return nuevoCliente;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clientes;
        }

        public Cliente GetClientePorId(int ClienteID)
        {
            return clientes.SingleOrDefault(s => s.Id==ClienteID);
        }

        public IEnumerable<Cliente> GetClientesPorFiltro(string filtro=null) // el parámetro es opcional 
        {
            var clientes = GetAll(); // Obtiene todos los clientes
            if (clientes != null)  //Si se tienen clientes
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    clientes = clientes.Where(s => s.Email.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return clientes;
        }

        public Cliente Update(Cliente clienteActualizado)
        {
            var cliente= clientes.SingleOrDefault(r => r.Id==clienteActualizado.Id);
            if (cliente!=null)
            {
                cliente.Id = clienteActualizado.Id;
                cliente.Nombre=clienteActualizado.Nombre;
                cliente.Apellidos=clienteActualizado.Apellidos;
                cliente.Telefono=clienteActualizado.Telefono;
                cliente.Email=clienteActualizado.Email;
                cliente.ClienteID=clienteActualizado.ClienteID;
                cliente.FechaNacimiento=clienteActualizado.FechaNacimiento;
                cliente.Puntos=clienteActualizado.Puntos;
            }
            return cliente;
        }
          
    }
}