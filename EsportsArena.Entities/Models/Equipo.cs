using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreEquipo { get; set; }

        [Required]
        public string JuegoPrincipal { get; set; } // PC o Móvil

        public int CapitanId { get; set; }
        [ForeignKey("CapitanId")]
        public virtual Capitan Capitan { get; set; }
    }
}