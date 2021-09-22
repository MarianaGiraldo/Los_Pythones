using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactuSys.App.Dominio
{
    /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>   
    public class Persona
    {
        // Identificador único de cada persona
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Los apellidos no pueden tener más de 80 caracteres.")]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(15, MinimumLength=10)]
        public string NumeroTelefono { get; set; }
        
        [Required]
        public string Email { get; set; }

    }
}