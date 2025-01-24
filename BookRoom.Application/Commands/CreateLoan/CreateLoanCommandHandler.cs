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
        var activeLoan = await _unitOfWork.LoanRepository.GetActiveLoanByUserAsync(request.IdUser);

        if (user is null)
            throw new Exception($"User with ID {request.IdUser} does not exist.");

        if (book is null)
            throw new Exception($"Book with ID {request.IdBook} does not exist.");


        if (book.Status == BookStatusEnum.Unavailable)
            throw new ArgumentException("This book is unavailable for a loan.");


        if (book.OnHand <= 0)
            throw new Exception("The book is out of stock.");


        if (activeLoan != null)
            throw new Exception("User already has an active loan.");


        if (request.NumberLoanDay <= 0 || request.NumberLoanDay > 7)
            throw new Exception("The number of loan days must be between 1 and 7.");


        var loan = new Loan(request.IdUser, request.IdBook);
        loan.SetExpectedReturnDate(request.NumberLoanDay);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _unitOfWork.LoanRepository.AddLoan(loan);

            book.DecreaseOnHand(1);

            await _unitOfWork.BookRepository.UpdateBookAsync(book);

            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
        
        return Unit.Value;
    }
}