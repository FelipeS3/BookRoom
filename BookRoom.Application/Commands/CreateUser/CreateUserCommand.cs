using BookRoom.Core.Entities;
using MediatR;

namespace BookRoom.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
}