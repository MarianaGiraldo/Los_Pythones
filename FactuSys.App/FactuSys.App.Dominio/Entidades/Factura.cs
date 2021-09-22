using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
         [Required]
         public int EstablecimientoID { get; set; }
         public virtual Establecimiento Establecimiento {get; set;}

         /// Relacion entre el Factura y Cliente
         [Required]
         public int ClienteID { get; set; }
         public virtual Cliente Cliente { get; set; }

         [Required]
         public DateTime FechaHora {get; set;}
     }
}