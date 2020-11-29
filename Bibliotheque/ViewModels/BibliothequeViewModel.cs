using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotheque.Models;

namespace Bibliotheque.ViewModels
{
    public class BibliothequeViewModel
    {
        public readonly UserViewModel UsersVM;
        public readonly CategoryViewModel CatsVM;
        public readonly LinkViewModel LinksVM;
        public readonly ElementViewModel ElemsVM;

        public BibliothequeViewModel()
        {
           UsersVM = new UserViewModel();
           CatsVM = new CategoryViewModel();
           LinksVM = new LinkViewModel();
           ElemsVM = new ElementViewModel();
        }
    }
}