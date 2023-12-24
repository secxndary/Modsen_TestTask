using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BookLibrary.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureIisIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options => { });
    
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("postgresConnection")));

}