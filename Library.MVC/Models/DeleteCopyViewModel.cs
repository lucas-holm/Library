using Library.Domain;
using Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class DeleteCopyViewModel
    {

        public int Id { get; set; }
        public BookCondition Condition { get; set; }
        public BookStatus BookStatus { get; set; }
    }
}
