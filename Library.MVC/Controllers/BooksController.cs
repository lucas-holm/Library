using System;
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
        public IActionResult Index()
        {
            var vm = new IndexBookViewModel();
            vm.Books = bookService.GetAllBooks();
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

                //Skapa ny bok
                var newBook = new BookDetails();
                vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name");
                newBook.Author = authorService.GetAuthor(vm.Author.Id);
                newBook.Description = vm.Description;
                newBook.Title = vm.Title;
                newBook.ISBN = vm.ISBN;
                //Lägg till i contex
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ISBN,AuthorID,Description")] BookDetails bookDetails)
        //{
        //    if (id != bookDetails.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bookDetails);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookDetailsExists(bookDetails.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AuthorID"] = new SelectList(_context.Authors, "Id", "Id", bookDetails.AuthorId);
        //    return View(bookDetails);
        //}

        // GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookDetails = await _context.BookDetails
        //        .Include(b => b.Author)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bookDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bookDetails);
        //}

        // POST: Books/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var bookDetails = await _context.BookDetails.FindAsync(id);
        //        _context.BookDetails.Remove(bookDetails);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool BookDetailsExists(int id)
        //    {
        //        return _context.BookDetails.Any(e => e.Id == id);
        //    }
    }
}
