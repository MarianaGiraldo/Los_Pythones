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
         public string Contrasena { get; set; }
     }
}