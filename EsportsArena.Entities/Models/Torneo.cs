using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EsportsArena.Entities.Models
{
    public class Torneo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreTorneo { get; set; }

        public decimal Premio { get; set; }

        public string Plataforma { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }

    }
}
