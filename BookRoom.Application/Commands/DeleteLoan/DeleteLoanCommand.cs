using MediatR;

namespace BookRoom.Application.Commands.DeleteLoan;

public class DeleteLoanCommand : IRequest<Unit>
{
    public DeleteLoanCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}