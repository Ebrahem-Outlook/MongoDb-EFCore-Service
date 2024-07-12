using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        string? SqlServerConnection = configuration.GetConnectionString("Docker-SqlServer");
        
        services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(SqlServerConnection));

        services.Add

        string? connection = configuration.GetConnectionString("Docker-MongoDB");

        return services;
    }
}
