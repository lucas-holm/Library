using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models.Loans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.MVC.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILoanService loanService;
        private readonly IBookService bookService;
        private readonly IMemberService memberService;

        public LoansController(ILoanService loanService, IBookService bookService, IMemberService memberService)
        {
            this.loanService = loanService;
            this.bookService = bookService;
            this.memberService = memberService;
        }
        public IActionResult Index()
        {
            var vm = new IndexLoanViewModel();

            vm.Loans = loanService.GetAllLoans();
            


            return View(vm);
        }


        
    }
}