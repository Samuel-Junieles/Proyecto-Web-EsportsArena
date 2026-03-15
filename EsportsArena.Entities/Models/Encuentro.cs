using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Encuentro
    {
        [Key]
        public int Id { get; set; }

        public int Equipo1Id { get; set; }
        public int Equipo2Id { get; set; }

        public DateTime FechaEncuentro { get; set; } = DateTime.Now;

        public string? Estado { get; set; } = "Pendiente";

        [ForeignKey("Equipo1Id")]
        public virtual Equipo Equipo1 { get; set; }

        [ForeignKey("Equipo2Id")]
        public virtual Equipo Equipo2 { get; set; }
    }
}