using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportsArena.Web.Controllers
{
    public class TorneosController : Controller
    {
        // GET: TorneosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TorneosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TorneosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TorneosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TorneosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TorneosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TorneosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TorneosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
