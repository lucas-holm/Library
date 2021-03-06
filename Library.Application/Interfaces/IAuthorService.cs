﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        IList<Author> GetAllAuthors();
        Author GetAuthor(int id);
        void AddAuthor(Author author);

    }
}
