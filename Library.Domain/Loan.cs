using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public DateTime? LoanReturned { get; set; }
        public int Fee
        {
            get
            {
                var feePerDay = 12;

                var daysOverdue = (LoanReturned.HasValue)
                    ? (LoanReturned.Value - LoanEnd).Days 
                    : (DateTime.Today - LoanEnd).Days;

                var fee = (daysOverdue >= 1) ? (daysOverdue * feePerDay) : 0;

                return fee;
            }
        }
    }
}