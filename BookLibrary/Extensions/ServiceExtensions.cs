using Contracts;
using Contracts.Repositories;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using Service.Contracts;

namespace BookLibrary.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination"));
        });

    public static void ConfigureIisIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(_ => { });

    public static void ConfigureLoggerManager(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));

}