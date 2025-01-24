using BookRoom.Application.ViewModels;
using MediatR;

namespace BookRoom.Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<List<BookViewModel>>
{
    
}