using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configurations.Identity;

public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData
        (
            // Admin
            new IdentityUserRole<string>
            {
                UserId = "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                RoleId = "f51135f0-adf7-4506-960e-f10ae287f792"
            },
            // Users
            new IdentityUserRole<string>
            {
                UserId = "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "f94a3937-8935-48a4-81f3-4d6e33603c65",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            // Librarians
            new IdentityUserRole<string>
            {
                UserId = "c459163f-341b-4073-a7b7-067c1ceeac15",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            },
            new IdentityUserRole<string>
            {
                UserId = "ed3707a2-a416-4318-95a6-e462b10e9936",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            }
        );
    }
}