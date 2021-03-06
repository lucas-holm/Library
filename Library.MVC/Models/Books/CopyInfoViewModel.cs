﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class CopyInfoViewModel
    {
        public int BookDetailsId { get; set; }
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();
    }
}
