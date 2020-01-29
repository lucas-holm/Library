using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
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
    }
}
