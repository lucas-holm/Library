﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Adds the book to the database
        /// </summary>
        /// <param name="book"></param>
        void AddBook(BookDetails book);

        /// <summary>
        /// Updates the database with the edited book
        /// </summary>
        /// <param name="book"></param>
        void UpdateBook(BookDetails book);
        void DeleteBook(int id);
        BookDetails ShowBookDetails(int? id);

        List<BookDetails> GetAllBooks();
        BookDetails GetBook(int? id);

    }
}
