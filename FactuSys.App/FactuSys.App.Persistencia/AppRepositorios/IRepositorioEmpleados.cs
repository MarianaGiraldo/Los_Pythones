using System.Collections.Generic;
using FactuSys.App.Dominio;

namespace FactuSys.App.Persistencia.AppRepositorios
{
    public interface IRepositorioEmpleados
    {
        IEnumerable<Empleado> GetAll();
        IEnumerable<Empleado> GetEmpleadosPorFiltro(string filtro);
        Empleado GetEmpleadoPorId(int empleadoId);
        Empleado Update(Empleado empleadoActualizado);
        Empleado Add(Empleado nuevoEmpleado);
        void Delete(int idEmpleado);
      
    }
}