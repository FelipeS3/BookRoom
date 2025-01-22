using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.DeleteLoan;

public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLoanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

        loan.ReturnedBook();

        await _unitOfWork.LoanRepository.UpdateLoan(loan);

        var book = await _unitOfWork.BookRepository.GetByIdAsync(loan.IdBook);

        book.ReturnedOnHand(loan.LoanedQuantity);

        await _unitOfWork.BookRepository.UpdateBookAsync(book);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}