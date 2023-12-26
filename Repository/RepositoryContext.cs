using Entities.Authentication;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using Repository.Configurations.Identity;

namespace Repository;

public class RepositoryContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new BookConfiguration())
            .ApplyConfiguration(new AuthorConfiguration())
            .ApplyConfiguration(new GenreConfiguration())
            .ApplyConfiguration(new BookGenreConfiguration())
            .ApplyConfiguration(new RoleConfiguration())
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new UserRolesConfiguration());
    }
    
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Genre>? Genres { get; set; }
}