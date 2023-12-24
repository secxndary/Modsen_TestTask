using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Isbn).IsRequired().HasMaxLength(17);
        builder.Property(b => b.Description).HasMaxLength(3000);
        builder.Property(b => b.AuthorId).IsRequired();

        builder.HasMany(b => b.Genres);
        builder.HasOne(b => b.Author);
    }
}