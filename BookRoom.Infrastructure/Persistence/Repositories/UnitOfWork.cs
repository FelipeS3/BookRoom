using BookRoom.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookRoom.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookRoomDbContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(BookRoomDbContext context, IBookRepository bookRepository, 
        ILoanRepository loanRepository, IUserRepository userRepository)
    {
        _context = context;
        
        BookRepository = bookRepository;
        LoanRepository = loanRepository;
        UserRepository = userRepository;
    }

    public IBookRepository BookRepository { get; }
    public ILoanRepository LoanRepository { get; }
    public IUserRepository UserRepository { get; }


    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    } 

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }

        catch(Exception ex)
        {
            await _transaction.RollbackAsync();
            throw ex;
        }

    }
    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }
}