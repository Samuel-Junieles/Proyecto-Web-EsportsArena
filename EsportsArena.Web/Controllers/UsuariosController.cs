using Microsoft.AspNetCore.Mvc;
using EsportsArena.Logic.Services;
using EsportsArena.Entities.Models;

namespace EsportsArena.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Vista de la Tabla: Ver Información (Punto 1 de tus requerimientos)
        public IActionResult Index()
        {
            var lista = _usuarioService.ObtenerTodosLosUsuarios();
            return View(lista);
        }

        // Vista del Formulario: Crear Usuario
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario, string passwordNormal)
        {
            if (ModelState.IsValid)
            {
                // Aquí usamos el SHA256 que definimos en la lógica
                _usuarioService.RegistrarUsuario(usuario, passwordNormal);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
    }
}