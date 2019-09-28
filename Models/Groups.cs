using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class Groups
    {
        [Key]
        public int Group_Id { get; set; }
        [Required(ErrorMessage = "Group Name Required")]
        public string Group_Name { get; set; }
    }
}
