using Library.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.Loans
{
    public class CreateLoanViewModel
    {
        public Member Member { get; set; }
        public SelectList MemberList { get; set; }
        public SelectList BookDetailsList { get; set; }
        public BookDetails BookDetails { get; set; }

    }
}

