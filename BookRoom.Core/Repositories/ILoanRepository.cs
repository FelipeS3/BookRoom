using BookRoom.Core.Entities;

namespace BookRoom.Core.Repositories;

public interface ILoanRepository
{
    Task<List<Loan>> GetAll();
    Task<Loan> GetByIdAsync(int id);
    Task AddLoan(Loan loan);
    Task UpdateLoan(Loan loan);
    Task<Loan?>GetActiveLoanByUserAsync(int userId);
}