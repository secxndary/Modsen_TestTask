using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Isbn = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    Title = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    BorrowDateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BorrowDateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksGenres",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BooksGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8"), "Frank", "Herbert" },
                    { new Guid("2796af44-1fcf-499b-b035-6e1a9b124162"), "Andrzej", "Sapkowski" },
                    { new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd"), "Ernest", "Hemingway" },
                    { new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1"), "Chuck", "Palahniuk" },
                    { new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741"), "Margaret", "Mitchell" },
                    { new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114"), "John Ronald", "Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf"), "Involves magical or mythical elements set in a fictional world often with magical creatures, quests, and adventures", "Fantasy" },
                    { new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b"), "A broad category encompassing a wide range of fictional narratives that explore various themes, characters, and settings", "Novel" },
                    { new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b"), "Centers around solving mysteries, typically featuring a protagonist investigator unraveling puzzles or crimes", "Detective" },
                    { new Guid("6bf1774a-d50a-4ced-8411-fa8c5e1dd4ec"), "Emphasizes realistic characters and their emotional journeys through life's challenges and conflicts", "Drama" },
                    { new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45"), "Builds suspense and tension, often involving danger, high stakes, and unexpected plot twists to keep readers on edge", "Thriller" },
                    { new Guid("ddc73049-a302-4148-812d-32912ae83dd2"), "Genre focused on narratives involving elements of the supernatural, magic, or extraordinary phenomena", "Fantastic" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BorrowDateEnd", "BorrowDateStart", "Isbn", "Title" },
                values: new object[,]
                {
                    { new Guid("058e65fa-eec1-4e39-8238-a381d0d8a6d4"), new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), "0-4032-7202-5", "Gone with the Wind" },
                    { new Guid("3ee6cb42-74ff-4cdf-a09c-03f0a1c4b28b"), new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114"), new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "0-3782-2861-7", "The Hobbit, or There and Back Again" },
                    { new Guid("4b6d65c8-ca10-4202-87e0-ba536645b79a"), new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), "0-4032-7202-5", "For Whom the Bell Tolls" },
                    { new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"), new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1"), new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), "0-3332-3849-4", "Suffocation" },
                    { new Guid("619c765f-24dd-4ee0-9e9c-8a8fc64e827c"), new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "0-2876-3432-9", "The Lord of the Rings" },
                    { new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"), new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), "0-3241-5925-0", "Dune Messiah" },
                    { new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"), new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), "0-4032-7202-5", "The shortest story that will make anyone cry" },
                    { new Guid("792a3d91-22fa-4c78-8661-a7c2cb1e15b8"), new Guid("2796af44-1fcf-499b-b035-6e1a9b124162"), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), "0-1964-1253-6", "Ostatnie życzenie" },
                    { new Guid("b246a750-a069-49b3-8913-aae02b0de49d"), new Guid("05186e3e-8982-42ac-bcb3-002e318a48b8"), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "0-3194-0445-5", "The Dune" },
                    { new Guid("b714252d-b6ea-405b-b677-12ace22c5f56"), new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1"), new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), "0-7077-9427-7", "Fight Club" },
                    { new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"), new Guid("5df85459-145f-4ad6-ac61-983dfd81e1c1"), new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), "0-8031-4675-2", "Lullaby" },
                    { new Guid("e4551d56-4dba-4ba6-8189-7512ffb2e450"), new Guid("dddf6823-9ea0-4f0a-a4de-bbd0beb1f114"), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), "0-2668-5566-0", "The Silmarillion" },
                    { new Guid("e5b11af4-77c6-4417-b688-162dd98a023e"), new Guid("2796af44-1fcf-499b-b035-6e1a9b124162"), new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), "0-2887-4531-0", "Miecz Przeznaczenia" },
                    { new Guid("e7a5e68d-02ed-4250-af48-b3eadffe19c7"), new Guid("9f87f1f9-929d-4d97-ad16-31d2d569a741"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "0-4032-7202-5", "Lost Laysen" },
                    { new Guid("fa275350-95b7-438c-925e-411478cf3d1c"), new Guid("4c27f650-5075-4514-92ec-46e9817a1fdd"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), "0-4032-7202-5", "A Farewell to Arms" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("3ee6cb42-74ff-4cdf-a09c-03f0a1c4b28b"), new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf") },
                    { new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"), new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b") },
                    { new Guid("5bfa4c5e-e410-436b-b728-a25d8aea298d"), new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45") },
                    { new Guid("619c765f-24dd-4ee0-9e9c-8a8fc64e827c"), new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf") },
                    { new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"), new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b") },
                    { new Guid("663ec857-77b1-4d11-8fe4-ebf7978eb978"), new Guid("ddc73049-a302-4148-812d-32912ae83dd2") },
                    { new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"), new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b") },
                    { new Guid("77e833a2-7b4e-4191-baeb-5bd530c098f8"), new Guid("6bf1774a-d50a-4ced-8411-fa8c5e1dd4ec") },
                    { new Guid("792a3d91-22fa-4c78-8661-a7c2cb1e15b8"), new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf") },
                    { new Guid("b246a750-a069-49b3-8913-aae02b0de49d"), new Guid("1f7bc731-4f1a-4d69-9c20-696d67f34b8b") },
                    { new Guid("b246a750-a069-49b3-8913-aae02b0de49d"), new Guid("ddc73049-a302-4148-812d-32912ae83dd2") },
                    { new Guid("b714252d-b6ea-405b-b677-12ace22c5f56"), new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45") },
                    { new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"), new Guid("4dbe2362-71e2-47dc-98a6-a8c1c2c3bb3b") },
                    { new Guid("d49afd60-24fc-41d9-b9e0-56aa392e92ca"), new Guid("88ad3525-dbcd-4df6-88e0-70ddae40dc45") },
                    { new Guid("e4551d56-4dba-4ba6-8189-7512ffb2e450"), new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf") },
                    { new Guid("e5b11af4-77c6-4417-b688-162dd98a023e"), new Guid("189ebc8a-2ced-4202-bb1f-52e29f059cbf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksGenres_GenreId",
                table: "BooksGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BooksGenres");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
