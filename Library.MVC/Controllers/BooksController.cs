﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Library.MVC.Models;
using Library.Application.Interfaces;

namespace Library.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        //GET: Books
        public IActionResult Index(string sortOrder, string CurrentFilter)
        {
            var vm = new IndexBookViewModel();
            vm.Books = bookService.GetAllBooks();

            vm.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            vm.AuthorSortParam = sortOrder == "Author" ? "author_desc" : "Author";
            vm.CurrentFilter = CurrentFilter;

            if (!String.IsNullOrEmpty(CurrentFilter))
            {
                vm.Books = vm.Books.Where(x => x.Title.ToUpper().Contains(CurrentFilter.ToUpper())
                                       || x.Author.Name.ToUpper().Contains(CurrentFilter.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "title_desc":
                    vm.Books = vm.Books.OrderByDescending(x => x.Title).ToList();
                    break;
                case "Author":
                    vm.Books = vm.Books.OrderBy(x => x.Author.Name).ToList();
                    break;
                case "author_desc":
                    vm.Books = vm.Books.OrderByDescending(x => x.Author.Name).ToList();
                    break;
                default:
                    vm.Books = vm.Books.OrderBy(x => x.Title).ToList();
                    break;
            }

                       
            return View(vm);
            
        }

        //GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = bookService.ShowBookDetails(id);
            if (bookDetails == null)
            {
                return NotFound();
            }

            return View(bookDetails);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var vm = new CreateBookViewModel();
            vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name");
            return View(vm);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookViewModel vm)
        {
            if (ModelState.IsValid)
            {

                var newBook = new BookDetails();
                vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name");

                newBook.Author = authorService.GetAuthor(vm.Author.Id);
                newBook.Description = vm.Description;
                newBook.Title = vm.Title;
                newBook.ISBN = vm.ISBN;

                for (int i = 0; i < vm.NumberOfCopies; i++)
                {
                    newBook.Copies.Add(new BookCopy());
                }
                bookService.AddBook(newBook);

                //Visa /Books/Index
                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction("Error", "Home", "");
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = bookService.ShowBookDetails(id);
            var vm = new EditBookViewModel();

            vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name");
            vm.Author = bookDetails.Author;
            vm.BookDetailsId = bookDetails.Id;
            vm.ISBN = bookDetails.ISBN;
            vm.Title = bookDetails.Title;
            vm.Description = bookDetails.Description;

            if (bookDetails == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditBookViewModel vm)
        {
            var bookDetails = bookService.ShowBookDetails(id);

            bookDetails.AuthorId = vm.AuthorId;
            bookDetails.Description = vm.Description;
            bookDetails.ISBN = vm.ISBN;
            bookDetails.Title = vm.Title;
            
            bookService.UpdateBook(bookDetails);
                                 
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = bookService.ShowBookDetails(id);
            var vm = new DeleteBookViewModel();
            vm.Author = bookDetails.Author;
            vm.Title = bookDetails.Title;
            vm.ISBN = bookDetails.ISBN;
            vm.Description = bookDetails.Description;

            if (bookDetails == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bookDetails = bookService.GetBook(id);
            if (bookDetails.Copies.Any(x => x.LoanStart == null))
            {
            bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
            }
            return View("BookUnavaliable");
        }

        public IActionResult CopyInfo(int id)
        {
            var vm = new CopyInfoViewModel();
            vm.Copies = bookService.GetAllBookCopies(id);
            vm.BookDetailsId = id;

            return View(vm);
        }

        public IActionResult AuthorInfo(int id)
        {
            var vm = new AuthorInfoViewModel();

            var author = authorService.GetAuthor(id);
            vm.Name = author.Name;
            vm.Books = author.Books;

            return View(vm);
        }

        public IActionResult CreateCopy(int id)
        {
            var vm = new CreateCopyViewModel();
            var bookDetails = bookService.GetBook(id);
            vm.BookDetailsId = bookDetails.Id;
            
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCopy(CreateCopyViewModel vm)
        {
            var bookDetails = bookService.GetBook(vm.BookDetailsId);
            
            for (int i = 0; i < vm.NumberOfCopies; i++)
            {
                bookDetails.Copies.Add(new BookCopy());
            }

            bookService.UpdateBook(bookDetails);

            return RedirectToAction(nameof(CopyInfo), new { id = vm.BookDetailsId });
        }

        public IActionResult DeleteCopy(int id)
        {
            var vm = new DeleteCopyViewModel();
            var copy = bookService.GetBookCopy(id);
            
            vm.BookStatus = copy.BookStatus;
            vm.Condition = copy.Condition;
            vm.Id = id;

            return View(vm);
        }

        [HttpPost, ActionName("DeleteCopy")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCopyConfirmed(int id)
        {
            var bookCopy = bookService.GetBookCopy(id);
            if(bookCopy.BookStatus != Domain.Enums.BookStatus.Out)
            {
                bookService.DeleteCopy(id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("BookUnavaliable");
            }
        }
    }
}
