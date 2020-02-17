using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<BookCopy> Copies { get; set; } = new List<BookCopy>();
    }
}
