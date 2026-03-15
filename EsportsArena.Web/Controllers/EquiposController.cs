using EsportsArena.Entities.Models;
using EsportsArena.Logic.Services;
using Microsoft.AspNetCore.Mvc;


public class EquiposController : Controller
{
    private readonly EquipoService _equipoService;
    private readonly UsuarioService _usuarioService;

    public EquiposController(EquipoService equipoService, UsuarioService usuarioService)
    {
        _equipoService = equipoService;
        _usuarioService = usuarioService;
    }

    // VISTA 1: La Tabla de Equipos
    public IActionResult Index()
    {
        string username = HttpContext.Session.GetString("UsuarioLogueado");
        if (string.IsNullOrEmpty(username)) return RedirectToAction("Index", "Login");

        var usuario = _usuarioService.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username);

        // Obtenemos solo los equipos de este capitán
        var misEquipos = _equipoService.ObtenerEquiposPorUsuario(usuario.Id);
        return View(misEquipos);
    }

    // VISTA 2: El Formulario (GET)
    public IActionResult Registrar()
    {
        return View();
    }

    // ACCIÓN: Guardar en la DB (POST)
    [HttpPost]
    public IActionResult Registrar(Equipo nuevoEquipo)
    {
        string username = HttpContext.Session.GetString("UsuarioLogueado");
        var usuario = _usuarioService.ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Username == username);

        if (usuario != null)
        {
            nuevoEquipo.CapitanId = usuario.Id;
            _equipoService.RegistrarEquipo(nuevoEquipo);

            if (string.IsNullOrEmpty(nuevoEquipo.Logo))
            {
                // Apuntamos a la carpeta que creaste en wwwroot
                nuevoEquipo.Logo = "/Images/LogoDefault.png";
            }
        }

        return RedirectToAction("Index");
    }
}