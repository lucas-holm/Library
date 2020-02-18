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
        public IActionResult CreateLoan()
        {
            var vm = new CreateLoanViewModel();

            vm.BookDetailsList = new SelectList(bookService.GetAllAvailableBooks(), "Id", "Title");
            vm.MemberList = new SelectList(memberService.GetAllMembers(), "Id", "Name");
            vm.Members = memberService.GetAllMembers();

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLoan(CreateLoanViewModel vm)
        {

            vm.Members = memberService.GetAllMembers();
            var date = DateTime.Today;


            foreach (var member in vm.Members)
            {
                if (member.ShoppingCart != null)
                {
                    foreach (var copy in member.ShoppingCart.Copies.ToList())
                    {   
                        var newLoan = new Loan();
                        
                        copy.InCart = false;
                        
                        newLoan.BookCopy = copy;
                        newLoan.BookCopy.LoanStart = date;
                        newLoan.Member = member;
                        newLoan.LoanStart = date;
                        newLoan.LoanEnd = date.AddDays(14);

                        member.ShoppingCart.Copies.Remove(copy);
                        member.Loans.Add(newLoan);
                    }

                    member.ShoppingCart = null;
                    memberService.UpdateMember(member);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddLoan(CreateLoanViewModel vm)
        {

            var member = memberService.GetMember(vm.Member.Id);
            var copy = bookService.GetLoanCopy(vm.BookDetails.Id);
            if (member.ShoppingCart == null)
            {
                member.ShoppingCart = new ShoppingCart();
            }

            copy.InCart = true;
            member.ShoppingCart.Copies.Add(copy);

            memberService.UpdateMember(member);

            return RedirectToAction(nameof(CreateLoan));
        }
    }
}