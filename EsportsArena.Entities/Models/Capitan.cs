using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Capitan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        public string Telefono { get; set; }

        // Relación One-to-One con Usuario
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}