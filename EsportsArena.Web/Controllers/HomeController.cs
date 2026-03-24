using Microsoft.AspNetCore.Mvc;
using EsportsArena.Logic.Services;
using EsportsArena.Entities.Models;

namespace EsportsArena.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EquipoService _equipoService;
        private readonly EncuentroService _encuentroService;
        private readonly UsuarioService _usuarioService;

        public HomeController(EquipoService equipoService, EncuentroService encuentroService, UsuarioService usuarioService)
        {
            _equipoService = equipoService;
            _encuentroService = encuentroService;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            // 1. Sesión
            var username = HttpContext.Session.GetString("UsuarioLogueado");
            if (string.IsNullOrEmpty(username)) return RedirectToAction("Index", "Login");

            // 2. Mis Equipos (Filtro por usuario)
            var usuarioActivo = _usuarioService.ObtenerTodosLosUsuarios()
                .FirstOrDefault(u => u.Username == username);

            int contadorMisEquipos = 0;
            if (usuarioActivo != null)
            {
                contadorMisEquipos = _equipoService.ObtenerTodos()
                    .Count(e => e.CapitanId == usuarioActivo.Id);
            }

            // 3. Lógica de Encuentros y Torneos
            var todosLosEncuentros = _encuentroService.ObtenerTodos().ToList();

            // Contamos cuántos tienen un resultado (ya se jugaron)
            // Asumiendo que si no se ha jugado, el estado es nulo, vacío o dice "Pendiente"
            int jugados = todosLosEncuentros.Count(e => !string.IsNullOrEmpty(e.Estado) && e.Estado != "Pendiente");

            // Contamos los que están por jugar
            int porJugar = todosLosEncuentros.Count(e => string.IsNullOrEmpty(e.Estado) || e.Estado == "Pendiente");

            // Enviamos a la vista
            ViewBag.MisEquipos = contadorMisEquipos;
            ViewBag.PartidosJugados = jugados;
            ViewBag.PartidosPendientes = porJugar;

            return View();
        }
    }
}