using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class DeleteBookViewModel
    {
        public int BookDetailsId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }

    }
}
