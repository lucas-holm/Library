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
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext context;
        public LoanService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Loan> GetAllLoans()
        {
            return context.Loans.Include(x => x.Member).Include(x => x.BookCopy).ThenInclude(x => x.Details).ToList();
        }

        public Loan GetLoan(int id)
        {
            return context.Loans.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateLoan(Loan loan)
        {
            context.Update(loan);
            context.SaveChanges();
        }
    }
}
