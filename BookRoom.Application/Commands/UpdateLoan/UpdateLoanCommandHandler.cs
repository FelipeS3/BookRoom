using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLoanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

        if (loan.ReturnedDate == null)
        {
            loan.RenewLoan(request.RenewLoanDay);

            await _unitOfWork.LoanRepository.UpdateLoan(loan);

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("This book already returned.");
        }
        
        return Unit.Value;
    }
}