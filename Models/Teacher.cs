using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Actor Type is required")]
        public string Teacher_Name { get; set; }
        [MaxLength(40)]
        public String Designation { get; set; }
        public int Contact { get; set; }
    }
}
