using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Interfaces;
using UberSystem.Domain.Interfaces.Services;
using UberSystem.Infrastructure;
using UberSystem.Service;

namespace UberSystem.OData.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add needed instances for database
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, string ConnectionString)
    {
        // Configure DbContext with Scoped lifetime  
        services.AddDbContext<UberSystemDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString,
                    sqlOptions => sqlOptions.CommandTimeout(120));
                // options.UseLazyLoadingProxies();
            }
        );

        services.AddScoped<Func<UberSystemDbContext>>((provider) => () => provider.GetService<UberSystemDbContext>());
        services.AddScoped<DbFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    /// <summary>
    /// Add instances of in-use services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<ICabService, CabService>();
    }
}