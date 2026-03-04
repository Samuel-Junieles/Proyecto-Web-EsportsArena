using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Resultado
    {
        [Key]
        public int Id { get; set; }

        public int Puntaje { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int IdEquipo { get; set; }

        [ForeignKey("IdEquipo")]
        public virtual Equipo Equipo { get; set; }

        public int IdTorneo { get; set; }

        [ForeignKey("IdTorneo")]
        public virtual Torneo Torneo { get; set; }
    }
}