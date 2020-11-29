using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotheque.Models;

namespace Bibliotheque.ViewModels
{
    public class CategoryViewModel
    {
        private readonly CategoryContext dbCategoryContext = new CategoryContext();
        public IEnumerable<Category> Categories;

        public CategoryViewModel()
        {
            Categories = dbCategoryContext.Categories.ToList();
            dbCategoryContext.Dispose();
        }

    }
}