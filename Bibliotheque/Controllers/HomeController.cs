using System;
using System.Linq;
using System.Web.Mvc;
using Bibliotheque.Models;
using Bibliotheque.ViewModels;

namespace Bibliotheque.Controllers
{
    public class HomeController : Controller
    {
        private readonly BibliothequeViewModel ViewModel = new BibliothequeViewModel();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            //Regarde si user est dans bdd
            var userSearch = ViewModel.UsersVM
                .Users.FirstOrDefault(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password));

            if (userSearch != null)
            {
                //Si user deja connecter
                if (Session["User"] != null)
                {
                    ViewBag.NotValidUser = "You are already logged in";
                    return View();
                } 

                Session["User"] = (User) userSearch; //Session lié au user

                return RedirectToAction("Main");
            }

            else
            {
                ViewBag.NotValidUser = "User does not exist";
                return View();
            }
        }

        public ActionResult Disconnect()
        {
            Session["User"] = null;

            return RedirectToAction("Login");
        }

        //page d'erreur
        [Route("404")] 
        public ActionResult Error()
        {
            return View("Error");
        }

        //page principal
        public ActionResult Main()
        {
            if (Session["User"] != null)
            {
                return View("Main",ViewModel);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}