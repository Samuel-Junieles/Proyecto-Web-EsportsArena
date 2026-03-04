using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EsportsArena.Entities.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [ForeignKey("Capitan")]
        public int CapitanId { get; set; }

        public virtual Capitan Capitan { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
