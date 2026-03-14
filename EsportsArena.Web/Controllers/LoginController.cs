using EsportsArena.Entities.Models;
using EsportsArena.Logic.Services;
using EsportsArena.Logic.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportsArena.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public LoginController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Login/Index (Vista de Ingreso)
        public IActionResult Index() => View();

        // GET: Login/Registro (Vista de Formulario)
        public IActionResult Registro() => View();

        // POST: Login/Registro (Procesar nuevo usuario)
        [HttpPost]
        public IActionResult Registrar(Usuario usuario, string password)
        {
            // Asignamos el Rol de Capitán por defecto para nuevos registros
            usuario.RolId = 2;
            _usuarioService.RegistrarUsuario(usuario, password);
            return RedirectToAction("Index");
        }

        // POST: Login/Ingresar (Validar credenciales)
        [HttpPost]
        public IActionResult Ingresar(string username, string password)
        {
            var user = _usuarioService.ValidarLogin(username, password);
            if (user != null)
            {
                // Guardamos en sesión para cumplir con el requerimiento
                HttpContext.Session.SetString("UsuarioLogueado", user.Username);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View("Index");
        }

    }
}