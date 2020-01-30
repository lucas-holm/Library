﻿using Library.Application.Interfaces;
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

        public List<BookDetails> GetAllBooks()
        {
            return context.BookDetails.Include(x => x.Author).ToList();
        }


        public BookDetails ShowBookDetails(int? id)
        {
            return context.BookDetails.Where(x => x.Id == id).Include(x => x.Author).First();  
        }
    }
}
