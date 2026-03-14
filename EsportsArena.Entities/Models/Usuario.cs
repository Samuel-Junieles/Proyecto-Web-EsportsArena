using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsArena.Entities.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(64)] // Longitud para SHA256
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relación con Rol
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; }
    }
}