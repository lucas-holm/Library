using Library.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Display(Name = "Authors")]
        public SelectList AuthorList { get; set; }
        public Author Author { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid number.")]
        public string ISBN { get; set; }
        [Required]
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
    }
}
