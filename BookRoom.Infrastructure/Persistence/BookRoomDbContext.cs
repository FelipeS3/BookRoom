using BookRoom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace BookRoom.Infrastructure.Persistence;

public class BookRoomDbContext : DbContext
{
    public BookRoomDbContext(DbContextOptions<BookRoomDbContext> options) : base(options)
    {
        
    }
    public BookRoomDbContext() { }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}