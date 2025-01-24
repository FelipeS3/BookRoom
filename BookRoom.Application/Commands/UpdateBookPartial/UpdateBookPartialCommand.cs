using MediatR;

namespace BookRoom.Application.Commands.UpdateBookPartial;

public class UpdateBookPartialCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int AddedQuantity { get; set; }
    public int DecreseadQuantity { get; set; }
}