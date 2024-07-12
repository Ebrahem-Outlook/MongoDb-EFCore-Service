using API.Database;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Docker-MongoDB");

        string? databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;

        services.AddDbContext<AppDbContext>(options => options.UseMongoDB(connectionString, databaseName));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
