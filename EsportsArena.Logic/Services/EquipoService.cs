using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;

public class EquipoService
{
    private readonly IGenericDAO<Equipo> _equipoDAO;

    public EquipoService(IGenericDAO<Equipo> equipoDAO)
    {
        _equipoDAO = equipoDAO;
    }

    public void RegistrarEquipo(Equipo equipo)
    {
        _equipoDAO.Insertar(equipo);
        _equipoDAO.Guardar();
    }

    public IEnumerable<Equipo> ObtenerEquiposPorUsuario(int usuarioId)
    {
        // Esto filtrará para que el capitán solo vea SUS equipos
        return _equipoDAO.ObtenerTodos().Where(e => e.CapitanId == usuarioId);
    }
    
    public IEnumerable<Equipo> ObtenerTodos()
    {
        return _equipoDAO.ObtenerTodos();
    }

    // Insertar nuevo (POST)
    public void Insertar(Equipo equipo)
    {
        _equipoDAO.Insertar(equipo);
        _equipoDAO.Guardar();
    }

    // Actualizar existente (PUT)
    public bool Actualizar(Equipo equipo)
    {
        try
        {
            _equipoDAO.Actualizar(equipo);
            _equipoDAO.Guardar();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Eliminar (DELETE)
    public bool Eliminar(int id)
    {
        try
        {
            _equipoDAO.Eliminar(id);
            _equipoDAO.Guardar();
            return true;
        }
        catch (Exception)
        {
            // Aquí podrías manejar errores de Llave Foránea 
            // (si el equipo ya tiene encuentros registrados)
            return false;
        }
    }
}