namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Registro</c>
     /// Modela un Registro en general en el sistema 
     /// </summary> 
     public class Registro 
     {
         // Identificador único de cada Registro
         public int Id {get; set;}
         /// Relacion entre el Registro y el Cliente
         public Cliente Cliente {get; set;}
         /// Relacion entre el Registro y el Empleado
         public Empleado Empleado {get; set;}
         public DateTime FechaRegistro {get; set;}
     }
}