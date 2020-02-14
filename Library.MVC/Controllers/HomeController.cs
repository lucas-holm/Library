using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.MVC.Models;
using Library.Domain;
using Library.Application.Interfaces;

namespace Library.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoanService loanService;
        private readonly IMemberService memberService;

        public HomeController(ILogger<HomeController> logger, ILoanService loanService, IMemberService memberService)
        {
            _logger = logger;
            this.loanService = loanService;
            this.memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
         
        }

        public IActionResult JsonTest()
        {

            var allLoans = loanService.GetAllLoans();

            var loansNotReturned = allLoans.Where(x => x.LoanReturned == null).Count();
            var loansOverdue = allLoans.Where(x => x.Fee > 0).Count();
            var members = memberService.GetAllMembers().Count();

            return Json(new
            {
                loansNotReturned,
                loansOverdue,
                members
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
