using EsportsArena.Data.Context;
using EsportsArena.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace EsportsArena.Data.DAO
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericDAO(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> ObtenerTodos() => _dbSet.ToList();
        public T ObtenerPorId(int id) => _dbSet.Find(id);
        public void Insertar(T entidad) => _dbSet.Add(entidad);
        public void Actualizar(T entidad) => _context.Entry(entidad).State = EntityState.Modified;
        public void Eliminar(int id) { T entidad = _dbSet.Find(id); _dbSet.Remove(entidad); }
        public void Guardar() => _context.SaveChanges();
    }
}
