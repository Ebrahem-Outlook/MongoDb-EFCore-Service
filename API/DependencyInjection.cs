using API.Database;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
    {
        string? connection = configuration.GetConnectionString("Docker-MongoDB");

        services.AddDbContext<AppDbContext>(options => options.UseMongoDB(connection, "API_DB"));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
