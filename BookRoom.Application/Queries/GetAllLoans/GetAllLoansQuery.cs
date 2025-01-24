using BookRoom.Application.ViewModels;
using MediatR;

namespace BookRoom.Application.Queries.GetAllLoans;

public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
{
    
}