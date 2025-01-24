using BookRoom.Application.ViewModels;
using MediatR;

namespace BookRoom.Application.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<BookDetailsViewModel>
{
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}