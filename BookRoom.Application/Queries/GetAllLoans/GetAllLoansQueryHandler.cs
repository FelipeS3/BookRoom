using BookRoom.Application.ViewModels;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Queries.GetAllLoans;

public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery,List<LoanViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLoansQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
        var loan = await _unitOfWork.LoanRepository.GetAll();

        var loanViewModel = loan.Select(l => new LoanViewModel(l.Id, l.IdUser, l.IdBook)).ToList();

        return loanViewModel;
    }
}