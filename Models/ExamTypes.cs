using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class ExamTypes
    {
        [Key]
        public int ExamType_Id { get; set; }

        [Required(ErrorMessage = "Exam Type is empty")]
        [MaxLength(20)]
        public string ExamType_Name { get; set; }
    }
}
