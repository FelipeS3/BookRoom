using System.Security.Cryptography.X509Certificates;
using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookRoom.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly BookRoomDbContext _context;

    public LoanRepository(BookRoomDbContext context)
    {
        _context = context;
    }

    public async Task<List<Loan>> GetAll()
    {
        return await _context.Loans
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Loan> GetByIdAsync(int id)
    {
        return await _context.Loans.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddLoan(Loan loan)
    {
        await _context.Loans.AddAsync(loan);
    }

    public async Task UpdateLoan(Loan loan)
    {
        _context.Loans.Update(loan);
    }

    public async Task<Loan?> GetActiveLoanByUserAsync(int userId)
    {
        return await _context.Loans.FirstOrDefaultAsync(x => x.IdUser == userId && x.ReturnedDate == null);
    }
}