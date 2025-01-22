using MediatR;

namespace BookRoom.Application.Commands.DeleteBook;

public class DeleteBookCommand : IRequest<Unit>
{
    public DeleteBookCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}