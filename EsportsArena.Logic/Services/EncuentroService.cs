using EsportsArena.Data;
using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;

namespace EsportsArena.Logic.Services
{
    public class EncuentroService
    {
        private readonly IGenericDAO<Encuentro> _encuentroDAO;

        public EncuentroService(IGenericDAO<Encuentro> encuentroDAO)
        {
            _encuentroDAO = encuentroDAO;
        }

        public Encuentro ObtenerPorId(int id)
        {
            return _encuentroDAO.ObtenerPorId(id);
        }

        public void Actualizar(Encuentro encuentro)
        {
            _encuentroDAO.Actualizar(encuentro);
            _encuentroDAO.Guardar(); // Para que el resultado del Random se guarde en MySQL
        }

        public void Guardar(Encuentro encuentro)
        {
            if (string.IsNullOrEmpty(encuentro.Estado))
                encuentro.Estado = "Pendiente";

            _encuentroDAO.Insertar(encuentro);
            _encuentroDAO.Guardar();
        }

        public IEnumerable<Encuentro> ObtenerTodos()
        {
            // Traemos todos los encuentros registrados en MySQL
            return _encuentroDAO.ObtenerTodos();
        }
    }
}