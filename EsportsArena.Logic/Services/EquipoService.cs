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
}