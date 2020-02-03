using Library.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class EditBookViewModel
    {
        public int BookDetailsId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public SelectList AuthorList { get; set; }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
    }
}
