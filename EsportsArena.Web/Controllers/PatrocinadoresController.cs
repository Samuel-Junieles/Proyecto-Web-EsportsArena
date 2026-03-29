using Microsoft.AspNetCore.Mvc;

namespace EsportsArena.Web.Controllers
{
    public class PatrocinadoresController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}