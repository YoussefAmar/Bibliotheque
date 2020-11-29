using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotheque.Models;

namespace Bibliotheque.ViewModels
{
    public class LinkViewModel
    {
        private readonly LinkContext dbLinkContext = new LinkContext();
        public IEnumerable<Link> Links;

        public LinkViewModel()
        {
            Links = dbLinkContext.Links.ToList();
            dbLinkContext.Dispose();
        }

    }
}