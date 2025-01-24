using BookRoom.Application.ViewModels;
using MediatR;
using Microsoft.Identity.Client;

namespace BookRoom.Application.Queries.GetUserById;

public class GetUserIdQuery : IRequest<UserDetailsViewModel>
{
    public GetUserIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}