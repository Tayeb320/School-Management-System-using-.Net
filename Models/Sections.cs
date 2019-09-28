using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Sections
    {
        [Key]
        public int Section_Id { get; set; }
        [Required(ErrorMessage = "Section Name Required")]
        public string Section_Name { get; set; }
    }
}
