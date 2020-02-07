using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ILoanService loanService;
        private readonly IMemberService memberService;

        public APIController(
            IBookService bookService, 
            IAuthorService authorService, 
            ILoanService loanService, 
            IMemberService memberService)

        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.loanService = loanService;
            this.memberService = memberService;
        }




    }
}