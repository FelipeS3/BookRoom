using BookRoom.Application.ViewModels;
using BookRoom.Core.Enum;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetDetails(request.Id);

        if (book == null) return null;

        var loans = book.Loans?.Where(l => l.IdBook == book.Id)
            .Select(l => new LoanDetailsViewModel(
                l.Id,
                l.IdUser,
                l.IdBook,
                l.LoanedQuantity,
                l.LoanDate,
                l.ExpectedReturnDate,
                l.ReturnedDate)).ToList() ?? new List<LoanDetailsViewModel>();

        var booksDetailsViewModel = new BookDetailsViewModel(
            book.Id,
            book.Title,
            book.Author,
            book.ISBN,
            book.YearPublication,
            book.LoanQuantity,
            book.OnHand,
            Enum.GetName(typeof(BookStatusEnum), book.Status),
            loans);

        return booksDetailsViewModel;
    }
}