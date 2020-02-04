using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.Members
{
    public class DetailsMemberViewModel
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
