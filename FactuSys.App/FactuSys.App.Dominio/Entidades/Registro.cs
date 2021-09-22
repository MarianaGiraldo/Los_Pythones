using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Registro</c>
     /// Modela un Registro en general en el sistema 
     /// </summary> 
     public class Registro 
     {
         // Identificador único de cada Registro
         public int RegistroID {get; set;}

         /// Relacion entre el Registro y el Cliente
         public int ClienteID { get; set; }
         public virtual Cliente Cliente {get; set;}

         /// Relacion entre el Registro y el Empleado
         public int EmpleadoID { get; set; }
         public virtual Empleado Empleado {get; set;}

         [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime FechaRegistro {get; set;}

         public int Puntos { get; set; }
     }
}