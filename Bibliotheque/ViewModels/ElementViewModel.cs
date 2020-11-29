using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotheque.Models;

namespace Bibliotheque.ViewModels
{
    public class ElementViewModel
    {

        private readonly ElementContext dbElementContext = new ElementContext();
        public IEnumerable<Element> Elements;

        public ElementViewModel()
        {
            Elements = dbElementContext.Elements.ToList();
            dbElementContext.Dispose();
        }

    }
}