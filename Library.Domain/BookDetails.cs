using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();

    }
}
