using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using AM.ApplicationCore.Domain;
using System.Net.Sockets;

namespace AM.UI.WEB.Controllers
{
    public class InvitationController : Controller
    {
        // GET: InvitationController

        private readonly IServiceInvitation invitationsrv;
        private readonly IServiceInvite invitesrv;
        private readonly IServiceFete fetesrv;

        public InvitationController(IServiceInvitation _invitationsrv, IServiceInvite _invitesrv, IServiceFete _fetesrv)
        {
            invitationsrv = _invitationsrv;
            invitesrv = _invitesrv;
            fetesrv = _fetesrv;
        }
        public ActionResult Index()
        {
            return View(invitationsrv.GetAll().ToList());
        }

        // GET: InvitationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvitationController/Create
        public ActionResult Create()
        {
            ViewBag.InviteFk = new SelectList(invitesrv.GetAll(), "IdInvite", "Prenom");
            ViewBag.FeteFk = new SelectList(fetesrv.GetAll(), "IdFete", "Description");
            return View();
        }

        // POST: InvitationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invitation invitation)
        {
            try
            {
                invitationsrv.Add(invitation);
                invitationsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvitationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvitationController/Edit/5
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

        // GET: InvitationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvitationController/Delete/5
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
