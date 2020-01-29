using Library.Domain;
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
        /// Updates a book
        /// </summary>
        /// <param name="book"></param>
        void UpdateBookDetails(BookDetails book);


        /// <summary>
        /// Updates a book with new values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        void UpdateBookDetails(int id, BookDetails book);

    }
}
