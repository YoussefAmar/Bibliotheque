using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "A title is required")]
        public string Title { get; set; }

    }
}