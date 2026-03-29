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
        public DbSet<Patrocinador> Patrocinadores { get; set; }

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
                .HasOne(en => en.Equipo1)
                .WithMany()
                .HasForeignKey(en => en.Equipo1Id)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Encuentro>()
                .HasOne(en => en.Equipo2)
                .WithMany()
                .HasForeignKey(en => en.Equipo2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patrocinador>(entity =>
            {
                // Nombre de la tabla en XAMPP
                entity.ToTable("Patrocinadores");

                // Llave Primaria
                entity.HasKey(e => e.Id);

                // Propiedades obligatorias y límites de caracteres
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(100);

                // Configuración para el monto (Importante para evitar errores de precisión)
                entity.Property(e => e.MontoInversion)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.EmailContacto)
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .HasDefaultValue("Activo")
                    .HasMaxLength(20);
            });
        }
    }
}