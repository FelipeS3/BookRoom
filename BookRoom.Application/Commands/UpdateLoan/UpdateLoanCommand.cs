using System.Data.SqlTypes;
using BookRoom.Core.Entities;
using MediatR;

namespace BookRoom.Application.Commands.UpdateLoan;

public class UpdateLoanCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int RenewLoanDay { get; set; }
}