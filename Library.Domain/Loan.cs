using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }
        public DateTime LoanStart { get; set; }
        public DateTime LoanEnd { get; set; }
    }
}
