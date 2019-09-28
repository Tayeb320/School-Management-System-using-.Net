using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.ViewModel
{
    public class StudentResultViewModel
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string Subject { get; set; }
        public string ExamType { get; set; }
        public string Year { get; set; }
        public int Mark { get; set; }
    }
}
