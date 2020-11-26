using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotheque.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("Bibliotheque")
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}