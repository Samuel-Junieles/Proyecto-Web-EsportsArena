using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportsArena.Web.Controllers
{
    public class EncuentrosController : Controller
    {
        // GET: EncuentrosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EncuentrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EncuentrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncuentrosController/Create
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

        // GET: EncuentrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EncuentrosController/Edit/5
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

        // GET: EncuentrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EncuentrosController/Delete/5
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
