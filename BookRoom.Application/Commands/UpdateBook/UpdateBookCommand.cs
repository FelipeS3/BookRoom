using MediatR;

namespace BookRoom.Application.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int YearPublication { get; set; }
}