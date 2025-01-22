using BookRoom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRoom.Infrastructure.Persistence.Configuration;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
    
        builder
            .HasKey(x => x.Id);

        builder
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        
        builder
            .Property(u => u.Email)
            .HasMaxLength(100);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .HasMany(u => u.Loans)
            .WithOne(l => l.User)
            .HasForeignKey(l =>l.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}