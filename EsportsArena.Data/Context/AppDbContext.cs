using EsportsArena.Entities.Models; // Asegúrate de que tus clases estén en este namespace
using Microsoft.EntityFrameworkCore;

namespace EsportsArena.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Capitan> Capitanes { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Encuentro> Encuentros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para SHA256
            modelBuilder.Entity<Usuario>()
                .Property(u => u.PasswordHash)
                .HasMaxLength(64)
                .IsFixedLength();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Capitan>()
                .HasOne(c => c.Usuario)
                .WithOne()
                .HasForeignKey<Capitan>(c => c.UsuarioId);

            modelBuilder.Entity<Equipo>()
                .HasOne(e => e.Capitan)
                .WithMany(c => c.Equipos)
                .HasForeignKey(e => e.CapitanId);

            modelBuilder.Entity<Encuentro>()
                .HasOne(en => en.Equipo)
                .WithMany()
                .HasForeignKey(en => en.EquipoId);
        }
    }
}