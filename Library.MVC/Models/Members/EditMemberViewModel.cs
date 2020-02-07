using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.Members
{
    public class EditMemberViewModel
    {
        public int MemberId { get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
