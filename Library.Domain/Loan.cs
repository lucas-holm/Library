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
                var overdue = (DateTime.Now - LoanEnd).Days;

                var returned = 0;

                if (LoanReturned.HasValue)
                {
                    returned = (LoanReturned.Value - LoanEnd).Days;
                }

                if (overdue >= 0)
                {
                    if(LoanReturned != null)
                    {
                        return (returned * feePerDay) + feePerDay;
                    }
                    if(overdue == 0)
                    {
                        return feePerDay;
                    }
                    else
                    {
                        return (overdue * feePerDay) + feePerDay;
                    }
                }
                return 0;    
            }
        }
    }
}
