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
            .ToListAsync();
    }

    public async Task<Book> GetDetails(int id)
    {
        return await _context.Books
            .Include(b => b.Loans)
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id); ;
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Post(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
    }
}