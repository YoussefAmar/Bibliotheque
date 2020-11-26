using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.Models
{
    public class Element
    {
        [Key]
        public int IdElement { get; set; }
        [Required(ErrorMessage = "A category is required")]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

    }
}