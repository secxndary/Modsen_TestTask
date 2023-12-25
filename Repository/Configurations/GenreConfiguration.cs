using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
        
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Description).HasMaxLength(1000);


        builder.HasData
        (
            new Genre
            {
                Id = new Guid("ddc73049-a302-4148-812d-32912ae83dd2"),
                Name = "Fantastic",
                Description = "Genre focused on narratives involving elements of the supernatural, magic, or extraordinary phenomena"
            },
            new Genre
            {
                Id = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf"),
                Name = "Fantasy",
                Description = "Involves magical or mythical elements set in a fictional world often with magical creatures, quests, and adventures"
            },
            new Genre
            {
                Id = new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b"),
                Name = "Detective",
                Description = "Centers around solving mysteries, typically featuring a protagonist investigator unraveling puzzles or crimes"
            },
            new Genre
            {
                Id = new Guid("6bf1774a-d50a-4ced-8411-fa8c5e1dd4ec"),
                Name = "Drama",
                Description = "Emphasizes realistic characters and their emotional journeys through life's challenges and conflicts"
            },
            new Genre
            {
                Id = new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b"),
                Name = "Novel",
                Description = "A broad category encompassing a wide range of fictional narratives that explore various themes, characters, and settings"
            },
            new Genre
            {
                Id = new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45"),
                Name = "Thriller",
                Description = "Builds suspense and tension, often involving danger, high stakes, and unexpected plot twists to keep readers on edge"
            }
        );
    }
}