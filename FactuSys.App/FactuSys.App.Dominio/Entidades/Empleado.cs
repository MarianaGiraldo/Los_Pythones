using System;
namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Empleado</c>
     /// Modela un Empleado en general en el sistema 
     /// </summary> 
     public class Empleado : Persona
     {
         // Identificador único de cada empleado
         public int EmpleadoID { get; set; }
         /// Relacion entre el empleado y el Cargo
         public int CargoID { get; set; }
         public virtual Cargo Cargo { get; set; }
     }
}