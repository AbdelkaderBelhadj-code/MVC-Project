using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class FeteController : Controller
    {
        private readonly IServiceFete fetesrv;
        private readonly IServiceSalle sallesrv;
        // GET: FeteController

        public FeteController(IServiceFete _fetesrv, IServiceSalle _sallesrv)
        {
            fetesrv = _fetesrv;
            sallesrv = _sallesrv;
        }
        public ActionResult Index(DateTime? dateFete)
        {
            if (dateFete == null)
            {
                return View(fetesrv.GetAll().OrderByDescending(f => f.DateFete).ToList());
            }
            else
            {

                return View(fetesrv.GetfeteByDate(((DateTime)dateFete)));
            }
        }

        // GET: FeteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeteController/Create
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

        // GET: FeteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeteController/Edit/5
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

        // GET: FeteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeteController/Delete/5
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
