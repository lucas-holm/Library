using Library.Domain;
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
            //ConfigureBookDetails(modelBuilder);
            //ConfigureAuthor(modelBuilder);
            //ConfigureBook(modelBuilder);
            //ConfigureLoan(modelBuilder);
            //ConfigureMember(modelBuilder);

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            var author1 = new { Id = 1, Name = "William Shakespeare"};
            var author2 = new { Id = 2, Name = "Villiam Skakspjut"};
            var author3 = new { Id = 3, Name = "Robert C. Martin"};
            
            modelBuilder.Entity<Author>().HasData(author1, author2, author3);

            var details1 = new { Id = 1, AuthorId = author1.Id, Title = "Hamlet", ISBN = "1472518381", Description = "Arguably Shakespeare's greatest tragedy"};
            var details2 = new { Id = 2, AuthorId = author2.Id, Title = "King Lear", ISBN = "9780141012292", Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all." };
            var details3 = new { Id = 3, AuthorId = author3.Id, Title = "Othello", ISBN = "1853260185", Description = "An intense drama of love, deception, jealousy and destruction." };


            modelBuilder.Entity<BookDetails>().HasData(details1, details2, details3);

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, SSN = "1234567890", Loans = null, Name = "Kjell Svantesson" },
                new Member { Id = 2, SSN = "1122334455", Loans = null, Name = "Maja Svantesson" },
                new Member { Id = 3, SSN = "5544332211", Loans = null, Name = "Ola Svantesson" }
            );

            var bookCopy1 = new { Id = 1, DetailsId = details1.Id };
            var bookCopy2 = new { Id = 2, DetailsId = details2.Id };
            var bookCopy3 = new { Id = 3, DetailsId = details3.Id };
            modelBuilder.Entity<BookCopy>().HasData(bookCopy1, bookCopy2, bookCopy3);
        }

        private void ConfigureMember(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void ConfigureLoan(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void ConfigureBook(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private static void ConfigureAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(55);
        }

        //private static void ConfigureBookDetails(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookDetails>().HasKey(x => x.Id);
        //    modelBuilder.Entity<BookDetails>()
        //        .HasOne(x => x.Author)
        //        .WithMany(a => a.Books)
        //        .HasForeignKey(x => new { x.Author, x.Id });
        //}
    }
}
