using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Encuentro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreTorneo { get; set; }

        public DateTime FechaEncuentro { get; set; } = DateTime.Now;

        public string ResultadoRandom { get; set; } // Ganó / Perdió / Empate

        public decimal PremioAcumulado { get; set; }

        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
    }
}