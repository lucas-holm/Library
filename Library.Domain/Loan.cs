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
        public DateTime? LoanReturned { get; set; }
        public int Fee
        {
            get
            {
                var feeTotal = 0;
                var feeIncrease = 12;
                var daysDelayed = (DateTime.Now - LoanEnd).Days;

                if(daysDelayed >= 0)
                {
                    if(daysDelayed == 0)
                    {
                        return 12;
                    }
                    feeTotal = daysDelayed * feeIncrease;
                }
                return feeTotal;    
            }
        }
    }
}
