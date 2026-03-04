using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EsportsArena.Entities.Models
{
    public class Capitan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public virtual required ICollection<Equipo> Equipos { get; set; }
    }
}
