namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Empleado</c>
     /// Modela un Empleado en general en el sistema 
     /// </summary> 
     public class Empleado : Persona
     {
         // Identificador único de cada empleado
         public int Id {get; set;}
         /// Relacion entre el empleado y el Cargo
         public Cargo Cargo {get; set;}
     }
}