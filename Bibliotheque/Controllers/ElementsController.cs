using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bibliotheque.Models;
using Bibliotheque.ViewModels;

namespace Bibliotheque.Controllers
{
    public class ElementsController : Controller
    {
        private ElementContext db = new ElementContext();
        private readonly BibliothequeViewModel ViewModel = new BibliothequeViewModel();

        // GET: Elements
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View(db.Elements.ToList());
        }

        // GET: Elements/Details/5
        [NoDirectAccess]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // GET: Elements/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdElement,IdCategory,Content")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Elements.Add(element);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(element);
        }

        // GET: Elements/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Elements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdElement,IdCategory,Content")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(element);
        }

        // GET: Elements/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Elements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Element element = db.Elements.Find(id);
            db.Elements.Remove(element);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult List(string id)
        {

            Int32.TryParse(id, out var CatTemp);

            var elementlist = ViewModel.ElemsVM.Elements.Where(e => e.IdCategory.Equals(CatTemp));

            return PartialView("Index", elementlist);
            
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
