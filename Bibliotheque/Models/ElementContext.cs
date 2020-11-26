using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotheque.Models
{
    public class ElementContext : DbContext
    {
        public ElementContext() : base("Bibliotheque")
        {

        }

        public DbSet<Element> Elements { get; set; }

    }
}