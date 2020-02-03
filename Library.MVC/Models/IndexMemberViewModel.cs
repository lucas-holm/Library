using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class IndexMemberViewModel
    {
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
