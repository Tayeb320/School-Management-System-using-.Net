using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Admission
    {
        [Key]
        public Int32 StudentId { get; set; }

        [Required(ErrorMessage = "Class name is empty"),]
        public string Class { get; set; }

        [Required(ErrorMessage = "Student name is empty"), MaxLength(50)]
        public string StudentNameBan { get; set; }

        [Required(ErrorMessage = "Student name is empty"), MaxLength(50)]
        public string StudentNameEng { get; set; }

        [Required(ErrorMessage = "Father name is empty"), MaxLength(50)]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Mother name is empty"), MaxLength(50)]
        public string MotherName { get; set; }

        public string Guardian { get; set; }

        [Required(ErrorMessage = "Permanent Village is empty"), MaxLength(50)]
        public string PerVill { get; set; }

        [Required(ErrorMessage = "Post name is empty"), MaxLength(50)]
        public string PerPost { get; set; }

        [Required(ErrorMessage = "Upozila name is empty"), MaxLength(50)]
        public string PerZila { get; set; }

        [Required(ErrorMessage = "Present Village is empty"), MaxLength(50)]
        public string PreVill { get; set; }

        [Required(ErrorMessage = "Present Post name is empty"), MaxLength(50)]
        public string PrePost { get; set; }

        [Required(ErrorMessage = "Present Upozila name is empty"), MaxLength(50)]
        public string PreZila { get; set; }

        [Required(ErrorMessage = "BirthDate is empty")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Religion is empty"), MaxLength(50)]
        public string Religion { get; set; }

        [Required(ErrorMessage = "LastSchool name is empty"), MaxLength(100)]
        public string LastSchool { get; set; }

        [Required(ErrorMessage = "GuardianDetails is empty"), MaxLength(80)]
        public string GuardianDetails { get; set; }

        [Required(ErrorMessage = "Contact is empty"), MaxLength(15)]
        public string Contact { get; set; }
    }
}
