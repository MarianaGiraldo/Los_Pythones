using System;
using System.ComponentModel.DataAnnotations;

namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>   
    public class Persona
    {
        // Identificador único de cada persona
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required, StringLength(70)]
        public string Apellidos { get; set; }

        [Required, StringLength(10)]
        public string Telefono { get; set; }
        
       [Required, StringLength(255)]
         public string Email { get; set; }

    }
}