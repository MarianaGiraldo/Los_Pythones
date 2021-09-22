using System;
namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Factura</c>
     /// Modela un Factura en general en el sistema 
     /// </summary> 
     public class Factura 
     {
         // Identificador único de cada Factura
         public int FacturaID { get; set; }

         /// Relacion entre el Factura y Establecimiento
         public int EstablecimientoID { get; set; }
         public virtual Establecimiento Establecimiento {get; set;}

         /// Relacion entre el Factura y Cliente
         public int ClienteID { get; set; }
         public virtual Cliente Cliente { get; set; }

         public DateTime FechaHora {get; set;}
     }
}