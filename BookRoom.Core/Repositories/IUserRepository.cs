using BookRoom.Core.Entities;

namespace BookRoom.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task Create(User user);
}