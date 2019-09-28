using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Actors
    {
        [Key]
        public int Actor_Id { get; set; }
        [Required(ErrorMessage = "Actor Type is required")]
        public string Actor_Type { get; set; }
    }
}
