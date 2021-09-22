using System;
using System.Collections.Generic;

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
         public virtual Empleado Empleado { get; set; }

         public DateTime FechaRegistro { get; set; }

         /// Relacion entre el Registro y Facturas de 1 a muchos
         public virtual ICollection<Factura> Facturas { get; set; }

         public int Puntos { get; set; }
     }
}