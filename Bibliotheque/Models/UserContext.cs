using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotheque.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Bibliotheque")
        {

        }

        public DbSet<User> Users { get; set; }

    }
}