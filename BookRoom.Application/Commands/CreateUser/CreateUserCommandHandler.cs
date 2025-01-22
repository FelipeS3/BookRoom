using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using MediatR;

namespace BookRoom.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email);

        await _unitOfWork.UserRepository.Create(user);

        await _unitOfWork.CompleteAsync();

        return user.Id;
    }
}