using System;
using System.Collections.Generic;
using FactuSys.App.Dominio;
using FactuSys.App.Persistencia;

namespace FactuSys.App.Consola
{
    class Program
    {
        public static IRepositorioClientes _repoCliente = new RepositorioClientesMemoria(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddCliente();
            //AddAnotherCliente();
            //BuscarCliente(4);
            //ListarClientePorNombre("Paula");
            //ListarClientePorApellido("Luna");
            //DeleteCliente(1);
            var cliente = new Cliente{
                Nombre = "Paula",
                Apellidos = "Luna Cruz",
                Telefono = "3054650245",
                Email = "paula_luna1973@yahoo.com",
                FechaNacimiento = new DateTime(1973, 08, 03),
                Puntos = 10,
                ClienteID = 4
            };
            UpdateCliente(cliente);
        }

        private static void AddCliente()
        {
            var cliente = new Cliente{
                Nombre = "Gabriela",
                Apellidos = "Giraldo Luna",
                Telefono = "3125478724",
                Email = "gabislinda6@gmail.com",
                FechaNacimiento = new DateTime(2004, 01, 30),
                Puntos = 0
            };
            _repoCliente.Add(cliente);
        }

        private static void AddAnotherCliente()
        {
            var cliente = new Cliente{
                Nombre = "Paula",
                Apellidos = "Luna",
                Telefono = "3054650245",
                Email = "paula_luna1973@yahoo.com",
                FechaNacimiento = new DateTime(1973, 08, 03),
                Puntos = 0
            };
            _repoCliente.Add(cliente);
        }

        private static Cliente BuscarCliente(int idCliente)
        {
            var cliente = _repoCliente.GetClientePorId(idCliente);
            Console.WriteLine(cliente.Nombre + " " + cliente.Apellidos);
            return cliente;
        }

        private static void ListarClientePorNombre(string nombre)
        {
            var clientes = _repoCliente.GetClientesporNombre(nombre);
            foreach (Cliente p in clientes)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }

        private static void ListarClientePorApellido(string apellido)
        {
            var clientes = _repoCliente.GetClientesporApellido(apellido);
            foreach (Cliente p in clientes)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }

        private static void DeleteCliente(int idCliente)
        {
            _repoCliente.Delete(idCliente);
        }

        private static void UpdateCliente(Cliente clienteActualizado)
        {
            _repoCliente.Update(clienteActualizado);
            Cliente cliente = BuscarCliente(clienteActualizado.ClienteID);
        }
    }
}
