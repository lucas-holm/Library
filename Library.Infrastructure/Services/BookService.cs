using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext context;

        public BookService(ApplicationDbContext context)
        {
            this.context = context;
        }     

        public void AddBook(BookDetails book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            context.BookDetails.Remove(context.BookDetails.Where(x => x.Id == id).FirstOrDefault());
            context.SaveChanges();
        }

        public void DeleteCopy(int id)
        {
            context.BookCopies.Remove(context.BookCopies.Where(x => x.Id == id).FirstOrDefault());
            context.SaveChanges();
        }

        public List<BookDetails> GetAllAvailableBooks()
        {
             return context.BookDetails.Where(x => x.Copies.Any(x => x.LoanStart == null)).ToList();
        }

        public List<BookCopy> GetAllBookCopies(int id)
        {
            return context.BookCopies.Where(x => x.DetailsId == id).Include(x => x.Details.Author).ToList();
        }

        public List<BookDetails> GetAllBooks()
        {
            return context.BookDetails.Include(x => x.Author).Include(y => y.Copies).ToList();
        }

        public BookDetails GetBook(int? id)
        {
                return context.BookDetails.Where(x => x.Id == id).FirstOrDefault();
        }

        public BookCopy GetBookCopy(int id)
        {
            return context.BookCopies.Where(x => x.Id == id).FirstOrDefault();
        }

        public BookCopy GetLoanCopy(int id)
        {
            return context.BookCopies
                .Where(x => x.DetailsId == id)
                .Include(x => x.Details)
                .ThenInclude(x => x.Author)
                .FirstOrDefault(x => x.LoanStart == null && x.InCart == false); //Behöver check här
        }

        public BookDetails ShowBookDetails(int? id)
        {
            return context.BookDetails.Where(x => x.Id == id).Include(x => x.Author).First();  
        }

        public void UpdateBook(BookDetails book)
        {
            context.Update(book);
            context.SaveChanges();
        }

        public void UpdateCopy(BookCopy copy)
        {
            context.Update(copy);
            context.SaveChanges();
        }
    }
}
