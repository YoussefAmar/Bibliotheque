using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheque.Models
{
    public class Link
    {
        [Key]
        public int IdLink { get; set; }
        [Required(ErrorMessage = "A username is required")]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "A element is required")]
        public int IdElement { get; set; }
        public DateTime? Done { get; set; }

    }
}