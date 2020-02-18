using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface ILoanService
    {
        public List<Loan> GetAllLoans();
        public Loan GetLoan(int id);
        public void UpdateLoan(Loan loan);
    }
}
