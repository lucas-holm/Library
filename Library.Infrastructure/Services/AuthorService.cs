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
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext context;
        public AuthorService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IList<Author> GetAllAuthors()
        {
            return context.Authors.OrderBy(x => x.Name).ToList();
        }

        public Author GetAuthor(int id)
        {
            return context.Authors.Where(x => x.Id == id).Include(x => x.Books).FirstOrDefault();
        }
    }
}
