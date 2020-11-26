using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotheque.Models
{
    public class LinkContext : DbContext
    {
        public LinkContext() : base("Bibliotheque")
        {

        }

        public DbSet<Link> Links { get; set; }

    }
}