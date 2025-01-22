using BookRoom.Core.Enum;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

        if (book.Status == BookStatusEnum.Available)
        {
            book.Status = BookStatusEnum.Unavailable;

            await _unitOfWork.BookRepository.UpdateBookAsync(book);

            await _unitOfWork.CompleteAsync();
        }

        else
        {
            throw new Exception("The book is already unavailable");
        }

        return Unit.Value;
    }
}