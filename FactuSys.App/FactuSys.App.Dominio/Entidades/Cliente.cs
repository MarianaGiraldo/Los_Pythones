using System;
namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Cliente</c>
     /// Modela un Cliente en general en el sistema 
     /// </summary> 
     public class Cliente : Persona
     {
         // Identificador único de cada Cliente
         public int ClienteID { get; set; }
         // Fecha de nacimiento del cliente
         public DateTime FechaNacimiento { get; set; }
         public int Puntos { get; set; }
     }
}