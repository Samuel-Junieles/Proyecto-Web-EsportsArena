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

        public IActionResult Index() => View();

        public IActionResult Registro() => View();

        [HttpPost]
        public IActionResult Registrar(Usuario usuario, string password)
        {
            try
            {
                usuario.RolId = 2;

                _usuarioService.RegistrarUsuario(usuario, password);

                TempData["RegistroExitoso"] = "¡Cuenta creada con éxito, Legend! Ya puedes ingresar.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Por si algo falla en el Service o DAO (ej: correo duplicado)
                TempData["LoginError"] = "Hubo un problema al crear la cuenta: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Ingresar(string username, string password)
        {
            var user = _usuarioService.ValidarLogin(username, password);

            if (user != null)
            {
                HttpContext.Session.SetString("UsuarioLogueado", user.Username);

                TempData["LoginSuccess"] = $"¡Bienvenido de nuevo, {user.Username}!";

                return RedirectToAction("Index", "Home");
            }

            TempData["LoginError"] = "Usuario o contraseña incorrectos. Verifica tus credenciales.";

            return View("Index");
        }

        [HttpGet]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }

    }
}