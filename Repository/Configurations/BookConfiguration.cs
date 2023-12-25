using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Isbn).IsRequired().HasMaxLength(17);
        builder.Property(b => b.Title).HasMaxLength(3000);
        builder.Property(b => b.AuthorId).IsRequired();

        builder
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasData
        (
            new Book
            {
                Id = new Guid("b714252d-b6ea-405b-b677-12ace22c5f56"),
                Isbn = "0-7077-9427-7",
                Title = "Fight Club",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 3), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 15), DateTimeKind.Utc),
                AuthorId = new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1")
            },
            new Book
            {
                Id = new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"),
                Isbn = "0-3332-3849-4",
                Title = "Suffocation",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 3), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 17), DateTimeKind.Utc),
                AuthorId = new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1")
            },
            new Book
            {
                Id = new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"),
                Isbn = "0-8031-4675-2",
                Title = "Lullaby",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 4), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 18), DateTimeKind.Utc),
                AuthorId = new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1")
            },
            new Book
            {
                Id = new Guid("e4551d56-4dba-4ba6-8189-7512ffb2e450"),
                Isbn = "0-2668-5566-0",
                Title = "The Silmarillion",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 8), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 22), DateTimeKind.Utc),
                AuthorId = new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114")
            },
            new Book
            {
                Id = new Guid("619c765f-24dd-4ee0-9e9c-8a8fc64e827c"),
                Isbn = "0-2876-3432-9",
                Title = "The Lord of the Rings",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 10), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 24), DateTimeKind.Utc),
                AuthorId = new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114")
            },
            new Book
            {
                Id = new Guid("3ee6cb42-74ff-4cdf-a09c-03f0a1c4b28b"),
                Isbn = "0-3782-2861-7",
                Title = "The Hobbit, or There and Back Again",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 12), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 26), DateTimeKind.Utc),
                AuthorId = new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114")
            },
            new Book
            {
                Id = new Guid("e5b11af4-77c6-4417-b688-162dd98a023e"),
                Isbn = "0-2887-4531-0",
                Title = "Miecz Przeznaczenia",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 13), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 27), DateTimeKind.Utc),
                AuthorId = new Guid("2796af44-1fcf-499b-b035-6e1a9b124162")
            },
            new Book
            {
                Id = new Guid("792a3d91-22fa-4c78-8661-a7c2cb1e15b8"),
                Isbn = "0-1964-1253-6",
                Title = "Ostatnie życzenie",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 14), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 28), DateTimeKind.Utc),
                AuthorId = new Guid("2796af44-1fcf-499b-b035-6e1a9b124162")
            },
            new Book
            {
                Id = new Guid("b246a750-a069-49b3-8913-aae02b0de49d"),
                Isbn = "0-3194-0445-5",
                Title = "The Dune",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 16), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2023, 12, 30), DateTimeKind.Utc),
                AuthorId = new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8")
            },
            new Book
            {
                Id = new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"),
                Isbn = "0-3241-5925-0",
                Title = "Dune Messiah",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 19), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 2), DateTimeKind.Utc),
                AuthorId = new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8")
            },
            new Book
            {
                Id = new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"),
                Isbn = "0-4032-7202-5",
                Title = "The shortest story that will make anyone cry",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 20), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 3), DateTimeKind.Utc),
                AuthorId = new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd")
            },
            new Book
            {
                Id = new Guid("4b6d65c8-ca10-4202-87e0-ba536645b79a"),
                Isbn = "0-4032-7202-5",
                Title = "For Whom the Bell Tolls",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 21), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 4), DateTimeKind.Utc),
                AuthorId = new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd")
            },
            new Book
            {
                Id = new Guid("fa275350-95b7-438c-925e-411478cf3d1c"),
                Isbn = "0-4032-7202-5",
                Title = "A Farewell to Arms",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 24), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 7), DateTimeKind.Utc),
                AuthorId = new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd")
            },
            new Book
            {
                Id = new Guid("058e65fa-eec1-4e39-8238-a381d0d8a6d4"),
                Isbn = "0-4032-7202-5",
                Title = "Gone with the Wind",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 26), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 9), DateTimeKind.Utc),
                AuthorId = new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741")
            },
            new Book
            {
                Id = new Guid("e7a5e68d-02ed-4250-af48-b3eadffe19c7"),
                Isbn = "0-4032-7202-5",
                Title = "Lost Laysen",
                BorrowDateStart = DateTime.SpecifyKind(new DateTime(2023, 12, 29), DateTimeKind.Utc),
                BorrowDateEnd = DateTime.SpecifyKind(new DateTime(2024, 1, 12), DateTimeKind.Utc),
                AuthorId = new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741")
            }
        );
    }
}