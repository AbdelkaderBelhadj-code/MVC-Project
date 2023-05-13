using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class InviteController : Controller
    {
        // GET: InviteController
        private readonly IServiceInvite invitesrv;

        public InviteController(IServiceInvite _invitesrv)
        {
            invitesrv = _invitesrv;
        }
        public ActionResult Index()
        {
            return View(invitesrv.GetAll().ToList());
        }

        // GET: InviteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InviteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InviteController/Create
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

        // GET: InviteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InviteController/Edit/5
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

        // GET: InviteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InviteController/Delete/5
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
