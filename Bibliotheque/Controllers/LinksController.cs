using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bibliotheque.Models;
using Bibliotheque.ViewModels;

namespace Bibliotheque.Controllers
{
    public class LinksController : Controller
    {
        private LinkContext db = new LinkContext();
        private BibliothequeViewModel vm = new BibliothequeViewModel();

        [NoDirectAccess]
        public ActionResult Index_Partial(int? id)
        {
            var userSearch = (User)Session["User"];

            IEnumerable<Link> Links = db.Links.Where(l => l.IdUser == userSearch.IdUser && id == l.IdElement).ToList();

            return PartialView("Index_Partial", Links);
        }

        [NoDirectAccess]
        public ActionResult Create()
        {
            var userSearch = (User) Session["User"];

            if (TempData["IdElement"] != null && userSearch != null)
            {
                db.Links.Add(new Link { Done = DateTime.Now, IdUser = userSearch.IdUser, IdElement = (int) TempData["IdElement"] });
                db.SaveChanges();
            }
                
            return RedirectToAction("Main", "Home");
        }

        [NoDirectAccess]
        public ActionResult Details()
        {
            TempData["Userlist"] = vm.UsersVM.Users.ToList();

            TempData["Element"] = vm.ElemsVM.Elements.FirstOrDefault(e => e.IdElement == (int) TempData["IdElement"])?.Content;

            return View("Details", vm);
        }

        [NoDirectAccess]
        public ActionResult Delete()
        {
            var userSearch = (User)Session["User"];

            if (TempData["IdElement"] != null && userSearch != null)
            {
                var link = (db.Links.AsEnumerable() 
                            ?? Array.Empty<Link>())
                    .LastOrDefault(l => l.IdUser == userSearch.IdUser && l.IdElement == (int) TempData["IdElement"]);

                if (link != null)
                {
                    db.Links.Remove(link);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Main", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}