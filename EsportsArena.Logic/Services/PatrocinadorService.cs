using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;

namespace EsportsArena.Logic.Services
{
    public class PatrocinadorService
    {
        private readonly IGenericDAO<Patrocinador> _dao;

        public PatrocinadorService(IGenericDAO<Patrocinador> dao)
        {
            _dao = dao;
        }

        public IEnumerable<Patrocinador> Listar() => _dao.ObtenerTodos();
        public Patrocinador Obtener(int id) => _dao.ObtenerPorId(id);

        public void Crear(Patrocinador p)
        {
            _dao.Insertar(p);
            _dao.Guardar();
        }

        public void Editar(Patrocinador p)
        {
            _dao.Actualizar(p);
            _dao.Guardar();
        }

        public void Borrar(int id)
        {
            _dao.Eliminar(id);
            _dao.Guardar();
        }
    }
}