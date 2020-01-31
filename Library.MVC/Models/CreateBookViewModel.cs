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
        [Display(Name = "Titel")]
        [MaxLength(7)]
        public string Title { get; set; }
        [Display(Name = "Författare")]
        public SelectList AuthorList { get; set; }
        public Author Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
    }
}
