using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName).HasMaxLength(200);
        builder.Property(a => a.LastName).HasMaxLength(200);

        builder.HasMany(a => a.Books);


        builder.HasData
        (
            new Author
            {
               Id = new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1"),
               FirstName = "Chuck",
               LastName = "Palahniuk"
            },
            new Author
            {
                Id = new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114"),
                FirstName = "John Ronald",
                LastName = "Tolkien"
            },
            new Author
            {
                Id = new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741"),
                FirstName = "Margaret",
                LastName = "Mitchell"
            },
            new Author
            {
                Id = new Guid("2796af44-1fcf-499b-b035-6e1a9b124162"),
                FirstName = "Andrzej",
                LastName = "Sapkowski"
            },
            new Author
            {
                Id = new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8"),
                FirstName = "Frank",
                LastName = "Herbert"
            },
            new Author
            {
                Id = new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd"),
                FirstName = "Ernest",
                LastName = "Hemingway"
            }
        );
    }
}