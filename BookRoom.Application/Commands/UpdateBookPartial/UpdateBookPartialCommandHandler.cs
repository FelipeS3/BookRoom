using System.Linq.Expressions;
using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.UpdateBookPartial;

public class UpdateBookPartialCommandHandler : IRequestHandler<UpdateBookPartialCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookPartialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateBookPartialCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

        if (book == null)
            throw new Exception("Book not found.");

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // Atualizar quantidade adicionada
            if (request.AddedQuantity > 0)
            {
                book.IncreaseOnHand(request.AddedQuantity);
                await _unitOfWork.BookRepository.UpdateBookAsync(book);
            }

            // Atualizar quantidade removida
            if (request.DecreseadQuantity > 0)
            {
                if (book.OnHand < request.DecreseadQuantity)
                    throw new Exception("Cannot decrease more than available stock.");

                book.DecreaseOnHand(request.DecreseadQuantity);

                await _unitOfWork.BookRepository.UpdateBookAsync(book);
            }


            await _unitOfWork.CompleteAsync();


        }
        catch(Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
        return Unit.Value;
    }
}