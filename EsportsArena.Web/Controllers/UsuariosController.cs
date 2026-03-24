using Microsoft.AspNetCore.Mvc;
using EsportsArena.Logic.Services; 
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult Actualizar([FromBody] Usuario datosNuevos)
        {
            // 1. Buscamos el usuario real que está en XAMPP actualmente
            var usuarioDB = _usuarioService.ObtenerPorId(datosNuevos.Id);

            if (usuarioDB == null)
                return Json(new { success = false, message = "Usuario no encontrado" });

            // 2. MAPEAMOS SOLO LOS CAMPOS PERMITIDOS
            // Esto protege el PasswordHash y el RolId porque nunca los tocamos
            usuarioDB.Username = datosNuevos.Username;
            usuarioDB.Email = datosNuevos.Email;

            // 3. Guardamos el objeto que ya tiene su Password y Rol intactos
            var exito = _usuarioService.Actualizar(usuarioDB);

            if (exito)
                return Json(new { success = true, message = "Perfil actualizado correctamente" });

            return Json(new { success = false, message = "Error al persistir cambios" });
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            // Llamamos al método real del Service que creamos antes
            bool exito = _usuarioService.Eliminar(id);

            if (exito)
            {
                return Json(new { success = true, message = "Usuario eliminado de la base de datos." });
            }
            else
            {
                return Json(new { success = false, message = "Error: No se pudo eliminar el registro en XAMPP." });
            }
        }
    }
}