using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Results
    {
        [Key]
        public int Result_Id { get; set; }
        [Required(ErrorMessage = "Student Id Required")]
        public int Student_Id { get; set; }
        [Required(ErrorMessage = "Class Id Required")]
        public int Class_Id { get; set; }
        [Required(ErrorMessage = "Section Id Required")]
        public int Section_Id { get; set; }
        [Required(ErrorMessage = "Subject Id Required")]
        public int Subject_Id { get; set; }
        [Required(ErrorMessage = "Exam Id Required")]
        public int ExamType_Id { get; set; }
        [Required(ErrorMessage = "Please Input Mark")]
        public int Mark { get; set; }
        [Required(ErrorMessage = "Please Input Year")]
        public string Year { get; set; }

        public Classes Class { get; set; }
        public Sections Section { get; set; }
        public ExamTypes ExamType { get; set; }
        public Subjects Subject { get; set; }
    }
}
