using System;
using System.Collections.Generic;
using System.Linq;
using FactuSys.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;

namespace FactuSys.App.Persistencia.AppRepositorios
{
    public class RepositorioEmpleadosMemoria : IRepositorioEmpleados
    {
        List<Empleado> empleados;
        /// <summary>
        ///Referencia al contexto del Empleado
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        ///Modelo constructor utiliza
        /// Inyección de dependencia para indicar el contexto a utilizar
        /// </summary>
        ///<param name="appContext"></param>//

        public RepositorioEmpleadosMemoria(AppContext appContext)
        {
            _appContext = appContext;
            empleados = new List<Empleado>()
            {
                new Empleado{Id=11,Nombre="Julian",Apellidos="Gonzáles",Telefono="3104567892", Email="juliangonzalez@gmail.com", EmpleadoID=1, Contrasena="Micont12"},
                new Empleado{Id=12,Nombre="Clara",Apellidos="Pérez",Telefono="3007895431", Email="claraperez@factusys.com", EmpleadoID=2, Contrasena="5678Pass"},
                new Empleado{Id=13,Nombre="Maritza",Apellidos="Martínez",Telefono="3158904325", Email="maritzamzC@gmail.com", EmpleadoID=3, Contrasena="Mari3450"}

            };
            // foreach (Empleado empleado in empleados)
            // {
            //     var empleadoAdicionado = _appContext.Empleados.Add(empleado);
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

        Empleado IRepositorioEmpleados.Add(Empleado nuevoEmpleado)
        {
           nuevoEmpleado.Id=empleados.Max(r => r.Id) + 1; 
           nuevoEmpleado.EmpleadoID=_appContext.Empleados.Max(r => r.EmpleadoID) + 1; 
           empleados.Add(nuevoEmpleado);
            var empleadoAdicionado = _appContext.Empleados.Add(nuevoEmpleado);
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

            return empleadoAdicionado.Entity;
        }

        IEnumerable<Empleado> IRepositorioEmpleados.GetAll()
        {
            return _appContext.Empleados;
        }

        Empleado IRepositorioEmpleados.GetEmpleadoPorId(int EmpleadoID)
        {
            return _appContext.Empleados.FirstOrDefault(p => p.EmpleadoID == EmpleadoID);
        }

        IEnumerable<Empleado> IRepositorioEmpleados.GetEmpleadosPorFiltro(string filtro=null) // el parámetro es opcional 
        {
            IEnumerable<Empleado> empleados = _appContext.Empleados; // Obtiene todos los empleados
            if (empleados != null)  //Si se tienen empleados
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    empleados = empleados.Where(s => s.Email.Contains(filtro)).ToList(); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return empleados;
        }
        Empleado IRepositorioEmpleados.Update(Empleado empleadoActualizado)
        {
            var empleado = _appContext.Empleados.FirstOrDefault(p => p.EmpleadoID == empleadoActualizado.EmpleadoID);
            if (empleado!=null)
            {
                empleado.Nombre=empleadoActualizado.Nombre;
                empleado.Apellidos=empleadoActualizado.Apellidos;
                empleado.Telefono=empleadoActualizado.Telefono;
                empleado.Email=empleadoActualizado.Email;
                empleado.Contrasena=empleadoActualizado.Contrasena;
                _appContext.SaveChanges();
            }
            return empleado;
        }

        void IRepositorioEmpleados.Delete(int idEmpleado)
        {
            var empleadoEncontrado = _appContext.Empleados.FirstOrDefault(p => p.EmpleadoID == idEmpleado);
            if(empleadoEncontrado == null)
                return;
            empleados.Remove(empleadoEncontrado);
            _appContext.Empleados.Remove(empleadoEncontrado);
            _appContext.SaveChanges();
        }
          
    }
}