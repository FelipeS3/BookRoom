using BookRoom.Core.Entities;
using BookRoom.Core.Enum;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateLoanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.IdBook);

        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.IdUser);

        if (user is null || book is null)
            throw new Exception("User or book do not exist!");
        

        if (book.Status == BookStatusEnum.Unavailable)
            throw new ArgumentException("This book is unavailable for a loan.");
        

        if (request.LoanedQuantity > 1)
            throw new Exception("Only one book can be borrowed!");


        if (request.NumberLoanDay > 7)
            throw new Exception("The number of loan days cannot exceed 7 days.");


        var loan = new Loan(request.IdUser, request.IdBook);
        loan.ExpectedReturnedDate(request.NumberLoanDay);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // Adicionar empréstimo no repositório
            await _unitOfWork.LoanRepository.AddLoan(loan);

            // Reduzir quantidade do livro
            book.DecreaseOnHand(request.LoanedQuantity);
            await _unitOfWork.BookRepository.UpdateBookAsync(book);

            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
        }
        
        return Unit.Value;
    }
}