using Library.Domain.Enums;
using System;

namespace Library.Domain
{
    public class BookCopy
    {
        public int Id { get; set; }
        public BookCondition Condition { get; set; }
        public int DetailsId { get; set; }
        public BookDetails Details { get; set; }
        public DateTime? LoanStart { get; set; }
        public bool InCart { get; set; } = false;
        public BookStatus BookStatus {
            get
            {
                if (LoanStart == null && InCart == false)
                {
                    return BookStatus.In;
                }

                return BookStatus.Out;
            }
        }            
    }
}