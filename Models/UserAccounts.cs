using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class UserAccounts
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "User name is empty")]
        public string Username { get; set; }
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Account type not selected")]
        public string Account_Type { get; set; }
        [Required(ErrorMessage = "User Email is empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password is not match.")]
        public string ComfirmPassword { get; set; }

    }
}
