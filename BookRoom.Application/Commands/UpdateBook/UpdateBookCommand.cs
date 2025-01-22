using MediatR;

namespace BookRoom.Application.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int YearPublication { get; private set; }
    public int AddedQuantity { get; set; }
    public int DecreseadQuantity { get; set; }
}