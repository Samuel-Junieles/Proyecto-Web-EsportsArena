using Microsoft.AspNetCore.Mvc;
using EsportsArena.Logic.Services; 
using Microsoft.AspNetCore.Http;

namespace EsportsArena.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            // Seguridad: Si no hay sesión, al login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado")))
            {
                return RedirectToAction("Index", "Login");
            }

            // Obtenemos los datos de MySQL
            var listaUsuarios = _usuarioService.ObtenerTodosLosUsuarios();
            return View(listaUsuarios);
        }
    }
}