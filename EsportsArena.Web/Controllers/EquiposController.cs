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

    [HttpPost]
    public IActionResult Actualizar([FromBody] Equipo datosNuevos)
    {
        var equipoDB = _equipoService.ObtenerTodos().FirstOrDefault(e => e.Id == datosNuevos.Id);
        if (equipoDB == null) return Json(new { success = false });

        // Solo actualizamos lo permitido
        equipoDB.NombreEquipo = datosNuevos.NombreEquipo;
        equipoDB.JuegoPrincipal = datosNuevos.JuegoPrincipal;

        _equipoService.Actualizar(equipoDB); // Asegúrate que tu Service tenga este método
        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        try
        {
            _equipoService.Eliminar(id); // Asegúrate que tu Service tenga este método
            return Json(new { success = true });
        }
        catch
        {
            return Json(new { success = false });
        }
    }
}