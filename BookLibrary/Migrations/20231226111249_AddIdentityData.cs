using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", null, "User", "USER" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", null, "Librarian", "LIBRARIAN" },
                    { "f51135f0-adf7-4506-960e-f10ae287f792", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1567fa9b-7fc8-4f4f-b4df-896397616bfe", 0, "834bf8bb-11fc-4505-97f2-24dcd18ff51b", "johndoe@example.org", false, "John", "Doe", true, null, "JOHNDOE@EXAMPLE.ORG", "JOHNDOE", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375291234567", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e26d6019-b01f-4612-a5cf-92e2f0f1398e", false, "johndoe" },
                    { "3a08ecca-7fbe-4886-ad58-61998c01c9e0", 0, "8e920edf-fbd2-4471-bc8c-5b998bec22f6", "valdaitsevv@mail.ru", false, "Alexander", "Valdaitsev", true, null, "VALDAITSEVV@MAIL.RU", "VALDAITSEVV", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375445574506", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d93eea16-c67e-470b-aab8-19a36cfd4700", false, "valdaitsevv" },
                    { "c459163f-341b-4073-a7b7-067c1ceeac15", 0, "ea8230d2-5682-41c0-9b0f-16d75f6f2d71", "krotnichenko@gmail.com", false, "Alexei", "Krotnichenko", true, null, "KROTNICHENKO@GMAIL.COM", "ELITE_LIBRARIAN", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375333744859", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bd3a191f-f0cf-4ade-8652-e78dbd5bdd91", false, "elite_librarian" },
                    { "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9", 0, "0b73ca3e-5646-4e48-b3bd-e2dea6f85109", "root@example.org", false, "Admin", "Root", true, null, "ROOT@EXAMPLE.ORG", "ROOT", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375449274568", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3fc23d0a-cd53-4c0b-8bf9-f88e29f543c7", false, "root" },
                    { "ed3707a2-a416-4318-95a6-e462b10e9936", 0, "0e828c2d-4e53-43b3-a15d-832c3092dc01", "nmazenkov@mail.ru", false, "Nikolay", "Mazenkov", true, null, "NMAZENKOV@MAIL.RU", "DEFAULT_LIBRARIAN", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375447568124", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2e9be610-65a3-422b-9982-f1346d486fe9", false, "default_librarian" },
                    { "f94a3937-8935-48a4-81f3-4d6e33603c65", 0, "d5840947-1d78-4938-8a6c-edde092523f1", "default@example.org", false, "Default", "User", true, null, "DEFAULT@EXAMPLE.ORG", "USER", "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375294859923", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "97684751-2487-4f50-b2e2-449cd93e3c3b", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "1567fa9b-7fc8-4f4f-b4df-896397616bfe" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "3a08ecca-7fbe-4886-ad58-61998c01c9e0" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "c459163f-341b-4073-a7b7-067c1ceeac15" },
                    { "f51135f0-adf7-4506-960e-f10ae287f792", "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ed3707a2-a416-4318-95a6-e462b10e9936" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "f94a3937-8935-48a4-81f3-4d6e33603c65" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "1567fa9b-7fc8-4f4f-b4df-896397616bfe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "3a08ecca-7fbe-4886-ad58-61998c01c9e0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "c459163f-341b-4073-a7b7-067c1ceeac15" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f51135f0-adf7-4506-960e-f10ae287f792", "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ed3707a2-a416-4318-95a6-e462b10e9936" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "f94a3937-8935-48a4-81f3-4d6e33603c65" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744a95cd-b364-44bd-842d-6ca02f9fe5fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f51135f0-adf7-4506-960e-f10ae287f792");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
