using Library.Domain;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            var author1 = new { Id = 1, Name = "William Shakespeare" };
            var author2 = new { Id = 2, Name = "Villiam Skakspjut" };
            var author3 = new { Id = 3, Name = "Robert C. Martin" };

            modelBuilder.Entity<Author>().HasData(author1, author2, author3);

            var details1 = new { Id = 1, AuthorId = author1.Id, Title = "Hamlet", ISBN = "1472518381", Description = "Arguably Shakespeare's greatest tragedy" };
            var details2 = new { Id = 2, AuthorId = author2.Id, Title = "King Lear", ISBN = "9780141012292", Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all." };
            var details3 = new { Id = 3, AuthorId = author3.Id, Title = "Othello", ISBN = "1853260185", Description = "An intense drama of love, deception, jealousy and destruction." };

            modelBuilder.Entity<BookDetails>().HasData(details1, details2, details3);

            var member1 = new Member { Id = 1, SSN = "1234567890", Loans = null, Name = "Kjell Svantesson" };
            var member2 = new Member { Id = 2, SSN = "1122334455", Loans = null, Name = "Maja Svantesson" };
            var member3 = new Member { Id = 3, SSN = "5544332211", Loans = null, Name = "Ola Svantesson" };

            modelBuilder.Entity<Member>().HasData(member1, member2, member3);

            var bookCopy1 = new BookCopy{ Id = 1, DetailsId = details1.Id, Condition = BookCondition.New};
            var bookCopy2 = new BookCopy{ Id = 2, DetailsId = details2.Id, Condition = BookCondition.Used};
            var bookCopy3 = new BookCopy{ Id = 3, DetailsId = details3.Id, Condition = BookCondition.Good};

            modelBuilder.Entity<BookCopy>().HasData(bookCopy1, bookCopy2, bookCopy3);
        }
    }
}
