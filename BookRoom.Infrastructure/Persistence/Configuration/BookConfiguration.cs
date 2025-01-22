using BookRoom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRoom.Infrastructure.Persistence.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Title)
            .HasMaxLength(200);

        builder
            .Property(b => b.Author)
            .HasMaxLength(100);

        builder
            .Property(b => b.ISBN)
            .HasMaxLength(13);

        builder
            .HasIndex(b => b.ISBN)
            .IsUnique();

        builder
            .HasMany(b => b.Loans)
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.IdBook)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(b => b.Status)
            .HasConversion(typeof(string))
            .HasMaxLength(50);
    }
}