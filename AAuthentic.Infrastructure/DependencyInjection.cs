using AAuthentic.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AAuthentic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AAuthenticDbContext>(options => {
            options.Use
        });

        return services;
    }
}