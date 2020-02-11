using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class IndexBookViewModel
    {
        public string CurrentFilter { get; set; }
        public ICollection<BookDetails> Books { get; set; } = new List<BookDetails>();
        public string AuthorSortParam { get; internal set; }
        public string TitleSortParam { get; internal set; }
    }
}
