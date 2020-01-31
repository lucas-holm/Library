﻿using Library.Domain.Enums;
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
        
    }
}