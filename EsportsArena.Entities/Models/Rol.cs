using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EsportsArena.Entities.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreRol { get; set; } // ADMIN, CAPITAN, ORGANIZADOR

        // Relación: Un rol lo tienen muchos usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}