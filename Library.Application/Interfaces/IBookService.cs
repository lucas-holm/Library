﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookDetails book);
        void UpdateBook(BookDetails book);
        void DeleteBook(int id);
        BookDetails ShowBookDetails(int? id);
        List<BookDetails> GetAllBooks();
        BookDetails GetBook(int? id);
        List<BookCopy> GetAllBookCopies(int id);
        List<BookCopy> GetAllBookCopies();
        void DeleteCopy(int id);
        BookCopy GetBookCopy(int id);
        BookCopy GetLoanCopy(int id);
        void UpdateCopy(BookCopy copy);
        List<BookDetails> GetAllAvailableBooks();
    }
}
