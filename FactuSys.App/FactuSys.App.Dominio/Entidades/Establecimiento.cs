using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Establecimiento</c>
     /// Modela un Establecimiento en general en el sistema 
     /// </summary> 
     public class Establecimiento 
     {
         // Identificador único de cada Establecimiento
         public int EstablecimientoID { get; set; }

         [Required]
         public string RazonSocial { get; set; }
         
         [Required]
         public int NumeroLocal { get; set; }
         
         /// Relacion entre el Establecimiento y Tipo
         [Required]
         public int TipoID { get; set; }
         public virtual Tipo Tipo { get; set; }
     }
}