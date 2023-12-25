using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder.ToTable("BooksGenres");

        builder.HasKey(bg => new { bg.BookId, bg.GenreId });

        builder
            .HasOne(bg => bg.Book)
            .WithMany(b => b.Genres)
            .HasForeignKey(bg => bg.BookId);

        builder
            .HasOne(bg => bg.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(bg => bg.GenreId);

        builder.HasData(
            new BookGenre
            {
                BookId = new Guid("b714252d-b6ea-405b-b677-12ace22c5f56"),
                GenreId = new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45")
            },
            new BookGenre
            {
                BookId = new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"),
                GenreId = new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45")
            },
            new BookGenre
            {
                BookId = new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"),
                GenreId = new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b")
            },
            new BookGenre
            {
                BookId = new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"),
                GenreId = new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45")
            },
            new BookGenre
            {
                BookId = new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"),
                GenreId = new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b")
            },
            new BookGenre
            {
                BookId = new Guid("e4551d56-4dba-4ba6-8189-7512ffb2e450"),
                GenreId = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf")
            },
            new BookGenre
            {
                BookId = new Guid("619c765f-24dd-4ee0-9e9c-8a8fc64e827c"),
                GenreId = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf")
            },
            new BookGenre
            {
                BookId = new Guid("3ee6cb42-74ff-4cdf-a09c-03f0a1c4b28b"),
                GenreId = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf")
            },
            new BookGenre
            {
                BookId = new Guid("e5b11af4-77c6-4417-b688-162dd98a023e"),
                GenreId = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf")
            },
            new BookGenre
            {
                BookId = new Guid("792a3d91-22fa-4c78-8661-a7c2cb1e15b8"),
                GenreId = new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf")
            },
            new BookGenre
            {
                BookId = new Guid("b246a750-a069-49b3-8913-aae02b0de49d"),
                GenreId = new Guid("ddc73049-a302-4148-812d-32912ae83dd2")
            },
            new BookGenre
            {
                BookId = new Guid("b246a750-a069-49b3-8913-aae02b0de49d"),
                GenreId = new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b")
            },
            new BookGenre
            {
                BookId = new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"),
                GenreId = new Guid("ddc73049-a302-4148-812d-32912ae83dd2")
            },
            new BookGenre
            {
                BookId = new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"),
                GenreId = new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b")
            },
            new BookGenre
            {
                BookId = new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"),
                GenreId = new Guid("6bf1774a-d50a-4ced-8411-fa8c5e1dd4ec")
            },
            new BookGenre
            {
                BookId = new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"),
                GenreId = new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b")
            }
        );
    }
}