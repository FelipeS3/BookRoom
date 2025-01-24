using BookRoom.Application.ViewModels;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Queries.GetUserById;

public class GetUserIdQueryHandler : IRequestHandler<GetUserIdQuery, UserDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null) return null;

        var loan = user.Loans.Where(l => l.IdUser == request.Id)
            .Select(l => new LoanDetailsViewModel(
                l.Id,
                l.IdUser,
                l.IdBook,
                l.LoanedQuantity,
                l.LoanDate,
                l.ExpectedReturnDate,
                l.ReturnedDate)).ToList();

        var userDetailsViewModel = new UserDetailsViewModel(
            user.Id,
            user.Name,
            user.Email,
            user.CreatedAt,
            user.Active,
            loan);

        return userDetailsViewModel;
    }
}