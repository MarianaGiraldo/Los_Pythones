using System;
namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Establecimiento</c>
     /// Modela un Establecimiento en general en el sistema 
     /// </summary> 
     public class Establecimiento 
     {
         // Identificador único de cada Establecimiento
         public int EstablecimientoID { get; set; }

         public string RazonSocial { get; set; }

         public int NumeroLocal { get; set; }
         
         /// Relacion entre el Establecimiento y Tipo
         public int TipoID { get; set; }
         public virtual Tipo Tipo { get; set; }
     }
}