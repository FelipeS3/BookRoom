using BookRoom.Core.Entities;

namespace BookRoom.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooks();
    Task<Book> GetDetails(int id);
    Task<Book> GetByIdAsync(int id);
    Task Post(Book book);
    Task UpdateBookAsync(Book book);
}