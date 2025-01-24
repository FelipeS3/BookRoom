using BookRoom.Application.ViewModels;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Queries.GetLoanById;

public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery,LoanDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLoanByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LoanDetailsViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

        if (loan == null)
        {
            throw new Exception($"Loan with ID {request.Id} not found.");
        }

        var loansDetailsViewModel = new LoanDetailsViewModel(
            loan.Id,
            loan.IdUser,
            loan.IdBook,
            loan.LoanedQuantity,
            loan.LoanDate,
            loan.ExpectedReturnDate,
            loan.ReturnedDate
        );

        return loansDetailsViewModel;
    }
}