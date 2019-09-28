using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Classes
    {
        [Key]
        public int Class_Id { get; set; }
        [Required(ErrorMessage = "Class Name Required")]
        public string Class_Name { get; set; }
    }
}
