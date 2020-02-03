using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public AuthorsController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            var vm = new IndexAuthorViewModel();
            vm.Authors = authorService.GetAllAuthors();
            return View(vm);
        }
        public IActionResult CreateAuthor()
        {
            var vm = new CreateAuthorViewModel();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAuthor(CreateAuthorViewModel vm)
        {
            var author = new Author();
            author.Name = vm.Name;
            authorService.AddAuthor(author);

            return RedirectToAction(nameof(Index));
        }
    }
}
