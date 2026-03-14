using Microsoft.AspNetCore.Mvc;

namespace EsportsArena.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Validamos que el usuario realmente haya pasado por el login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogueado")))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
