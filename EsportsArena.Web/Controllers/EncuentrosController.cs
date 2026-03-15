using EsportsArena.Entities.Models;
using EsportsArena.Logic.Services;
using Microsoft.AspNetCore.Mvc;

public class EncuentrosController : Controller
{
    private readonly EquipoService _equipoService;
    private readonly UsuarioService _usuarioService;
    private readonly EncuentroService _encuentroService; // Agregado

    public EncuentrosController(EquipoService equipoService, UsuarioService usuarioService, EncuentroService encuentroService)
    {
        _equipoService = equipoService;
        _usuarioService = usuarioService;
        _encuentroService = encuentroService; // Asignación
    }

    // VISTA 1: Lista de enfrentamientos programados
    public IActionResult Index()
    {
        string username = HttpContext.Session.GetString("UsuarioLogueado");
        if (string.IsNullOrEmpty(username)) return RedirectToAction("Index", "Login");

        // 2. Traer Encuentros (Usa .ToList() para evitar que la conexión se cierre)
        var encuentros = _encuentroService.ObtenerTodos().ToList();

        // 3. Traer TODOS los equipos para poder buscar los nombres
        // Es mejor traer todos los equipos una vez, que consultar la DB por cada fila de la tabla
        ViewBag.Equipos = _equipoService.ObtenerTodos().ToList();

        return View(encuentros);
    }

    // VISTA 2: Formulario para crear el duelo
    public IActionResult Registrar()
    {
        string username = HttpContext.Session.GetString("UsuarioLogueado");
        var usuario = _usuarioService.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username);

        // Obtenemos solo los equipos del usuario actual
        var misEquipos = _equipoService.ObtenerEquiposPorUsuario(usuario.Id).ToList();

        // Los pasamos a la vista para llenar los selectores
        return View(misEquipos);
    }

    [HttpPost]
    public IActionResult GuardarEncuentro(Encuentro nuevoEncuentro)
    {
        // 1. Asignar estado por defecto (Evita el error de columna null)
        if (string.IsNullOrEmpty(nuevoEncuentro.Estado))
        {
            nuevoEncuentro.Estado = "Pendiente";
        }

        // 2. Validación básica
        if (nuevoEncuentro.Equipo1Id == nuevoEncuentro.Equipo2Id)
        {
            TempData["Error"] = "Un equipo no puede enfrentarse a sí mismo.";
            return RedirectToAction("Registrar");
        }

        // 3. Guardar
        try
        {
            _encuentroService.Guardar(nuevoEncuentro);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            // Esto te dirá en pantalla si hay un error de base de datos
            TempData["Error"] = "Error en DB: " + ex.Message;
            return RedirectToAction("Registrar");
        }
    }

}