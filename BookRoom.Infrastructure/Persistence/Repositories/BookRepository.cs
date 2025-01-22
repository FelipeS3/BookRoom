using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookRoom.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookRoomDbContext _context;

    public BookRepository(BookRoomDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books
            .Include(b => b.Title)
            .Include(b => b.Author)
            .Include(b => b.YearPublication)
            .ToListAsync();
    }

    public async Task<Book> GetDetails(int id)
    {
        return await _context.Books
            .Include(b => b.Title)
            .Include(b => b.Author)
            .Include(b => b.YearPublication)
            .Include(b => b.LoanQuantity)
            .Include(b=>b.Status)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Post(Book book)
    {
        await _context.Books.AddAsync(book);
        _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChangesAsync();
    }
}