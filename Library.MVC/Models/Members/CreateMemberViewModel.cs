using Library.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class CreateMemberViewModel
    {
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid number.")]
        public string SSN { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
