using Microsoft.EntityFrameworkCore;
using EsportsArena.Entities.Models;

namespace EsportsArena.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí registraremos las tablas (DbSets) en el siguiente paso
        // public DbSet<Capitan> Capitanes { get; set; }
    }
}
