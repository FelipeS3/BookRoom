using MediatR;

namespace BookRoom.Application.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<Unit>
{
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    public int LoanedQuantity { get; set; }
    public int NumberLoanDay { get; set; }
}