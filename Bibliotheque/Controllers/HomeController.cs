using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bibliotheque.Models;

namespace Bibliotheque.Controllers
{
    public class HomeController : Controller
    {

        private UserContext db = new UserContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var obj = db.Users.FirstOrDefault(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password));

            if (obj != null)
            {

                if (Session["IdUser"] != null)
                {
                    ViewBag.NotValidUser = "You are already logged in";
                    return View();
                }

                Session["IdUser"] = obj.IdUser;
                Session["Name"] = obj.Name;

                return RedirectToAction("Main");
            }
            else
            {
                ViewBag.NotValidUser = "User does not exist";
                return View();
            }
        }

        // GET: Home
        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult Main()
        {
            if (Session["IdUser"] != null)
            {
                ViewBag.Id = Session["IdUser"];
                ViewBag.Name = Session["Name"];

                return View("Main");
            }
            else
            {
                ViewBag.NotValidUser = "You are not logged in";
                return View("Login");
            }
        }

    }
}