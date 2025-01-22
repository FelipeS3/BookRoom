using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(
            request.Title,
            request.Author,
            request.ISBN,
            request.PublicationYear);
        

        book.IncreaseOnHand(request.AddedQuantity);

        await _unitOfWork.BookRepository.Post(book);

        await _unitOfWork.CompleteAsync();

        return book.Id;
    }
}