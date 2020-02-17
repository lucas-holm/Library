using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Library.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LoanStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LoanEnd { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
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