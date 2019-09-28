using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Subjects
    {
        [Key]
        public int Subject_Id { get; set; }
        [Required(ErrorMessage = "Subject Name Required")]
        [MaxLength(50)]
        public string Subject_Name { get; set; }
    }
}
