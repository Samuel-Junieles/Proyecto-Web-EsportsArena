using EsportsArena.Logic.Services;
using Microsoft.AspNetCore.Mvc;

public class TorneosController : Controller
{
    private readonly TorneoService _torneoService;
    private readonly EncuentroService _encuentroService;
    private readonly EquipoService _equipoService;

    public TorneosController(TorneoService torneoService, EncuentroService encuentroService, EquipoService equipoService)
    {
        _torneoService = torneoService;
        _encuentroService = encuentroService;
        _equipoService = equipoService;
    }

    public IActionResult Index()
    {
        var encuentros = _encuentroService.ObtenerTodos().ToList();
        ViewBag.Equipos = _equipoService.ObtenerTodos().ToList();
        return View(encuentros);
    }

    [HttpPost]
    public IActionResult ProcesarResultado(int id)
    {
        var encuentro = _encuentroService.ObtenerPorId(id);
        if (encuentro == null) return Json(new { success = false });

        // Buscamos los equipos para saber sus nombres
        var e1 = _equipoService.ObtenerTodos().FirstOrDefault(e => e.Id == encuentro.Equipo1Id);
        var e2 = _equipoService.ObtenerTodos().FirstOrDefault(e => e.Id == encuentro.Equipo2Id);

        // Llamamos al nuevo método con nombres reales
        string resultadoReal = _torneoService.GenerarResultadoAleatorio(e1.NombreEquipo, e2.NombreEquipo);

        encuentro.Estado = resultadoReal;
        _encuentroService.Actualizar(encuentro);

        return Json(new { success = true, resultado = resultadoReal });
    }
}