using Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData
        (
            new User
            {
                Id = "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                FirstName = "Admin",
                LastName = "Root",
                UserName = "root",
                Email = "root@example.org",
                NormalizedUserName = "ROOT",
                NormalizedEmail = "ROOT@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375449274568",
            },
            new User
            {
                Id = "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "johndoe@example.org",
                NormalizedUserName = "JOHNDOE",
                NormalizedEmail = "JOHNDOE@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375291234567",
            },
            new User
            {
                Id = "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                FirstName = "Alexander",
                LastName = "Valdaitsev",
                UserName = "valdaitsevv",
                Email = "valdaitsevv@mail.ru",
                NormalizedUserName = "VALDAITSEVV",
                NormalizedEmail = "VALDAITSEVV@MAIL.RU",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375445574506",
            },
            new User
            {
                Id = "f94a3937-8935-48a4-81f3-4d6e33603c65",
                FirstName = "Default",
                LastName = "User",
                UserName = "user",
                Email = "default@example.org",
                NormalizedUserName = "USER",
                NormalizedEmail = "DEFAULT@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375294859923",
            },
            new User
            {
                Id = "c459163f-341b-4073-a7b7-067c1ceeac15",
                FirstName = "Alexei",
                LastName = "Krotnichenko",
                UserName = "elite_librarian",
                Email = "krotnichenko@gmail.com",
                NormalizedUserName = "ELITE_LIBRARIAN",
                NormalizedEmail = "KROTNICHENKO@GMAIL.COM",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375333744859",
            },
            new User
            {
                Id = "ed3707a2-a416-4318-95a6-e462b10e9936",
                FirstName = "Nikolay",
                LastName = "Mazenkov",
                UserName = "default_librarian",
                Email = "nmazenkov@mail.ru",
                NormalizedUserName = "DEFAULT_LIBRARIAN",
                NormalizedEmail = "NMAZENKOV@MAIL.RU",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375447568124",
            }
        );
    }
}