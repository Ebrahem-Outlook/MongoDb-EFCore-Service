using Application.Core.Data;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        string? SqlServerConnection = configuration.GetConnectionString("Docker-PostgerSql");
        
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(SqlServerConnection));

        services.AddScoped<IDbContext, AppDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        

        string? connection = configuration.GetConnectionString("Docker-MongoDB");

        return services;
    }
}
