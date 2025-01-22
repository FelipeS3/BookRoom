using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookRoom.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookRoomDbContext _context;

    public UserRepository(BookRoomDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(User user)
    {
        await _context.AddAsync(user);
        _context.SaveChangesAsync();
    }
}