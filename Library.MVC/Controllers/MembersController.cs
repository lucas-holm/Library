using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models;
using Library.MVC.Models.Loans;
using Library.MVC.Models.Members;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IBookService bookService;


        public MembersController(IMemberService memberService, IBookService bookService)
        {
            this.memberService = memberService;
            this.bookService = bookService;

        }
        // GET: Members
        public ActionResult Index()
        {
            var vm = new IndexMemberViewModel();
            vm.Members = memberService.GetAllMembers();

            return View(vm);
        }

        // GET: Members/Details/5
        public ActionResult Details(int id)
        {
            var vm = new DetailsMemberViewModel();
            var member = memberService.GetMember(id);
            vm.Id = member.Id;
            vm.SSN = member.SSN;
            vm.Name = member.Name;
            vm.Loans = member.Loans;

            return View(vm);
        }

        // GET: Members/Create
        public ActionResult CreateMember()
        {
            var vm = new CreateMemberViewModel();
            return View(vm);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMember(CreateMemberViewModel vm)
        {
            try
            {
                // TODO: Add insert logic here
                var member = new Member();
                member.Name = vm.Name;
                member.SSN = vm.SSN;

                memberService.AddMember(member);
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateLoan(int id)
        {
            var vm = new CreateLoanViewModel();
            vm.MemberId = id;
            vm.BookDetailsList = new SelectList(bookService.GetAllBooks(), "Id", "Title");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLoan(CreateLoanViewModel vm)
        {

            var loan = new Loan();
            //vm.BookDetailsList = new SelectList(bookService.GetAllBooks(), "Id", "Title");
            var member = memberService.GetMember(vm.MemberId);
            
            var copy = bookService.GetLoanCopy(vm.BookDetails.Id);
            loan.BookCopy = copy;
            loan.Member = member;


            member.Loans.Add(loan);

            memberService.UpdateMember(member);


            return RedirectToAction(nameof(Index));
        }
    }
}