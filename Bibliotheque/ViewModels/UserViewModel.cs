using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotheque.Models;

namespace Bibliotheque.ViewModels
{
    public class UserViewModel
    {
        private readonly UserContext dbUserContext = new UserContext();
        public IEnumerable<User> Users;

        public UserViewModel()
        {
            Users = dbUserContext.Users.ToList();
            dbUserContext.Dispose();
        }
    }
}